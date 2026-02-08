namespace SUT.Abstract_Test_Infrastructure_Class;

public class ConfigurationManager
{
    public bool IsConigured(string configName)
    {
        bool result = true;
        LoggingFacility.Log("checking " + configName);
        return result;
    }
}