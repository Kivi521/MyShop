using System;
using AutoMapper;
using OrderManagementSystemNew.Data.Entities;
using OrderManagementSystemNew.Data.Entity;
using OrderManagementSystemNew.ViewModels;

namespace OrderManagementSystemNew.Data
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
