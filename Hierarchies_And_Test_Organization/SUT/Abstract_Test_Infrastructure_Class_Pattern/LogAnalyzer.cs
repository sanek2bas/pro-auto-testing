namespace SUT.Abstract_Test_Infrastructure_Class_Pattern;

public class LogAnalyzer
{
    public void Analyze(string fileName)
    {
        if (fileName.Length < 8)
        {
            LoggingFacility.Log("The file name iss too short: " + fileName);
        }
        //the rest of the method
    }
}