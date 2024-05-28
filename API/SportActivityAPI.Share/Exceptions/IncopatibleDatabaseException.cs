namespace SportActivityAPI.Share.Exceptions
{
    public class IncopatibleDatabaseException : Exception
    {
        public IncopatibleDatabaseException(string? message) : base(message)
        {
        }
    }
}
