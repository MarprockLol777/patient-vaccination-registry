using patient_vaccination_registry.Domain.Core;

namespace patient_vaccination_registry.Domain.Entities
{
    public class Vaccine : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Manufacturer { get; set; }
        public string? Batch { get; set; }
        public int RequiredDoses { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
