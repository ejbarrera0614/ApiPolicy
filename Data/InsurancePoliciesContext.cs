using Microsoft.EntityFrameworkCore;
using InsurancePoliciesAPI.Models;
namespace InsurancePoliciesAPI.Data;
public class InsurancePoliciesContext : DbContext
{
    public DbSet<Policy> Policies { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Coverage> Coverages { get; set; }
    public DbSet<PolicyVehicle> PolicyVehicle { get; set; }
    public DbSet<PolicyCoverage> PolicyCoverage { get; set; }

    public InsurancePoliciesContext(DbContextOptions<InsurancePoliciesContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure the "Policy" table
        modelBuilder.Entity<Policy>()
            .ToTable("Policy")
            .HasIndex(p => p.PolicyNumber)
            .IsUnique();
        // Configure the "Policy" table
        modelBuilder.Entity<Vehicle>()
            .ToTable("Vehicle")
            .HasIndex(v => v.NumberPlate)
            .IsUnique();
        // Configure the "Policy" table
        modelBuilder.Entity<Customer>()
            .ToTable("Customer")
            .HasIndex(c=> c.DocumentIdentity).IsUnique();
        // Configure the "Policy" table
        modelBuilder.Entity<Coverage>()
            .ToTable("Coverage");
    }

}



