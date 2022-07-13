using HRM.BLL.Models;

namespace HRM.BLL.Interfaces
{
    public interface IHumanService
    {
        Task<IEnumerable<Human>> GetAllHumans(CancellationToken token);
        Task<Human> GetHumanById(int id);
        Task AddHuman(Human human, CancellationToken token);
        Task UpdateHuman(Human human, CancellationToken token);
        Task DeleteHumanById(int id, CancellationToken token);
    }
}
