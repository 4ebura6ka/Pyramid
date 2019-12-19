using System;
using System.IO;

namespace Pyramid
{
    class MainClass
    {
        private const string PATH = "/Users/serz/Projects/Pyramid/Pyramid/sample.txt";

        public static void Main(string[] args)
        {
            if (!File.Exists(PATH))
            {
                throw new FileNotFoundException("Data file not found");
            }

            int[] integerNodes = new int[100000];

            int i = 0;

            using (StreamReader fileStream = File.OpenText(PATH))
            {

                while (!fileStream.EndOfStream)
                {
                    string data = fileStream.ReadLine();
                    string[] nodes = data.Split(' ');

                    foreach (var node in nodes)
                    {
                        i++;
                        if (!int.TryParse(node, out integerNodes[i]))
                        {
                            throw new InvalidDataException("Issue with converting to integer");
                        }

                        Console.Write(node + " ");
                    }
                }
            }

            for (var h = 1; h <= i; h++ )
            {
                Console.Write(integerNodes[h] + " ");
            }

            Console.WriteLine();
        }

        public static void CreateTree (string[] nodes)
        {

        }
    }
}
