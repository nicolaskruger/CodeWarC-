using System;
using System.Collections.Generic;
using System.Linq;
namespace codeWar
{
    class Program
    {
        public static string[] TowerBuilder(int nFloors)
        {
            string str = new string('*',nFloors*2-1);
            List<string> st = new List<string>();
            for (int i = 0; i < nFloors; i++)
            {
                st.Add(new string(' ',nFloors-i-1)+new string('*',i*2+1)+new string(' ',nFloors-i-1));
            } 
            return st.ToArray();
        }
        static void Main(string[] args)
        {
            string[] str = TowerBuilder(4);
        }
    }
}
