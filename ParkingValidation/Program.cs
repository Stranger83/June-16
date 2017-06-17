using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingValidation
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			var namePlate = new Dictionary<string, string>();
			for (int i = 0; i < n; i++)
			{
				string[] input = Console.ReadLine().Split();
				var command = input[0];
				var user = input[1];

				if (command == "register")
				{
					var plate = input[2];
					var plateNums = plate.ToCharArray();
					var first = plateNums.Take(2).Select(x => (int)x).ToList();
					var firstAndLast = first.Concat(plateNums.Skip(6).Take(2).Select(x => (int)x).ToList()).ToList();
					var middle = plateNums.Skip(2).Take(4).Select(x => (int)x).ToList();
					bool isValid = true;
					
					
					if (!namePlate.ContainsKey(user) && !namePlate.ContainsValue(plate))
					{
						for (int j = 0; j < 4; j++)
						{
							if (firstAndLast[j] < 65 || firstAndLast[j] > 90 ||
								middle[j] < 48 || middle[j] > 57 || plateNums.Length != 8)
							{
								Console.WriteLine($"ERROR: invalid license plate {plate}");
								isValid = false;
								break;
							}
						}
						if (isValid)
						{
							namePlate[user] = "";
							namePlate[user] = plate;
							Console.WriteLine($"{user} registered {plate} successfully");
						}
					}
					else if (namePlate.ContainsKey(user))
					{
						Console.WriteLine($"ERROR: already registered with plate number {namePlate[user]}");
					}
					else if (namePlate.ContainsValue(plate))
					{
						Console.WriteLine($"ERROR: license plate {plate} is busy");
					}
				}
				else if (command == "unregister")
				{
					if (!namePlate.ContainsKey(user))
					{
						Console.WriteLine($"ERROR: user {user} not found");
					}
					else
					{
						namePlate.Remove(user);
						Console.WriteLine($"user {user} unregistered successfully");
					}
				}
			}
			foreach (var kvp in namePlate)
			{
				Console.WriteLine($"{kvp.Key} => {kvp.Value}");
			}
		}
	}
}
