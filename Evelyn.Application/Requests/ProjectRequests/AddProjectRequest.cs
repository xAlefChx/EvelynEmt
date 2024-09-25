using static Evelyn.Domain.Enums.Enums;

namespace Evelyn.Application.Requests.ProjectRequests
{
    public class AddProjectRequest
    {
        public int AddressId { get; set; }
        public ProjectType Type { get; set; }
        public DateTime DateOfProject { get; set; }
    }
}