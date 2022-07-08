using HumanResourceMachine.Entities;

namespace HumanResourceMachine.Interfaces
{
    public interface IBusinessLogicService
    {
        IEnumerable<Human> GetAllHumans();
        Human GetHumanById(int id);
        void AddHuman(Human human);
        void UpdateHuman(Human human);
        void DeleteHumanById(int id);
    }
}
