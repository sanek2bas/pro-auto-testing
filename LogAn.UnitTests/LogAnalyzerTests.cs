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
    [InlineData("filewithbadextension.foo", false)]
    public void IsValidLogFileName_VariousExtensions_ChecksThem(string file, bool expected)
    {
        LogAnalyzer analyzer = new LogAnalyzer();
        bool result = analyzer.IsValidLogFileName(file);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void IsValidLogFileName_EmptyFileName_Throws()
    {
        LogAnalyzer la = MakeAnalyzer();

        var ex = Assert.Throws<ArgumentException>(() => 
            la.IsValidLogFileName(string.Empty));

        Assert.Contains("filename has to be provided", ex.Message);
    }

    [Fact(Skip = "there is an error")]
    public void IsValidFileName_ValidFile_ReturnsTrue()
    {
        /// ...
    }

    [Theory]
    [InlineData("badfile.foo", false)]
    [InlineData("goodfile.slf", true)]
    public void IsValidFileName_WhenCalled_ChangesWasLastFileNameValid(string file, bool expected)
    {
        LogAnalyzer la = MakeAnalyzer();

        la.IsValidLogFileName(file);

        Assert.Equal(expected, la.WasLastFileNameValid);
    }

    private LogAnalyzer MakeAnalyzer()
    {
        return new LogAnalyzer();
    }
}