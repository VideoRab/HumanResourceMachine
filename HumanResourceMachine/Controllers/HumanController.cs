﻿using HumanResourceMachine.Entities;
using HumanResourceMachine.Interfaces.Mapper;
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
        private readonly IMyOwnMapper _mapper;

        public HumanController(IHumanService service, IMyOwnMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<HumanViewModel> GetAllHumans()
        {
            var humans = _service.GetAllHumans();
            foreach (var human in humans)
            {
                yield return _mapper.MappingToHumanVM(human);
            }
        }

        [HttpGet("{id}")]
        public HumanViewModel GetHumanById([FromRoute] int id)
        {
            var human = _service.GetHumanById(id);
            var result = _mapper.MappingToHumanVM(human);

            return result;
        }

        [HttpPost]
        public void AddHuman(HumanViewModel humanVM)
        {
            var human = _mapper.MappingToHuman(humanVM);
            _service.AddHuman(human);
        }

        [HttpPut]
        public void UpdateHuman(HumanViewModel humanVM)
        {
            var human = _mapper.MappingToHuman(humanVM);
            _service.UpdateHuman(human);
        }

        [HttpDelete("{id}")]
        public void DeleteHumanById([FromRoute] int id)
        {
            _service.DeleteHumanById(id);
        }
    }
}
