using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskCleverens
{
    internal class Task1
    {
        public static string Compress(string input)
        {
            if (string.IsNullOrEmpty(input)) return "";

            StringBuilder builder = new StringBuilder();

            char currentChar = input[0];
            int count = 1;

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == currentChar)
                {
                    count++;
                }
                else
                {
                    builder.Append(currentChar);
                    if (count > 1)
                    {
                        builder.Append(count.ToString());
                        currentChar = input[i];
                        count = 1;
                    }
                }
            }

            builder.Append(currentChar);
            if (count > 1) builder.Append(count.ToString());

            return builder.ToString();
        }

        public static string Decompress(string input)
        {
            if (string.IsNullOrEmpty(input)) return "";

            StringBuilder builder = new StringBuilder();
            int i = 0;

            while (i < input.Length)
            {
                char currentChar = input[i];
                i++;
                int count = 0;

                while (i < input.Length && char.IsDigit(input[i]))
                {
                    count = count * 10 + (input[i] - '0');
                    i++;
                }

                if (count == 0) count = 1;

                builder.Append(new string(currentChar, count));
            }

            return builder.ToString();
        }
    }
}
