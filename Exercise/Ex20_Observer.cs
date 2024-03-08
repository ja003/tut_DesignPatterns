using Coding.Exercise20;
using System;
using System.Collections.Generic;

namespace tut_DesignPatterns.Exercise
{
	class Ex20_Observer
	{
		public static void Start()
		{
			Game game = new Game();
			Rat rat1 = new Rat(game);
			Rat rat2 = new Rat(game);
			Rat rat3 = new Rat(game);

			Console.WriteLine($"Rat attack = {rat1.Attack}");
			Console.WriteLine($"Rat attack = {rat2.Attack}");
			Console.WriteLine($"Rat attack = {rat3.Attack}");

			rat3.Dispose();
			Console.WriteLine($"Rat attack = {rat1.Attack}");
			Console.WriteLine($"Rat attack = {rat2.Attack}");
			Console.WriteLine($"Rat attack = {rat3.Attack}");

		}
	}
}

namespace Coding.Exercise20
{
	public class Game
	{
		// todo
		// remember - no fields or properties!


		public event EventHandler RatSpawned;
		public event EventHandler RatDied;

		internal void OnRatSpawned(Rat rat)
		{
			RatSpawned?.Invoke(rat, EventArgs.Empty);
		}

		internal void OnRatDied(Rat rat)
		{
			RatDied?.Invoke(rat, EventArgs.Empty);
		}
	}

	public class Rat : IDisposable
	{
		public int Attack = 1;
		private Game game;

		public Rat(Game game)
		{
			this.game = game;

			// todo
			game.OnRatSpawned(this);

			game.RatSpawned += (sender, args) =>
			{
				Attack++;
				((Rat)sender).Attack++;
			};

			game.RatDied += (sender, args) =>
			{
				Attack--;
			};
		}


		public void Dispose()
		{
			// todo
			game.OnRatDied(this);
		}
	}
}