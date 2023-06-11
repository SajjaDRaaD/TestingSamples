using CodeSamples;
using FluentAssertions;
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
        public void serializes_flat_object()
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
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void serializes_nested_object()
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
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void does_not_serialize_null_inputs()
        {
            Action serialization = () => NinjaXmlSerializer.Serialize(null);

            serialization.Should().Throw<ArgumentNullException>();
        }
        
    }
}
