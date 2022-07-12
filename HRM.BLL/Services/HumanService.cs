using AutoMapper;
using HRM.DAL.Entities;
using HRM.BLL.Interfaces;
using HRM.DAL.Interfaces.Repository;
using HRM.BLL.Models;

namespace HRM.BLL.Services
{
    public class HumanService : IHumanService
    {
        private readonly IHumanRepository _repository;
        private readonly IMapper _mapper;

        public HumanService(IHumanRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<Human> GetAllHumans()
        {
            var humans = _repository.GetAllHumans();
            var result = _mapper.Map<IEnumerable<Human>>(humans);

            return result;
        }

        public Human GetHumanById(int id)
        {
            var human = _repository.GetHumanById(id);
            if (human is null)
            {
                throw new ArgumentNullException("Object doesn't exist.", nameof(human));
            }

            var result = _mapper.Map<Human>(human);

            return result;
        }

        public void AddHuman(Human human)
        {
            var humanEntity = _mapper.Map<HumanEntity>(human);
            _repository.AddHuman(humanEntity);
        }

        public void UpdateHuman(Human human)
        {
            var humanEntity = _mapper.Map<HumanEntity>(human);
            _repository.UpdateHuman(humanEntity);
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
