using Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Repositories.DAL
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _iConfig;
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration iConfig) : base(options) 
        {
            _iConfig = iConfig;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            //builder.UseSqlServer(_iConfig["ConnectionStrings:DbConnection"]);
            builder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Blackstone.Cars;Integrated Security=True");
            base.OnConfiguring(builder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarRoad>()
                .HasIndex(nameof(CarRoad.CardId), nameof(CarRoad.RoadId))
                .IsUnique();
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Road> Roads { get; set; }
        public DbSet<CarRoad> CarRoads { get; set; }
        public DbSet<CarRoadLog> CarRoadLogs { get; set; }
    }
}
