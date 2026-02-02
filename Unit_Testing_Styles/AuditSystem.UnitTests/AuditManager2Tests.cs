namespace AuditSystem.UnitTests;

public class AuditManager2Tests
{
    [Fact]
    public void A_New_File_Is_Created_When_The_Current_File_Overflows()
    {
        var sut = new AuditManager2(3);
        var files = new FileContent[]
        {
            new FileContent("audit_1.txt", new string[0]),
            new FileContent("audit_2.txt", new string[]
            {
                "Peter; 2019-04-06T16:30:00",
                "Jane; 2019-04-06T16:40:00",
                "Jack; 2019-04-06T17:00:00"
            })
        };

        var parsedDateTime = DateTime.Parse("2019-04-06T18:00:00");
        FileUpdate update = sut.AddRecord(files, "Alice", parsedDateTime);

        Assert.Equal("audit_3.txt", update.FileName);
        Assert.Equal($"Alice;{parsedDateTime}", update.NewContent);
    }
}
