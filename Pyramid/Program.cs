using System;
using System.IO;

namespace Pyramid
{
    class MainClass
    {
        private const string PATH = "/Users/serz/Projects/Pyramid/Pyramid/sample2.txt";

        private static TreeNode treeNode;

        private static int height;

        public static void Main(string[] args)
        {
            if (!File.Exists(PATH))
            {
                throw new FileNotFoundException("Data file not found");
            }

            int[] integerNodes = new int[100000];

            int i = 0;

            height = 0;

            using (StreamReader fileStream = File.OpenText(PATH))
            {

                while (!fileStream.EndOfStream)
                {
                    string data = fileStream.ReadLine();
                    string[] nodes = data.Split(' ');

                    height++;

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

            Console.WriteLine();

            TreeNode tn = CreateTree(integerNodes, 1, 1, i);
        }

        public static TreeNode CreateTree(int[] nodes, int ndx, int jump, int length)
        {
            if (ndx + jump + 1 <= length)
            {
                Console.Write("Node: " + nodes[ndx] + " ");
                Console.Write("Children 1: " + nodes[ndx + jump] + " ");
                Console.Write("Children 2: " + nodes[ndx + jump + 1]);

                Console.WriteLine();

                treeNode = new TreeNode(nodes[ndx], CreateTree(nodes, ndx + jump, jump + 1, length), CreateTree(nodes, ndx + jump + 1, jump + 1, length));
            }
            else
            {
                treeNode = new TreeNode(nodes[ndx], null, null);

                Console.WriteLine("NO CHILDREN: " + nodes[ndx]);
            }

            return treeNode;
        }
    }
}
