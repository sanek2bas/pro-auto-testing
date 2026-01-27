using NSubstitute;

namespace LogAn.UnitTests;

public class PresenterTests
{
    [Fact]
    public void Ctor_WhenViewIsLoaded_CallsViewRender()
    {
        var mockView = Substitute.For<IView>();

        Presenter p = new Presenter(mockView, Substitute.For<ILogger>());
        mockView.Loaded += Raise.Event<Action>();
        mockView.Received()
            .Render(Arg.Is<string>(s => s.Contains("Hello World")));
    }

    [Fact]
    public void Ctor_WhenViewhasError_CallsLogger()
    {
        var stubView = Substitute.For<IView>();
        var mockLogger = Substitute.For<ILogger>();

        Presenter p = new Presenter(stubView, mockLogger);
        stubView.ErrorOccured +=
            Raise.Event<Action<string>>("fake error");
    }

    [Fact]
    public void EventFiringManual()
    {
        bool loadFired = false;
        SomeView view = new SomeView();
        view.Load += delegate
        {
            loadFired = true;
        };
        view.DoSomethingThatEventuallyFiresThisEvent();

        Assert.True(loadFired);
    }
}