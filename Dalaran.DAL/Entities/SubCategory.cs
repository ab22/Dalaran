
using System.Collections.Generic;
using Dalaran.DAL.Interfaces;

namespace Dalaran.DAL.Entities
{
    public partial class SubCategory : IEntity
    {
        public SubCategory()
        {

        }

        public int SubCategoryId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
