namespace AuditSystem;

public class AuditManager2
{
    private readonly int maxEntriesPerFile;

    public AuditManager2(int maxEntriesPerFile)
    {
        this.maxEntriesPerFile = maxEntriesPerFile;
    }

    public FileUpdate AddRecord(FileContent[] files, string visitorName, DateTime timeOfVisit)
    {
        (int index, FileContent file)[] sorted = SortByIndex(files);

        string newRecord = visitorName + ';' + timeOfVisit;

        if (sorted.Length == 0)
            return new FileUpdate("audit_1.txt", newRecord);

        (int currentFileIndex, FileContent currentFile) = sorted.Last();

        List<string> lines = currentFile.Text.ToList();
        if (lines.Count < maxEntriesPerFile)
        {
            lines.Add(newRecord);
            string newContent = string.Join("\r\n", lines);
            return new FileUpdate(currentFile.FileName, newContent);
        }
        else
        {
            int newIndex = currentFileIndex + 1;
            string newName = $"audit_{newIndex}.txt";
            return new FileUpdate(newName, newRecord);
        }
    }

    private (int, FileContent)[] SortByIndex(FileContent[] files)
    {
        var result = new (int, FileContent)[files.Length];
        for (int i = 0; i < files.Length; i++)
            result[i] = new(i + 1, files[i]);
        return result;
    }
}