using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.Migrations;

namespace DAL.Repository
{
    /// <summary>
    /// The Repository mediates between the domain and data mapping layers, acting like an in-memory collection of domain objects
    /// </summary>
    internal class AgencyRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// DbContext instance
        /// </summary>
        private readonly AgencyContext _context;

        /// <summary>
        /// DbSet represents the collection of all TEntity in the context
        /// </summary>
        private readonly DbSet<TEntity> _dataBaseSet;

        /// <summary>
        /// Creates instance of <see cref="AgencyRepository{TEntity}"/>
        /// </summary>
        /// <param name="context"></param>
        public AgencyRepository(AgencyContext context)
        {
            _context = context;
            _dataBaseSet = context.Set<TEntity>();
        }

        /// <summary>
        /// Adds <see cref="TEntity"/> item to the corresponding <see cref="DbContext"/>
        /// </summary>
        /// <param name="item"><see cref="TEntity"/> item to add</param>
        public void Create(TEntity item)
        {
            _dataBaseSet.Add(item);
        }

        /// <summary>
        /// Finds <see cref="TEntity"/> item in the corresponding <see cref="DbSet"/> by its id
        /// </summary>
        /// <param name="id">Id of object</param>
        /// <returns><see cref="TEntity"/> object</returns>
        public TEntity FindById(int id)
        {
            return _dataBaseSet.Find(id);
        }

        /// <summary>
        /// Gets all objects from the corresponding <see cref="DbContext"/>
        /// </summary>
        /// <returns>All <see cref="TEntity"/> objects 
        /// from corresponding <see cref="DbContext"/></returns>
        public IEnumerable<TEntity> Get()
        {
            return _dataBaseSet.AsNoTracking().ToList();
        }

        /// <summary>
        /// Gets all objects by predicate from the corresponding <see cref="DbContext"/>
        /// </summary>
        /// <returns>All founded <see cref="TEntity"/> objects 
        /// from corresponding <see cref="DbContext"/></returns>
        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dataBaseSet.AsNoTracking().Where(predicate).ToList();
        }

        /// <summary>
        /// Gets first corresponding object by predicate from the corresponding <see cref="DbContext"/>
        /// </summary>
        /// <returns>Founded <see cref="TEntity"/> object 
        /// from corresponding <see cref="DbContext"/></returns>
        public TEntity GetOne(Func<TEntity, bool> predicate)
        {
            return _dataBaseSet.AsNoTracking().Where(predicate).FirstOrDefault();
        }

        /// <summary>
        /// Removes <see cref="TEntity"/> item from the corresponding <see cref="DbContext"/>
        /// </summary>
        /// <param name="item"><see cref="TEntity"/> item to remove</param>
        public void Remove(TEntity item)
        {
            try
            {
                _dataBaseSet.Remove(item);
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Data cannot be removed. Removable item is null.");
            }
        }

        /// <summary>
        /// Updates <see cref="TEntity"/> item in the corresponding <see cref="DbContext"/>
        /// </summary>
        /// <param name="item"><see cref="TEntity"/> item to update</param>
        public void Update(TEntity item)
        {
            _context.Set<TEntity>().AddOrUpdate(item);
            _context.SaveChanges();
        }
    }
}
