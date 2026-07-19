using patient_vaccination_registry.Application.Models.Dtos;
using patient_vaccination_registry.Domain.Entities;
using patient_vaccination_registry.Infrastructure.Repositories;

namespace patient_vaccination_registry.Application.Services
{
    public class VaccineService
    {
        private readonly VaccineRepository _vaccineRepository;

        public VaccineService(VaccineRepository vaccineRepository)
        {
            _vaccineRepository = vaccineRepository;
        }

        public IEnumerable<Vaccine> GetAll()
        {
            return _vaccineRepository.GetAll();
        }

        public Vaccine? GetById(int id)
        {
            return _vaccineRepository.GetById(id);
        }

        public int Create(CreateVaccineDto request)
        {
            var vaccine = new Vaccine
            {
                Name = request.Name,
                Manufacturer = request.Manufacturer,
                Batch = request.Batch,
                RequiredDoses = request.RequiredDoses,
                IsActive = true
            };

            return _vaccineRepository.Add(vaccine);
        }

        public bool Update(int id, UpdateVaccineDto request)
        {
            var existing = _vaccineRepository.GetById(id);
            if (existing == null) return false;

            existing.Name = request.Name;
            existing.Manufacturer = request.Manufacturer;
            existing.Batch = request.Batch;
            existing.RequiredDoses = request.RequiredDoses;
            existing.IsActive = request.IsActive;

            _vaccineRepository.Update(existing);
            return true;
        }

        public bool Delete(int id)
        {
            var existing = _vaccineRepository.GetById(id);
            if (existing == null) return false;

            _vaccineRepository.Delete(id);
            return true;
        }
    }
}