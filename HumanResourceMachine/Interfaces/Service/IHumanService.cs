using HumanResourceMachine.Models;

namespace HumanResourceMachine.Interfaces.Service
{
    public interface IHumanService
    {
        IEnumerable<Human> GetAllHumans();
        Human GetHumanById(int id);
        void AddHuman(Human human);
        void UpdateHuman(Human human);
        void DeleteHumanById(int id);
    }
}
