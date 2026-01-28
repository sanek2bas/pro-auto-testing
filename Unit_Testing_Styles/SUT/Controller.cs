namespace SUT;

public interface IEmailGateway
{
    void SendGreetingsEmail(string email);
}

public class Controller
{
    private readonly IEmailGateway emailGateway;

    public Controller(IEmailGateway gateway)
    {
        emailGateway = gateway;
    }

    public void GreetUser(string email)
    {
        emailGateway.SendGreetingsEmail(email);
    }
}