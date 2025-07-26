using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTool
{
         public class WordNode
        {
            public WordInfo Data;
            public WordNode Next;

            public WordNode(WordInfo data)
            {
                Data = data;
                Next = null;
            }
        }

    
}
