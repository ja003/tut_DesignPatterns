using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tut_DesignPatterns
{
    class Ex5_Singleton
    {
        public static void Start()
        {
        }
    }
}


namespace Coding.Exercise
{
    public class SingletonTester
    {
        public static bool IsSingleton(Func<object> func)
        {
            // todo
            object obj1 = func();
            object obj2 = func();

            return obj1.Equals(obj2);
        }

        public static bool IsSingleton_solution(Func<object> func)
        {
            var obj1 = func();
            var obj2 = func();
            return ReferenceEquals(obj1, obj2);
        }
    }
}