using Coding.Exercise24;
using System;
using System.Collections.Generic;
using System.Text;

namespace tut_DesignPatterns.Exercise
{
	class Ex24_Visitor
	{
		public static void Start()
		{
			var simple = new AdditionExpression(new Value(2), new Value(3));
			var ep = new ExpressionPrinter();
			ep.Visit(simple);
			Console.WriteLine(ep.ToString());//, Is.EqualTo("(2+3)"));


			var e1 = new AdditionExpression(new MultiplicationExpression(
				new Value(1), new Value(2)), 
				  new Value(3));
			ep = new ExpressionPrinter();
			ep.Visit(e1);
			Console.WriteLine(ep.ToString());


		}
	}
}

namespace Coding.Exercise24
{
	public abstract class ExpressionVisitor
	{
		public abstract void Visit(Value value);
		public abstract void Visit(AdditionExpression ae);
		public abstract void Visit(MultiplicationExpression me);

	}

	public abstract class Expression
	{
		public abstract void Accept(ExpressionVisitor ev);
	}

	public class Value : Expression
	{
		public readonly int TheValue;

		public Value(int value)
		{
			TheValue = value;
		}

		public override void Accept(ExpressionVisitor ev)
		{
			if(ev is ExpressionPrinter)
				ev.Visit(this);
		}
	}

	public class AdditionExpression : Expression
	{
		public readonly Expression LHS, RHS;

		public AdditionExpression(Expression lhs, Expression rhs)
		{
			LHS = lhs;
			RHS = rhs;
		}

		public override void Accept(ExpressionVisitor ev)
		{
			if(ev is ExpressionPrinter)
				ev.Visit(this);
		}
	}

	public class MultiplicationExpression : Expression
	{
		public readonly Expression LHS, RHS;

		public MultiplicationExpression(Expression lhs, Expression rhs)
		{
			LHS = lhs;
			RHS = rhs;
		}

		public override void Accept(ExpressionVisitor ev)
		{
			if(ev is ExpressionPrinter)
				ev.Visit(this);
		}
	}

	public class ExpressionPrinter : ExpressionVisitor
	{
		StringBuilder sb = new StringBuilder();

		public override void Visit(Value value)
		{
			sb.Append(value.TheValue.ToString());
		}

		public override void Visit(AdditionExpression ae)
		{
			sb.Append("(");
			ae.LHS.Accept(this);
			//Visit(ae.LHS);
			sb.Append("+");
			ae.RHS.Accept(this);
			//Visit(ae.RHS);
			sb.Append(")");
		}

		public override void Visit(MultiplicationExpression me)
		{
			me.LHS.Accept(this);
			sb.Append("*");
			me.RHS.Accept(this);
		}

		public override string ToString()
		{
			return sb.ToString();
		}

	}
}