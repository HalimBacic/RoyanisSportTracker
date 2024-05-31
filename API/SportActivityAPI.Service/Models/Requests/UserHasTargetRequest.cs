using SportActivityAPI.Share.Enums;

namespace SportActivityAPI.Service.Models.Requests
{
    public class UserHasTargetRequest
    {
        public int UserId { get; set; }
        public int ActivityTypeId { get; set; }
        public DateOnly? DateActivity { get; set; }
        public TargetTypeEnum Type { get; set; }
        public int? Count { get; set; }
        public int? Target { get; set; }
    }
}
