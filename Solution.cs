namespace MeetingRoomIII
{
	internal class Solution
	{
		public int MostBooked(int n, int[][] meetings)
		{
			int[] meetingRoom = new int[n];
			int[] availableRoom = new int[n];
			for (int i = 0; i < n; ++i)
			{
				availableRoom[i] = i;
			}
			var availableRoomMinHeap = new AvailableRoomMinHeap([.. availableRoom]);
			var usedRoomMinHeap = new UsedRoomMinHeap();
			Array.Sort(meetings, (a, b) => a[0] == b[0] ? a[1].CompareTo(b[1]) : a[0].CompareTo(b[0]));
			foreach (int[] meeting in meetings)
			{
				int startTime = meeting[0];
				int endTime = meeting[1];
				while (!usedRoomMinHeap.IsEmpty() && usedRoomMinHeap.Peek().endTime <= startTime)
				{
					var usedRoom = usedRoomMinHeap.Pop();
					availableRoomMinHeap.Push(usedRoom.room);
				}
				if (!availableRoomMinHeap.IsEmpty())
				{
					int room = availableRoomMinHeap.Pop();
					usedRoomMinHeap.Push(endTime, room);
					++meetingRoom[room];
				}
				else
				{
					var usedRoom = usedRoomMinHeap.Pop();
					usedRoomMinHeap.Push(usedRoom.endTime + endTime - startTime, usedRoom.room);
					++meetingRoom[usedRoom.room];
				}
			}
			int maxCount = 0;
			int maxIndex = 0;
			for (int i = 0; i < n; ++i)
			{
				if (maxCount < meetingRoom[i])
				{
					maxCount = meetingRoom[i];
					maxIndex = i;
				}
			}
			return maxIndex;
		}
	}
}
