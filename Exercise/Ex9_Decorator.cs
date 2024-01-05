using Coding.Exercise9;
using System;

namespace tut_DesignPatterns.Exercise
{
	class Ex9_Decorator
	{
		public static void Start()
		{
			Console.WriteLine("Ex9_Decorator");

			Dragon dragon = new Dragon();
			dragon.Age = 10;
			Console.WriteLine(dragon.Crawl());
			Console.WriteLine(dragon.Fly());
		}
	}
}

namespace Coding.Exercise9
{
	public class Bird
	{
		public int Age { get; set; }

		public string Fly()
		{
			return (Age < 10) ? "flying" : "too old";
		}
	}

	public class Lizard
	{
		public int Age { get; set; }

		public string Crawl()
		{
			return (Age > 1) ? "crawling" : "too young";
		}
	}

	public class Dragon // no need for interfaces
	{
		Lizard lizard = new Lizard();
		Bird bird = new Bird();

		public int Age
		{
			set
			{ 
				lizard.Age = value;
				bird.Age = value;
			}
			get
			{
				return lizard.Age;
			}
		}

		public string Fly()
		{
			return bird.Fly();
		}

		public string Crawl()
		{
			return lizard.Crawl();
		}
	}
}