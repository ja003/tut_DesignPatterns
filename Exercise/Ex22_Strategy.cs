using Coding.Exercise22;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace tut_DesignPatterns.Exercise
{
	class Ex22_Strategy
	{
		public static void Start()
		{
			QuadraticEquationSolver solver = new QuadraticEquationSolver(new OrdinaryDiscriminantStrategy());
			solver.Solve(1, 2, 1);
		}

	}
}

namespace Coding.Exercise22
{
	public interface IDiscriminantStrategy
	{
		double CalculateDiscriminant(double a, double b, double c);
	}

	public class OrdinaryDiscriminantStrategy : IDiscriminantStrategy
	{
		// todo
		public double CalculateDiscriminant(double a, double b, double c)
		{
			return b * b - 4 * a * c;
		}
	}

	public class RealDiscriminantStrategy : IDiscriminantStrategy
	{
		// todo (return NaN on negative discriminant!)
		public double CalculateDiscriminant(double a, double b, double c)
		{
			double result = b * b - 4 * a * c;
			return result < 0 ? double.NaN : result;
		}
	}

	public class QuadraticEquationSolver
	{
		private readonly IDiscriminantStrategy strategy;

		public QuadraticEquationSolver(IDiscriminantStrategy strategy)
		{
			this.strategy = strategy;
		}

		public Tuple<Complex, Complex> Solve(double a, double b, double c)
		{
			var disc = new Complex(strategy.CalculateDiscriminant(a, b, c), 0);
			var rootDisc = Complex.Sqrt(disc);
			return Tuple.Create(
			  (-b + rootDisc) / (2 * a),
			  (-b - rootDisc) / (2 * a)
			);
		}
	}
}