using Coding.Exercise21;
using NUnit.Framework;

namespace tut_DesignPatterns.Exercise
{
	[TestFixture]
	class Ex21_State
	{
		[Test]
		public static void Start()
		{
			var cl = new CombinationLock(new[] { 1, 2, 3, 4, 5 });
			Assert.That(cl.Status, Is.EqualTo("LOCKED"));
			cl.EnterDigit(1);
			Assert.That(cl.Status, Is.EqualTo("1"));
			cl.EnterDigit(2);
			Assert.That(cl.Status, Is.EqualTo("12"));
			cl.EnterDigit(3);
			Assert.That(cl.Status, Is.EqualTo("123"));
			cl.EnterDigit(4);
			Assert.That(cl.Status, Is.EqualTo("1234"));
			cl.EnterDigit(5);
			Assert.That(cl.Status, Is.EqualTo("OPEN"));
		}
	}
}

namespace Coding.Exercise21
{
	public class CombinationLock
	{
		public CombinationLock(int[] combination)
		{
			this.combination = combination;
			Status = "LOCKED";
			currentIndex = 0;
		}

		// you need to be changing this on user input
		public string Status;
		private int[] combination;
		int currentIndex;

		public void EnterDigit(int digit)
		{
			if (currentIndex == 0)
			{
				Status = "";
			}

			if (combination[currentIndex] == digit)
			{
				Status += digit;
				currentIndex++;
			}
			else
			{
				Status = "ERROR";
				currentIndex = 0;
				return;
			}

			if (currentIndex == combination.Length)
			{
				Status = "OPEN";
			}
		}
	}
}