namespace LogAn.UnitTests
{
    public class DifficultLogAnalyzerTests
    {
        [Fact]
        public void IsValidFileName_NameSupportedExtension_ReturnsTrue()
        {
            FakeExtensionManager myFakeManager = 
                new FakeExtensionManager();
            myFakeManager.WillBeValid = true;

            DifficultLogAnalyzer log = 
                new DifficultLogAnalyzer(myFakeManager);

            bool result = log.IsValidLogFileName("short.ext");
            Assert.True(result);
        }

        internal class FakeExtensionManager : IExtensionManager
        {
            public bool WillBeValid { get; set; }

            public bool IsValid(string fileName)
            {
                return WillBeValid;
            }
        }
    }
}
