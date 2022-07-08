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
            var human = _repository.GetHumanById(id);
            if (human is null)
            {
                throw new ArgumentNullException("Object doesn't exist.", nameof(human));
            }

            return human;
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
            var target = _repository.GetHumanById(id);
            if (target is null)
            {
                throw new ArgumentNullException("Object doesn't exist.", nameof(target));
            }

            _repository.DeleteHumanById(id);
        }
    }
}
