using System;
using System.Collections.Generic;

namespace Pyramid
{
    public class Tree
    {
        private TreeNode treeNode;

        public string MaxSumPath { get; private set; }

        public int MaxSum { get; private set; }

        public Tree()
        {
            MaxSumPath = string.Empty;
            MaxSum = 0;
        }

        public TreeNode CreateTree(List<int> nodes, int ndx, int jump, int length, int sum, string path)
        {
            int leftChildIndex = ndx + jump;
            int rightChildIndex = leftChildIndex + 1;

            TreeNode leftChild = null;
            TreeNode rightChild = null;

            sum += nodes[ndx];

            if (rightChildIndex <= length)
            {
                path += nodes[ndx] + ", ";

                if (nodes[ndx] % 2 == 0)
                {
                    if (nodes[leftChildIndex] % 2 != 0)
                    {
                        leftChild = CreateTree(nodes, leftChildIndex, jump + 1, length, sum, path);
                    }

                    if (nodes[rightChildIndex] % 2 != 0)
                    {
                        rightChild = CreateTree(nodes, rightChildIndex, jump + 1, length, sum, path);
                    }
                }
                else
                {
                    if (nodes[leftChildIndex] % 2 == 0)
                    {
                        leftChild = CreateTree(nodes, leftChildIndex, jump + 1, length, sum, path);
                    }

                    if (nodes[rightChildIndex] % 2 == 0)
                    {
                        rightChild = CreateTree(nodes, rightChildIndex, jump + 1, length, sum, path);
                    }
                }

                treeNode = new TreeNode(nodes[ndx], leftChild, rightChild);
            }
            else
            {
                path += nodes[ndx];
                treeNode = new TreeNode(nodes[ndx], null, null);

                if (sum > MaxSum)
                {
                    MaxSumPath = path;
                    MaxSum = sum;
                }

#if DEBUG
                Console.WriteLine("Tree sum: " + sum);
                Console.WriteLine(path);
#endif
            }

            return treeNode;
        }
    }
}
