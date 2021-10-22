using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using vehicles.API.Data.Entities;


namespace vehicles.API.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Brand> brands { get; set; }
        public DbSet<Detail> details { get; set; }
        public DbSet<DocumentType> documentTypes { get; set; }
        public DbSet<Procedure> procedures { get; set; }
        public DbSet<History> histories { get; set; }
        public DbSet<VehicleType> vehicleTypes { get; set; }
        public DbSet<VehiclePhoto> vehiclePhotos { get; set; }
        public DbSet<Vehicle> vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DocumentType>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<Brand>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<Procedure>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<VehicleType>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<Vehicle>().HasIndex(x => x.Plaque).IsUnique();
        }
    }
}
