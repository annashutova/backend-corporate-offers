using System.Security.Cryptography;
using System.Text;

namespace CorporateOffers.Utils;

public static class Hash
{
    public static byte[] HashPassword(string password)
    {
        byte[] bytesPassword = Encoding.UTF8.GetBytes(password);
        byte[] hashedPassword = SHA256.HashData(bytesPassword);

        return hashedPassword;
    }
}