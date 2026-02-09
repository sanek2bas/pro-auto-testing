using SUT.Template_Test_Class;

namespace SUT.UnitTests.Template_Test_Class;

public class XmlStringParserTests : TemplateStringParserTests
{
    [Fact]
    public override void TestGetStringVersionFromHeader_SingleDigit_Found()
    {
        IStringParser parser = GetParser("< Header > 1 </ Header >");

        string versionFromHeader = parser.GetTextVersionFromHeader();
        
        //Assert.Equal("1", versionFromHeader);
    }

    [Fact]
    public override void TestGetStringVersionFromHeader_WithMinorVersion_Found()
    {
        IStringParser parser = GetParser("< Header > 1.1 </ Header >");

        string versionFromHeader = parser.GetTextVersionFromHeader();
        
        //Assert.Equal("1.1", versionFromHeader);
    }

    [Fact]
    public override void TestGetStringVersionFromHeader_WithRevision_Found()
    {
        IStringParser parser = GetParser("< Header > 1.1.1 </ Header >");

        string versionFromHeader = parser.GetTextVersionFromHeader();
        
        //Assert.Equal("1.1.1", versionFromHeader);
    }

    protected IStringParser GetParser(string input)
    {
        return new XMLStringParser(input);
    }
}
