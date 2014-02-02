using System;
using System.Collections.Generic;
using Dalaran.DAL.Interfaces;

namespace Dalaran.DAL.Entities
{
    public partial class City : IEntity
    {
        public City()
        {
            this.Users = new List<User>();
        }

        public int CityId { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }

        public virtual State State { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
