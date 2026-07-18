using Microsoft.EntityFrameworkCore;
using patient_vaccination_registry.Domain.Entities;

namespace patient_vaccination_registry.API.DATA
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions <DataContext> options): base(options)
        { 
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Drive> Drives { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
    }
}
