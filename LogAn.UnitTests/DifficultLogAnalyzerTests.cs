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

        [Fact]
        public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse()
        {
            FakeExtensionManager myFakeManager = 
                new FakeExtensionManager();
            string exMessage = "it's a fake copy";
            myFakeManager.WillThrow = new Exception(exMessage);

            DifficultLogAnalyzer log =
                new DifficultLogAnalyzer(myFakeManager);

            bool result;
            string message = string.Empty;
            try
            {
                result = log.IsValidLogFileName("anything.anyextension");
            }
            catch(Exception exception)
            {
                result = false;
                message = exception.Message;
            }

            Assert.False(result);
            Assert.Contains(message, exMessage);
        }

        internal class FakeExtensionManager : IExtensionManager
        {
            public bool WillBeValid { get; set; }

            public Exception WillThrow { get; set; }

            public bool IsValid(string fileName)
            {
                if (WillThrow != null)
                    throw WillThrow;
                return WillBeValid;
            }
        }
    }
}
