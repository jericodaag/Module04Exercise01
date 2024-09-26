namespace Module02Exercise01.Services
{
    public interface IMyService
    {
        string GetMessage();
    }

    public class MyService : IMyService
    {
        public string GetMessage()  
        {
            return "Hello, this is from MyService!";
        }
    }
}
