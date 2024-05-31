using SportActivityAPI.Share.Enums;

namespace SportActivityAPI.Service.Models.Responses
{
    public class UserHasTargetResponse
    {
        public int UserId { get; set; }
        public int ActivityTypeId { get; set; }
        public DateOnly? Date { get; set; }
        public TargetTypeEnum Type { get; set; }
        public int? Count { get; set; }
        public int? Target { get; set; }
    }
}
