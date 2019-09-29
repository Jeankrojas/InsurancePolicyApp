using InsurancePolicyApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace InsurancePolicyApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>  options) : base (options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<PolicyEventType> PolicyEventTypes { get; set; }
        public DbSet<PolicyEventType> PolicyClients { get; set; }
        public DbSet<RiskType> RiskTypes { get; set; }

    }
}