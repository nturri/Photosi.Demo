


namespace Business.Users.Security
{
    public class BCryptHashManager : IHashManager
    {
        public string HashString(string clearText)
        {
           

            return BCrypt.Net.BCrypt.HashPassword(clearText);
        }

        public bool ValidateHash(string hashedText, string clearText)
        {
            return BCrypt.Net.BCrypt.Verify(clearText, hashedText);
        }

       
    }
}
