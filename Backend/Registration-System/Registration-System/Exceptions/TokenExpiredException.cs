namespace Registration_System.Exceptions
{
    public class TokenExpiredException : Exception
    {
        public TokenExpiredException(string Message) : base(Message) { }
    }
}
