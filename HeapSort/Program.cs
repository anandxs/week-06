namespace HeapSort
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] arr = { 5, 2, 7, 1, 3 };
			HS(arr);
			foreach (int i in arr)
				Console.Write(i + " ");
		}

		public static void HS(int[] arr)
		{
			int index = (arr.Length - 1) / 2;
			for (int i = index; i >= 0; i--)
			{
				Heapify(arr, arr.Length, i);
			}

			int size = arr.Length;

			for (int i = size; i > 0; i--)
			{
				int temp = arr[0];
				arr[0] = arr[size - 1];
				arr[size - 1] = temp;
				size--;
				Heapify(arr, size, 0);
			}
		}

		private static void Heapify(int[] arr, int n, int i)
		{
			int larger = i;
			int l = 2 * i + 1;
			int r = 2 * i + 2;

			if (l < n && arr[l] > arr[larger])
				larger = l;
			if (r < n && arr[r] > arr[larger])
				larger = r;

			if (larger != i)
			{
				int temp = arr[i];
				arr[i] = arr[larger];
				arr[larger] = temp;

				Heapify(arr, n, larger);
			}
		}
	}
}