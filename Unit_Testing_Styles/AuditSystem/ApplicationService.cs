namespace AuditSystem;

public class ApplicationService
{
    private readonly string directoryName;
    private readonly AuditManager2 auditManager;
    private readonly Persister persister;

    public ApplicationService(string directoryName, int maxEntriesPerFile)
    {
        this.directoryName = directoryName;
        this.auditManager = new AuditManager2(maxEntriesPerFile);
        this.persister = new Persister();
    }

    public void AddRecord(string visitorName, DateTime timeOfVisit)
    {
        FileContent[] files = persister.ReadDirectory(directoryName);
        FileUpdate update = auditManager.AddRecord(files, visitorName, timeOfVisit);
        persister.ApplyUpdate(directoryName, update);
    }
}
