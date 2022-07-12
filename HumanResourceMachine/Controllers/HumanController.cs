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
        public IEnumerable<HumanViewModel> GetAllHumans()
        {
            var humans = _service.GetAllHumans();
            var result = _mapper.Map<IEnumerable<HumanViewModel>>(humans);

            return result;
        }

        [HttpGet("{id}")]
        public HumanViewModel GetHumanById([FromRoute] int id)
        {
            var human = _service.GetHumanById(id);
            var result = _mapper.Map<HumanViewModel>(human);

            return result;
        }

        [HttpPost]
        public void AddHuman(HumanViewModel humanVM)
        {
            var human = _mapper.Map<Human>(humanVM);
            _service.AddHuman(human);
        }

        [HttpPut]
        public void UpdateHuman(HumanViewModel humanVM)
        {
            var human = _mapper.Map<Human>(humanVM);
            _service.UpdateHuman(human);
        }

        [HttpDelete("{id}")]
        public void DeleteHumanById([FromRoute] int id)
        {
            _service.DeleteHumanById(id);
        }
    }
}
