using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Evelyn.Domain.Enums.Enums;

namespace Evelyn.Application.Requests.UserRequests
{
    public class AddUserRoleRequest
    {
        public Guid UserId { get; set; }
        public RoleType Role { get; set; }
    }
}