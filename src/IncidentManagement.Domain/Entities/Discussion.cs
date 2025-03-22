using System;

namespace IncidentManagement.Domain.Entities
{
    public class Discussion
    {
        public int Id { get; set; }
        public int IncidentId { get; set; }
        public string Comment { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public Incident Incident { get; set; }
    }
}