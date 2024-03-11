namespace BoosterConf.Ef.Ninja.Api;

public class Claim
{
    public required Guid Id { get; set; }
    public required string Description { get; set; }
    public required DateTimeOffset Date { get; set; }
    public required ClaimStatus Status { get; set; }
    public required decimal Amount { get; set; }
}

public class ClaimStatus
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
}

public record Cover
{
    public required Guid Id { get; set; }
    public required CoverType Type { get; set; }
    public required DateTimeOffset StartDate { get; set; }
    public required DateTimeOffset EndDate { get; set; }
    public required decimal Premium { get; set; }
    public required Customer Customer { get; set; }
    public ICollection<Claim>? Claims { get; set; }
}

public class CoverType
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
}

public class Customer
{
    public Guid? Id { get; set; }
    public CustomerAddress? Address { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public ICollection<Cover>? Covers { get; set; }
}

public class CustomerAddress
{
    public required Guid Id { get; set; }
    public required string Street { get; set; }
    public required string City { get; set; }
    public required string PostalCode { get; set; }
    public required string Country { get; set; }
}
