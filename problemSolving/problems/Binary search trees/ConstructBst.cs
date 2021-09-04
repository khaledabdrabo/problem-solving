using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems
{
	public class BST
	{
		public int value;
		public BST left;
		public BST right;

		public BST(int value)
		{
			this.value = value;
		}

		public BST Insert(int value)
		{
            if (value > this.value)
				right = new BST(value);
			else
				left = new BST(value);

			return this;
		}

		public bool Contains(int value)
		{
			return CheckIfExisted(this, value);
		}

        private bool CheckIfExisted(BST bST, int value)
        {
			if (bST.value==value)
				return true;
			else if (bST.value > value)
				CheckIfExisted(bST.left, value);
			else if (bST.value > value)
				CheckIfExisted(bST.right, value);

			return false;
        }
		private BST GetItemAndRemove(BST bST, int value)
		{
			if (bST.value == value)
            {
				bST = bST.right;
				return bST;
			}
			else if (bST.value > value)
				CheckIfExisted(bST.left, value);
			else if (bST.value > value)
				CheckIfExisted(bST.right, value);

			return bST;
		}

		public BST Remove(int value)
		{
			GetItemAndRemove(this, value);
			return this;
		}
	}
	public static class ConstructBst
    {
		public static BST CreateBst()
        {
			var bst=new BST(10);
			bst = bst.Insert(12);
			bst=bst.Insert(4);
			bst=bst.Insert(7);
			bst=bst.Insert(3);
			bst=bst.Insert(1);
			return bst;
        }
    }
}
