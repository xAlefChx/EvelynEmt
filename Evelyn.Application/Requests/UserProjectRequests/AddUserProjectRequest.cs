using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Evelyn.Domain.Enums.Enums;

namespace Evelyn.Application.Requests.UserProjectRequests
{
    public class AddUserProjectRequest
    {
        public Guid UserId { get; set; }
        public Guid UserInChargeId { get; set; }
        public Guid UserTechId { get; set; }
        public int ProjectId { get; set; }
    }
}