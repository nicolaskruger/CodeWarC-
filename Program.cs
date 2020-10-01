using System;
using System.Collections.Generic;
using System.Linq;
namespace codeWar
{
    class Program
    {
        public static int find_it(int[] seq) 
        {
            Dictionary<int,int> dic = new Dictionary<int, int>();
            foreach (var s in seq)
            {
                try
                {
                    dic[s]++;
                }
                catch (System.Exception)
                {
                    
                    dic[s]=1;
                }
            }
            return dic.Where(s => s.Value%2==1).First().Key;
        }
        static void Main(string[] args)
        {
            
        }
    }
}
