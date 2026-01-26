namespace LogAn.UnitTests
{
    public class LogAnalyzerTests
    {
        [Fact]
        public void Analyze_TooShortFileName_CallsWebService()
        {
            FakeWebService mockService = new FakeWebService();
            LogAnalyzer log = new LogAnalyzer(mockService);

            string tooShortFileName = "abc.ext";
            log.Analyze(tooShortFileName);

            Assert.Contains(mockService.LastError, $"The name is too short: {tooShortFileName}");
        }
    }
}
