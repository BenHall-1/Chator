using Chator.Core.Base;
using Chator.Shared.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Chator.Core
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<User, IdentityRole<long>, long>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>()
                .HasIndex(u => new { u.UserName, u.Discriminator })
                .IsUnique();
        }
    }
}
