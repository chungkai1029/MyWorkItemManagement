using Microsoft.EntityFrameworkCore;
using MyWorkItemManagement.Models;

namespace MyWorkItemManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkItem> WorkItems { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<UserWorkItemStatus> UserWorkItemStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>()
                .HasData(new Role { Id = 1, RoleName = "Admin" }, new Role { Id = 2, RoleName = "User" });

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Token>()
                .Property(t => t.TokenValue)
                .HasColumnName("token");

            modelBuilder.Entity<Token>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tokens)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserWorkItemStatus>()
                .HasOne(s => s.User)
                .WithMany(u => u.UserWorkItemStatuses)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserWorkItemStatus>()
                .HasOne(s => s.WorkItem)
                .WithMany(w => w.UserWorkItemStatuses)
                .HasForeignKey(s => s.WorkItemId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}