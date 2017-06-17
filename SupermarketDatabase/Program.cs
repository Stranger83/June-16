using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketDatabase
{
	class Program
	{
		static void Main(string[] args)
		{
			var input = Console.ReadLine();
			var productPrice = new Dictionary<string, double>();
			var productQty = new Dictionary<string, int>();

			while (input != "stocked")
			{
				var tokens = input.Split(' ');
				var product = tokens[0];
		        var price = double.Parse(tokens[1]);
				var quantity = int.Parse(tokens[2]);

				if (!productPrice.ContainsKey(product)) {
					productPrice[product] = 0;
				}
				productPrice[product] = price;

				if (!productQty.ContainsKey(product))
				{
					productQty[product] = 0;
				}
				productQty[product] += quantity;
								
				input = Console.ReadLine();
			}
			var total = 0.0;
			foreach (var kvp in productPrice)
			{
				var prod = kvp.Key;
				var price = kvp.Value;
				var qty = productQty[prod];
				Console.WriteLine($"{prod}: ${price:f2} * {qty} = ${price * qty:f2}");
				total += price * qty;
			}

			Console.WriteLine("------------------------------");
			Console.WriteLine($"Grand Total: ${total:f2}");
		}
	}
}
