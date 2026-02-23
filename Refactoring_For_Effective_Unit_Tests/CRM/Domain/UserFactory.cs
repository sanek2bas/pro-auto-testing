namespace CRM.Domain;

public class UserFactory
{
    public static User Create(object[] data)
    {
        //Precondition.Requires(data.Length >= 3);
        if (data.Length < 3)
            throw new Exception();

        int id = (int)data[0];
        string email = (string)data[1];
        UserType type = (UserType)data[2];
        return new User(id, email, type);
    }
}
