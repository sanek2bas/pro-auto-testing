public interface IDateTimeServer
{
    DateTime Now { get; }
}

public class DateTimeServer2 : IDateTimeServer
{
    public DateTime Now => DateTime.Now;
}