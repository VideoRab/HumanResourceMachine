namespace HRM.BLL.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public List<Human> Employees { get; set; }
    }
}
