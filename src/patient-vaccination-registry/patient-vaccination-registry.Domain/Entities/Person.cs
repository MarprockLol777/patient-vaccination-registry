using patient_vaccination_registry.Domain.Core;

namespace patient_vaccination_registry.Domain.Entities
{
    public class Person : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? IdNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
