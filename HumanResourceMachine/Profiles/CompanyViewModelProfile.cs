using AutoMapper;
using HRM.BLL.Models;
using HumanResourceMachine.ViewModels;

namespace HumanResourceMachine.Profiles
{
    public class CompanyViewModelProfile : Profile
    {
        public CompanyViewModelProfile()
        {
            CreateMap<CompanyViewModel, Company>().ReverseMap();
        }
    }
}
