using Dalaran.DAL.Interfaces;
using System.Collections.Generic;

namespace Dalaran.DAL.Entities
{
    public partial class ProductDescriptionType : IEntity
    {
        public ProductDescriptionType()
        {
            this.ProductDescriptions = new List<ProductDescription>();
        }

        public int ProductDescriptionTypeId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ProductDescription> ProductDescriptions { get; set; }
    }
}
