using CustomersTable.Data.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [NotMapped]
        public bool Checked { get; set; }

        [NotMapped] 
        public bool IsValid => Validate();

        private bool Validate()
        {
            var context = new ValidationContext(this);
            var results = new List<ValidationResult>();
            return Validator.TryValidateObject(this, context, results, true);
        }


        public static int CalculateAge(DateTime birthDate)
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
