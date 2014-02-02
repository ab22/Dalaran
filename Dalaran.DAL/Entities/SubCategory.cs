
using Dalaran.DAL.Interfaces;

namespace Dalaran.DAL.Entities
{
    public class SubCategory : IEntity
    {
        public SubCategory()
        {

        }

        public int SubCategoryId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
