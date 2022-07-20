using AutoMapper;
using HRM.BLL.Interfaces;
using HRM.DAL.Interfaces;

namespace HRM.BLL.Services
{
    public class GenericService<TModel, TEntity> : IGenericService<TModel>
        where TModel : class
        where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public GenericService(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TModel>> GetAll(CancellationToken token)
        {
            var tEntities = await _repository.GetAll(token);
            var result = _mapper.Map<IEnumerable<TModel>>(tEntities);

            return result;
        }

        public async Task<TModel> GetById(int id, CancellationToken token)
        {
            var tEntity = await _repository.GetById(id, token);
            if (tEntity is null)
            {
                throw new ArgumentNullException("Object doesn't exist.", nameof(tEntity));
            }

            var result = _mapper.Map<TModel>(tEntity);

            return result;
        }

        public async Task Add(TModel tModel, CancellationToken token)
        {
            var tEntity = _mapper.Map<TEntity>(tModel);
            await _repository.Add(tEntity, token);
        }

        public async Task Update(TModel tModel, CancellationToken token)
        {
            var tEntity = _mapper.Map<TEntity>(tModel);
            await _repository.Update(tEntity, token);
        }

        public async Task DeleteById(int id, CancellationToken token)
        {
            var target = await _repository.GetById(id, token);
            if (target is null)
            {
                throw new ArgumentNullException("Object doesn't exist.", nameof(target));
            }

            await _repository.DeleteById(id, token);
        }
    }
}
