using BoosterConf.Ef.Ninja.TaskOne.Completed.Storage.Entities;

namespace BoosterConf.Ef.Ninja.TaskOne.Completed.Storage
{
    public interface IGenericRepository<TEntity> where TEntity : class, IEntity   
    {
        IQueryable<TEntity> GetAll();        
    }

    public class GenericRepository<TEntity>(InsuranceDbContext dbContext) : IGenericRepository<TEntity>
        where TEntity : class, IEntity
    {
        public IQueryable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>();
        }
    }
}
