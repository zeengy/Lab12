using System;

namespace Lab12
{
    internal class Program
    {
        static string[] ReadFromFile(string filename)
        {
            try
            {
                string text = System.IO.File.ReadAllText(filename);
                int wordCount = CountWords(text);

                string[] words = new string[wordCount];
                int wordIndex = 0;
                int startIndex = 0;

                for (int i = 0; i <= text.Length; i++)
                {
                    if (i == text.Length || text[i] == ' ' || text[i] == '.' || text[i] == ',')
                    {
                        int length = i - startIndex;
                        words[wordIndex++] = text.Substring(startIndex, length);
                        startIndex = i + 1;
                    }
                }

                return words;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
                return new string[0];
            }
        }

        static int CountWords(string text)
        {
            int count = 0;
            bool inWord = false;

            foreach (char c in text)
            {
                if (char.IsWhiteSpace(c) || c == '.' || c == ',')
                {
                    if (inWord)
                    {
                        count++;
                        inWord = false;
                    }
                }
                else
                {
                    if (!inWord)
                    {
                        inWord = true;
                    }
                }
            }

            if (inWord)
            {
                count++;
            }

            return count;
        }

        static void Main(string[] args)
        {
            string[] words = ReadFromFile("input.txt");

            Console.WriteLine("Кількість слів у тексті: " + words.Length);

            Array.Sort(words);
            Console.WriteLine("Слова у тексті за абеткою:");
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}

