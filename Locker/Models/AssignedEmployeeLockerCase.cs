using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace Locker.Models
{
    public class AssignedEmployeeLockerCase
    {
     
        [Key]
        public int EmployeeId { get; internal set; }
        
       
        
        
        public int LockerCaseId { get; internal set; }

        public virtual Employee Employee { get; set; }
        public virtual LockerCase LockerCase { get; set; }
        
        
    }
}