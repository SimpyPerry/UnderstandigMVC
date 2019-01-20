using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnderstandigMVC.Models;

namespace UnderstandigMVC.Entities
{
    public class MVCMapping_profile : Profile
    {
        public MVCMapping_profile()
        {
            CreateMap<Product, ProductModel>()
                .ForMember(p => p.ProductId, ex => ex.MapFrom(pm => pm.Id));
            CreateMap<ProductModel, Product>()
                .ForMember(p => p.Id, ex => ex.MapFrom(pm => pm.ProductId));
            CreateMap<Contact, ContactViewModel>();
            CreateMap<ContactViewModel, Contact>();

        }
    }
}
