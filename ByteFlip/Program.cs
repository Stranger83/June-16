using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteFlip
{
	class Program
	{
		static void Main(string[] args)
		{
			var input = Console.ReadLine().Split().Where(x => x.Length == 2).ToList();
			var bytes = new List<string>();
			for (int i = 0; i < input.Count; i++)
			{
				var bytesToAdd = input[i].ToCharArray().Reverse().ToList();
				string byteee = string.Join("", bytesToAdd);
				bytes.Add(byteee);
			}
			bytes.Reverse();

			var final = "";
			for (int i = 0; i < bytes.Count; i++)
			{
				var test = Convert.ToInt32(bytes[i], 16);
				final += (char)test;
			}
			Console.WriteLine(final);
		}
	}
}
