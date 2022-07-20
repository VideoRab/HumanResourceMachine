using AutoMapper;
using HRM.BLL.Interfaces;
using HRM.BLL.Models;
using HumanResourceMachine.ViewModels;

namespace HumanResourceMachine.Controllers
{
    public class CompanyController : GenericController<CompanyViewModel, Company>
    {
        public CompanyController(IGenericService<Company> service, IMapper mapper) : base(service, mapper)
        {

        }
    }
}
