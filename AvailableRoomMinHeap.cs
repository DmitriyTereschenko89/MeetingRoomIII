namespace MeetingRoomIII
{
	internal class AvailableRoomMinHeap
	{
		private readonly List<int> heap;

		private void SiftDown(int curIdx, int endIdx, List<int> arr)
		{
			int childOneIdx = curIdx * 2 + 1;
			while (childOneIdx <= endIdx)
			{
				int childTwoIdx = curIdx * 2 + 2;
				int swapIdx = childOneIdx;
				if (childTwoIdx <= endIdx && arr[childTwoIdx] < arr[childOneIdx])
				{
					swapIdx = childTwoIdx;
				}
				if (arr[swapIdx] < arr[curIdx])
				{
					(arr[swapIdx], arr[curIdx]) = (arr[curIdx], arr[swapIdx]);
					curIdx = swapIdx;
					childOneIdx = curIdx * 2 + 1;
				}
				else
				{
					return;
				}
			}
		}

		private void SiftUp(int curIdx, List<int> arr)
		{
			int parentIdx = (curIdx - 1) / 2;
			while (parentIdx >= 0 && arr[parentIdx] > arr[curIdx])
			{
				(arr[parentIdx], arr[curIdx]) = (arr[curIdx], arr[parentIdx]);
				curIdx = parentIdx;
				parentIdx = (curIdx - 1) / 2;
			}
		}

		private List<int> BuildHeap(List<int> arr)
		{
			int parentIdx = (arr.Count - 2) / 2;
			for (int i = parentIdx; i >= 0; --i)
			{
				SiftDown(i, arr.Count - 1, arr);
			}
			return arr;
		}

		public AvailableRoomMinHeap(List<int> arr)
		{
			heap = BuildHeap(arr);
		}

		public void Push(int val)
		{
			heap.Add(val);
			SiftUp(heap.Count - 1, heap);
;		}

		public int Pop()
		{
			(heap[0], heap[^1]) = (heap[^1], heap[0]);
			int removed = heap[^1];
			heap.RemoveAt(heap.Count - 1);
			SiftDown(0, heap.Count - 1, heap);
			return removed;
		}

		public bool IsEmpty()
		{
			return heap.Count == 0;
		}
	}
}