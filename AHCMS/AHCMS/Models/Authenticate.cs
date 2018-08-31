using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AHCMS.CORE;

namespace AHCMS.Models
{
    public class Authenticate
    {
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Role")]
        public string Role { get; set; }

        public UserRole UserType { get; set; }

        public string Username { get; set; }
    }

    public class SessionModel
    {
        public string Status { get; set; }
        public string ReffNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Img { get; set; }
    }


    //
    public class AccountLoginModel
    {

        public string ID { get; set; }
        public string ReffNo { get; set; }
        public string Role { get; set; }       
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string CountryCode { get; set; }
        public Int64 PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }        
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }        
        public DateTime BirthDate { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string BloodGroup { get; set; }
        public int Gender { get; set; }

       
    }

    public class AccountForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

    public class AccountResetPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
    }

    public class AccountRegistrationModel
    {
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [EmailAddress]
        [Compare("Email")]
        public string EmailConfirm { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
    }
}