using SportActivityAPI.Share.Enums;

namespace SportActivityAPI.Service.Models.Requests
{
    public class DeleteUserTargetRequest
    {
        public int UserId { get; set; }
        public int ActivityTypeId { get; set; }
        public DateOnly DateActivity { get; set; }
        public TargetTypeEnum Type { get; set; }
    }
}
