using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestTaskCleverens
{
    internal class Task3
    {
        public static string Normalize(string level)
        {
            string upper = level.ToUpper();

            if (upper == "INFORMATION" || upper == "INFO")
                return "INFO";
            else if (upper == "WARNING" || upper == "WARN")
                return "WARN";
            else if (upper == "ERROR")
                return "ERROR";
            else if (upper == "DEBUG")
                return "DEBUG";
            else
                return "UNKNOWN";
        }

        public static void Start()
        {
            string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
            string outputPath = "output.txt";
            string problemsPath = "problems.txt";

            var format1Regex = new Regex(@"^(\d{2}\.\d{2}\.\d{4}) (\d{2}:\d{2}:\d{2}\.\d+)\s+(\w+)\s+(.*)$");
            var format2Regex = new Regex(@"^(\d{4}-\d{2}-\d{2}) (\d{2}:\d{2}:\d{2}\.\d+)\| (\w+)\|\d+\|([^\|]+)\|\s+(.*)$");

            var reader = new StreamReader(inputPath);
            var writer = new StreamWriter(outputPath);
            var problems = new StreamWriter(problemsPath);

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;

                Match match1 = format1Regex.Match(line);
                Match match2 = format2Regex.Match(line);

                if (match1.Success)
                {
                    try
                    {
                        string date = DateTime.ParseExact(match1.Groups[1].Value, "dd.MM.yyyy", null).ToString("yyyy-MM-dd");
                        string time = match1.Groups[2].Value;
                        string level = Normalize(match1.Groups[3].Value);
                        string method = "DEFAULT";
                        string message = match1.Groups[4].Value;

                        writer.WriteLine($"{date}\t{time}\t{level}\t{method}\t{message}");
                    }
                    catch
                    {
                        problems.WriteLine(line);
                    }
                }
                else if (match2.Success)
                {
                    try
                    {
                        string date = match2.Groups[1].Value;
                        string time = match2.Groups[2].Value;
                        string level = Normalize(match2.Groups[3].Value);
                        string method = match2.Groups[4].Value.Trim();
                        string message = match2.Groups[5].Value;

                        writer.WriteLine($"{date}\t{time}\t{level}\t{method}\t{message}");
                    }
                    catch
                    {
                        problems.WriteLine(line);
                    }
                }
                else
                {
                    problems.WriteLine(line);
                }
            }

            Console.WriteLine("Обработка завершена.");

            writer.Flush();
            writer.Close();

            problems.Flush();
            problems.Close();

            reader.Close();
        }
    }
}
