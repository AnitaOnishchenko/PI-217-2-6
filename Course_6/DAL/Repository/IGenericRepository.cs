using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DAL.Repository
{
    /// <summary>
    /// The Repository mediates between the domain and data mapping layers, acting like an in-memory collection of domain objects
    /// </summary>
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Adds <see cref="TEntity"/> item to the corresponding <see cref="DbContext"/>
        /// </summary>
        /// <param name="item"><see cref="TEntity"/> item to add</param>
        void Create(TEntity item);

        /// <summary>
        /// Finds <see cref="TEntity"/> item in the corresponding <see cref="DbSet"/> by its id
        /// </summary>
        /// <param name="id">Id of object</param>
        /// <returns><see cref="TEntity"/> object</returns>
        TEntity FindById(int id);

        /// <summary>
        /// Gets all objects from the corresponding <see cref="DbContext"/>
        /// </summary>
        /// <returns>All <see cref="TEntity"/> objects 
        /// from corresponding <see cref="DbContext"/></returns>
        IEnumerable<TEntity> Get();

        /// <summary>
        /// Gets all objects by predicate from the corresponding <see cref="DbContext"/>
        /// </summary>
        /// <returns>All founded <see cref="TEntity"/> objects 
        /// from corresponding <see cref="DbContext"/></returns>
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);

        /// <summary>
        /// Gets first corresponding object by predicate from the corresponding <see cref="DbContext"/>
        /// </summary>
        /// <returns>Founded <see cref="TEntity"/> object 
        /// from corresponding <see cref="DbContext"/></returns>
        TEntity GetOne(Func<TEntity, bool> predicate);

        /// <summary>
        /// Removes <see cref="TEntity"/> item from the corresponding <see cref="DbContext"/>
        /// </summary>
        /// <param name="item"><see cref="TEntity"/> item to remove</param>
        void Remove(TEntity item);

        /// <summary>
        /// Updates <see cref="TEntity"/> item in the corresponding <see cref="DbContext"/>
        /// </summary>
        /// <param name="item"><see cref="TEntity"/> item to update</param>
        void Update(TEntity item);
    }
}
