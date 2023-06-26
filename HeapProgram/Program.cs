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

		public void Print()
		{
			for (int i = 0; i < size; i++)
				Console.Write($"{heap[i]} ");
        }
    }

	internal class Program
	{
		static void Main(string[] args)
		{
			MinHeap h = new();
			h.Insert(3);
			h.Insert(5);
			h.Insert(6);
			h.Insert(2);
			h.Print();
		}
	}
}