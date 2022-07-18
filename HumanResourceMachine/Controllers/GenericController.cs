using AutoMapper;
using HRM.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourceMachine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<TViewModel, TModel> : ControllerBase
        where TViewModel : class
        where TModel : class
    {
        private readonly IGenericService<TModel> _service;
        private readonly IMapper _mapper;

        public GenericController(IGenericService<TModel> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TViewModel>> GetAll(CancellationToken token)
        {
            var tModels = await _service.GetAll(token);
            var result = _mapper.Map<IEnumerable<TViewModel>>(tModels);

            return result;
        }

        [HttpGet("{id}")]
        public async Task<TViewModel> GetById([FromRoute] int id, CancellationToken token)
        {
            var tModel = await _service.GetById(id, token);
            var result = _mapper.Map<TViewModel>(tModel);

            return result;
        }

        [HttpPost]
        public async Task Add(TViewModel tViewModel, CancellationToken token)
        {
            var tModel = _mapper.Map<TModel>(tViewModel);
            await _service.Add(tModel, token);
        }

        [HttpPut]
        public async Task Update(TViewModel tViewModel, CancellationToken token)
        {
            var tModel = _mapper.Map<TModel>(tViewModel);
            await _service.Update(tModel, token);
        }

        [HttpDelete("{id}")]
        public async Task DeleteById([FromRoute] int id, CancellationToken token)
        {
            await _service.DeleteById(id, token);
        }
    }
}
