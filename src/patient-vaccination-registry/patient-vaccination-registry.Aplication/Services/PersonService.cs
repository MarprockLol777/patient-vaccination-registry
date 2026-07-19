using patient_vaccination_registry.Application.Models.Dtos;
using patient_vaccination_registry.Domain.Entities;
using patient_vaccination_registry.Infrastructure.Repositories;

namespace patient_vaccination_registry.Application.Services
{
    public class PersonService
    {
        private readonly PersonRepository _personRepository;

        public PersonService(PersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public IEnumerable<Person> GetAll()
        {
            return _personRepository.GetAll();
        }

        public Person? GetById(int id)
        {
            return _personRepository.GetById(id);
        }

        public int Create(CreatePersonDto request)
        {
            var person = new Person
            {
                Name = request.Name,
                IdNumber = request.IdNumber,
                BirthDate = request.BirthDate,
                IsActive = true
            };

            return _personRepository.Add(person);
        }

        public bool Update(int id, UpdatePersonDto request)
        {
            var existing = _personRepository.GetById(id);
            if (existing == null) return false;

            existing.Name = request.Name;
            existing.IdNumber = request.IdNumber;
            existing.BirthDate = request.BirthDate;
            existing.IsActive = request.IsActive;

            _personRepository.Update(existing);
            return true;
        }

        public bool Delete(int id)
        {
            var existing = _personRepository.GetById(id);
            if (existing == null) return false;

            _personRepository.Delete(id);
            return true;
        }
    }
}