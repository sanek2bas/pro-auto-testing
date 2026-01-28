using Moq;

namespace SUT.UnitTests;

public class ControllerTests
{
    [Fact]
    public void Sending_A_Greetings_Email()
    {
        var emailGatewayMock = new Mock<IEmailGateway>();
        var sut = new Controller(emailGatewayMock.Object);

        sut.GreetUser("user@email.com");

        emailGatewayMock.Verify(
            x => x.SendGreetingsEmail("user@email.com"),
            Times.Once);
    }
}
