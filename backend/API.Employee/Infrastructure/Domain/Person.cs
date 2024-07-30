namespace API.Employee.Infrastructure.Domain;

public class Person
{
    public int PersonID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }

    public int AddressID { get; set; }
    public Address Address { get; set; }

    public int ContactID { get; set; }
    public Contact Contact { get; set; }
}
