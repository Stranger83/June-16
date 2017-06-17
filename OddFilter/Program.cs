using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddFilter
{
	class Program
	{
		static void Main(string[] args)
		{
			var input = Console.ReadLine().Split().Select(int.Parse).ToList();
			var evenOnly = new List<int>();
			for (int i = 0; i < input.Count; i++)
			{
				if (input[i] % 2 == 0)
				{
					evenOnly.Add(input[i]);
				}
			
			}

			var av = evenOnly.Average();

			for (int i = 0; i < evenOnly.Count; i++)
			{
				if (evenOnly[i] > av)
				{
					evenOnly[i] += 1;
				}
				else
				{
					evenOnly[i] -= 1;
				}
			}
			Console.WriteLine(string.Join(" ", evenOnly));
		}
	}
}
