using Coding.Exercise13;
using System;
using System.Collections.Generic;
using System.Text;

namespace tut_DesignPatterns.Exercise
{
	class Ex14_Command
	{
		public static void Start()
		{

		}
	}
}

namespace Coding.Exercise14
{
	public class Command
	{
		public enum Action
		{
			Deposit,
			Withdraw
		}

		public Action TheAction;
		public int Amount;
		public bool Success;
	}

	public class Account
	{
		public int Balance { get; set; }

		public void Process(Command c)
		{
			switch(c.TheAction)
			{
				case Command.Action.Deposit:
					Balance += c.Amount;
					c.Success = true;
					break;
				case Command.Action.Withdraw:
					c.Success = Balance >= c.Amount;
					if(c.Success) Balance -= c.Amount;
					break;
			}
		}
	}
}