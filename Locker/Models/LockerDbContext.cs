using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace Locker.Models
{
    public class LockerDbContext:DbContext 
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<LockerCase> LockerCase { get; set; }
        public DbSet<AssignedEmployeeLockerCase> AssignedEmployeeLockerCase { get; set; }
    }
}