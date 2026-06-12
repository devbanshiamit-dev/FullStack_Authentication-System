namespace Registration_System.PasswordSecurity
{
    public class PasswordHasher
    {
        // Password ko Hash karne ke liye
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool VerifyPassword(string storedHash, string enteredPassword)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHash);
        }
    }
}
