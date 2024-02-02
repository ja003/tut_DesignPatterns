using Coding.Exercise15;
using System;
using System.Collections.Generic;

namespace tut_DesignPatterns.Exercise
{
	class Ex15_Processor
	{
		public static void Start()
		{
			ExpressionProcessor ep = new ExpressionProcessor();
			ep.Variables.Add('x', 2);
			ep.Variables.Add('y', 3);

			Console.WriteLine(ep.Calculate("3+3-xy"));
			Console.WriteLine(ep.Calculate("3+3-5"));
			Console.WriteLine(ep.Calculate("3+3-y"));
			Console.WriteLine(ep.Calculate("1+23-x"));
		}
	}
}

namespace Coding.Exercise15
{
	public class ExpressionProcessor
	{
		public Dictionary<char, int> Variables = new Dictionary<char, int>();

		public int Calculate(string expression)
		{
			int result = 0;
			int lastOpIndex = expression.Length;

			bool NotNumberDetected = false;

			for(int i = expression.Length - 1; i >= 0; i--)
			{
				if(expression[i] == '+')
				{
					result += ParseInt(expression.Substring(i + 1, lastOpIndex - (i + 1)));
					lastOpIndex = i;
					NotNumberDetected = false;
				}
				if(expression[i] == '-')
				{
					result -= ParseInt(expression.Substring(i + 1, lastOpIndex - (i + 1)));
					lastOpIndex = i;
					NotNumberDetected = false;

				}
				if(!IsNumber(expression[i]))
				{
					if(NotNumberDetected) return 0;
					NotNumberDetected = true;
				}
			}
			result += ParseInt(expression.Substring(0, lastOpIndex));

			return result;
		}

		public int ParseInt(string exp)
		{
			int val = 0;
			for(int i = exp.Length - 1; i >= 0; i--)
			{				

				val += ReadInt(exp[i]) * (int)Math.Pow(10, exp.Length - i - 1);
			}
			return val;
		}

		private int ReadInt(char c)
		{
			if(Variables.ContainsKey(c))
				return Variables[c];

			int result = c - '0';
			return result < 10 ? result : 0;
		}

		private bool IsNumber(char c)
		{
			int result = c - '0';
			return result < 10;
		}
	}
}