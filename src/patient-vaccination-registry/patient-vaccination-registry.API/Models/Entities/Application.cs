namespace patient_vaccination_registry.API.Models.Entities
{
    public class Application
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int VaccineId { get; set; }
        public int DriveId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int DoseNumber { get; set; }
    }
}
