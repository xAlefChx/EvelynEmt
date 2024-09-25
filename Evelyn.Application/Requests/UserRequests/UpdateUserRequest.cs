using static Evelyn.Domain.Enums.Enums;

namespace Evelyn.Application.Requests.UserRequests
{
    public class UpdateUserRequest
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalId { get; set; }
        public MatterType MatterType { get; set; }
    }
}
