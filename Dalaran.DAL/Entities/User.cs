using System;
using System.Collections;
using System.Collections.Generic;
using Dalaran.DAL.Interfaces;

namespace Dalaran.DAL.Entities
{
    public partial class User : IEntity
    {
        public User()
        {
            this.Products = new List<Product>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime RegisterDate { get; set; }
        public int Rating { get; set; }
        public int CityId { get; set; }
        public int AccountState { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
