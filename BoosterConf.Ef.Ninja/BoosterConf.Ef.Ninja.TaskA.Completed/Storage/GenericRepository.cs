﻿using BoosterConf.Ef.Ninja.TaskA.Solved.Storage.Entities;

namespace BoosterConf.Ef.Ninja.TaskA.Solved.Storage
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
