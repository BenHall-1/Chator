using System;
using System.ComponentModel.DataAnnotations;

namespace Chator.Shared.ViewModels.User
{
    public class UserViewModel
    {
        [Display(Name = "User ID")]
        public long Id { get; set; }

        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Display(Name = "Discriminator")]
        [Range(1, 9999)]
        public int Discriminator { get; set; }

        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Avatar Hash")]
        public string Avatar { get; set; }
    }
}
