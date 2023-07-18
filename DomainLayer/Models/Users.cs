﻿using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models
{
   public class Users : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        //public string? FirstName { get; set; }
        //public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        //public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public ICollection<UserRoles> UserRoles { get; set; }
    }
}
