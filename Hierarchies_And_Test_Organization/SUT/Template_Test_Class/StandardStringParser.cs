namespace SUT.Template_Test_Class;

public class StandardStringParser : BaseStringParser
{
    public StandardStringParser(string toParse) 
        : base(toParse)
    {}

    public override string GetTextVersionFromHeader()
    {
        //missing here: real implementation
        return string.Empty;
    }

    public override bool HasCorrectHeader()
    {
        //missing here: real implementation
        return false;
    }
}
