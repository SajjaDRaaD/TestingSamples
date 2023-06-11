using CodeSamples;
using Xunit.Sdk;

namespace TestSamples
{
    public class NinjaXmlSerializerTest
    {
        public class Order
        {
            public int Id { get; set; }
            public Customer Customer { get; set; }
        }
        public class Customer
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        [Fact]
        public void serialize_flat_object()
        {
            Customer customer = new Customer
            {
                FirstName = "Sajjad",
                LastName = "Raad"
            };

            var expected = "<Customer>" +
                           "<FirstName>Sajjad</FirstName>" +
                           "<LastName>Raad</LastName>" +
                           "</Customer>";

            var result = NinjaXmlSerializer.Serialize(customer);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void serialize_nested_object()
        {
            Order order = new Order
            {
                Id = 22,
                Customer = new Customer
                {
                    FirstName = "Sajjad",
                    LastName = "Raad"
                }
            };

            var expected = "<Order>" +
                           "<Id>22</Id>" +
                           "<Customer>" +
                           "<FirstName>Sajjad</FirstName>" +
                           "<LastName>Raad</LastName>" +
                           "</Customer>" +
                           "</Order>";
            var result = NinjaXmlSerializer.Serialize(order);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void throw_null_exception_when_input_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => NinjaXmlSerializer.Serialize(null));
        }
        
    }
}
