namespace HRM.BLL.Interfaces
{
    public interface IGenericService<TModel>
        where TModel : class
    {
        Task<IEnumerable<TModel>> GetAll(CancellationToken token);
        Task<TModel> GetById(int id, CancellationToken token);
        Task Add(TModel tModel, CancellationToken token);
        Task Update(TModel tModel, CancellationToken token);
        Task DeleteById(int id, CancellationToken token);
    }
}
