//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dalaran.DAL
{
    using System.Collections.Generic;
    using Dalaran.DAL.Interfaces;
    public partial class ProductDescriptionTypes : IEntity
    {
        public ProductDescriptionTypes()
        {
            this.ProductDescriptions = new HashSet<ProductDescriptions>();
        }
    
        public int ProductDescriptionTypeId { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<ProductDescriptions> ProductDescriptions { get; set; }
    }
}
