namespace SportActivityAPI.Service.Models.Requests
{
    public class ActivityRequest
    {
        public int? Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public DateOnly DateActivity { get; set; }
        public int Duration { get; set; }
        public int ActivityTypeId { get; set; }
    }
}
