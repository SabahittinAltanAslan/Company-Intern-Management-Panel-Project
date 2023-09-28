using Microsoft.EntityFrameworkCore;
using stajerYonetim.Models;
using System.Collections.Generic;

namespace stajerYonetim.Models
{
    public class Context :DbContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LEGEN\\MSSQLSERVER01;database=stajerYonetim;integrated security= true; Trust Server Certificate=true;");
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Intern> Interns { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<PdfRecord> PdfRecords { get; set; }

        public DbSet<Document> Documents{ get; set; }

    }
}
