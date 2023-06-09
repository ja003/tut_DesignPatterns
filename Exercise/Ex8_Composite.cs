using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System;
using System.Collections;
using System.Collections.Generic;

namespace tut_DesignPatterns.Exercise
{
    class Ex8_Composite
    {
        public static void Start()
        {
        }
    }
}

namespace Coding.Exercise9
{
    public interface IValueContainer : IEnumerable<int>
    {

    }

    public class SingleValue : IValueContainer
    {
        public int Value;

		public IEnumerator GetEnumerator()
		{
            yield return this;
        }


		IEnumerator<int> IEnumerable<int>.GetEnumerator()
		{
            yield return Value;

        }
    }

	public class ManyValues : List<int>, IValueContainer
	{

	}

	public static class ExtensionMethods
    {
        public static int Sum(this List<IValueContainer> containers)
        {
            int result = 0;
            foreach(var c in containers)
                foreach(var i in c)
                    result += i;
            return result;
        }
    }
}



