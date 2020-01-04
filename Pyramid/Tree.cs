using System;
using System.Collections.Generic;

namespace Pyramid
{
    public class Tree
    {
        private List<List<int>> pyramid;

        private TreeNode node;

        public TreeNode Root { get; private set; }

        public int Height { get; private set; }

        public string MaxSumPath { get; private set; }

        public int MaxSum { get; private set; }

        public Tree(List<List<int>> pyramid, int height)
        {
            MaxSumPath = string.Empty;
            MaxSum = 0;

            Height = height;
            this.pyramid = pyramid;

            if (height < 1)
            {
                throw new ArgumentOutOfRangeException("Tree at least should contain a root");
            }
        }

        public void CalculatePath()
        {
            List<int> sumsInCurrentRow = new List<int>(pyramid[Height - 1]);

            for (var row = Height - 1; row > 0; row --)
            {
                List<int> sumsInNextRow = new List<int>();

                foreach (var s in sumsInCurrentRow)
                {
                    Console.Write(s + " ");
                }
                Console.WriteLine();

                List<int> children = pyramid[row];
                int rowSize = pyramid[row - 1].Count;

                for (var i = 0; i < rowSize; i++)
                {
                    int parent = pyramid[row - 1][i];
                    int leftChild = children[i];
                    int rightChild = children[i + 1];

                    int leftChildSum = 0;
                    int rightChildSum = 0;

                    if (parent % 2 == 0 ^ leftChild % 2 == 0)
                    {
                        leftChildSum = sumsInCurrentRow[i] + parent;
                    }

                    if (parent % 2 == 0 ^ rightChild % 2 == 0)
                    {
                        rightChildSum = sumsInCurrentRow[i + 1] + parent;
                    }

                    sumsInNextRow.Add(Math.Max(leftChildSum, rightChildSum));
                }

                sumsInCurrentRow = new List<int>(sumsInNextRow);
            }
        }
    }
}
