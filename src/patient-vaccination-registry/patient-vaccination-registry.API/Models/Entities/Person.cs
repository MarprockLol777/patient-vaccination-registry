namespace patient_vaccination_registry.API.Models.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? IdNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
