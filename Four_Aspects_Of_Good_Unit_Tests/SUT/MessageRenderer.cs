namespace SUT;

public interface IRenderer
{
    string Render(Message message);
}

public class MessageRenderer : IRenderer
{
    public IReadOnlyList<IRenderer> SubRenderers { get; }
    public MessageRenderer()
    {
        SubRenderers = new List<IRenderer>
        {
            new HeaderRenderer(),
            new BodyRenderer(),
            new FooterRenderer()
        };
    }

    public string Render(Message message)
    {
        return SubRenderers
            .Select(x => x.Render(message))
            .Aggregate("", (str1, str2) => str1 + str2);
    }
}

public class HeaderRenderer : IRenderer
{
    public string Render(Message message)
    {
        return $"<h1>{message.Header}</h1>";
    }
}

public class BodyRenderer : IRenderer
{
    public string Render(Message message)
    {
        return $"<b>{message.Body}</b>";
    }
}

public class FooterRenderer : IRenderer
{
    public string Render(Message message)
    {
        return $"<f>{message.Footer}</f>";
    }
}
