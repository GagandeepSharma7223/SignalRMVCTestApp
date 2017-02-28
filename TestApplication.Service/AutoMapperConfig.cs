using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Data;
using TestApplication.Data.Entities;
using TestApplication.Service.Models;

namespace TestApplication.Service
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new DevProfile());
            });
        }
    }
    public class DevProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<TestAppModel, DevTest>().ReverseMap();
            Mapper.CreateMap<OrderModel, Order>().ReverseMap();
        }
    }
}
