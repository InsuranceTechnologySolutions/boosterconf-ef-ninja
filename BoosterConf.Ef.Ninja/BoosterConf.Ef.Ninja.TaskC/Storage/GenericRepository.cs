﻿using BoosterConf.Ef.Ninja.TaskC.Storage.Entities;

namespace BoosterConf.Ef.Ninja.TaskC.Storage
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