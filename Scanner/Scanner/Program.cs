using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\HP\Desktop\Scanner\loop.txt");

            Tokenizer tokenizer = new Tokenizer();

            foreach (var item in tokenizer.Tokenize(text))
            {
                Console.WriteLine(item);
            }

        }
    }
}
