using System.Linq.Expressions;
using TelemetryPortal_MVC.Data;

namespace TelemetryPortal_MVC.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly TechtrendsContext _context;

        public GenericRepository(TechtrendsContext context)
        {
            _context = context;

        }

        // Adds a single entity to the database.
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        // Adds multiple entities to the database at once.
        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        // Finds entities that match a specific condition.
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        // Retrieves all entities from the database.
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        // Retrieves an entity by its ID.
        public T GetByID(int id)
        {
            return _context.Set<T>().Find(id);
        }

        // Removes a single entity from the database.
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        // Removes multiple entities from the database at once.
        public void RemoveRange(IEnumerable<T> entities)
        {  
            _context.Set<T>().RemoveRange(entities); 
        }


        // Updates an existing entity in the database.
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

    }

    /*
       public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly Techtrends2Context _context;

        public GenericRepository(Techtrends2Context context)
        {
            _context = context;
        }

        public T GetByID(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).ToList();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            _context.SaveChanges();
        }
    }
}
     */
}
