namespace Domain.Employee;

public class Employee
{
    public int EmployeeID { get; set; }
    public int PersonID { get; set; }
    public Person Person { get; set; }
    public int DepartmentID { get; set; }
    public Department Department { get; set; }
    public string Position { get; set; }
    public DateTime HireDate { get; set; }
    public decimal Salary { get; set; }
    public string Status { get; set; }

    public List<SalaryIncrease> SalaryHistory { get; set; }
    public string EmergencyContactName { get; set; }
    public string EmergencyContactPhone { get; set; }
    public string SocialSecurityNumber { get; set; }
    public string HealthInsuranceProvider { get; set; }
    public string HealthInsurancePolicyNumber { get; set; }

    public List<AccessLog> AccessLogs { get; set; }
}
