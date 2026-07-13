
namespace ExtraStuff;

public class Customer
{

    // backing field
    private string firstName = "";

    private string someVariable;

    // constructors cannot be asynchronous
    public Customer()
    {
        someVariable = "";
    }
    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string LastName { get; set; } = "";

    public string FullName
    {
        get
        {
            return $"{FirstName} {LastName}";
        }
    }

    public string? PhoneNumber { get; set; }
    public string Department { get; private set; } = "";

    public void SetDepartment(string department)
    {
        if (department == "DEV")
        {
            throw new ArgumentOutOfRangeException("Too many developers already");
        }
        Department = department;
    }
    public override string ToString()
    {
        return FullName;
    }

    public static async Task<Customer> LoadByIdAsync(string id)
    {

        return new Customer();
    }

    public IList<PurchaseRecord> GetPurchaseHistory()
    {
       
        return [
            new PurchaseRecord("Shampoo", 3.29M),
            new PurchaseRecord("Beer",  7.99M),
            

            ];
    }


}


//public record PurchaseRecord
//{
//    public required string Sku { get; init; } = string.Empty;
//    public required decimal Cost { get; init; }
//}
public record PurchaseRecord(string Sku, decimal Cost);


public record Pet 
{
    public required string Name { get; init; } = string.Empty;
    public required string Breed { get; init; } = string.Empty;
    public required int Age { get; init; }

}

public struct Point
{
    public int X { get; set; }
    public int Y { get; set; }
}