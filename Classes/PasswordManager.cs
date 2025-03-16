using System;
using System.Security.Cryptography;
using System.Text;

namespace AOOP_Homework2;

public static class PasswordManager
{
    public static string HashPassword(string password)
    {
        // Convert password to byte array
        var passwordBytes = Encoding.UTF8.GetBytes(password);

        // Hash password
        var hashedBytes = SHA256.HashData(passwordBytes);

        // Convert hashed bytes to hexadecimal string for storage
        var hashedPassword = Convert.ToHexString(hashedBytes);

        // For testing
        // Console.WriteLine(hashedPassword);

        return hashedPassword;
    }

    public static bool VerifyPassword(string? inputPassword, string hashedPassword)
    {
        if (inputPassword is null) return false;
        
        // Compare hashed input with stored hashed password
        return HashPassword(inputPassword) == hashedPassword;
    }
}