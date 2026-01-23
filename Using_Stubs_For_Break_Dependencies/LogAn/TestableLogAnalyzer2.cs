namespace LogAn;

public class TestableLogAnalyzer2 : LogAnalyzerUsingFactoryMethod2
{
    public bool IsSupported { get; set; }

    protected override bool IsValid(string fileName)
    {
        return IsSupported;
    }
}
