using System;
using System.ComponentModel.DataAnnotations;

namespace Chator.Shared.ViewModels.User
{
    public class CreateUserViewModel
    {
        [EmailAddress]
        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
