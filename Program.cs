using System;
using System.Linq;
namespace codeWar
{
    static class Program
    {
        public static void print<T>(this T[] array){
            foreach (var a in array)
            {
                Console.WriteLine(a);
            }
        }
        public static int sumTwoSmallestNumbers(params int[] numbers)
	    {
	    	//Code here...
            return numbers.OrderBy(i => i).Take(2).Sum();
;
	    }
        static void Main(string[] args)
        {
            sumTwoSmallestNumbers(10, 343445353, 3453445, 45353453);
        }
    }
}
