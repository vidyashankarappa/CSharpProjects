namespace TextTool
{
    public class WordLinkedList
    {
        private WordNode head;

        public void AddOrUpdate(string word, int lineNumber)
        {
            WordNode current = head;
            WordNode prev = null;

            while (current != null)
            {
                if (current.Data.Word == word)
                {
                    current.Data.Increment(lineNumber);
                    return;
                }
                prev = current;
                current = current.Next;
            }

            WordNode newNode = new WordNode(new WordInfo(word, lineNumber));
            if (head == null)
                head = newNode;
            else
                prev.Next = newNode;
        }

        public void DisplayAllWords()
        {
            WordNode current = head;
            while (current != null)
            {
                Console.WriteLine($"{current.Data.Word} ({current.Data.Count})");
                current = current.Next;
            }
        }
        public int GetUniqueWordCount()
        {
            int count = 0;
            WordNode current = head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }

        public void DisplayWordsAlphabetically(bool ascending = true)
        {
            WordNode[] nodes = ToArray();
            Array.Sort(nodes, (a, b) => ascending ?
                string.Compare(a.Data.Word, b.Data.Word) :
                string.Compare(b.Data.Word, a.Data.Word));

            foreach (var node in nodes)
                Console.WriteLine($"{node.Data.Word} ({node.Data.Count})");
        }

        public void DisplayLongestWord()
        {
            WordNode current = head;
            string longest = "";
            int count = 0;

            while (current != null)
            {
                if (current.Data.Word.Length > longest.Length)
                {
                    longest = current.Data.Word;
                    count = current.Data.Count;
                }
                current = current.Next;
            }

            Console.WriteLine($"Longest word: {longest} ({count} times)");
        }


        public void DisplayMostFrequentWord()
        {
            WordNode current = head;
            string frequent = "";
            int max = 0;

            while (current != null)
            {
                if (current.Data.Count > max)
                {
                    max = current.Data.Count;
                    frequent = current.Data.Word;
                }
                current = current.Next;
            }

            Console.WriteLine($"Most frequent word: {frequent} ({max} times)");
        }
        public void DisplayLineNumbers(string word)
        {
            WordNode current = head;
            while (current != null)
            {
                if (current.Data.Word == word)
                {
                    Console.WriteLine($"'{word}' found on lines: ");
                    foreach (int line in current.Data.LineNumbers)
                        Console.Write(line + " ");

                    Console.WriteLine();
                    return;
                }
                current = current.Next;
            }

            Console.WriteLine($"'{word}' not found.");
        }

        public void DisplayFrequency(string word)
        {
            WordNode current = head;
            while (current != null)
            {
                if (current.Data.Word == word)
                {
                    Console.WriteLine($"'{word}' appears {current.Data.Count} times.");
                    return;
                }
                current = current.Next;
            }
            Console.WriteLine($"'{word}' not found.");
        }

        private WordNode[] ToArray()
        {
            List<WordNode> list = new List<WordNode>();
            WordNode current = head;
            while (current != null)
            {
                list.Add(current);
                current = current.Next;
            }
            return list.ToArray();
        }
    }
}
