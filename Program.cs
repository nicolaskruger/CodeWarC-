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
       

        static string divMult = @"\-?\d+\.?\d*([/*])\-?\d*\.?\d*";
        static string sumSub = @"\-?\d+\.?\d*";
        static Regex DivMult = new Regex(divMult);
        static Regex SumSub = new Regex(sumSub);
        public delegate double Oper(double a, double b);
        static Dictionary<string,Oper> operation = new Dictionary<string,Oper>(){
            {"/",(a,b) => (a/b)},
            {"*",(a,b) => (a*b)},
            {"+",(a,b) => (a+b)},
            {"-",(a,b) => (a-b)},
        };
        public static Regex parent = new Regex(@"\([^\(|^\)]*\)");
        public static string cleanString(string str){
            str= string.Join("",str.Where(s => s=='('||s==')'||(s>='0'&&s<='9') || s=='/'||s=='*'||s=='+'||s=='-'||s=='.').ToArray());
            str = str.Replace("--","+");
            str = str.Replace("/+","/");
            str = str.Replace("*+","*");
            return str;
        }
        public static double solveSimple(string str){
            try
            {
                double valor= double.Parse(str);
                return valor;
            }
            catch (System.Exception)
            {
              
                MatchCollection matches = DivMult.Matches(str);
                if(matches.Count>0){
                    var math= matches[0];
                    string gOper = math.Groups[1].Value;
                    string[] st = math.Value.Split(gOper).ToArray();
                    double val = operation[gOper](double.Parse(st[0]),double.Parse(st[1]));
                    str= str.Remove(math.Index,math.Value.Length);
                    str= str.Insert(math.Index,val.ToString());
                    return solveSimple(str);
                }
                matches = SumSub.Matches(str);
                double reduce = 0;
                foreach (Match math in matches)
                {
                    string valor = math.Value;
                    reduce += double.Parse(valor);
                }
                return reduce;
            }
        }
        public static double solveParentese(string str){
            str =cleanString(str);
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
        }
        static public double Evaluate(string expression)
        {
            return solveParentese(expression);  
        }
        static void Main(string[] args)
        {
            //int n;
            CultureInfo cult = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture =cult;
            System.Console.WriteLine(Evaluate("2 / (2 + 3) * 4.33 - -6"));
        }
    }
}
