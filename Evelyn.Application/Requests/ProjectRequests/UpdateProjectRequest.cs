using static Evelyn.Domain.Enums.Enums;

namespace Evelyn.Application.Requests.ProjectRequests
{
    public class UpdateProjectRequest
    {
        public ProjectType Type { get; set; }
        public ProjectStatus Status { get; set; }
        public DateTime DateOfProject { get; set; }
        public int AddressId { get; set; }
    }
}
