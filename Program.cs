using System;
using System.Collections.Generic;
namespace codeWar
{
    class Program
    {
        public delegate double Oper(double a, double b);
        static Dictionary<string,Oper> oper = new Dictionary<string,Oper>(){
            {"/",(a,b) => (a/b)},
            {"*",(a,b) => (a*b)},
            {"+",(a,b) => (a+b)},
            {"-",(a,b) => (a-b)},
        };
        public static double basicOp(char operation, double value1, double value2)
        {
          return oper[operation.ToString()](value1,value2);
        }

        static void Main(string[] args)
        {
            
        }
    }
}
