using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class StringCalculator
    {
        private const string Separator = ",";

        public static decimal Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers)) return 0;

            var fixedNumbers = FixSeparator(numbers);
            var numbersArray = fixedNumbers.Split(Separator);

            DetectNegatives(numbersArray);

            if (numbersArray.Length == 1) return int.Parse(numbersArray[0]);

            if (numbersArray.Length > 1)
            {
                decimal sum = 0;
                foreach (var number in numbersArray)
                {
                    int numberInt = int.Parse(number);
                    if (numberInt < 1000)
                        sum += numberInt;
                }

                return sum;
            }

            return 0;
        }

        private static void DetectNegatives(string[] numbersArray)
        {
            List<string> invalidValues = new List<string>();

            foreach (string number in numbersArray)
            {
                if (number.StartsWith("-"))
                    invalidValues.Add(number);
            }

            if (invalidValues.Count > 0)
                throw new ArgumentException($"Negative values are disallowed: {string.Join(Separator, invalidValues)}");
        }

        private static string FixSeparator(string numbers)
        {
            string separatorToReplace = "\n";
            if (numbers.StartsWith("//"))
            {
                separatorToReplace = numbers.Substring(2, numbers.IndexOf('\n')-2);
                numbers = numbers.Substring(numbers.IndexOf('\n')+1);
            }
            return numbers.Replace(separatorToReplace, Separator);
        }
    }
}
