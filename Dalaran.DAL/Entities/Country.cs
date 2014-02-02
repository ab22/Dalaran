using Dalaran.DAL.Interfaces;
using System.Collections.Generic;

namespace Dalaran.DAL.Entities
{
    public partial class Country : IEntity
    {
        public Country()
        {
            States = new List<State>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<State> States { get; set; }
    }
}
