namespace MeetingRoomIII
{
	internal class UsedRoomMinHeap
	{
		private readonly List<UsedRoom> heap;

		private void SiftDown(int curIdx, int endIdx)
		{
			int childOneIdx = curIdx * 2 + 1;
			while (childOneIdx <= endIdx)
			{
				int childTwoIdx = curIdx * 2 + 2;
				int swapIdx = childOneIdx;
				if (childTwoIdx <= endIdx && heap[childTwoIdx].endTime < heap[childOneIdx].endTime)
				{
					swapIdx = childTwoIdx;
				}
				if (heap[swapIdx].endTime < heap[curIdx].endTime)
				{
					(heap[swapIdx], heap[curIdx]) = (heap[curIdx], heap[swapIdx]);
					curIdx = swapIdx;
					childOneIdx = curIdx * 2 + 1;
				}
				else
				{
					return;
				}
			}
		}

		private void SiftUp(int curIdx)
		{
			int parentIdx = (curIdx - 1) / 2;
			while (parentIdx >= 0 && heap[parentIdx].endTime > heap[curIdx].endTime)
			{
				(heap[parentIdx], heap[curIdx]) = (heap[curIdx], heap[parentIdx]);
				curIdx = parentIdx;
				parentIdx = (curIdx - 1) / 2;
			}
		}

		public UsedRoomMinHeap()
		{
			heap = [];
		}

		public void Push(long endTime, int room)
		{
			heap.Add(new(endTime, room));
			SiftUp(heap.Count - 1);			
		}

		public UsedRoom Pop()
		{
			(heap[0], heap[^1]) = (heap[^1], heap[0]);
			var removed = heap[^1];
			heap.RemoveAt(heap.Count - 1);
			SiftDown(0, heap.Count - 1);
			return removed;
		}

		public UsedRoom Peek()
		{
			return heap[0];
		}

		public bool IsEmpty()
		{
			return heap.Count == 0;
		}
	}
}