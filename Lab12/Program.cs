using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] ReadFromFile(string filename)
            {
                try
                {
                    return File.ReadAllLines(filename);
                }
                catch (Exception ex)
                {
                    return new string[0];
                }
            }


            string[] textFile = ReadFromFile("input.txt");
            string text = textFile[0];

            string[] words = text.Split(new char[] { ' ', '.', ',' });

            int wordCount = words.Length;
            Console.WriteLine("Кількість слів у тексті: " + wordCount);

            Array.Sort(words);
            Console.WriteLine("Слова у тексті за абеткою:");
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
