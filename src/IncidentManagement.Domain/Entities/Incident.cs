using IncidentManagement.Domain.Enums;

namespace IncidentManagement.Domain.Entities
{
    public class Incident
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public IncidentStatus Status { get; set; }
        public int? Priority { get; set; }

        public ICollection<Discussion> Discussions { get; set; }
    }
}