using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CSharpSandbox
{
	class DPC363
	{
		public static void Easy2()
		{
			string input = Console.ReadLine();
			input.Where(r => r.ToString().Contains("cei"));
		}
		public static void Easy()
		{
			string input;

			while (!String.IsNullOrEmpty(input = Console.ReadLine()))
			{
				try
				{
					bool isCorrect = true;
					List<string> exceptions = Easy_Exceptions();

					if (input.Length == 2 && input.Equals("ei"))
						isCorrect = false;
					else if (input.Length > 2)
					{
						bool isPrevC = false;

						List<string> words = input.Split(' ').ToList();

						foreach(var word in words)
						{
							for (int i = 1; i < word.Length; i++)
							{
								if ((isPrevC && word[i - 1] == 'i' && word[i] == 'e' && !exceptions.Contains(word)) || (!isPrevC && word[i - 1] == 'e' && word[i] == 'i'))
									isCorrect = false;

								if (word[i] == 'c')
									isPrevC = true;
								else
									isPrevC = false;
							}
						}
					}

					if (isCorrect)
						Console.WriteLine("True");
					else
						Console.WriteLine("False");
				}
				catch (Exception e)
				{
					Console.WriteLine("Incorrect format, please try again. Detailed Error: " + e.Message);
					continue;
				}


			}
		}

		public static List<string> Easy_Exceptions()
		{
			List<string> exceptions = new List<string>() { "sleigh","stein","fahrenheit","deifies","either","nuclei","reimburse","ancient","juicier","societies" };

			return exceptions;
		}
	}
}
