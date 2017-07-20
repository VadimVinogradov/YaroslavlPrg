using Microsoft.EntityFrameworkCore;
using Proba1.ProjectCod;

namespace Proba1.Models
{
    public partial class DbDataContext : DbContext
    {
        public DbSet<Tovar> Tovars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql(ModelCsCL.ConnectionStringDB);
            optionsBuilder.UseNpgsql(ModelEntityCL.CurentConnectionString);
        }
    }
}
