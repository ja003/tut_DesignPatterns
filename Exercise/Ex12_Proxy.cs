using Coding.Exercise12;
using System;
using System.Collections.Generic;
using System.Text;

namespace tut_DesignPatterns.Exercise
{
	class Ex12_Proxy
	{
        public static void Start()
        {
            Person p = new Person() { Age = 10 };
            ResponsiblePerson rp = new ResponsiblePerson(p);
            Console.WriteLine(rp.Drink());
        }
	}
}

namespace Coding.Exercise12
{    public class Person
    {
        public int Age { get; set; }

        public string Drink()
        {
            return "drinking";
        }

        public string Drive()
        {
            return "driving";
        }

        public string DrinkAndDrive()
        {
            return "driving while drunk";
        }
    }

    public class ResponsiblePerson
    {
		private readonly Person person;

		public ResponsiblePerson(Person person)
        {
			this.person = person;
		}

        public string Drink()
        {
            if(Age < 18) return "too young";
            return person.Drink();
        }

        public string Drive()
        {
            if(Age < 16) return "too young";
            return person.Drive();
        }

        public string DrinkAndDrive()
        {
            return "dead";
        }

        public int Age
        {
            get { return person.Age; }
            set { person.Age = value; }
        }
    }

}