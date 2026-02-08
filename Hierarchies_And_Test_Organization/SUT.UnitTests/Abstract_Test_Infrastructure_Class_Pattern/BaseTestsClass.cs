using NSubstitute;
using SUT.Abstract_Test_Infrastructure_Class_Pattern;

namespace SUT.UnitTests.Abstract_Test_Infrastructure_Class_Pattern;

public class BaseTestsClass
{
    public ILogger FakeTheLogger()
    {
        LoggingFacility.Logger = Substitute.For<ILogger>();
        return LoggingFacility.Logger;
    }

    public void TearDown()
    {
        LoggingFacility.Logger = null;
    }
}
