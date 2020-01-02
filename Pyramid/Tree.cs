using System;
using System.Collections.Generic;

namespace Pyramid
{
    public class Tree
    {
        private TreeNode treeNode;

        private List<int> nodes;

        private int length;

        public string MaxSumPath { get; private set; }

        public int MaxSum { get; private set; }

        public Tree(List<int> nodes)
        {
            MaxSumPath = string.Empty;
            MaxSum = 0;
            length = nodes.Count;
            this.nodes = nodes;
        }

        public void ConstructPaths()
        {
            ConstructPaths(0, 1, 0, string.Empty);
        }

        private TreeNode ConstructPaths(int ndx, int jump, int sum, string path)
        {
            int leftChildIndex = ndx + jump;
            int rightChildIndex = leftChildIndex + 1;

            TreeNode leftChild = null;
            TreeNode rightChild = null;

            sum += nodes[ndx];

            if (rightChildIndex <= length)
            {

                bool leftChildIsEven = nodes[leftChildIndex] % 2 != 0;
                bool rightChildIsEven = nodes[rightChildIndex] % 2 != 0;

                path += nodes[ndx] + ", ";

                if (nodes[ndx] % 2 == 0)
                {
                    if (leftChildIsEven)
                    {
                        leftChild = ConstructPaths(leftChildIndex, jump + 1, sum, path);
                    }

                    if (rightChildIsEven)
                    {
                        rightChild = ConstructPaths(rightChildIndex, jump + 1, sum, path);
                    }
                }
                else
                {
                    if (!leftChildIsEven)
                    {
                        leftChild = ConstructPaths(leftChildIndex, jump + 1, sum, path);
                    }

                    if (!rightChildIsEven)
                    {
                        rightChild = ConstructPaths(rightChildIndex, jump + 1, sum, path);
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
            }

            return treeNode;
        }
    }
}
