namespace AuditSystem;

public class FileUpdate
{
    public string FileName { get; private set; }

    public string NewContent { get; private set; }

    public FileUpdate(string fileName, string newContent)
    {
        FileName = fileName;
        NewContent = newContent;
    }
}
