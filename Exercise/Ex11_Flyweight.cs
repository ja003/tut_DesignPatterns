using Coding.Exercise11;
using System;
using System.Collections.Generic;
using System.Text;

namespace tut_DesignPatterns.Exercise
{
	class Ex11_Flyweight
	{
		public static void Start()
		{
			Console.WriteLine("Ex11_Flyweight");

			Sentence s = new Sentence("hello mama");
			s[1].Capitalize = true;

			Console.WriteLine(s);

		}
	}
}

namespace Coding.Exercise11
{
	public class Sentence
	{
		List<string> words = new List<string>();

		//todo: this isnt flyweight..right? should be a map of WordTokens?
		List<WordToken> wordTokens = new List<WordToken>();

		public Sentence(string plainText)
		{
			var splitSentence = plainText.Split(' ');
			for (int i = 0; i < splitSentence.Length; i++)
			{
				words.Add(splitSentence[i]);
				wordTokens.Add(new WordToken());
			}
		}

		public WordToken this[int index]
		{
			get
			{
				return wordTokens[index];
			}
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			for(int i = 0; i < words.Count; i++)
			{
				string word = words[i];
				sb.Append(wordTokens[i].Capitalize ? ToUpper(word) : word);
				if (i < words.Count - 1)
					sb.Append(" ");
			}

			return sb.ToString();
		}

		string ToUpper(string text)
		{
			StringBuilder sb = new StringBuilder();
			foreach(char c in text)
			{
				sb.Append(char.ToUpper(c));
			}
			return sb.ToString();
		}

		public class WordToken
		{
			public bool Capitalize;
		}
	}
}