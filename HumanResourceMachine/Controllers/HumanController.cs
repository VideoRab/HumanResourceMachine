using System.Net;
using HumanResourceMachine.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HumanResourceMachine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanController : ControllerBase
    {
        // Temporary database
        private static List<Human> people = new List<Human>()
        {
            new Human
            {
                Id = 1,
                Name = "Ilya",
                Surname = "Safonov",
                Patronymic = "Alexandrovich"
            },
            new Human
            {
                Id = 2,
                Name = "SomeName",
                Surname = "SomeSurname",
                Patronymic = "SomePatronymic"
            }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(people);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Human result = people.Find(h => h.Id == id);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(Human human)
        {
            people.Add(human);

            return Ok(people);
        }

        [HttpPut]
        public IActionResult Put(Human request)
        {
            Human human = people.Find(h => h.Id == request.Id);
            human.Name = request.Name;
            human.Surname = request.Surname;
            human.Patronymic = request.Patronymic;

            return Ok(people);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Human target = people.Find(h => h.Id == id);
            people.Remove(target);

            return Ok(people);
        }
    }
}
