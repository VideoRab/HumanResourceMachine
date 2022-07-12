using AutoMapper;
using HRM.BLL.Entities;
using HRM.BLL.Models;

namespace HRM.BLL.Profiles
{
    public class HumanProfile : Profile
    {
        public HumanProfile()
        {
            CreateMap<Human, HumanEntity>().ReverseMap();
        }
    }
}
