using System;
using System.Linq;
namespace codeWar
{
    class Program
    {
        public static int[] CountPositivesSumNegatives(int[] input)
        {
            if(input==null || input.Length==0 ) return new int[]{};
            int[] num = new int[]{
                0,0
            };
            num[0] = input.Where(n => n>0).Count();
            num[1] = input.Where(n => n<0).Sum();
            num = num.Select(s => s==null?0:s).ToArray();
            return num; //return an array with count of positives and sum of negatives
        }
        static void Main(string[] args)
        {
            
        }
    }
}
