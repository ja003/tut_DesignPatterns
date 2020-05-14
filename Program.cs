using DotNetDesignPatternDemos.Creational.Builder.Coding.Exercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tut_DesignPatterns._4._Factory;

namespace tut_DesignPatterns
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Main");

			var cb = new CodeBuilder("Person")
			.AddField("Name", "string")
			.AddField("Age", "int");
			Console.WriteLine(cb);




			Exercise_Factory.Start();



			Console.ReadKey();
		}
	}
}
