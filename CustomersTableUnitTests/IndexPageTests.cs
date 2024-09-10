using CustomersTable.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersTableUnitTests
{
    public class IndexPageTests
    {
        [Fact]
        public void CancelChanges_ShouldRevertCustomerListToOriginal()
        {
            // Arrange
            var page = new Index();
            var originalList = new List<Customer>
            {
                new Customer {  
                                FirstName = "Jan", 
                                LastName = "Kowalski",
                                StreetName = "Kwiatowa",
                                HouseNumber = "1",
                                PostalCode = "00-001",
                                Town = "Warszawa",
                                PhoneNumber = "123456789",
                                BirthDate = new DateTime(1990, 1, 1),
                                Age = 31
                }
            };
            
        }
    }
}
