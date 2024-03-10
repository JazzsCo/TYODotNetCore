using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using TYODotNetCore.MvcAtmApp.Models;

namespace TYODotNetCore.MvcAtmApp
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "LAPTOP-GF6QM6AD\\SQLEXPRESS",
                InitialCatalog = "TestDb",
                UserID = "sa",
                Password = "sasa@123",
                TrustServerCertificate = true,
            };

            optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
        }

        public DbSet<AtmModel> Atms { get; set; }
    }
}
