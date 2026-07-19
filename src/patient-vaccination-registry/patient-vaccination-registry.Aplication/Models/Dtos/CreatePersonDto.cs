namespace patient_vaccination_registry.Application.Models.Dtos
{
    public class CreatePersonDto
    {
        public string Name { get; set; } = string.Empty;
        public string? IdNumber { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
