using Microsoft.EntityFrameworkCore;

namespace GT.Models
{
    public class GlobalTaskEFContext : DbContext
    {
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }

        public GlobalTaskEFContext(DbContextOptions<GlobalTaskEFContext> optionsBuilder) : base(optionsBuilder) { }
    }
}
