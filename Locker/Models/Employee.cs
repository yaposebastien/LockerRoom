using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Locker.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeePhone { get; set; }

        public virtual ICollection<AssignedEmployeeLockerCase> AssignedEmployeeLockerCases { get; set; }
        

    }
}