using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ConsignorMGT.Models;

namespace ConsignorMGT.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Consignor> Consignor { get; set; }

        public DbSet<Contract> Contract { get; set; }

        public DbSet<Event> Event { get; set; }
        public DbSet<Buyer> Buyer { get; set; }
        public DbSet<ContractHeader> ContractHeader { get; set; }
        public DbSet<ContractDetail> ContractDetail { get; set; }


    }
}
