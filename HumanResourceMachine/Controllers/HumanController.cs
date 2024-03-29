﻿using AutoMapper;
using HRM.BLL.Interfaces;
using HRM.BLL.Models;
using HumanResourceMachine.ViewModels;

namespace HumanResourceMachine.Controllers
{
    public class HumanController : GenericController<HumanViewModel, Human>
    {
        public HumanController(IGenericService<Human> service, IMapper mapper) : base(service, mapper)
        {

        }
    }
}
