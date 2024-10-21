using ClassLibrary.Configurations;
using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary
{
    public class ProjDbContext : DbContext
    {
        public ProjDbContext(DbContextOptions<ProjDbContext> options)
        : base(options)
        {
        }
        public DbSet<ContactPersonEntity> ContactPersons { get; set; }
        public DbSet<MilitaryUnitEntity> MilitaryUnits { get; set; }
        public DbSet<OrganizationEntity> Organizations { get; set; }
        public DbSet<RequestEntity> Requests { get; set; }
        public DbSet<VolunteerEntity> Volunteers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VolunteerOrganizationConfiguration());
            modelBuilder.ApplyConfiguration(new MilitaryUnitConfiguration());
            modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
            modelBuilder.ApplyConfiguration(new RequestConfiguration());
            modelBuilder.ApplyConfiguration(new VolunteerConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\Documents\\ProjDb.mdf;Integrated Security=True;Connect Timeout=30");
            }
        }
    }
}