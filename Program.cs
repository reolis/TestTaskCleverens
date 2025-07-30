using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskCleverens
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задание 1
            Console.WriteLine("Задание 1:");

            string original = "aaabbcccdde";
            string compressed = Task1.Compress(original);
            string decompressed = Task1.Decompress(compressed);

            Console.WriteLine($"Исходная строка: {original}");
            Console.WriteLine($"Сжатая строка: {compressed}");
            Console.WriteLine($"Восстановленная строка: {decompressed}");

            Console.WriteLine("=========================================");

            // Задание 2
            Console.WriteLine("Задание 2:");

            Parallel.Invoke(
                () => Task2.Server.ReadLoop("Reader1"),
                () => Task2.Server.ReadLoop("Reader2"),
                () => Task2.Server.WriteLoop("Writer"));

            Console.WriteLine("Готово");

            Console.WriteLine("=========================================");

            // Задание 3
            Console.WriteLine("Задание 3:");

            Task3.Start();
        }
    }
}
