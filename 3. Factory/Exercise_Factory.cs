using Coding.Exercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tut_DesignPatterns._4._Factory
{
	public static class Exercise_Factory
	{
        public static void Start()
        {
            Console.WriteLine("Exercise_Factory");
            var fact = new Person.Factory();
            fact.CreatePerson("Adam");
            fact.CreatePerson("Téra");
        }

    }
}


namespace Coding.Exercise
{
    public class Person
    {


        public int Id { get; set; }
        public string Name { get; set; }

        private Person(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return Id + ": " + Name;
        }

        public class Factory
        {
            int currentId = 0;

            public Person CreatePerson(string name)
            {
                Person person = new Person(currentId++, name);
                Console.WriteLine("Creating: " + person);
                return person;
            }
        }

    }


}