using patient_vaccination_registry.Application.Models.Dtos;
using patient_vaccination_registry.Domain.Entities;
using patient_vaccination_registry.Infrastructure.Repositories;

namespace patient_vaccination_registry.Application.Services
{
    public class DriveService
    {
        private readonly DriveRepository _driveRepository;

        public DriveService(DriveRepository driveRepository)
        {
            _driveRepository = driveRepository;
        }

        public IEnumerable<Drive> GetAll()
        {
            return _driveRepository.GetAll();
        }

        public Drive? GetById(int id)
        {
            return _driveRepository.GetById(id);
        }

        public int Create(CreateDriveDto request)
        {
            var drive = new Drive
            {
                Name = request.Name,
                Date = request.Date,
                Location = request.Location,
                IsActive = true
            };

            return _driveRepository.Add(drive);
        }

        public bool Update(int id, UpdateDriveDto request)
        {
            var existing = _driveRepository.GetById(id);
            if (existing == null) return false;

            existing.Name = request.Name;
            existing.Date = request.Date;
            existing.Location = request.Location;
            existing.IsActive = request.IsActive;

            _driveRepository.Update(existing);
            return true;
        }

        public bool Delete(int id)
        {
            var existing = _driveRepository.GetById(id);
            if (existing == null) return false;

            _driveRepository.Delete(id);
            return true;
        }
    }
}