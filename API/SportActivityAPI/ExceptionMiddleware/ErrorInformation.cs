namespace SportActivityAPI.ExceptionMiddleware
{
    public class ErrorInformation
    {
        public int StatusCode { get; set; }
        public string? ExceptionType { get; set; }
        public string? Message { get; set; }
        public string? StackTrace { get; set; }
    }
}
