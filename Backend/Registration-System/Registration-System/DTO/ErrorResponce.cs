namespace Registration_System.DTO
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime TimeStamp { get; set; }
    }
}
