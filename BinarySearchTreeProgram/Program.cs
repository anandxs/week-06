using System.Threading.Channels;

namespace BinarySearchTreeProgram
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

		public void Insert(int val) => root = InsertHelper(root, val);
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

		public void Remove(int val)
		{
			root = RemoveHelper(root, val);
		}

		private Node? RemoveHelper(Node? root, int val)
		{
			if (root is null)
				return root;

			if (root.val > val)
				root.left = RemoveHelper(root.left, val);
			else if (root.val < val)
				root.right = RemoveHelper(root.right, val);
			else
			{
				if (root.left is null)
					return root.right;
				if (root.right is null)
					return root.left;

				root.val = MinValue(root.right);
				root.right = RemoveHelper(root.right, root.val);
			}

			return root;
		}

		private int MinValue(Node? root)
		{
			while (root.left is not null)
				root = root.left;

			return root.val;
		}

		public bool Contains(int val)
		{
			return ContainsHelper(root, val);
		}
		private bool ContainsHelper(Node? root, int val)
		{
			if (root is null)
				return false;

			if (root.val == val)
				return true;

			return ContainsHelper(root.left, val) || ContainsHelper(root.right, val);
		}

		public void InOrderTraversal() => InOrderHelper(root);
		private void InOrderHelper(Node? root)
		{
			if (root is null)
				return;

			InOrderHelper(root.left);
            Console.Write(root.val + " ");
			InOrderHelper(root.right);
        }

		public void PreOrderTraversal() => PreOrderHelper(root);
		private void PreOrderHelper(Node? root)
		{
			if (root is null)
				return;

            Console.Write(root.val + " ");
			PreOrderHelper(root.left);
			PreOrderHelper(root.right);
        }

		public void PostOrderTraversal() => PostOrderHelper(root);
		private void PostOrderHelper(Node? root)
		{
			if (root is null)
				return;

			PostOrderHelper(root.left);
			PostOrderHelper(root.right);
            Console.Write(root.val + " ");
        }

		public void LevelOrderTraversal() => LevelOrderHelper(root);
		private void LevelOrderHelper(Node? root)
		{
			if (root is null)
				return;

			Queue<Node> q = new();
			q.Enqueue(root);

			while (q.Count is not 0)
			{
				var node = q.Dequeue();

				if (node.left is not null)
					q.Enqueue(node.left);

				if (node.right is not null)
					q.Enqueue(node.right);

                Console.Write($"{node.val} ");
            }
		}

		private int minDiffKey;
		private int minDiff = int.MaxValue;

		public int ClosestValue(int val)
		{
			ClosestHelper(root, val);
			return minDiffKey;
		}

		private void ClosestHelper(Node? root, int val)
		{
			if (root is null)
				return;

			if (root.val == val)
				minDiffKey = val;

			if (minDiff > Math.Abs(root.val - val))
			{
				minDiff = Math.Abs(root.val - val);
				minDiffKey = root.val;
			}

			if (val < root.val)
				ClosestHelper(root.left, val);

			if (val > root.val)
				ClosestHelper(root.right, val);
		}
	}
	internal class Program
	{
		static void Main(string[] args)
		{
			BST t = new();
			t.Insert(5);
			t.Insert(2);
			t.Insert(7);
			t.InOrderTraversal();
            Console.WriteLine();
            Console.WriteLine(t.ClosestValue(4));
        }
	}
}