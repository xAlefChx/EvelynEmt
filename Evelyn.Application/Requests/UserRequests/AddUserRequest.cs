using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Evelyn.Domain.Enums.Enums;

namespace Evelyn.Application.Requests.UserRequests
{
    public class AddUserRequest
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalId { get; set; }
        public MatterType MatterType { get; set; }
    }
}
