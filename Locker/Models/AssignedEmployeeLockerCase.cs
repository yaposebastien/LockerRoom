using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Locker.Models
{
    public class AssignedEmployeeLockerCase
    {
        [Key]
        [Column(Order=1)]
        public int EmployeeId { get; set; }
        
        [Key]
        [Column(Order=2)]
        public int LockerCaseId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual LockerCase LockerCase { get; set; }
    }
}