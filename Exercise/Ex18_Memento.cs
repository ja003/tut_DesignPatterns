using Coding.Exercise18;
using System;
using System.Collections.Generic;
using System.Linq;

namespace tut_DesignPatterns.Exercise
{
	class Ex18_Memento
	{
		public static void Start()
		{
			var tm = new TokenMachine();
			var m = tm.AddToken(123);
			tm.AddToken(456);
			tm.Revert(m);
			Console.WriteLine(tm.Tokens.Count);
			Console.WriteLine(tm.Tokens[0].Value);

		}
	}
}

namespace Coding.Exercise18
{
	public class Token
	{
		public int Value = 0;

		public Token(int value)
		{
			this.Value = value;
		}
	}

	public class Memento
	{
		public List<Token> Tokens = new List<Token>();
	}

	public class TokenMachine
	{
		public List<Token> Tokens = new List<Token>();

		public Memento AddToken(int value)
		{
			return AddToken(new Token(value));
		}

		public Memento AddToken(Token token)
		{
			Tokens.Add(token);
			var m = new Memento();
			// a rather roundabout way of cloning
			m.Tokens = Tokens.Select(t => new Token(t.Value)).ToList();
			return m;
		}

		public void Revert(Memento m)
		{
			Tokens = m.Tokens.Select(mm => new Token(mm.Value)).ToList();
		}
	}
}