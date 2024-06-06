namespace SportActivityAPI.Share.Exceptions
{
    /// <summary>
    /// Exception messages for usage in project. 
    /// Here you can add or update all messages which will be use in project
    /// </summary>
    public class ExceptionsMessages
    {
        public static readonly string UserNotAuthorized = "Unsuccessful authorization";
        public static readonly string NotFoundIndatabase = "Entity not found in database.\n Contact administrator for more information.";
        public static readonly string InvalidParametres = "Invalid parametres in API call.";
        public static readonly string BothParametresNull = "All query parametres is null.";
    }
}
