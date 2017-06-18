using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkipTakeRope
{
	class Program
	{
		static void Main(string[] args)
		{
			var input = Console.ReadLine().ToCharArray();
			var letters = input.Where(x => !Char.IsNumber(x)).ToList();
			var nums = input.Where(x => Char.IsNumber(x)).Select(x => (int)Char.GetNumericValue(x)).ToList();
			var takeList = new List<int>();
			var skipList = new List<int>();
			DivideIntoTakeAndSkipLists(nums, skipList, takeList);
			string message = ExtractMessage(letters, takeList, skipList);
			Console.WriteLine(message);
		}

		private static string ExtractMessage(List<char> letters, List<int> takeList, List<int> skipList)
		{
			var msg = new List<string>();
			var mark = 0;
			for (int i = 0; i < takeList.Count; i++)
			{
				var test = letters.Skip(mark).Take(takeList[i]).ToList();
				mark += skipList[i] + takeList[i];
				msg.Add(string.Join("",test));
			}
			string message = string.Join("", msg);
			return message;
		}

		private static void DivideIntoTakeAndSkipLists(List<int> nums, List<int> skipList, List<int> takeList)
		{
			for (int i = 0; i < nums.Count; i++)
			{
				if (i % 2 == 0)
				{
					takeList.Add(nums[i]);
				}
				else
				{
					skipList.Add(nums[i]);
				}
			}
		}
				
	}
}
