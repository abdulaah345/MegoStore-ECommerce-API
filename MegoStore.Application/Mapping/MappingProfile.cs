using AutoMapper;
using MegoStore.Application.Dtos;
using MegoStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegoStore.Application.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, ProductDto>().ReverseMap();
            CreateMap<CartItem, CartItemDto>()
    .ForMember(d => d.ProductName, o => o.MapFrom(s => s.Product.Name))
    .ForMember(d => d.subtotal, o => o.MapFrom(s => s.UnitPrice * s.Quantity));
        }


    }
}
