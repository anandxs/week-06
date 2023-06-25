namespace BinarySearchTreeProgram
{
	public class BST
	{
		class Node
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
	}
	internal class Program
	{
		static void Main(string[] args)
		{

		}
	}
}