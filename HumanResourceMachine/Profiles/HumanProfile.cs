using AutoMapper;
using HumanResourceMachine.Entities;
using HumanResourceMachine.Models;

namespace HumanResourceMachine.Profiles
{
    public class HumanProfile : Profile
    {
        public HumanProfile()
        {
            CreateMap<Human, HumanEntity>().ReverseMap();
        }
    }
}
