using System;
 
namespace Pyramid
{
    public class TreeNode
    {
		public int Number { get; private set; }

        public TreeNode LeftNode { get; private set; }

        public TreeNode RightNode { get; private set; }

        public TreeNode(int number, TreeNode leftNode, TreeNode rightNode)
        {
            if (number <= 0)
			{
				throw new ArgumentNullException("Cannot insert negative or 0");
			}

            LeftNode = leftNode;
            RightNode = rightNode;

			Number = number;
        }
    }
}
