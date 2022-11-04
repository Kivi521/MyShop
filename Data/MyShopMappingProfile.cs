using System;
using AutoMapper;
using MyShop.Data.Entities;
using MyShop.Data.Entity;
using MyShop.ViewModels;

namespace MyShop.Data
{
    public class MyShopMappingProfile: Profile
    {
        public MyShopMappingProfile()
        {
            //CreateMap<Order, OrderViewModel>()
            //  .ForMember(o => o.OrderId, ex => ex.MapFrom(i => i.Id))
            //  .ReverseMap();

            //CreateMap<OrderItem, OrderItemViewModel>()
            //  .ReverseMap();
        }
    }
}
