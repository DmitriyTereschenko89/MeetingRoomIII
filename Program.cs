namespace MeetingRoomIII
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var solution = new Solution();
            Console.WriteLine(solution.MostBooked(2, [[0, 10], [1, 5], [2, 7], [3, 4]]));
			Console.WriteLine(solution.MostBooked(3, [[1, 20], [2, 10], [3, 5], [4, 9], [6, 8]]));
		}
	}
}
