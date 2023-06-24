using Microsoft.EntityFrameworkCore;
using Web_Api.Model;

namespace Web_Api.Date;

public class MyDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Resource> Resources { get; set; }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost;port=3306;database=authority;uid=root;pwd=root", new MySqlServerVersion("5.7.41"));
    }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>()
            .HasMany(r => r.Resources)
            .WithMany(r => r.Roles);
        modelBuilder.Entity<Role>()
            .HasMany(r => r.Users)
            .WithMany(u => u.Roles);
    
        // 如果你想要指定中间表的名字和配置中间表的其他属性，你需要调用 UsingEntity
        /*
        modelBuilder.Entity<User>()
            .HasMany(u => u.Roles)
            .WithMany()
            .UsingEntity(j => j.ToTable("UserRoles"));

        modelBuilder.Entity<Role>()
            .HasMany(r => r.Resources)
            .WithMany()
            .UsingEntity(j => j.ToTable("RoleResources"));
        */
    }
}