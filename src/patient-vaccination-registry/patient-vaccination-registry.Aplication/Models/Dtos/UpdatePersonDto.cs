namespace patient_vaccination_registry.Application.Models.Dtos
{
    public class UpdatePersonDto
    {
        public string Name { get; set; } = string.Empty;
        public string? IdNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsActive { get; set; }
    }
}
