namespace Project.Domain.Entities;

public class Customer
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; } = string.Empty;
    public string Surname { get; private set; } = string.Empty;
    public DateOnly DateOfBirth { get; private set; }
    public string Address { get; private set; } = string.Empty;
    public string PhoneNumber { get; private set; } = string.Empty;
    public string Iban { get; private set; } = string.Empty;
    public DateTime CreatedAtUtc { get; private set; }
    
    protected Customer()
    {
    }

    private Customer(
        string firstName,
        string surname,
        DateOnly dateOfBirth,
        string address,
        string phoneNumber,
        string iban)
    {
        Id = Guid.NewGuid();
        FirstName = firstName.Trim();
        Surname = surname.Trim();
        DateOfBirth = dateOfBirth;
        Address = address.Trim();
        PhoneNumber = phoneNumber.Trim();
        Iban = iban.Replace(" ", string.Empty).ToUpperInvariant();
        CreatedAtUtc = DateTime.UtcNow;
    }

    public static Customer Create(
        string firstName,
        string surname,
        DateOnly dateOfBirth,
        string address,
        string phoneNumber,
        string iban)
    {
        var customer = new Customer(firstName, surname, dateOfBirth, address, phoneNumber, iban);
        return customer;
    }

    public void UpdateAddress(string address)
    {
        Address = address.Trim();
    }

    public void UpdatePhoneNumber(string phoneNumber)
    {
        PhoneNumber = phoneNumber.Trim();
    }

    public void UpdateIban(string iban)
    {
        Iban = iban.ToUpperInvariant();
    }
}
