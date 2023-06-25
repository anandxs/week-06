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
	}
	internal class Program
	{
		static void Main(string[] args)
		{
		}
	}
}