using System;
using System.Collections.Generic;
using System.Linq;
namespace codeWar
{
    class Program
    {
        static
        Dictionary<string,string> cord = new Dictionary<string, string>(){
            {"n","x"},
            {"s","x"},
            {"e","y"},
            {"w","y"},
        };
        static
        Dictionary<string,int> passo = new Dictionary<string, int>(){
            {"n",1},
            {"s",-1},
            {"e",1},
            {"w",-1},
        };

        public static bool IsValidWalk(string[] walk)
        {      
            if(walk.Length!=10) return false;
            Dictionary<string,int> pos = new Dictionary<string, int>(){
                {"x",0},
                {"y",0}
            };
            foreach (var p in walk)
            {
                pos[cord[p]]+=passo[p];    
            }
            
            return pos["x"]==0&&pos["y"]==0;
        }
        static void Main(string[] args)
        {
            bool val = IsValidWalk(new string[] {"n","n","n","s","n","s","n","s","n","s"});
        }
    }
}
