using CRM1.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CRM1.Data
{
    public class CrmDb : DbContext
    {
        public CrmDb(DbContextOptions options) : base(options)
        {
        }
        public DbSet<CRM> CRMs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CRM>()
                .Property(crm => crm.CompaType)
                .HasConversion<string>();
        }
    }
}
