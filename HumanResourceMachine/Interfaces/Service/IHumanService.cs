using HumanResourceMachine.Entities;

namespace HumanResourceMachine.Interfaces.Service
{
    public interface IHumanService
    {
        IEnumerable<HumanEntity> GetAllHumans();
        HumanEntity GetHumanById(int id);
        void AddHuman(HumanEntity human);
        void UpdateHuman(HumanEntity human);
        void DeleteHumanById(int id);
    }
}
