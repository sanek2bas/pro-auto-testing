using SUT.Abstract_Test_Infrastructure_Class_Pattern;

namespace SUT.UnitTests.Abstract_Test_Infrastructure_Class_Pattern;

public class ConfigurationManagerTests : BaseTestsClass
{
    [Fact]
    public void Analyze_EmptyFile_ThrowsException()
    {
        FakeTheLogger();
        
        ConfigurationManager cm = new ConfigurationManager();
        bool configured = cm.IsConigured("something");
        //the rest of the method

        TearDown();
    }
}