using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalaran.DAL.Entities
{
    public partial class ProductDescription
    {
        public int ProductDescriptionId { get; set; }
        public int ProductId { get; set; }
        public int ProductDescriptionTypeId { get; set; }
        public string Description { get; set; }

        public virtual ProductDescriptionType ProductDescriptionType { get; set; }
        public virtual Product Product { get; set; }
    }
}
