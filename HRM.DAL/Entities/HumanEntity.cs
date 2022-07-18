using System.ComponentModel.DataAnnotations.Schema;

namespace HRM.DAL.Entities
{
    public class HumanEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int CompanyId { get; set; }
    }
}
