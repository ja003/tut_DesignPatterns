using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class CodeBuilder
{
	string className;
	List<Attribute> attributes = new List<Attribute>();

	public CodeBuilder(string pClass)
	{
		className = pClass;
	}

	public CodeBuilder AddField(string pName, string pType)
	{
		attributes.Add(new Attribute() { name = pName, type = pType });
		return this;
	}

	public override string ToString()
	{
		return $"public class {className}{Environment.NewLine}" +
			'{' + Environment.NewLine +
				attributes[0].ToString() +
			'}' + Environment.NewLine
			;
	}

	private class Attribute
	{
		public string type;
		public string name;

		public override string ToString()
		{
			return $"  public {type} {name};{Environment.NewLine}";
		}
	}
}

public class Exercise_Builder
{
	//Console.WriteLine();

	public static void Start()
	{
		Console.WriteLine("Exercise_Builder");

		var cb = new CodeBuilder("Person")
			.AddField("Name", "string")
			.AddField("Age", "int");
		Console.WriteLine(cb);
	}
}