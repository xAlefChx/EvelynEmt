using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Evelyn.Domain.Enums.Enums;

namespace Evelyn.Domain.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public DateTime DateOfProject { get; set; }
        public ProjectStatus Status { get; set; }
        public ProjectType Type { get; set; }
        public int AddressId { get; set; }


        #region Relations
        public Address Address { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<UserProject> UserProjects { get; set; }
        #endregion
    }
}