using CustomersTable.Data.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CustomersTable.Data
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }

        [PolishAlphabet]
        public required string FirstName { get; set; }

        [PolishAlphabet]
        public required string LastName { get; set; }

        [PolishAlphabet]
        public required string StreetName { get; set; }

        [HouseNumber]
        public required string HouseNumber { get; set; }

        [AppartmentNumber]
        public string? AppartmentNumber { get; set; }

        [PostalCode]
        public required string PostalCode { get; set; }

        [PolishAlphabet]
        public required string Town { get; set; }

        [PhoneNumber]
        public required string PhoneNumber { get; set; }

        public DateOnly BirthDate { get; set; }

        public int Age { get; set; }
    }
}
