namespace HRM.DAL.Interfaces
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll(CancellationToken token);
        Task<TEntity> GetById(int id, CancellationToken token);
        Task Add(TEntity tEntity, CancellationToken token);
        Task Update(TEntity tEntity, CancellationToken token);
        Task DeleteById(int id, CancellationToken token);
    }
}
