using System;
using System.Collections.Generic;

namespace codeWar
{
    class Program
    {
        public static int DuplicateCount(string str)
        {
            str= str.ToLower();
            Dictionary<char,int> dic= new Dictionary<char, int>();
            char ch;
            for (int i=0;i<str.Length;i++)
            {
                ch = str[i];
                try
                {
                    dic[ch]+=1;
                }
                catch (System.Exception)
                {
                    
                    dic[ch]=1;
                }
            }
            int cont = 0;
            var cha=dic.Keys;
            foreach (var c in cha)
            {
                if(dic[c]>=2){
                    cont++;
                }
            }
            return cont;
        }
        static void Main(string[] args)
        {
            int n= DuplicateCount("aabBcde");
            Console.WriteLine(n);
        }
    }
}
