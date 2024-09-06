using CustomersTable.Data.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CustomersTable.Data
{
    public class Customer
    {
        public Customer()
        {
            Id = Guid.NewGuid();
            FirstName = string.Empty;
            LastName = string.Empty;
            StreetName = string.Empty;
            HouseNumber = string.Empty;
            AppartmentNumber = string.Empty;
            PostalCode = string.Empty;
            Town = string.Empty;
            PhoneNumber = string.Empty;
            BirthDate = new DateTime();
            Age = CalculateAge(BirthDate);
        }

        [Key]
        public Guid Id { get; set; }

        [PolishAlphabet]
        public required string FirstName { get; set; }

        [PolishAlphabet]
        public required string LastName { get; set; }

        [PolishAlphanumeric]
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

        public required DateTime BirthDate { get; set; }

        public int Age { get; set; }

        private int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            int age = today.Year - birthDate.Year;

            if (today < birthDate.AddYears(age))
            {
                age--;
            }

            return age;
        }
    }
}
