namespace SUT.UnitTests.Template_Test_Class;

public abstract class TemplateStringParserTests
{
    public abstract void TestGetStringVersionFromHeader_SingleDigit_Found();
    public abstract  void TestGetStringVersionFromHeader_WithMinorVersion_Found();
    public abstract void TestGetStringVersionFromHeader_WithRevision_Found();
}