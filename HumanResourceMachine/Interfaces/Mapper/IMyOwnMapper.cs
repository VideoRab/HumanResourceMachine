using HumanResourceMachine.Entities;
using HumanResourceMachine.ViewModels;

namespace HumanResourceMachine.Interfaces.Mapper
{
    public interface IMyOwnMapper
    {
        public Human MappingToHuman(HumanViewModel humanVM);
        public HumanViewModel MappingToHumanVM(Human human);
    }
}
