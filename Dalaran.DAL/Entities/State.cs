using System;
using System.Collections.Generic;
using Dalaran.DAL.Interfaces;

namespace Dalaran.DAL.Entities
{
    public partial class State : IEntity
    {
        public State()
        {
            Cities = new List<City>();
        }

        public int StateId { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
