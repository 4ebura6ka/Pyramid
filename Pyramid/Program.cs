using System;
using System.IO;

namespace Pyramid
{
    class MainClass
    {
        private const string PATH = "/Users/serz/Projects/Pyramid/Pyramid/sample2.txt";

        public static void Main(string[] args)
        {
            if (!File.Exists(PATH))
            {
                throw new FileNotFoundException("Data file not found");
            }

            int[] integerNodes = new int[100000];

            int length = 0;

            using (StreamReader fileStream = File.OpenText(PATH))
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

            TreeNode tn = new Tree().CreateTree(integerNodes, 1, 1, length, 0);
        }
    }
}
