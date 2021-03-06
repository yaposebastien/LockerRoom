using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace Locker.Models
{
    public class LockerDbContext:DbContext 
    {
        public LockerDbContext (DbContextOptions<LockerDbContext> options)
            :base(options)
            {

            }

        // Adding fluent API to solve composite primary key
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssignedEmployeeLockerCase>()
                .HasKey(Loc => new { Loc.EmployeeId, Loc.LockerCaseId});
        }
        public DbSet<Employee> Employee { get; set; }
       
        
        public DbSet<LockerCase> LockerCase { get; set; }
       
        public DbSet<AssignedEmployeeLockerCase> AssignedEmployeeLockerCase { get; set; }
        
        
        
    }
}