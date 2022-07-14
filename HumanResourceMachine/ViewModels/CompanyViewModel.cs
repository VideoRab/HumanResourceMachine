using HRM.BLL.Models;

namespace HumanResourceMachine.ViewModels
{
    public class CompanyViewModel
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public List<HumanViewModel> Employees { get; set; }
    }
}
