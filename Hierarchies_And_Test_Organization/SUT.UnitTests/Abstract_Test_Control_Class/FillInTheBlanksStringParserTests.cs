using SUT.Template_Test_Class;

namespace SUT.UnitTests.Abstract_Test_Control_Class;

public abstract class FillInTheBlanksStringParserTests
{
    protected abstract IStringParser GetParser(string input);

    protected abstract string HeaderVersion_SingleDigit { get; }
    protected abstract string HeaderVersion_WithMinorVersion { get; }
    protected abstract string HeaderVersion_WithRevision { get; }

    public const string EXPECTED_SINGLE_DIGIT = "1";
    public const string EXPECTED_WITH_REVISION = "1.1.1";
    public const string EXPECTED_WITH_MINORVERSION = "1.1";

    [Fact]
    public void GetStringVersionFromHeader_SingleDigit_Found()
    {
        string input = HeaderVersion_SingleDigit;
        
        IStringParser parser = GetParser(input);
        string versionFromHeader = parser.GetTextVersionFromHeader();

        Assert.Equal(EXPECTED_SINGLE_DIGIT, versionFromHeader);
    }

    [Fact]
    public void GetStringVersionFromHeader_WithRevision_Found()
    {
        string input = HeaderVersion_WithRevision;

        IStringParser parser = GetParser(input);
        string versionFromHeader = parser.GetTextVersionFromHeader();

        Assert.Equal(EXPECTED_WITH_REVISION, versionFromHeader);
    }
}
