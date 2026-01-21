namespace SUT.UnitTests;

public class MessageRendererTests
{
    [Fact]
    public void MessageRenderer_Uses_Correct_Sub_Renderers()
    {
        var sut = new MessageRenderer();
        IReadOnlyList<IRenderer> renderers = sut.SubRenderers;
        Assert.Equal(3, renderers.Count);
        Assert.IsAssignableFrom<HeaderRenderer>(renderers[0]);
        Assert.IsAssignableFrom<BodyRenderer>(renderers[1]);
        Assert.IsAssignableFrom<FooterRenderer>(renderers[2]);
    }

    [Fact]
    public void Rendering_A_Message()
    {
        var sut = new MessageRenderer();
        var message = new Message
        {
            Header = "h",
            Body = "b",
            Footer = "f"
        };
        string html = sut.Render(message);
        Assert.Equal("<h1>h</h1><b>b</b><f>f</f>", html);
    }

    private MessageRenderer CreateMessageRender()
    {
        return new MessageRenderer();
    }
}