using System;
using System.Collections.Generic;
using System.Text;

namespace LogAn.UnitTests
{
    public class LogAnalyzerUsingFactoryTests
    {
        [Fact]
        public void IsValidFileName_SupportedExtension_ReturnsTrue()
        {
            FakeExtensionManager myFakeManager = CreateFakeExtensionManager();            
            myFakeManager.WillBeValid = true;
            ExtensionManagerFactory.Instance.SetManager(myFakeManager);
            LogAnalyzerUsingFactory log = new LogAnalyzerUsingFactory();

            bool result = log.IsValidLogFileName("short.ext");

            Assert.True(result);
        }

        private FakeExtensionManager CreateFakeExtensionManager()
        {
            return new FakeExtensionManager();
        }
    }
}
