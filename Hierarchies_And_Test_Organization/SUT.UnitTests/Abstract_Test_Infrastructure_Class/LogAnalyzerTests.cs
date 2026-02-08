using SUT.Abstract_Test_Infrastructure_Class;

namespace SUT.UnitTests.Abstract_Test_Infrastructure_Class;

public class LogAnalyzerTests : BaseTestsClass
{
    [Fact]
    public void Analyze_EmptyFile_ThrowsException()
    {
        FakeTheLogger();

        LogAnalyzer logAnalyzer = new LogAnalyzer();
        logAnalyzer.Analyze("MyEmptyFile.txt");
        //the rest of the method

        TearDown();
    }
}