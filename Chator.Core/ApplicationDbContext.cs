using Chator.Shared.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Chator.Core
{
    /// <summary>
    /// Database Context.
    /// </summary>
    public class ApplicationDbContext : ApiAuthorizationDbContext<User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">the options for the database.</param>
        /// <param name="operationalStoreOptions">The storage options for the database.</param>
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>()
                .HasIndex(u => new { u.UserName, u.Discriminator })
                .IsUnique();
        }
    }
}
