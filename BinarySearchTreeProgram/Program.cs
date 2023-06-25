﻿namespace BinarySearchTreeProgram
{
	public class BST
	{
		public class Node
		{
			public int val { get; set; }
			public Node? left { get; set; }
			public Node? right { get; set; }

            public Node(int val)
            {
                this.val = val;
				left = right = null;
            }
        }
		public Node? root;

        public BST()
        {
            root = null;
        }

		public void Insert(int val)
		{
			root = InsertHelper(root, val);
		}

		private Node InsertHelper(Node? root, int val)
		{
			if (root is null)
				root = new Node(val);
			else if (val < root.val)
				root.left = InsertHelper(root.left, val);
			else if (val > root.val)
				root.right = InsertHelper(root.right, val);

			return root;
		}

		public void InOrderTraversal()
		{
			InOrderHelper(root);
		}

		private void InOrderHelper(Node? root)
		{
			if (root is null)
				return;

			InOrderHelper(root.left);
            Console.Write(root.val + " ");
			InOrderHelper(root.right);
        }
	}
	internal class Program
	{
		static void Main(string[] args)
		{
			BST t = new();
			t.Insert(2);
			t.Insert(1);
			t.Insert(3);
			t.InOrderTraversal();
        }
	}
}