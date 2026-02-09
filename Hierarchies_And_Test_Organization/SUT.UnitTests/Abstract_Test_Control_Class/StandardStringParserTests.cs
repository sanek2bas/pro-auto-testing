using SUT.Template_Test_Class;

namespace SUT.UnitTests.Abstract_Test_Control_Class;

public class StandardStringParserTests : FillInTheBlanksStringParserTests
{
    protected override string HeaderVersion_SingleDigit =>
        string.Format("header\tversion ={0}\t\n", EXPECTED_SINGLE_DIGIT);

    protected override string HeaderVersion_WithMinorVersion =>
        string.Format("header\tversion ={0}\t\n", EXPECTED_WITH_MINORVERSION);

    protected override string HeaderVersion_WithRevision =>
        string.Format("header\tversion ={0}\t\n", EXPECTED_WITH_REVISION);

    protected override IStringParser GetParser(string input)
    {
        return new StandardStringParser(input);
    }
}
