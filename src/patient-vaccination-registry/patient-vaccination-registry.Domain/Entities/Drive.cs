using patient_vaccination_registry.Domain.Core;

namespace patient_vaccination_registry.Domain.Entities
{
    public class Drive : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string? Location { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
