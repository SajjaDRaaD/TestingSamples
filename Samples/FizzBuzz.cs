using System.Transactions;

namespace Samples
{
    public class FizzBuzz
    {
        public static List<string> Generate(int start , int end)
        {
            var result = new List<string>();
            for (int i = start; i <= end; i++)
            {


                if(i % 3 == 0 && i % 5 == 0)
                {
                    result.Add("FizzBuzz");
                }
                else if (i % 5 == 0)
                {
                    result.Add("Buzz");
                }
                else if (i % 3 == 0)
                {
                    result.Add("Fizz");
                }else
                {
                    result.Add(i.ToString());
                }
            }

            return result;
        }
    }
}