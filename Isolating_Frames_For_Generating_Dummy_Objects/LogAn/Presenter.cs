namespace LogAn;

public interface IView
{
    event Action Loaded;
    event Action<string> ErrorOccured;
    void Render(string text);
}

public class Presenter
{
    private readonly IView view;
    private readonly ILogger log;

    public Presenter(IView view, ILogger log)
    {
        this.view = view;
        this.log = log;
        this.view.Loaded += OnLoaded;
        this.view.ErrorOccured += OnError;
    }

    private void OnLoaded()
    {
        view.Render("Hello World");
    }

    private void OnError(string text)
    {
        log.LogError(text);
    }
}