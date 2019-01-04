using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Locker.Models
{
    public class LockerCase
    {
        public int LockerCaseId { get; set; }
        public string LockerCaseName { get; set; }

        public virtual ICollection<AssignedEmployeeLockerCase> AssignedEmployeeLockerCases { get; set; }


    }

}