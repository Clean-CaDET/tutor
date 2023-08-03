using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Tutor.Stakeholders.Infrastructure.Authentication;

public static class PasswordUtilities
{
    public static string HashPassword(string password, byte[] salt)
    {
        return Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password,
            salt,
            KeyDerivationPrf.HMACSHA256,
            100000,
            256 / 8));
    }

    public static byte[] GenerateSalt()
    {
        var salt = new byte[128 / 8];
        var randomNumberGenerator = RandomNumberGenerator.Create();
        randomNumberGenerator.GetBytes(salt);
        return salt;
    }
}