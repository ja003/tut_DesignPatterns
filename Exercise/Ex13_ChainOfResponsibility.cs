using Coding.Exercise13;
using System;
using System.Collections.Generic;
using System.Text;

namespace tut_DesignPatterns.Exercise
{
	class Ex13_ChainOfResponsibility
	{
		public static void Start()
		{
			var game = new Game();
			var goblin = new Goblin(game);
			game.Creatures.Add(goblin);

			Console.WriteLine(goblin.Attack == 1);
			Console.WriteLine(goblin.Defense == 1);

			var goblin2 = new Goblin(game);
			game.Creatures.Add(goblin2);

			Console.WriteLine(goblin.Attack == 1);
			Console.WriteLine(goblin.Defense == 2);

			var goblin3 = new GoblinKing(game);
			game.Creatures.Add(goblin3);

			Console.WriteLine(goblin.Attack == 2);
			Console.WriteLine(goblin.Defense == 3);

		}
	}
}

namespace Coding.Exercise13
{
	public abstract class Creature
	{
		protected Game game;
		protected readonly int baseAttack;
		protected readonly int baseDefense;

		protected Creature(Game game, int baseAttack, int baseDefense)
		{
			this.game = game;
			this.baseAttack = baseAttack;
			this.baseDefense = baseDefense;
		}

		public int Attack 
		{ 
			get 
			{
				Game.Query q = new Game.Query(game, Game.Query.Type.Attack, this, baseAttack);
				return q.Handle();
			}
		}
		public int Defense
		{
			get
			{
				Game.Query q = new Game.Query(game, Game.Query.Type.Defense, this, baseDefense);
				return q.Handle();
			}
		}

	}

	public class Goblin : Creature
	{
		public Goblin(Game game) : base(game, 1, 1)
		{
		}

		protected Goblin(Game game, int baseAttack, int baseDefense) : base(game,
		  baseAttack, baseDefense)
		{
		}
	}

	public class GoblinKing : Goblin
	{
		public GoblinKing(Game game) : base(game, 3, 3)
		{
		}
	}

	public class Game
	{
		public IList<Creature> Creatures = new List<Creature>();

		public class Query
		{
			public Game game;

			public enum Type
			{
				Attack, Defense
			}

			public Type QType;
			public Creature Querier;
			private int baseValue;

			public Query(Game game, Type qType, Creature querier, int baseValue)
			{
				this.game = game;
				QType = qType;
				Querier = querier;
				this.baseValue = baseValue;
			}

			public int Handle()
			{
				switch(QType)
				{
					case Type.Attack:
						int otherGoblinKings = 0;
						foreach(var c in game.Creatures)
						{
							if(c == Querier) continue;
							if(c.GetType() == typeof(GoblinKing))
								otherGoblinKings++;
						}
						return baseValue + otherGoblinKings;
					case Type.Defense:
						int otherGoblins = 0;
						foreach(var c in game.Creatures)
						{
							if(c == Querier) continue;
							if(c is Goblin)
								otherGoblins++;
						}
						return baseValue + otherGoblins;
				}
				return -1;
			}
		}
	}
}