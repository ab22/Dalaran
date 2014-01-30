using Dalaran.Infrastructure.Interfaces;
using AutoMapper;
using Dalaran.DAL;
using Dalaran.Models;
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
            Mapper.CreateMap<Users,UserModel>();
        }
    }
}