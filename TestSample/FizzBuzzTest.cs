using Samples;

namespace TestSamples
{
    public class FizzBuzzTest
    {
        [Fact]
        public void put_fizz_for_numbers_that_are_divided_to_3()
        {
            var expected = new List<string> { "1", "2", "Fizz" };
            var result = FizzBuzz.Generate(1, 3);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void put_buzz_for_numbers_that_are_divided_to_5()
        {
            var expected = new List<string> { "1", "2", "Fizz", "4", "Buzz" };
            var result = FizzBuzz.Generate(1, 5);
            Assert.Equal(expected, result);
        }
        [Fact]
        public void put_fizzbuzz_for_numbers_that_are_divided_to_3_and_5()
        {
            var expected = new List<string> { "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz" };
            var result = FizzBuzz.Generate(1, 15);
            Assert.Equal(expected, result);
        }
    }
}