using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CSharpSandbox
{
	class DPC364
	{
		public static void Hard()
		{
			string raw;
			char[,] board;

			while (!String.IsNullOrEmpty(raw = Console.ReadLine()))
			{
				int[] inputs;

				try
				{
					inputs = raw.Split(' ').Select(t => int.Parse(t)).ToArray();
					if (inputs.Length != 2)
						throw new Exception();

					board = new char[inputs[0], inputs[1]];
				}
				catch (Exception e)
				{
					Console.WriteLine("Invalid Input, please try again.");
					continue;
				}
				board[0, 0] = 'A';

				var a = Hard_FindNextGap(board);



				//Console.ReadLine();
			}
		}
		public static Tuple<int, int> Hard_FindNextGap(char[,] board)
		{
			for (int i = 0; i < board.GetLength(0); i++)
				for (int j = 0; j < board.GetLength(1); j++)
					if (board[i, j] == '\0')
						return new Tuple<int, int>(i, j);


			return new Tuple<int,int>(-1,-1);
		}
		public class Hard_Pentominos
		{
			//Define pentominos. Develop a workable/meaningful structure.
		}


		public static void Intermediate()
		{
			string input;
			while (!String.IsNullOrEmpty(input = Console.ReadLine()))
			{
				int[] InitialList;
				try
				{
					InitialList = input.Replace("(", "").Replace(")", "").Replace(" ", "").Split(',').Select(x => int.Parse(x)).ToArray();
				}
				catch (Exception e)
				{
					Console.WriteLine("Input string incorrectly formatted. Please try again");
					continue;
				}

				Intermediate_PrintTuple(InitialList);

				int length = InitialList.Count();
				int[] prevList = (int[])InitialList.Clone();
				int[] newList = new int[length];
				List<string> history = new List<string>();

				//bool stopLooping = false;
				string pattern = "";
				int LoopLimit = 0;
				while (LoopLimit < 100)
				{
					for (int i = 0; i < length; i++)
					{
						newList[i] = Math.Abs(prevList[i] - prevList[(i + 1) % length]);
					}


					Intermediate_PrintTuple(newList);
					history.Add(string.Join(",", newList));

					prevList = (int[])newList.Clone();

					//Break cases:
					//All 0's
					int sum = 0;
					foreach (int val in newList)
						sum += val;
					if (sum == 0)
					{
						pattern = string.Join(",", newList);
						break;
					}

					//Repeating pattern
					var patternStart = history.GroupBy(t => t.ToString()).Select(t => new { Sequence = t.Key, Count = t.Count() }).Where(t => t.Count > 1).SingleOrDefault();
					if (patternStart != null)
					{
						pattern = patternStart.Sequence;
						break;
					}

					LoopLimit++;
				}
				Console.WriteLine("Period Detected. Starting Sequence: " + pattern);

				//foreach (int in InitialList)
				//{
				//	Console.WriteLine(a);
				//}
			}

			Console.Read();
		}

		public static void Intermediate_PrintTuple(int[] tuple)
		{
			Console.Write("[");
			bool ignoreFirst = true;
			foreach (int val in tuple)
			{
				if (ignoreFirst)
					ignoreFirst = false;
				else
					Console.Write("; ");

				Console.Write(val);
			}
			Console.WriteLine("]");
		}

		public static void Easy()
		{
			string input;

			while (!String.IsNullOrEmpty(input = Console.ReadLine()))
			{
				try
				{
					List<string> inputlist = input.Split('d').ToList();

					if (inputlist.Count == 2)
					{
						Random rnd = new Random();
						int sum = 0;
						int num;
						string nums = "";

						//Ideally would use regex to confirm the correct format, but I'm not that skilled, so I'm janking it up. 
						int.TryParse(inputlist[0], out int number);
						int.TryParse(inputlist[1], out int sides);

						if (number == 0 || sides == 0)
							throw new Exception();

						for (int i = 0; i < number; i++)
						{
							num = rnd.Next(1, sides + 1);
							nums += " " + num;
							sum += num;
						}

						//Console.WriteLine(rnd.Next(1, sides));



						//Console.WriteLine("Hello Wurld! + " + number + "d" + sides);
						//Console.WriteLine(number + "d" + sides);
						Console.WriteLine(sum + ": " + nums);
					}
					else
						throw new Exception();
				}
				catch (Exception e)
				{
					Console.WriteLine("Incorrect format, please try again. Detailed Error: " + e.Message);
					continue;
				}
			}


			Console.Read();
		}
	}
}
