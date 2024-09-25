namespace Evelyn.Application.Requests.UserProjectRequests
{
    public class UpdateUserProjectRequest
    {
        public Guid UserId { get; set; }
        public Guid UserInChargeId { get; set; }
        public Guid UserTechId { get; set; }
        public int ProjectId { get; set; }
    }
}