using SimpleDnDTurnTracker.Data.Entities;

namespace SimpleDnDTurnTracker.Data.Repositories
{
    public interface IRepository<T>
    {
        public Task<T> Add(T entity);
        public Task<Boolean> Remove(Guid id);
        public Task<T?> Get(Guid id);
        public Task<List<T>> GetAll();
        public Task<IQueryable<T>> GetAllQueryable();
        public Task<T?> Update(T entity);
    }
}
