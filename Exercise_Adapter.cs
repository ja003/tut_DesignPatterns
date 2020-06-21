using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tut_DesignPatterns
{
	class Exercise_Adapter
	{
		public static void Start()
		{
		}
	}
}


namespace Coding.Exercise
{
	public class Square
	{
		public int Side;
	}

	public interface IRectangle
	{
		int Width { get; }
		int Height { get; }
	}

	public static class ExtensionMethods
	{
		public static int Area(this IRectangle rc)
		{
			return rc.Width * rc.Height;
		}
	}

	public class SquareToRectangleAdapter : IRectangle
	{
		Square square;

		public SquareToRectangleAdapter(Square square)
		{
			// todo
			this.square = square;
		}

		public int Width => square.Side;

		public int Height => square.Side;
		// todo
	}
}