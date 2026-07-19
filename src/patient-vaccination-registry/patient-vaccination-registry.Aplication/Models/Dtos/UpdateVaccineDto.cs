namespace patient_vaccination_registry.Application.Models.Dtos
{
    public class UpdateVaccineDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Manufacturer { get; set; }
        public string? Batch { get; set; }
        public int RequiredDoses { get; set; }
        public bool IsActive { get; set; }
    }
}
