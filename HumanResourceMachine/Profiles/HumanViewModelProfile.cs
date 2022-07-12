using AutoMapper;
using HRM.BLL.Models;
using HumanResourceMachine.ViewModels;

namespace HumanResourceMachine.Profiles
{
    public class HumanViewModelProfile : Profile
    {
        public HumanViewModelProfile()
        {
            CreateMap<Human, HumanViewModel>().ReverseMap();
        }
    }
}
