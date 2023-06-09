using Coding.Exercise;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace tut_DesignPatterns._5._Prototype
{
	class Ex4_Prototype
	{
		public static void Start()
		{
			Console.WriteLine("Exercise_Prototype");
			var line = new Line(new Point(0, 0), new Point(1, 1));
			Console.WriteLine(line.Start.X);

			var copyLine = line.DeepCopy();
			copyLine.Start.X = 1;
			Console.WriteLine(copyLine.Start.X);
            Console.WriteLine("----");
		}
	}
}


namespace Coding.Exercise
{
	[Serializable]
	public class Point
	{
		public int X, Y;

		public Point() { }

		public Point(int v1, int v2)
		{
			this.X = v1;
			this.Y = v2;
		}
	}

	[Serializable]
	public class Line
	{
		public Point Start, End;

		public Line() { }

		public Line(Point Start, Point End)
		{
			this.Start = Start;
			this.End = End;
		}

		public Line DeepCopy()
		{
			var stream = new MemoryStream();
			var formatter = new BinaryFormatter();
			formatter.Serialize(stream, this);
			stream.Seek(0, SeekOrigin.Begin);
			object copy = formatter.Deserialize(stream);
			stream.Close();
			return (Line)copy;
		}

		public Line DeepCopy_solution()
		{
			var newStart = new Point { X = Start.X, Y = Start.Y };
			var newEnd = new Point { X = End.X, Y = End.Y };
			return new Line { Start = newStart, End = newEnd };
		}
	}
}