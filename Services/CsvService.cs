using CsvHelper.Configuration;
using CsvHelper;
using CustomersTable.Data;
using Microsoft.AspNetCore.Components.Forms;
using static MudBlazor.CategoryTypes;
using System.Globalization;
using MudBlazor;
using System.Text;
using CustomersTable.Data.Interfaces;

namespace CustomersTable.Services
{
    public class CsvService : ICsvService
    {
        public async Task<List<Customer>> GetCustomersFromCsv(InputFileChangeEventArgs e)
        {
            var file = e.File;
            if (file is null)
            {
                return new List<Customer>();
            }
            using (var stream = file.OpenReadStream())
            using (var memoryStream = new MemoryStream())
            {
                await stream.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                using (var reader = new StreamReader(memoryStream))
                {
                    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null,
                        MissingFieldFound = null
                    };

                    using (var csv = new CsvReader(reader, config))
                    {
                        csv.Context.RegisterClassMap<CustomerMap>();
                        var records = await csv.GetRecordsAsync<Customer>().ToListAsync();
                        if (records.Any(c => !c.IsValid))
                            throw new Exception("Not all customers are valid in csv");
                        foreach (var r in records)
                        {
                            r.Id = 0;
                        }
                        return records;
                    }
                }
            }
        }

        public async Task<string> GetCsvFromCustomerList(List<Customer> customerList)
        {
            using (var stringWriter = new StringWriter())
            using (var csvWriter = new CsvWriter(stringWriter, CultureInfo.InvariantCulture))
            {
                csvWriter.Context.RegisterClassMap<CustomerMap>();

                await csvWriter.WriteRecordsAsync(customerList);
                return stringWriter.ToString();
            }
        }
    }
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Map(m => m.FirstName).Name("First Name");
            Map(m => m.LastName).Name("Last Name");
            Map(m => m.StreetName).Name("Street");
            Map(m => m.HouseNumber).Name("House No.");
            Map(m => m.AppartmentNumber).Name("Appartment No.");
            Map(m => m.PostalCode).Name("Postal Code");
            Map(m => m.Town).Name("City");
            Map(m => m.PhoneNumber).Name("Phone No.");

            Map(m => m.BirthDate).Name("Birth Date").TypeConverterOption.Format("dd.MM.yyyy");
        }
    }
}
