namespace HRM.DAL.Entities
{
    public class CompanyEntity
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public List<HumanEntity> Employees { get; set; }
    }
}
