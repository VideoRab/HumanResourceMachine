using AutoMapper;
using HRM.BLL.Interfaces;
using HRM.BLL.Models;
using HumanResourceMachine.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HumanResourceMachine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanController : ControllerBase
    {
        private readonly IHumanService _service;
        private readonly IMapper _mapper;

        public HumanController(IHumanService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<HumanViewModel>> GetAllHumans(CancellationToken token)
        {
            var humans = await _service.GetAllHumans(token);
            var result = _mapper.Map<IEnumerable<HumanViewModel>>(humans);

            return result;
        }

        [HttpGet("{id}")]
        public async Task<HumanViewModel> GetHumanById([FromRoute] int id, CancellationToken token)
        {
            var human = await _service.GetHumanById(id, token);
            var result = _mapper.Map<HumanViewModel>(human);

            return result;
        }

        [HttpPost]
        public async Task AddHuman(HumanViewModel humanVM, CancellationToken token)
        {
            var human = _mapper.Map<Human>(humanVM);
            await _service.AddHuman(human, token);
        }

        [HttpPut]
        public async Task UpdateHuman(HumanViewModel humanVM, CancellationToken token)
        {
            var human = _mapper.Map<Human>(humanVM);
            await _service.UpdateHuman(human, token);
        }

        [HttpDelete("{id}")]
        public async Task DeleteHumanById([FromRoute] int id, CancellationToken token)
        {
            await _service.DeleteHumanById(id, token);
        }
    }
}
