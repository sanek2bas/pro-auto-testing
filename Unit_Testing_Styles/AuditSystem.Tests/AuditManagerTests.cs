using Moq;

namespace AuditSystem.Tests;

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
                @"audits\audit_1.txt",
                @"audits\audit_2.txt"
            });

        fileSystemMock
            .Setup(x => x.ReadAllLines(@"audits\audit_2.txt"))
            .Returns(new List<string>
            {
                "Peter; 2019-04-06T16:30:00",
                "Jane; 2019-04-06T16:40:00",
                "Jack; 2019-04-06T17:00:00"
            });

        var sut = new AuditManager(3, "audits", fileSystemMock.Object);
        sut.AddRecord("Alice", DateTime.Parse("2019-04-06T18:00:00"));

        fileSystemMock.Verify(x => x.WriteAllText(
            @"audits\audit_3.txt",
            "Alice;2019-04-06T18:00:00"));
    }
}
