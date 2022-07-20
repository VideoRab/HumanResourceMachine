using System.ComponentModel.DataAnnotations.Schema;

namespace HRM.DAL.Entities
{
    public class CompanyEntity
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        [ForeignKey("CompanyId")]
        public List<HumanEntity> Employees { get; set; }
    }
}
