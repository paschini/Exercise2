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
            StringBuilder repeated = new();
            for (int i = 0; i < 10; i++)
            {
                if (i < 9)
                    repeated.Append($"{i + 1}. {input}, ");
                else
                    repeated.Append($"{i + 1}. {input}.");
            }

            return repeated.ToString();
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
