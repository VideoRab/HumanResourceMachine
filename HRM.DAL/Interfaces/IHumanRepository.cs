using HRM.DAL.Entities;

namespace HRM.DAL.Interfaces.Repository
{
    public interface IHumanRepository
    {
        Task<IEnumerable<HumanEntity>> GetAllHumans(CancellationToken token);
        Task<HumanEntity> GetHumanById(int id, CancellationToken token);
        Task AddHuman(HumanEntity human, CancellationToken token);
        Task UpdateHuman(HumanEntity human, CancellationToken token);
        Task DeleteHumanById(int id, CancellationToken token);
    }
}
