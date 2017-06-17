using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmuneSystem
{
	class Program
	{
		static void Main(string[] args)
		{
			var startHealth = int.Parse(Console.ReadLine());
			var command = Console.ReadLine();
			var virusStrength = new Dictionary<string, int>();
			var currentHealth = startHealth;
			while (command != "end")
			{
				var strength = command.ToCharArray().Select(x => (int)x).Sum() / 3;
				var timeToDefeat = 0;
				
				if (!virusStrength.ContainsKey(command))
				{
					virusStrength[command] = strength;
					timeToDefeat = strength * command.Length;
				}
				else
				{
					timeToDefeat = strength * command.Length / 3;
				}

				Console.WriteLine($"Virus {command}: {virusStrength[command]} => {timeToDefeat} seconds");

				currentHealth -= timeToDefeat;
				
				if (currentHealth <= 0)
				{
					Console.WriteLine("Immune System Defeated.");
					return;
				}
								
				Console.WriteLine($"{command} defeated in {timeToDefeat/60}m {timeToDefeat%60}s.");
				Console.WriteLine($"Remaining health: {currentHealth}");
				currentHealth = (int)(currentHealth * 1.2);
				if (currentHealth > startHealth)
				{
					currentHealth = startHealth;
				}
				command = Console.ReadLine();
			}
			Console.WriteLine($"Final Health: {currentHealth}");
		}
	}
}
