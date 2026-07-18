using patient_vaccination_registry.Domain.Entities;
using patient_vaccination_registry.Infrastructure.Context;
using patient_vaccination_registry.Infrastructure.Core;

namespace patient_vaccination_registry.Infrastructure.Repositories
{
    public class VaccineRepository : GenericRepository<Vaccine>
    {
        public VaccineRepository(DataContext context) : base(context)
        {
        }
    }
}