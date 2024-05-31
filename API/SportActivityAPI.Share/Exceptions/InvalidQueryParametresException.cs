namespace SportActivityAPI.Share.Exceptions
{
    public class InvalidQueryParametresException : Exception
    {
        public InvalidQueryParametresException(string? message) : base(message)
        {
        }
    }
}
