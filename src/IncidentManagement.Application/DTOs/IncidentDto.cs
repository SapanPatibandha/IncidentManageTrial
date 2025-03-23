using IncidentManagement.Domain.Enums;

public class IncidentDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IncidentStatus Status { get; set; }
    public DateTime CreatedDate { get; set; }
}