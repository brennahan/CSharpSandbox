using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace CSharpSandbox
{
	class DPC365
	{
		public static void Intermediate()
		{
			Regex regex = new Regex("[ ]{2,}", RegexOptions.None);

			//Load data, conduct initial formatting/cleanup, and split into revenue/expense objects
			string[] lines = System.IO.File.ReadAllLines("..\\..\\Inputs\\DPC365_Intermediate2.txt").Where(i => !String.IsNullOrEmpty(i.ToString())).Select(i => regex.Replace(i.ToString(), " ").TrimStart()).ToArray();
			string[] people = lines[1].Split(' ');
			string[][] revenue = lines.Skip(2).Take((lines.Length / 2) - 2).Select(l => l.Split(' ')).ToArray();
			string[][] expense = lines.Skip((lines.Length / 2) + 2).Take((lines.Length / 2) - 2).Select(l => l.Split(' ')).ToArray();

			//To increase robustness, would do error checking here to ensure revenue and expense grids are same sizes

			//Calculate commission
			string[] commission = new string[revenue[0].Length-1];
			int sub = 0;

			for (int col = 1; col < revenue[0].Length; col++)
			{
				sub = 0;

				for(int row = 0; row < revenue.Length; row++)
				{
					sub += Math.Max(0,Int32.Parse(revenue[row][col]) - Int32.Parse(expense[row][col]));
				}
				commission[col - 1] = ((sub) * .062).ToString();
			}

			//Format Results
			string[] commissionFormatted = new string[commission.Length];
			string[] peopleFormatted = new string[people.Length];

			for (int i = 0; i < commission.Length; i++)
				commissionFormatted[i] = commission[i].PadLeft(Math.Max(commission[i].Length, people[i].Length));

			for (int i = 0; i < people.Length; i++)
				peopleFormatted[i] = people[i].ToString().PadLeft(Math.Max(commission[i].ToString().Length, people[i].Length));

			//Display Results
			Console.WriteLine("            " + String.Join("  ", peopleFormatted));
			Console.WriteLine("Commission  " + String.Join("  ", commissionFormatted));
			Console.Read();
		}

		public static void Easy()
		{
			//WARNING: Only works for smaller 3-arrow numbers. Too slow currently to run faster. 
			int num1 = 4;
			int arrowCount = 2;
			ulong num2 = 3;

			Console.WriteLine(Easy_Recursion(num1, arrowCount, num2));

			Console.Read();
		}

		public static ulong Easy_Recursion(int num1, int arrowCount, ulong num2)
		{

			if (arrowCount == 1)
				return (ulong)Math.Pow(num1, num2);
			else if (arrowCount == 2)
			{
				ulong sum = (ulong) num1;
				for (int i = 1; (ulong) i < num2; i++)
					sum = (ulong)Math.Pow(num1, sum);
				return sum;
			}
			else
			{
				ulong sum = (ulong) num1;

				for (int i = 1; (ulong) i < num2; i++)
					sum = Easy_Recursion(num1, arrowCount - 1, sum);

				return sum;
			}

			return (ulong) 0;
		}
	}
}
