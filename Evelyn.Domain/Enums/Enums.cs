using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evelyn.Domain.Enums
{
    public class Enums
    {
        public enum RoleType
        {
            Admin,
            SalesManager,
            ServiceManager,
            StoreKeeper,
            SalesRepresentative,
            ServiceRepresentative,
            SalesRAE,
            SalesCAE,
            ServiceRAE,
            ServiceCAE,
            Technician,
            User
        }
        public enum ProjectStatus
        {
            NotStarted,
            InProgress,
            Completed,
            OnHold,
            Cancelled
        }
        public enum ProjectType
        {
            Install,
            Service,
            Repair
        }
        public enum MatterType
        {
            genuine,
            legal
        }
    }
}
