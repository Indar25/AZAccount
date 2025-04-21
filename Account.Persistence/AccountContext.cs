using Account.Persistence.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Account.Persistence;

public class AccountContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public AccountContext(DbContextOptions<AccountContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ApplicationUser>(b =>
        {
            b.Property(x => x.FirstName).HasMaxLength(100);
            b.Property(x => x.LastName).HasMaxLength(100);
        });
    }
}

//public class AccountContext : DbContext
//{
//    public AccountContext(DbContextOptions opt) : base(opt)
//    {

//    }
//    public DbSet<User> User { get; set; }

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<User>(entity =>
//        {
//            entity.HasKey(entity => entity.Id);
//            entity.HasIndex(entity => entity.Email).IsUnique();
//        });
//    }
//}

