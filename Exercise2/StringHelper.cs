using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    public class StringHelper
    {
        public static string RepeatedInput(string input)
        {
            string repeated = "";
            for (int i = 0; i < 10; i++)
            {
                if (i < 9)
                    repeated += $"{i + 1}. {input}, ";
                else
                    repeated += $"{i + 1}. {input}.";
            }

            return repeated;
        }

        public static string[] SplitBySpaces(string input)
        {
            return input.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        }

        public static string? Get3rdWord(string input)
        {
            var words = SplitBySpaces(input);
            if (words.Length >= 3)
            {
                return words[2];
            }
            return null;
        }
    }
}
