using patient_vaccination_registry.Domain.Core;
using patient_vaccination_registry.Infrastructure.Context;


namespace patient_vaccination_registry.Infrastructure.Core
{
    public class GenericRepository<T> where T : BaseEntity
    {
        private readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T? GetById(int id)
        {
            return _context.Set<T>().FirstOrDefault(e => e.Id == id);
        }

        public int Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return;
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}