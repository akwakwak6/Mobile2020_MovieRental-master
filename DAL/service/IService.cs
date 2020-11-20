using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.service {
    public interface IService<TKey, TEntity>
        where TEntity : IEntity<TKey> {
        // Create
        TKey Insert(TEntity entity);

        // Read
        TEntity Get(TKey key);
        IEnumerable<TEntity> GetAll();

        // Update
        bool Update(TEntity entity);

        // Delete
        bool Delete(TKey key);

    }
}