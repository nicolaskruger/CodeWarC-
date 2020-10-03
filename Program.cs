using System;
using System.Linq;
using System.Collections.Generic;
namespace codeWar
{
    class Program
    {
        public static KeyValuePair<string,int> getTupla(string str){
            int val = str.Sum( s => (int)(s-'a'+1));
            return new KeyValuePair<string, int>(str,val);
        }
        public static string High(string s)
        {
            int maior =0;
            return
            s.Split(" ").Select(ss =>{
                KeyValuePair<string,int> valuePair= getTupla(ss);
                if(valuePair.Value>maior) maior = valuePair.Value;
                return valuePair;
            })
                    .ToArray()
                    .Where( v => v.Value==maior)
                    .First().Key;
        }
        static void Main(string[] args)
        {
            var tupla = High("man i need a taxi up to ubud");
        }
    }
}
