using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tut_DesignPatterns
{
	class Ex7_Bridge
	{
		public static void Start()
		{
		}
	}
}


namespace Coding.Exercise7
{
    public interface IRenderer
    {
        string WhatToRenderAs { get; }
    }

    public abstract class Shape
    {
        public string Name { get; set; }

        IRenderer renderer;

        public Shape(IRenderer pRend)
        {
            renderer = pRend;
        }

        public override string ToString()
        {
            return $"Drawing {Name} as {renderer.WhatToRenderAs}";
        }
    }

    public class Triangle : Shape
    {
        public Triangle(IRenderer pRend) : base(pRend) => Name = "Triangle";
    }

    public class Square : Shape
    {
        public Square(IRenderer pRend) : base(pRend) => Name = "Square";
    }

    public class VectorSquare : Square
    {
        public VectorSquare(IRenderer pRend) : base(pRend)
        {
        }

        public string WhatToRenderAs
        {
            get { return "lines"; }
        }

        public override string ToString() => $"Drawing {Name} as lines";
    }

    public class RasterSquare : Square
    {
        public RasterSquare(IRenderer pRend) : base(pRend)
        {
        }

        public string WhatToRenderAs
        {
            get { return "pixels"; }
        }

        public override string ToString() => $"Drawing {Name} as pixels";
    }

    // imagine VectorTriangle and RasterTriangle are here too
}