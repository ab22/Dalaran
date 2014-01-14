using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
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