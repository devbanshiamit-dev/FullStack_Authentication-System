namespace Registration_System.PasswordSecurity
{
    public class PasswordHasher
    {
        // Password ko Hash karne ke liye
        public static string HashPassword(string password)
        {
            // Yahan '13' work factor hai (iterations). Jitna zyada work factor hoga, utna secure hoga.
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password, workFactor: 13);
        }

        // Password ko Verify karne ke liye
        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(enteredPassword, storedHash);
        }
    }
}
