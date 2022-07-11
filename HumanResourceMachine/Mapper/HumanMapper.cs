using HumanResourceMachine.Entities;
using HumanResourceMachine.Interfaces.Mapper;
using HumanResourceMachine.ViewModels;

namespace HumanResourceMachine.Mapper
{
    public class HumanMapper : IHumanMapper
    {
        public Human MappingToHuman(HumanViewModel humanVM)
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

        public HumanViewModel MappingToHumanVM(Human human)
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
    }
}
