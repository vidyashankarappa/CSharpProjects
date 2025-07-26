using System;
using System.IO;
using System.Text.RegularExpressions;

namespace TextTool
{
    class Program
    {
        static string fileName = "mobydick.txt"; 
        static string[] linesInFile;
        static WordLinkedList wordList = new WordLinkedList();

        static void Main(string[] args)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"File not found: {fileName}");
                return;
            }

            readDisplayFileWords();

            Console.WriteLine($"\n{fileName} processed successfully.\n");

            while (true)
            {
                Console.WriteLine("\nChoose an option (or type 'exit' to quit):");
                Console.WriteLine("1. Display Total Unique Words");
                Console.WriteLine("2. Display All Words and their Occurrences");
                Console.WriteLine("3. Display All Words and their Occurrences (Sorted)");
                Console.WriteLine("4. Display Longest Word and its Occurrence");
                Console.WriteLine("5. Display Most Frequent Word and its Occurrence");
                Console.WriteLine("6. Display Line Numbers for a Word");
                Console.WriteLine("7. Display Frequency of a Word");

                string choice = Console.ReadLine()?.ToLower();

                if (choice == "exit")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                switch (choice)
                {
                    case "1":
                      
                        int uniqueWordCount = wordList.GetUniqueWordCount();
                        Console.WriteLine("Total Unique Words: " + uniqueWordCount);
                        break;
                    case "2":
                        Console.WriteLine("\nAll Words and their Occurrences:");
                        wordList.DisplayAllWords();  
                        break;
                    case "3":
                        Console.WriteLine("\nAll Words and their Occurrences (Sorted Alphabetically):");
                        wordList.DisplayWordsAlphabetically();
                        break;
                    case "4":
                        wordList.DisplayLongestWord();
                        break;
                    case "5":
                        wordList.DisplayMostFrequentWord();
                        break;
                    case "6":
                        Console.Write("Enter a word to display its line numbers: ");
                        string wordForLineNumbers = Console.ReadLine()?.ToLower();
                        wordList.DisplayLineNumbers(wordForLineNumbers);
                        break;
                    case "7":
                        Console.Write("Enter a word to display its frequency: ");
                        string wordForFrequency = Console.ReadLine()?.ToLower();
                        wordList.DisplayFrequency(wordForFrequency);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void readDisplayFileWords()
        {
            linesInFile = File.ReadAllLines(fileName);
            int lineNumber = 0;
            char[] delimiters = { ' ', ',', '"', ':', ';', '?', '!', '-', '.', '\'', '*' };

            foreach (string line in linesInFile)
            {
                lineNumber++;
                string[] wordsInLine = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in wordsInLine)
                {
                    string cleaned = word.ToLower();
                    if (isWord(cleaned))
                    {
                        wordList.AddOrUpdate(cleaned, lineNumber);
                    }
                }
            }
        }

        static bool isWord(string str)
        {
            return Regex.IsMatch(str, @"\b(?:[a-z]{2,}|[ai])\b", RegexOptions.IgnoreCase);
        }
    }
}
