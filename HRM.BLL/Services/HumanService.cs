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

        public async Task<IEnumerable<Human>> GetAllHumans(CancellationToken token)
        {
            var humans = await _repository.GetAllHumans(token);
            var result = _mapper.Map<IEnumerable<Human>>(humans);

            return result;
        }

        public async Task<Human> GetHumanById(int id, CancellationToken token)
        {
            var human = await _repository.GetHumanById(id, token);
            if (human is null)
            {
                throw new ArgumentNullException("Object doesn't exist.", nameof(human));
            }

            var result = _mapper.Map<Human>(human);

            return result;
        }

        public async Task AddHuman(Human human, CancellationToken token)
        {
            var humanEntity = _mapper.Map<HumanEntity>(human);
            await _repository.AddHuman(humanEntity, token);
        }

        public async Task UpdateHuman(Human human, CancellationToken token)
        {
            var humanEntity = _mapper.Map<HumanEntity>(human);
            await _repository.UpdateHuman(humanEntity, token);
        }

        public async Task DeleteHumanById(int id, CancellationToken token)
        {
            var target = await _repository.GetHumanById(id, token);
            if (target is null)
            {
                throw new ArgumentNullException("Object doesn't exist.", nameof(target));
            }

            await _repository.DeleteHumanById(id, token);
        }
    }
}
