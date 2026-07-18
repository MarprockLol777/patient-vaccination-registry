namespace patient_vaccination_registry.API.Models.Entities
{
    public class Vaccine
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Manufacturer { get; set; }
        public string? Batch { get; set; }
        public int RequiredDoses { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
