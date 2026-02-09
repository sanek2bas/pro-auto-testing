using SUT.Template_Test_Class;
using System;
using System.Reflection.PortableExecutable;

namespace SUT.UnitTests.Template_Test_Class;

public class StandardStringParserTests : TemplateStringParserTests
{
    [Fact]
    public override void TestGetStringVersionFromHeader_SingleDigit_Found()
    {
        string input = "header; version = 1;\n";
        
        StandardStringParser parser = GetParser(input);
        string versionFromHeader = parser.GetTextVersionFromHeader();
        
        //Assert.Equal("1", versionFromHeader);
    }

    [Fact]
    public override void TestGetStringVersionFromHeader_WithMinorVersion_Found()
    {
        string input = "header; version = 1.1;\n";

        StandardStringParser parser = GetParser(input);
        string versionFromHeader = parser.GetTextVersionFromHeader();

        //Assert.Equal("1.1", versionFromHeader);
    }

    [Fact]
    public override void TestGetStringVersionFromHeader_WithRevision_Found()
    {
        string input = "header;version=1.1.1;\n";
        
        StandardStringParser parser = GetParser(input);
        string versionFromHeader = parser.GetTextVersionFromHeader();
        
        //Assert.Equal("1.1.1", versionFromHeader);
    }

    protected StandardStringParser GetParser(string input)
    {
        return new StandardStringParser(input);
    }
}
