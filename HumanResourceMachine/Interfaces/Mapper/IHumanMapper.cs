using HumanResourceMachine.Entities;
using HumanResourceMachine.ViewModels;

namespace HumanResourceMachine.Interfaces.Mapper
{
    public interface IHumanMapper
    {
        Human MappingToHuman(HumanViewModel humanVM);
        HumanViewModel MappingToHumanVM(Human human);
    }
}
