using HumanResourceMachine.Entities;
using HumanResourceMachine.Interfaces.Repository;
using HumanResourceMachine.Interfaces.Service;

namespace HumanResourceMachine.Services
{
    public class HumanService : IHumanService
    {
        private readonly IHumanRepository _repository;

        public HumanService(IHumanRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Human> GetAllHumans()
        {
            return _repository.GetAllHumans();
        }

        public Human GetHumanById(int id)
        {
            return _repository.GetHumanById(id);
        }

        public void AddHuman(Human human)
        {
            _repository.AddHuman(human);
        }

        public void UpdateHuman(Human human)
        {
            _repository.UpdateHuman(human);
        }

        public void DeleteHumanById(int id)
        {
            _repository.DeleteHumanById(id);
        }
    }
}
