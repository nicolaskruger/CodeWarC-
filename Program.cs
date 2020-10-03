using System;
using System.Linq;
namespace codeWar
{
    class Program
    {
       
        public static int[] SortArray(int[] array)
        {
            var odd = array.Where(s => s%2==1).OrderBy(s =>s).ToArray();
            int i=0;
            return array.Select(s => s%2==1?odd[i++]:s).ToArray();
        }
        static void Main(string[] args)
        {
           var arr = SortArray(new int[]{5, 3, 2, 8, 1, 4});
           
        }
    }
}
