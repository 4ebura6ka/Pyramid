using System;
using System.IO;
using System.Collections.Generic;

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

            List<int> nodes = new FileOperations().ReadFile(filePath);

            Tree tree = new Tree(nodes);
            tree.ConstructPaths();

            Console.WriteLine("Max sum: " + tree.MaxSum + "\nPath: " + tree.MaxSumPath);
        }
    }
}
