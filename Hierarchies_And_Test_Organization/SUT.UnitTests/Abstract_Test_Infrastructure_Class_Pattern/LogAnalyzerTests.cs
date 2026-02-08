using SUT.Abstract_Test_Infrastructure_Class_Pattern;

namespace SUT.UnitTests.Abstract_Test_Infrastructure_Class_Pattern;

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