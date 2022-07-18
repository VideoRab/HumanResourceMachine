using AutoMapper;
using HRM.BLL.Models;
using HRM.DAL.Entities;

namespace HRM.BLL.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyEntity>().ReverseMap();
        }
    }
}
