using patient_vaccination_registry.Application.Models.Dtos;
using patient_vaccination_registry.Infrastructure.Repositories;
using DomainApplication = patient_vaccination_registry.Domain.Entities.Application;

namespace patient_vaccination_registry.Application.Services
{
    public class ApplicationService
    {
        private readonly ApplicationRepository _applicationRepository;

        public ApplicationService(ApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public IEnumerable<DomainApplication> GetAll()
        {
            return _applicationRepository.GetAll();
        }

        public DomainApplication? GetById(int id)
        {
            return _applicationRepository.GetById(id);
        }

        public int Create(CreateApplicationDto request)
        {
            var application = new DomainApplication
            {
                PersonId = request.PersonId,
                VaccineId = request.VaccineId,
                DriveId = request.DriveId,
                ApplicationDate = request.ApplicationDate,
                DoseNumber = request.DoseNumber
            };

            return _applicationRepository.Add(application);
        }

        public bool Update(int id, UpdateApplicationDto request)
        {
            var existing = _applicationRepository.GetById(id);
            if (existing == null) return false;

            existing.PersonId = request.PersonId;
            existing.VaccineId = request.VaccineId;
            existing.DriveId = request.DriveId;
            existing.ApplicationDate = request.ApplicationDate;
            existing.DoseNumber = request.DoseNumber;

            _applicationRepository.Update(existing);
            return true;
        }

        public bool Delete(int id)
        {
            var existing = _applicationRepository.GetById(id);
            if (existing == null) return false;

            _applicationRepository.Delete(id);
            return true;
        }
    }
}