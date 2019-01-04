using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Locker.Models;

    public class LockerContext : DbContext
    {
        public LockerContext (DbContextOptions<LockerContext> options)
            : base(options)
        {
        }

        public DbSet<Locker.Models.Employee> Employee { get; set; }

        public DbSet<Locker.Models.LockerCase> LockerCase { get; set; }
    }
