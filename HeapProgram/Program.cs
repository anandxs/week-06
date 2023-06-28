namespace HeapProgram
{
	public class MinHeap
	{
		private int[] heap;
		private int capacity = 10;
		private int size;

        public MinHeap()
        {
            heap = new int[capacity];
			size = 0;
        }

		private int GetParentIndex(int childIndex) => (childIndex - 1) / 2;
		private int GetLeftChildIndex(int parentIndex) => 2 * parentIndex + 1;
		private int GetRightChildIndex(int parentIndex) => 2 * parentIndex + 2;

		private bool HasParent(int childIndex) => GetParentIndex(childIndex) >= 0;
		private bool HasLeftChild(int parentIndex) => GetLeftChildIndex(parentIndex) < size;
		private bool HasRightChild(int parentIndex) => GetRightChildIndex(parentIndex) < size;

		private void EnsureCapacity()
		{
			if (size == capacity)
			{
				capacity *= 2;
				int[] temp = new int[capacity];
				Array.Copy(heap, temp, size);
				heap = temp;
			}
		}
		private void Swap(int[] arr, int i, int j)
		{
			int temp = arr[i];
			arr[i] = arr[j];
			arr[j] = temp;
		}
		private void HeapifyUp()
		{
			int index = size - 1;
			while (HasParent(index) && heap[GetParentIndex(index)] > heap[index])
			{
				Swap(heap, index, GetParentIndex(index));
				index = GetParentIndex(index);
			}
		}
		private void HeapifyDown()
		{
			int index = 0;
			while (HasLeftChild(index))
			{
				int smallerChildIndex = GetLeftChildIndex(index);
				if (HasRightChild(index) && heap[smallerChildIndex] > heap[GetRightChildIndex(index)])
					smallerChildIndex = GetRightChildIndex(index);

				if (heap[index] < heap[smallerChildIndex])
					break;
				else
					Swap(heap, index, smallerChildIndex);

				index = smallerChildIndex;
			}
		}
		private void Heapify(int[] array, int index)
		{
			int smaller = index;
			int l = GetLeftChildIndex(index);
			int r = GetRightChildIndex(index);

			if (l < array.Length && array[l] < array[smaller])
				smaller = l;
			if (r < array.Length && array[r] < array[smaller])
				smaller = r;

			if (smaller != index)
			{
				Swap(array, index, smaller);
				Heapify(array, smaller);
			}
		}

		public void Insert(int val)
		{
			EnsureCapacity();
			heap[size] = val;
			size++;
			HeapifyUp();
		}

		public void Remove()
		{
			if (size is 0)
				throw new InvalidOperationException();

			int val = heap[0];
			heap[0] = heap[size - 1];
			size--;
			HeapifyDown();
		}

		public void Build(int[] array)
		{
			int index = (array.Length - 1) / 2;
			for (int i = index; i >= 0; i--)
				Heapify(array, i);
		}

		public void Print()
		{
			for (int i = 0; i < size; i++)
				Console.Write($"{heap[i]} ");
        }

		public bool IsHeap(int[] arr)
		{
			int size = arr.Length;
			int lastIndex = arr.Length - 1;
			int firstParent = 0;
			int lastParent = (lastIndex - 1) / 2;

			for (int i = firstParent; i <= lastParent; i++)
			{
				int leftIndex = 2 * i + 1;
				int rightIndex = 2 * i + 2;

				if (leftIndex < size && arr[i] > arr[leftIndex])
					return false;

				if (rightIndex < size && arr[i] > arr[rightIndex])
					return false;
			}

			return true;
		}

		public bool IsHeap(Node? root)
		{
			if (root is null)
				return false;

			if (root.left is null && root.right is null)
				return true;

			if (root.left is null && root.right is not null)
				return false;

			if (root.left is not null && root.left.val < root.val)
				return false;

			if (root.right is not null && root.right.val < root.val)
				return false;

			return IsHeap(root.left) && IsHeap(root.right);
		}
    }

	public class Node
	{
		public int val;
		public Node? left;
		public Node? right;

        public Node(int val)
        {
			this.val = val;
			left = right = null;
        }
    }

	public class MaxHeap
	{
		private int[] heap;
		private int capacity = 10;
		private int size;

        public MaxHeap()
        {
			heap = new int[capacity];
			size = 0;
        }

		private void Swap(int[] arr, int i, int j)
		{
			int temp = arr[i];
			arr[i] = arr[j];
			arr[j] = temp;
		}
		private void EnsureCapacity()
		{
			if (size == capacity)
			{
				capacity *= 2;
				int[] temp = new int[capacity];
				Array.Copy(heap, temp, size);
				heap = temp;
			}
		}

		private int GetParentIndex(int childIndex) => (childIndex - 1) / 2;
		private int GetLeftChildIndex(int parentIndex) => 2 * parentIndex + 1;
		private int GetRightChildIndex(int parentIndex) => 2 * parentIndex + 2;

		private bool HasParent(int childIndex) => GetParentIndex(childIndex) >= 0;
		private bool HasLeftChild(int parentIndex) => GetLeftChildIndex(parentIndex) < size;
		private bool HasRightChild(int parentIndex) => GetRightChildIndex(parentIndex) < size;

		private void HeapifyUp()
		{
			int index = size - 1;
			while (HasParent(index) && heap[GetParentIndex(index)] < heap[index])
			{
				Swap(heap, index, GetParentIndex(index));
				index = GetParentIndex(index);
			}
		}
		private void HeapifyDown()
		{
			int index = 0;
			while (HasLeftChild(index))
			{
				int largerChildIndex = GetLeftChildIndex(index);

				if (HasRightChild(index) && heap[largerChildIndex] < heap[GetRightChildIndex(index)])
					largerChildIndex = GetRightChildIndex(index);

				if (heap[index] > heap[largerChildIndex])
					break;
				else
					Swap(heap, index, largerChildIndex);

				index = largerChildIndex;
			}
		}
		private void Heapify(int[] array, int index)
		{
			int largest = index;
			int l = GetLeftChildIndex(index);
			int r = GetRightChildIndex(index);

			if (l < array.Length && array[l] > array[largest]) 
				largest = l;
			if (r < array.Length && array[r] > array[largest])
				largest = r;

			if (largest != index)
			{
				Swap(array, index, largest);
				Heapify(array, largest);
			}
		}

		public void Insert(int val)
		{
			EnsureCapacity();
			heap[size] = val;
			size++;
			HeapifyUp();
		}
		public int Poll()
		{
			if (size is 0)
				throw new InvalidOperationException();

			int val = heap[0];
			heap[0] = heap[size - 1];
			size--;
			HeapifyDown();
			return val;
		}
		public void Print()
		{
			for (int i = 0; i < size; i++)
				Console.Write($"{heap[i]} ");
        }

		public void Build(int[] arr)
		{
			int index = (arr.Length - 1) / 2;
			for (int i = index; i >= 0; i--)
				Heapify(arr, i);
		}
	}

	internal class Program
	{
		static void Main(string[] args)
		{
			MinHeap h = new();
			Node root = new Node(-8);
			root.left = new Node(-9);
			root.right = new Node(7);
			root.right.left = new Node(6);
			root.right.right = new Node(17);
            Console.WriteLine(h.IsHeap(root));
        }
	}
}