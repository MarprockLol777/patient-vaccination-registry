namespace patient_vaccination_registry.API.Models.Entities
{
    public class Drive
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string? Location { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
