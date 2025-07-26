using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace TextTool
{
    public class WordInfo
    {
        public string Word { get; set; }
        public int Count { get; set; }
        public List<int> LineNumbers = new List<int>();

        public WordInfo(string word, int lineNumber)
        {
            Word = word;
            Count = 1;
            AddLineNumber(lineNumber);
        }

        public void Increment(int lineNumber)
        {
            Count++;
            AddLineNumber(lineNumber);
        }

        private void AddLineNumber(int lineNumber)
        {
            if (!LineNumbers.Contains(lineNumber))
                LineNumbers.Add(lineNumber);
        }
    }



}
