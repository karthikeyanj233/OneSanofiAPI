using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DomainLayer.Data
{
    public class OneSanofiDbContext : DbContext
    {
        public OneSanofiDbContext(DbContextOptions<OneSanofiDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        //public DbSet<User> User { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Pages> Pages { get; set; }
        public DbSet<RolePages> RolePages { get; set; }
        public DbSet<Dashboard> Dashboard { get; set; }
        public DbSet<Dashboard_Boxes> Dashboard_Boxes { get; set;}
        public DbSet<Dashboard_Details> Dashboard_Details { get; set;}
    }
}
