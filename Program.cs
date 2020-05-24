using DotNetDesignPatternDemos.Creational.Builder.Coding.Exercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tut_DesignPatterns._4._Factory;
using tut_DesignPatterns._5._Prototype;

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

			Exercise_Prototype.Start();



			Console.ReadKey();
		}
	}
}
