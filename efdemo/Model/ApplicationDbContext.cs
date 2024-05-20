using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace efdemo.Model
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<ExpenseHeader> ExpenseHeaders { get; set; }
        public DbSet<ExpenseLine> ExpenseLines { get; set; }
        public DbSet<ExpanseUser> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<ExpenseLine>()
                .Property(e => e.TotalCost)
                .HasComputedColumnSql("[Quantity] * [UnitCost]");

            builder.Entity<ExpenseHeader>()
                .Property(e => e.UsdExchangeRate)
                    .HasColumnType($"decimal(13,4)")
                    .IsRequired(true);

            builder.Entity<ExpenseHeader>()
                .HasOne(e => e.Requester)
                .WithMany(e => e.RequesterExpenseHeaders)
                .HasForeignKey(e => e.RequesterId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
        }
    }
}

