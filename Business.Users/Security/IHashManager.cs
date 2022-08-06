

namespace Business.Users.Security
{
    public interface IHashManager
    {
        string HashString(string clearText);
        bool ValidateHash(string hashedText, string clearText);
    }
}
