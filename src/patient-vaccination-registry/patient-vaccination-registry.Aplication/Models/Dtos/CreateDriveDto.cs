namespace patient_vaccination_registry.Application.Models.Dtos
{
    public class CreateDriveDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string? Location { get; set; }
        public bool IsActive { get; set; }
    }
}
