using System;
using System.Linq;
using System.Collections.Generic;

namespace codeWar
{
    class Program
    {
        static Dictionary<string,char> xor = new Dictionary<string, char>(){
            {"00",'0'},
            {"01",'1'},
            {"10",'1'},
            {"11",'0'},
        };
        public static long Mystery(long n)
        {
            string str = Convert.ToString(n,2);
            char def='0';
            str= string.Join("",
            str.Select(c =>{
                char val=xor[def.ToString()+c.ToString()];
                def=c;
                return val;
            }));  
            return Convert.ToInt64(str,2);
        }

        public static long MysteryInv(long n)
        {
            string str = Convert.ToString(n,2);
            char def='0';
            str= string.Join("",
            str.Select(c =>{
                char val=xor[def.ToString()+c.ToString()];
                def=val;
                return val;
            }));  
            return Convert.ToInt64(str,2);
        }

        public static string NameOfMystery()
        {
            return "";
        }
        static void Main(string[] args)
        {
           long n=  MysteryInv(5);   
        }
    }
}
