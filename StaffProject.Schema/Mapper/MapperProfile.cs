using AutoMapper;
using StaffProject.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffProject.Schema;

public class MapperProfile :Profile
{
    public MapperProfile()
    {
        CreateMap<Staff,StaffResponse>();
        CreateMap<StaffRequest,Staff>();

        //CreateMap<Product, ProductResponse>();
        //CreateMap<ProductRequest, Product>();



    }
}
