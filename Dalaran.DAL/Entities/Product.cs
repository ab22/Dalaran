using Dalaran.DAL.Interfaces;
using System.Collections.Generic;

namespace Dalaran.DAL.Entities
{
    public partial class Product : IEntity
    {
        public Product()
        {
            this.ProductDescriptions = new List<ProductDescription>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Upc { get; set; }
        public string Condition { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<ProductDescription> ProductDescriptions { get; set; }
    }
}
