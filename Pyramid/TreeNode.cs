using System;
using System.Collections.Generic;

namespace Pyramid
{
    public class TreeNode
    {
		public int Number { get; private set; }

        private TreeNode leftNode;

        private TreeNode rightNode;

        public TreeNode(int number, TreeNode left, TreeNode right)
        {
            if (number <= 0)
			{
				throw new ArgumentNullException("Cannot insert negative or 0");
			}

            leftNode = left;
            rightNode = right;

			Number = number;
        }

        public void AddChild(TreeNode left, TreeNode right)
        {
            if (left == null || right == null)
            {
                throw new ArgumentNullException("Cannot insert null");
            }

            leftNode = left;
            rightNode = right;
        }
    }
}
