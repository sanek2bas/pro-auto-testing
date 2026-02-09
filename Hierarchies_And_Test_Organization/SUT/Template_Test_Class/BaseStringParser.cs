namespace SUT.Template_Test_Class;

public interface IStringParser
{
    string StringToParse { get; }

    string GetTextVersionFromHeader();

    bool HasCorrectHeader();
}

public abstract class BaseStringParser : IStringParser
{
    public string StringToParse { get; }

    protected BaseStringParser(string str)
    {
        StringToParse = str;
    }

    public abstract string GetTextVersionFromHeader();

    public abstract bool HasCorrectHeader();
}

