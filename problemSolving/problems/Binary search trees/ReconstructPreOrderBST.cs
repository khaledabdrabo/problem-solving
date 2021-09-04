using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems
{
    public class ReconstructPreOrderBST
    {
		public class BST
		{
			public int value;
			public BST left = null;
			public BST right = null;

			public BST(int value)
			{
				this.value = value;
			}
		}


		public static BST ReconstructBst(List<int> preOrderTraversalValues)
		{
			if (preOrderTraversalValues.Count == 0) return null;
			int rootValue = preOrderTraversalValues[0];
			int i = 1;
			while (i< preOrderTraversalValues.Count && preOrderTraversalValues[i] < rootValue )
			{
				i++;
			}
			BST left = ReconstructBst(preOrderTraversalValues.GetRange(1, i-1));
			BST right=ReconstructBst(preOrderTraversalValues.GetRange(i,preOrderTraversalValues.Count-i));

			BST root=new BST(rootValue);
			root.left=left;
			root.right=right;

			return root;
		}
	}
}
