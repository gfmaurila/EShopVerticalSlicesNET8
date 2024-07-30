namespace API.Employee.Infrastructure.Domain;

public class AccessLog
{
    public int AccessLogID { get; set; }
    public int EmployeeID { get; set; }
    public DateTime AccessTime { get; set; }
    public string AccessType { get; set; }
}
