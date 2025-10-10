namespace LogAn.UnitTests;

public class LogAnalyzerTests
{
    [Fact]
    public void IsValidLogFileName_BadExtension_ReturnFalse()
    {
        LogAnalyzer analyzer = new LogAnalyzer();
        bool result =
            analyzer.IsValidLogFileName("filewithbadextension.foo");

        Assert.False(result);
    }

    [Fact]
    public void IsValidLogFileName_GoodExtensionLowercase_ReturnsTrue()
    {
        LogAnalyzer analyzer = new LogAnalyzer();
        bool result =
            analyzer.IsValidLogFileName("filewithgoodextension.slf");

        Assert.True(result);
    }
    
    [Fact]
    public void IsValidLogFileName_GoodExtensionUppercase_ReturnsTrue()
    {
        LogAnalyzer analyzer = new LogAnalyzer();
        bool result = analyzer.IsValidLogFileName("filewithgoodextension.SLF");

        Assert.True(result);
    }

    // this is a refactoring of the previous two tests
    [Theory]
    [InlineData("filewithgoodextension.slf")]
    [InlineData("filewithgoodextension.SLF")]
    public void IsValidLogFileName_ValidExtensions_ReturnsTrue(string fileName)
    {
        LogAnalyzer analyzer = new LogAnalyzer();
        bool result = analyzer.IsValidLogFileName(fileName);

        Assert.True(result);
    }

    // this is a refactoring of all the "regular" tests
    [Theory]
    [InlineData("filewithgoodextension.SLF", true)]
    [InlineData("filewithgoodextension.slf", true)]
    [InlineData("filewithbadextension.foo",false)]
    public void IsValidLogFileName_VariousExtensions_ChecksThem(string file, bool expected)
    {
        LogAnalyzer analyzer = new LogAnalyzer();
        bool result = analyzer.IsValidLogFileName(file);
        
        Assert.Equal(expected, result);
    }
}