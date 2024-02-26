using BoosterConf.Ef.Ninja.TaskB.Solved.Storage.Contexts;
using BoosterConf.Ef.Ninja.TaskB.Solved.Storage.Entities;

namespace BoosterConf.Ef.Ninja.TaskB.Solved.Storage
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
