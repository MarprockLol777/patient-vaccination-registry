using patient_vaccination_registry.Domain.Entities;
using patient_vaccination_registry.Infrastructure.Context;
using patient_vaccination_registry.Infrastructure.Core;
using Application = patient_vaccination_registry.Domain.Entities.Application;

namespace patient_vaccination_registry.Infrastructure.Repositories
{
    public class ApplicationRepository : GenericRepository<Application>
    {
        public ApplicationRepository(DataContext context) : base(context)
        {
        }
    }
}