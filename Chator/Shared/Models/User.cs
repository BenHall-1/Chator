using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Chator.Shared.Models
{
    /// <summary>
    /// The main User model.
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            // TODO: Implement IDs
            // Id = new IdGenerator((int)EntityType.USER).CreateId();
            CreationDate = DateTime.Now;
        }

        /// <summary>
        /// Gets or sets the username of the <see cref="User"/>.
        /// </summary>
        [Required]
        public override string UserName { get; set; }

        /// <summary>
        /// Gets or sets the Discriminator of the <see cref="User"/>.
        /// </summary>
        [Required]
        [Range(1, 9999)]
        public int Discriminator { get; set; }

        /// <summary>
        /// Gets or sets the creation Date of the <see cref="User"/>.
        /// </summary>
        [Required]
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the avatar hash of the <see cref="User"/>.
        /// </summary>
        public string Avatar { get; set; }
    }
}