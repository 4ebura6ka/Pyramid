using System;
using System.IO;

namespace Pyramid
{
    class MainClass
    {
        private static string filePath; 

        public static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                throw new ArgumentException("Path not specified");
            }

            filePath = args[0];

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Data file not found");
            }

            int[] integerNodes = new int[100000];

            int length = 0;

            using (StreamReader fileStream = File.OpenText(filePath))
            {

                while (!fileStream.EndOfStream)
                {
                    string data = fileStream.ReadLine();
                    string[] nodes = data.Split(' ');

                    foreach (var node in nodes)
                    {
                        length++;
                        if (!int.TryParse(node, out integerNodes[length]))
                        {
                            throw new InvalidDataException("Issue with converting to integer");
                        }
                    }
                }
            }

            Tree tree = new Tree();
            tree.CreateTree(integerNodes, 1, 1, length, 0, string.Empty);

            Console.WriteLine("Max sum: " + tree.MaxSum + "\nPath: " + tree.MaxSumPath);
        }
    }
}
