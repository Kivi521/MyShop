using System;
using AutoMapper;
using EShop.Data.Entities;
using EShop.Data.Entity;
using EShop.ViewModels;

namespace EShop.Data
{
    public class EShopMappingProfile: Profile
    {
        public EShopMappingProfile()
        {
            //CreateMap<Order, OrderViewModel>()
            //  .ForMember(o => o.OrderId, ex => ex.MapFrom(i => i.Id))
            //  .ReverseMap();

            //CreateMap<OrderItem, OrderItemViewModel>()
            //  .ReverseMap();
        }
    }
}
