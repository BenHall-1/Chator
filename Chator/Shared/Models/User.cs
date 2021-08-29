using System;
using System.ComponentModel.DataAnnotations;
using Chator.Shared.Models.Base;
using IdGen;
using Microsoft.AspNetCore.Identity;

namespace Chator.Shared.Models
{
    public class User : IdentityUser<long>
    {
        public User()
        {
            Id = new IdGenerator((int)EntityType.USER).CreateId();
            CreationDate = DateTime.Now;
        }

        [Required]
        public override string UserName { get; set; }

        [Required]
        [Range(1, 9999)]
        public int Discriminator { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        public string Avatar { get; set; }
    }
}