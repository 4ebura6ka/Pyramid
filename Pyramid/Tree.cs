using System;

namespace Pyramid
{
    public class Tree
    {
        private TreeNode treeNode;

        public Tree()
        {
        }

        public TreeNode CreateTree(int[] nodes, int ndx, int jump, int length, int sum)
        {
            int leftChildIndex = ndx + jump;
            int rightChildIndex = leftChildIndex + 1;
            TreeNode leftChild = null;
            TreeNode rightChild = null;

            sum += nodes[ndx];

            if (rightChildIndex <= length)
            {
                Console.Write(nodes[ndx] + "->");

                if (nodes[ndx] % 2 == 0)
                {
                    if (nodes[leftChildIndex] % 2 != 0)
                    {
                        leftChild = CreateTree(nodes, leftChildIndex, jump + 1, length, sum);
                    }

                    if (nodes[rightChildIndex] % 2 != 0)
                    {
                        rightChild = CreateTree(nodes, rightChildIndex, jump + 1, length, sum);
                    }
                }
                else
                {
                    if (nodes[leftChildIndex] % 2 == 0)
                    {
                        leftChild = CreateTree(nodes, leftChildIndex, jump + 1, length, sum);
                    }

                    if (nodes[rightChildIndex] % 2 == 0)
                    {
                        rightChild = CreateTree(nodes, rightChildIndex, jump + 1, length, sum);
                    }
                }

                treeNode = new TreeNode(nodes[ndx], leftChild, rightChild);
            }
            else
            {
                treeNode = new TreeNode(nodes[ndx], null, null);

                Console.WriteLine(nodes[ndx]);
                Console.WriteLine("Tree sum: " + sum);
            }

            return treeNode;
        }
    }
}
