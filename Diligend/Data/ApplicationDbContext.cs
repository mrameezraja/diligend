using System;
using System.Collections.Generic;
using System.Text;
using Diligend.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Diligend.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<College> Colleges { get; set; }
        public DbSet<CollegeForm> CollegeForms { get; set; }
        public DbSet<RegistrationForm> RegistrationForms { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
