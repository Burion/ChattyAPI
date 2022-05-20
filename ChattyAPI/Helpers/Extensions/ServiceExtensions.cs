using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChattyAPI.Helpers.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddMapper(this IServiceCollection collection, MappingProfile profile)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(profile);
            });

            var mapper = mapperConfig.CreateMapper();

            collection.AddSingleton(mapper);
        }
    }
}
