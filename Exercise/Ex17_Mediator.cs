using Coding.Exercise17;
using System;
using System.Collections.Generic;

namespace tut_DesignPatterns.Exercise
{
	class Ex17_Mediator
	{
		public static void Start()
		{
			Mediator m = new Mediator();
			Participant p1 = new Participant(m);
			Participant p2 = new Participant(m);
			Participant p3 = new Participant(m);

			p1.Say(2);
			p2.Say(2);


			Console.WriteLine(p1.Value);
			Console.WriteLine(p2.Value);
			Console.WriteLine(p3.Value);
		}
	}
}

namespace Coding.Exercise17
{
	public class Participant
	{
		public int Value { get; set; }

		private Mediator mediator;

		public Participant(Mediator mediator)
		{
			Value = 0;
			this.mediator = mediator;
			mediator.participants.Add(this);
		}

		public void Say(int n)
		{
			mediator.BroadcastSay(this, n);
		}
	}

	public class Mediator
	{
		public List<Participant> participants = new List<Participant>();

		internal void BroadcastSay(Participant participant, int n)
		{
			foreach(var p in participants)
			{
				if(p != participant)
					p.Value += n;
			}
		}
	}
}