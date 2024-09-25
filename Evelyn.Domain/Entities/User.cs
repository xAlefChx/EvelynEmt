using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Evelyn.Domain.Enums.Enums;

namespace Evelyn.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public Guid? ParentUserId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public RoleType Role { get; set; }
        public string? CustomerFinancialId { get; set; }
        public MatterType MatterType { get; set; }
        public string NationalId { get; set; }
        public int CoinScore { get; set; }


        #region Relations
        public ICollection<Address> Addresses { get; set; }
        public ICollection<UserProject> UserProjects { get; set; }
        #endregion
    }
}
