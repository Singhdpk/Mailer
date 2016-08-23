namespace SIMailer.Enums
{
   public enum LoginAdminStatus
    {
        Successfull=1,
        IncorrectPassowrd=2,
        NotRegisterd=3,
        Exception=4
    }
    public enum AdminRgistrationStatus
    {
        Successfull = 1,
        AlreadyRegistered= 2,
        Exception = 3
    }
    public enum AddPersonStatus
    {
        Successfull = 1,
        AlreadyRegistered = 2,
        Exception = 3,
            IsEdited=4
    }
}