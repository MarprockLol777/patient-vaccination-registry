namespace patient_vaccination_registry.Application.Models.Dtos
{
    public class UpdateApplicationDto
    {
        public int PersonId { get; set; }
        public int VaccineId { get; set; }
        public int DriveId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int DoseNumber { get; set; } = 0;
    }
}
