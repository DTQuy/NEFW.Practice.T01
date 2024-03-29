using NEFW.Practice.T01.Core.Entity;

public class EmployeeProject
{
    public int EmployeeId { get; set; }
    public required Employee Employee { get; set; }

    public int ProjectId { get; set; }
    public required Project Project { get; set; }
}