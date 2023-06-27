namespace GraphProgram
{
	public class Graph
	{
		private Dictionary<int, List<int>> graph;

        public Graph()
        {
			graph = new Dictionary<int, List<int>>();   
        }

		public void AddVertex(int u)
		{
			graph.Add(u, new List<int>());
		}

		public void AddEdge(int u, int v, bool bi = false)
		{
			if (!graph.ContainsKey(u))
				AddVertex(u);

			if (!graph.ContainsKey(v))
				AddVertex(v);

			graph[u].Add(v);
			if (bi)
				graph[v].Add(u);
		}

		public void DFS(int source)
		{
            Console.Write(source + " ");

			foreach (int neighbour in graph[source])
				DFS(neighbour);
        }

		public void BFS(int source)
		{
			Queue<int> queue = new();
			queue.Enqueue(source);

			while (queue.Count > 0)
			{
				int current = queue.Dequeue();
                Console.Write(current + " ");

				foreach (int neighbour in graph[current])
					queue.Enqueue(neighbour);
            }
		}

		public void Print()
		{
			foreach (var entry in graph)
			{
				string neighbours = String.Join(", ", entry.Value);
                Console.WriteLine($"{entry.Key} : {neighbours}");
            }
		}
    }
	internal class Program
	{
		static void Main(string[] args)
		{
			Graph g = new();
			g.AddEdge(1, 4);
			g.AddEdge(1, 2);
			g.AddEdge(2, 3);
			g.Print();
		}
	}
}