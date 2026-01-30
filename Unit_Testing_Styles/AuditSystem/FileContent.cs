namespace AuditSystem;

public class FileContent
{
    public string FileName { get; private set; }

    public string[] Text { get; private set; }

    public FileContent(string fileName, string[] text)
    {
        FileName = fileName;
        Text = text;
    }
}