using patient_vaccination_registry.Domain.Entities;
using patient_vaccination_registry.Infrastructure.Context;
using patient_vaccination_registry.Infrastructure.Core;

namespace patient_vaccination_registry.Infrastructure.Repositories
{
    public class PersonRepository : GenericRepository<Person>
    {
        public PersonRepository(DataContext context) : base(context)
        {
        }
    }
}
