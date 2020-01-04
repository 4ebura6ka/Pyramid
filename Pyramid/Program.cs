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

            FileOperations fileOperations = new FileOperations();
            List<List<int>> pyramid = fileOperations.ReadFile(filePath);

            PyramidComputations pyramidComputatons = new PyramidComputations(pyramid, fileOperations.FileLinesCount);
            pyramidComputatons.CalculateMaxSumAndPath();

            Console.WriteLine("Max sum: " + pyramidComputatons.MaxSum + "\nPath: " + pyramidComputatons.MaxSumPath);
        }
    }
}
