using System;
using System.Linq;
namespace codeWar
{
    class Program
    {
        public static bool IsTriangle(int a, int b, int c)
        {
            int[] n = new int[]{a,b,c};
            n= n.OrderBy(s => s).ToArray();
            return n[2]<(n[0]+n[1]);
        }
        static void Main(string[] args)
        {
            bool b = IsTriangle(1,1,1);
        }
    }
}
