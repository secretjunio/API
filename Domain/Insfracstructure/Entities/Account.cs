﻿using System.ComponentModel.DataAnnotations;

namespace WebApi.Insfracstructure.Entities
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public string FullName { get; set; }
        public string? NumberPhone { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public int StatusId { get; set; }
        

    }
}
