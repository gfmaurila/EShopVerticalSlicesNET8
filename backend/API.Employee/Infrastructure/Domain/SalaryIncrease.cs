namespace API.Employee.Infrastructure.Domain;

public class SalaryIncrease
{
    public int SalaryIncreaseID { get; set; }
    public int EmployeeID { get; set; }
    public DateTime IncreaseDate { get; set; }
    public decimal Amount { get; set; }
    public string Reason { get; set; }
}
