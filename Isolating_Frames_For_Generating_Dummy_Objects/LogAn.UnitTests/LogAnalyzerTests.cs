using NSubstitute;
using System;

namespace LogAn.UnitTests;

public class LogAnalyzerTests
{
    [Fact]
    public void Analyze_TooShortFileName_CallLogger()
    {
        FakeLogger logger = new FakeLogger();
        LogAnalyzer analyzer = new LogAnalyzer(logger);

        analyzer.MinNameLength = 6;
        analyzer.Analyze("a.txt");
        
        Assert.Contains("is too short", logger.LastError);
    }

    [Fact]
    public void Analyze_TooShortFileName_CallLogger_With_NSub()
    {
        ILogger logger = Substitute.For<ILogger>();
        LogAnalyzer analyzer = new LogAnalyzer(logger);

        analyzer.MinNameLength = 6;
        analyzer.Analyze("a.txt");

        logger.Received().LogError($"The name is too short");
    }

    [Fact]
    public void Returns_ByDefault_WorksForHardCodedArgument()
    {
        IFileNameRules fakeRules = Substitute.For<IFileNameRules>();
        fakeRules.IsValidLogFileName("strict.txt").Returns(true);
        Assert.True(fakeRules.IsValidLogFileName("strict.txt"));
    }

    [Fact]
    public void Returns_ByDefault_WorksForHardCodedArgument_2()
    {
        IFileNameRules fakeRules = Substitute.For<IFileNameRules>();
        fakeRules.IsValidLogFileName(Arg.Any<String>()).Returns(true);
        Assert.True(fakeRules.IsValidLogFileName("anything.txt"));
    }

    [Fact]
    public void Returns_ArgAny_Throws()
    {
        IFileNameRules fakeRules = Substitute.For<IFileNameRules>();
        
        fakeRules.When(x => x.IsValidLogFileName(Arg.Any<string>()))
            .Do(context => { throw new Exception("fake exception"); });
        
        Assert.Throws<Exception>(() =>
            fakeRules.IsValidLogFileName("anything"));
    }
}