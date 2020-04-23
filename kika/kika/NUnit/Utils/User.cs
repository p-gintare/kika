namespace kika.NUnit.Utils
{
    public class User
    {
        public static User DefaultKikaUser = new User("test@test.lt", "test123");

        public string Username;
        public string Password;

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
