namespace patient_vaccination_registry.API.Models.Dtos
{
    public class CreateVaccineDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Manufacturer { get; set; }
        public string? Batch { get; set; }
        public int RequiredDoses { get; set; }
    }
}
