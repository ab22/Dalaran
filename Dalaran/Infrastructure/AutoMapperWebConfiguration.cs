using Dalaran.Infrastructure.Interfaces;

namespace Dalaran.Infrastructure
{
    public class AutoMapperWebConfiguration : IGlobalConfiguration
    {
        public void Configure()
        {
            /* 
             * All CreateMaps must go here.
             * 
             *  Example:
             *      Mapper.CreateMap<Products, SearchProductModel>();
             * 
             * */
        }
    }
}