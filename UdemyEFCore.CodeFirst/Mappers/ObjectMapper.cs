using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyEFCore.CodeFirst.DAL;
using UdemyEFCore.CodeFirst.DTOs;

namespace UdemyEFCore.CodeFirst.Mappers
{
    internal class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CustomMapping>();
            });
            return config.CreateMapper();
        });

        public static IMapper Mapper => lazy.Value; 
        // static hemen yüklenir ama lazy sınıfı value kullanana kadar yüklenmez.
    }

    internal class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            //product dtoyu product maple ama tersi de olabilir.
        }
    }
}
