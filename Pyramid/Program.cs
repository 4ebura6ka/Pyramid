using System;
using System.IO;

namespace Pyramid
{
    class MainClass
    {
        private const string PATH = "/Users/serz/Projects/Pyramid/Pyramid/sample.txt";
        public static void Main(string[] args)
        {
            Console.WriteLine("Initial commit");

            if (!File.Exists(PATH))
            {
                throw new FileNotFoundException("Data file not found");
            }

            using (StreamReader fileStream = File.OpenText(PATH))
            {
                while (!fileStream.EndOfStream)
                {
                    string data = fileStream.ReadLine();
                    string[] nodes = data.Split(' ');

                    foreach (var node in nodes)
                    {
                        Console.Write(node);
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
