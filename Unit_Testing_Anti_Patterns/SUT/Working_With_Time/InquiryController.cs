public class InquiryController
{
    public void ApproveInquiry()
    {
        DateTimeServer.Init(() => DateTime.Now); 
        //For tests
        // DateTimeServer.Init(() => new DateTime(2020, 1, 1));
    }
}