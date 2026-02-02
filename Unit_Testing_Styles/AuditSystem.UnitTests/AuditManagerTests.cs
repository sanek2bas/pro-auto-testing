using Moq;

namespace AuditSystem.UnitTests;

public class AuditManagerTests
{
    [Fact]
    public void A_New_File_Is_Created_When_The_Current_File_Overflows()
    {
        var fileSystemMock = new Mock<IFileSystem>();

        fileSystemMock
            .Setup(x => x.GetFiles("audits"))
            .Returns(new string[]
            {
                Path.Combine("audits", "audit_1.txt"),
                Path.Combine("audits", "audit_2.txt")
            });

        var audit2Path = Path.Combine("audits", "audit_2.txt");
        fileSystemMock
            .Setup(x => x.ReadAllLines(audit2Path))
            .Returns(new List<string>
            {
                "Peter; 2019-04-06T16:30:00",
                "Jane; 2019-04-06T16:40:00",
                "Jack; 2019-04-06T17:00:00"
            });

        var sut = new AuditManager(3, "audits", fileSystemMock.Object);
        var dateTimeParsed = DateTime.Parse("2019-04-06T18:00:00");
        sut.AddRecord("Alice", dateTimeParsed);

        fileSystemMock.Verify(x => x.WriteAllText(
            Path.Combine("audits", "audit_3.txt"),
            $"Alice;{dateTimeParsed}"));
    }
}
