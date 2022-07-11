using HumanResourceMachine.Entities;
using HumanResourceMachine.Interfaces.Service;
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

        public HumanController(IHumanService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<HumanViewModel> GetAllHumans()
        {
            var humans = _service.GetAllHumans();
            foreach (var human in humans)
            {
                yield return MappingToHumanVM(human);
            }
        }

        [HttpGet("{id}")]
        public HumanViewModel GetHumanById([FromRoute] int id)
        {
            var human = _service.GetHumanById(id);
            var result = MappingToHumanVM(human);

            return result;
        }

        [HttpPost]
        public void AddHuman(HumanViewModel humanVM)
        {
            var human = MappingToHuman(humanVM);
            _service.AddHuman(human);
        }

        [HttpPut]
        public void UpdateHuman(HumanViewModel humanVM)
        {
            var human = MappingToHuman(humanVM);
            _service.UpdateHuman(human);
        }

        [HttpDelete("{id}")]
        public void DeleteHumanById([FromRoute] int id)
        {
            _service.DeleteHumanById(id);
        }

        private HumanViewModel MappingToHumanVM(Human human)
        {
            var result = new HumanViewModel()
            {
                Id = human.Id,
                Name = human.Name,
                Surname = human.Surname,
                Patronymic = human.Patronymic
            };

            return result;
        }

        private Human MappingToHuman(HumanViewModel humanVM)
        {
            var result = new Human()
            {
                Id = humanVM.Id,
                Name = humanVM.Name,
                Surname = humanVM.Surname,
                Patronymic = humanVM.Patronymic
            };

            return result;
        }
    }
}
