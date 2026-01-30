using System.Runtime.InteropServices.Marshalling;

namespace AuditSystem;

public class AuditManager
{
    private readonly int maxEntriesPerFile;
    private readonly string directoryName;
    private readonly IFileSystem fileSystem;

    public AuditManager(
        int maxEntriesPerFile, 
        string directoryName, 
        IFileSystem fileSystem)
    {
        this.maxEntriesPerFile = maxEntriesPerFile;
        this.directoryName = directoryName;
        this.fileSystem = fileSystem;
    }

    public void AddRecord(string visitorName, DateTime timeOfVisit)
    {
        string[] filePaths = fileSystem.GetFiles(directoryName);
        (int index, string path)[] sorted = SortByIndex(filePaths);

        string newRecord = visitorName + ';' + timeOfVisit;

        if (sorted.Length == 0)
        {
            string newFile = Path.Combine(directoryName, "audit_1.txt");
            fileSystem.WriteAllText(newFile, newRecord);
            return;
        }

        (int currentFileIndex, string currentFilePath) = sorted.Last();
        List<string> lines = fileSystem.ReadAllLines(currentFilePath);

        if (lines.Count < maxEntriesPerFile)
        {
            lines.Add(newRecord);
            string newContent = string.Join("\r\n", lines);
            fileSystem.WriteAllText(currentFilePath, newContent);
        }
        else
        {
            int newIndex = currentFileIndex + 1;
            string newName = $"audit_{newIndex}.txt";
            string newFile = Path.Combine(directoryName, newName);
            fileSystem.WriteAllText(newFile, newRecord);
        }
    }

    private (int, string)[] SortByIndex(string[] filePaths)
    {
        var result = new (int, string)[filePaths.Length];
        for (int i = 0; i < filePaths.Length; i++)
            result[i] = new(i + 1, filePaths[i]);
        return result;
    }
}