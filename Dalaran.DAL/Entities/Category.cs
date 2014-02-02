using System.Collections.Generic;
using Dalaran.DAL.Interfaces;

namespace Dalaran.DAL.Entities
{
    public class Category: IEntity
    {
        public Category()
        {
            SubCategories = new List<SubCategory>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }

    }
}
