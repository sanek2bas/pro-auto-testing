public class Controller
{
    public void SomeMethod(Logger logger)
    {
        logger.Log("SomeMethod is called");
    }

    public void SomeMethod(ILogger logger)
    {
        logger.Log("SomeMethod is called");
    }
}