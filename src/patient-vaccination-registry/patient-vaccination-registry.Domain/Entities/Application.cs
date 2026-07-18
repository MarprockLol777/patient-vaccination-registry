using patient_vaccination_registry.Domain.Core;

namespace patient_vaccination_registry.Domain.Entities
{
    public class Application : BaseEntity
    {
        public int PersonId { get; set; }
        public int VaccineId { get; set; }
        public int DriveId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int DoseNumber { get; set; }
    }
}
