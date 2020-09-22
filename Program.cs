using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Runtime;
using System.Globalization;
namespace codeWar
{
    static class Program
    {        
        static char div = '/';
        static char mul = '*';
        static char sum = '+';
        static char sub = '-';
        static char[] op = new char[]{
            div,mul,sum,sub
        };
        static Regex divid = new Regex(@"\-?\d{0,1000}\.?\d{0,1000}[/]\-?\d{0,1000}\.?\d{0,1000}");
        static Regex mult = new Regex(@"\-?\d{0,1000}\.?\d{0,1000}[*]\-?\d{0,1000}\.?\d{0,1000}");
        static Regex suma = new Regex(@"\d{0,1000}\.?\d{0,1000}[+]\d{0,1000}\.?\d{0,1000}");
        static Regex subt = new Regex(@"\d{0,1000}\.?\d{0,1000}[-]\d{0,1000}\.?\d{0,1000}");
        
        static Regex[] oper = new Regex[]{
            divid,mult,suma,subt
        };
        public delegate double Oper(double a, double b);
        static Oper[] operation = new Oper[]{
            (a,b) => (a/b),
            (a,b) => (a*b),
            (a,b) => (a+b),
            (a,b) => (a-b),
        };
        public static Regex parent = new Regex(@"\([^\(|^\)]{0,1000000000}\)");
        public static string cleanString(string str){
            return string.Join("",str.Where(s => s=='('||s==')'||(s>='1'&&s<='9') || s=='/'||s=='*'||s=='+'||s=='-').ToArray());
        }
        public static double solveSimple(string str){
            //System.Console.WriteLine(double.Parse(str));
            try
            {
                double valor= double.Parse(str);
                return valor;
            }
            catch (System.Exception)
            {
                for (int i = 0; i < op.Length; i++)
                {
                   MatchCollection matches = oper[i].Matches(str);
                    if(matches.Count>0){
                        var math= matches[0];
                        string[] st = math.Value.Split(op[i]).ToArray();
                        double val = operation[i](double.Parse(st[0]),double.Parse(st[1]));
                        str= str.Remove(math.Index,math.Value.Length);
                        str= str.Insert(math.Index,val.ToString());
                        return solveSimple(str);  
                    } 
                }
            }
            return 0;
        }
        public static double solveParentese(string str){
            MatchCollection matches = parent.Matches(str);
            if(matches.Count>0){
                var math = matches[0];
                string st = math.Value;
                st= st.Substring(1,st.Length-2);
                double val = solveSimple(st);
                str= str.Remove(math.Index,math.Value.Length);
                str= str.Insert(math.Index,val.ToString());
                return solveParentese(str);
            }else{
                return solveSimple(str);
            }
            return 0;
        }
        static public double Evaluate(string expression)
        {
            expression = cleanString(expression);
            return solveParentese(expression);
            
        }
        static void Main(string[] args)
        {
            //int n;
            CultureInfo cult = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture =cult;
            System.Console.WriteLine(Evaluate("2 / (2 + 3) * 4 - 6"));
        }
    }
}
