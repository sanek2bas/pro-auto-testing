public class InquiryController2
{
    private readonly IDateTimeServer _dateTimeServer;

    public InquiryController2(IDateTimeServer dateTimeServer) 
    {
        _dateTimeServer = dateTimeServer;
    }
    
    public void ApproveInquiry(int id)
    {
        Inquiry inquiry = GetById(id);
        inquiry.Approve(_dateTimeServer.Now);
        SaveInquiry(inquiry);
    }

    private Inquiry GetById(int id)
    {
        return new Inquiry(id);
    }

    private void  SaveInquiry(Inquiry inquiry)
    {   
    }
}