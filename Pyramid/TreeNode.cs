using System;
using System.Collections.Generic;

namespace Pyramid
{
    public class TreeNode
    {
		public int Number { private set; get; }

		private bool hasParent;

		private List<TreeNode> children;

        public TreeNode(int number)
        {
            if (number == null)
			{
				throw new ArgumentNullException("Cannot insert null");
			}

			Number = number;
			this.children = new List<TreeNode>();
        }

        public void AddChild(TreeNode node)
		{
            if (node == null)
			{
				throw new ArgumentNullException("Cannot insert null");
			}

			node.hasParent = true;
			children.Add(node);
		}

        public TreeNode GetChild(int index)
		{
			return children[index];
		}
        
    }
}
