using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpSandbox
{
	class DPC303
	{
		static Node[,] maze;
		static List<Node> visited;
		readonly static int maxDist = 10000000;
		readonly static string document = "DPC303_Hard2";
		readonly static string documentPath = "..\\..\\Inputs\\" + document + ".txt";


		public static void Hard()
		{
			char[][] rawMaze = System.IO.File.ReadAllLines(documentPath).Select(r => r.ToArray()).ToArray();
			maze = new Node[rawMaze.Length, rawMaze[0].Length];
			visited = new List<Node>();
			Location start = new Location();
			Location end = new Location();
			Stopwatch watch = new Stopwatch();

			watch.Start();
			//Identify starting location, set up maze in node format.
			for (int i = 0; i < rawMaze.Length; i++)
				for (int j = 0; j < rawMaze[i].Length; j++)
				{
					maze[i, j] = (new Node(new Location(i, j), rawMaze[i][j]));

					if (rawMaze[i][j] == 'S')
					{
						maze[i, j].distance = 0;
						start = new Location(i, j);
					}
					else if (rawMaze[i][j] == 'G')
						end = new Location(i, j);
				}

			Location currentNodeLocation = start;

			//StartLoop
			while (true)
			{
				//Calculate new possible paths
				Scout(currentNodeLocation);

				//Mark as Visited;
				maze[currentNodeLocation.Row, currentNodeLocation.Column].visited = true;

				//Find next shortest path node
				Node shortest = FindShortest();

				if (currentNodeLocation.Equals(end) || shortest.location.Equals(end) || shortest.distance == maxDist)
					break;

				currentNodeLocation = shortest.location;
			}
			//EndLoop

			watch.Stop();
			String output = "";

			foreach (var loca in maze[end.Row, end.Column].path)
				output = output + " [" + loca.Row + "," + loca.Column + "]";

			OutputPath(end);

			Console.WriteLine("Path:" + output);
			Console.WriteLine("Time: " + watch.ElapsedMilliseconds);


			Console.Read();
		}
		public static Node FindShortest()
		{
			Node shortest = (new Node(new Location(0, 0), '#'));

			for (int i = 0; i < maze.GetLength(0); i++)
				for (int j = 0; j < maze.GetLength(1); j++)
					if (!maze[i, j].visited && maze[i, j].distance < shortest.distance)
						shortest = maze[i, j];

			return shortest;
		}
		public static void Scout(Location current)
		{
			List<Location> directions = new List<Location>() { new Location(1, 0), new Location(0, 1), new Location(-1, 0), new Location(0, -1) };//maze[0, 0] = new Node();
			char ascii;
			int tentDist;

			foreach (var dir in directions)
			{
				if ((current.Row + dir.Row) < 0 || current.Column + dir.Column < 0)
					continue;

				ascii = maze[current.Row + dir.Row, current.Column + dir.Column].ascii;

				if (ascii != '#' && !maze[current.Row + dir.Row, current.Column + dir.Column].visited)
				{
					if (ascii == 32 || ascii == 'G')
						tentDist = maze[current.Row, current.Column].distance;
					else if (ascii == 'm')
						tentDist = maze[current.Row, current.Column].distance + 1;
					else
						tentDist = maxDist;

					if (tentDist < maze[current.Row + dir.Row, current.Column + dir.Column].distance)
					{
						maze[current.Row + dir.Row, current.Column + dir.Column].distance = tentDist;
						maze[current.Row + dir.Row, current.Column + dir.Column].path = new List<Location>(maze[current.Row, current.Column].path);
						maze[current.Row + dir.Row, current.Column + dir.Column].path.Add(new Location(current.Row + dir.Row, current.Column + dir.Column));
					}
				}
			}
		}

		public static void OutputPath(Location end)
		{
			string documentSolutionPath = documentPath.Replace(".txt", "_Solution.txt");
			Node[,] solutionMaze = (Node[,])maze.Clone();
			foreach (var node in maze[end.Row, end.Column].path)
				solutionMaze[node.Row, node.Column].ascii = '@';

			if (File.Exists(documentSolutionPath))
			{
				File.Delete(documentSolutionPath);
			}

			// Create a new file 
			using (FileStream fs = File.Create(documentSolutionPath))
			{
				for (int i = 0; i < solutionMaze.GetLength(0); i++)
				{
					string line = "";

					for (int j = 0; j < solutionMaze.GetLength(1); j++)
						line+= solutionMaze[i,j].ascii;

					Byte[] lineByte = new UTF8Encoding(true).GetBytes(line + '\r');
					fs.Write(lineByte, 0, lineByte.Length);
				}
			}

		}

		public struct Node
		{
			public Location location;
			public char ascii;
			public int distance;
			public List<Location> path;
			public bool visited;

			public Node(Location inLocation, char inAscii)
			{
				this.location = inLocation;
				this.ascii = inAscii;
				this.distance = maxDist;
				this.path = new List<Location>();
				this.path.Add(inLocation);
				this.visited = false;
			}
		}

		public struct Location
		{
			public int Row, Column;
			public Location(int inRow, int inCol)
			{
				this.Row = inRow;
				this.Column = inCol;
			}

		}
	}
}
