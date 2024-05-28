namespace SportActivityAPI.Service.Models.Responses
{
    public class ActivityResponse
    {
        public int? Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public int ActivityTypeId { get; set; }
    }
}
