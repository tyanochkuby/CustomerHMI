using CustomersTable.Data.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CustomersTable.Data
{
    public class Customer
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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

        [JsonIgnore]
        public int Age { get; set; }

        [JsonIgnore]
        public bool Checked { get; set; }

        [JsonIgnore]
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

        public async Task SetAddressByPostalCode(string postalCode)
        {
            var context = new ValidationContext(this);
            var results = new List<ValidationResult>();
            
            var client = new HttpClient();
            var response = await client.GetAsync($"https://kodpocztowy.intami.pl/api/{postalCode}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                using (JsonDocument document = JsonDocument.Parse(content))
                {
                    JsonElement root = document.RootElement;

                    if (root.ValueKind == JsonValueKind.Array && root.GetArrayLength() > 0)
                    {
                        JsonElement firstObject = root[0];

                        if (firstObject.TryGetProperty("miejscowosc", out JsonElement miejscowoscElement))
                        {
                            string miejscowosc = miejscowoscElement.GetString();
                            if(!string.IsNullOrEmpty(miejscowosc))
                            {
                                Town = miejscowosc;
                            }
                        }
                        if (firstObject.TryGetProperty("ulica", out JsonElement ulicaElement))
                        {
                            string ulica = ulicaElement.GetString();
                            if (!string.IsNullOrEmpty(ulica))
                            {
                                StreetName = ulica;
                            }
                        }
                    }
                }
            }
            
        }

        public Customer Clone()
        {
            return new Customer
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                StreetName = this.StreetName,
                HouseNumber = this.HouseNumber,
                AppartmentNumber = this.AppartmentNumber,
                PostalCode = this.PostalCode,
                Town = this.Town,
                PhoneNumber = this.PhoneNumber,
                BirthDate = this.BirthDate,
                Age = this.Age,
                Checked = this.Checked
            };
        }

    }
}
