﻿using BeMyGuest.Shared.Model.Requests.Identity;
using System.ComponentModel.DataAnnotations;

namespace Client.BusinessComponents.Requests.Identity
{
    public class RegisterRequest : IRegisterRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string UserName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Email))]
        public string ConfirmEmail { get; set; }

        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        public string PhoneNumber { get; set; }

        public bool ActivateUser { get; set; } = false;

        public string ProfilePicture { get; set; }

        public List<string> Proffesion { get; set; } = new List<string>();
    }
}
