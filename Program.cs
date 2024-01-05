using DotNetDesignPatternDemos.Creational.Builder.Coding.Exercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tut_DesignPatterns._4._Factory;
using tut_DesignPatterns._5._Prototype;
using tut_DesignPatterns.Exercise;

namespace tut_DesignPatterns
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Main");
			Console.WriteLine();

			//var cb = new CodeBuilder("Person")
			//.AddField("Name", "string")
			//.AddField("Age", "int");
			//Console.WriteLine(cb);

			//Ex3_Factory.Start();

			//Ex4_Prototype.Start();

			Ex8_Composite.Start();



			Console.ReadKey();
		}
	}
}
