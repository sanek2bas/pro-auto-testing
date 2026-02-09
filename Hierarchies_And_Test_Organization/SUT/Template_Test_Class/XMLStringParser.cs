namespace SUT.Template_Test_Class;

public class XMLStringParser : BaseStringParser
{
    public XMLStringParser(string toParse) 
        : base(toParse)
    {}

    public override string GetTextVersionFromHeader()
    {
        //missing here: logic that parses xml
        return String.Empty;
    }

    public override bool HasCorrectHeader()
    {
        //missing here: logic that parses xml
        return false;
    }
}
