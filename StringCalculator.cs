using System.Linq;
using System;

namespace stringcalculator
{
    internal class StringCalculator
    {
        public StringCalculator()
        {
        }

        internal int Add(string? csvListOfInts)
        {
            if (String.IsNullOrWhiteSpace(csvListOfInts))
            {
                return 0;
            }
            else
            {
                var listOfIntStrings = csvListOfInts
                    .Replace('\n',',')
                    .Split(',')
                    .ToList();

                int sum = 0;
                foreach (var intString in listOfIntStrings)
                {
                    int integerNumber;
                    var isSuccessfullyParsed = int.TryParse(intString, out integerNumber);
                    if (isSuccessfullyParsed == false)
                    {
                        throw new ApplicationException("This is not a valid input. CSV lists of integers only.");
                    }
                    sum = sum + integerNumber;
                }
                return sum;
            }
        }
    }
}