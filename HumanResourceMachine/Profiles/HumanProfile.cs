using AutoMapper;
using HumanResourceMachine.Entities;
using HumanResourceMachine.ViewModels;

namespace HumanResourceMachine.Profiles
{
    public class HumanProfile : Profile
    {
        public HumanProfile()
        {
            CreateMap<HumanEntity, HumanViewModel>().ReverseMap();
        }
    }
}
