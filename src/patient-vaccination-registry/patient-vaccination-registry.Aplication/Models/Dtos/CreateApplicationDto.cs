namespace patient_vaccination_registry.Application.Models.Dtos
{
    public class CreateApplicationDto
    {
        public int PersonId { get; set; }
        public int VaccineId { get; set; }
        public int DriveId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int DoseNumber { get; set; }
    }
}
