using HRM.BLL.Entities;

namespace HRM.BLL.Interfaces.Repository
{
    public interface IHumanRepository
    {
        IEnumerable<HumanEntity> GetAllHumans();
        HumanEntity GetHumanById(int id);
        void AddHuman(HumanEntity human);
        void UpdateHuman(HumanEntity human);
        void DeleteHumanById(int id);
    }
}
