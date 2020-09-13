using System;
using System.Collections.Generic;
using System.Linq;
namespace codeWar
{
    static class Program
    {
        
        public static string Longest(string s1, string s2)
        {
            s1+=s2;
            char[] ss= s1.OrderBy(c=>c).Distinct().ToArray();
            return string.Join("",ss);
        }
        public static void print<T>(this T[] lis){
            System.Console.WriteLine(string.Join("\n",lis));
        }
        public static char FindMissingLetter(char[] array)
        {
          IEnumerable<int> emu=  Enumerable.Range(array[0],25);
          return (char)Enumerable.Range(array[0], 25).First(x => !array.Contains((char)x));
        }
        public static string cleanTheString(string str){
            return string.Join("",str.Where(s=> s=='('||s==')').ToArray());
        }
        public static bool ValidParentheses(string input)
        {
            // Your code here
            input = cleanTheString(input);
            while(input!=""){
                string after=input;
                input= input.Replace("()","");
                System.Console.WriteLine(input);
                if(after==input) return false;
            }
            return true;
            
        }
        public static int MaxSequence(int[] arr) 
        { 
          //TODO : create code
          if(arr.Length==0) return 0;
          int maxSr= arr[0];
          int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if(maxSr+arr[i]>arr[i]){
                    maxSr=maxSr+arr[i];
                }else{
                    maxSr=arr[i];
                }
                if(maxSr>max){
                    max=maxSr;
                }
            }
            return max;
        }
        public static string AlphabetPosition(string text)
        {
          text=text.ToLower();
          text= string.Join("",text.Where(text=> text>='a'&& text<='z').ToArray());
          return string.Join(" ",text.Select(text=>text-'a'+1).ToArray());  
        }
        public static long pot(long n){
            long[] arr= Array.ConvertAll(n.ToString().Select(n=>n).ToArray(),s=>long.Parse(s.ToString()));
            long soma=0;
            for (int i = 0; i < arr.Length; i++)
            {
                soma+=(long)Math.Pow(arr[i],i+1);
            }
            return soma;
        }
        public static long[] SumDigPow(long a, long b) 
        {
            // your code
            long[] squares = Array.ConvertAll(Enumerable.Range((int)a, (int)(b-a)).ToArray(),s=>(long)s);
            squares= squares.Where(s=>s==pot(s)).ToArray();
            return squares;

        }
        public static int fact(int n){
            if(n==0){
                return 1;
            }
            return n*fact(n-1);
        }
        public static int TrailingZeros(int n)
        {
          n =fact(n);
          bool zero=false;
          int cont=0;
          foreach (var c in n.ToString())
          {
              if(c=='0'){
                  if(!zero){
                      cont++;
                  }
                  zero=true;
              }
              else{
                  zero=false;
              }
          }
          return cont;
        }
        public static void print<T>(this IEnumerable<T> lis){
            foreach (var l in lis)
            {
                System.Console.WriteLine(l);
            }
        }
        public static Dictionary<int,int> Factor(int number) {
            int div=2;
            Dictionary<int,int> dic =new Dictionary<int, int>();
            while (number!=1)
            {
                if(number%div==0){
                    number/=div;
                    try
                    {
                        dic[div]+=1;
                    }
                    catch (System.Exception)
                    {
                        
                        dic[div]=1;
                    }
                }else{
                    div++;
                }
            }
            return dic;
        }
        static int GCD(int[] numbers)
        {
            return numbers.Aggregate(GCD);
        }

        static int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
        public static (int, int)? IsPerfectPower(int n)
        {
            Dictionary<int,int> fac= Factor(n);
            if(fac.Count>1){
                int gcd = GCD(fac.Values.ToArray());
                if(gcd==1) return null;
                var elev= fac.Select((s)=> (int)Math.Pow(s.Key,s.Value/gcd)).Aggregate(1,(x,y) => x*y);
                return (elev,gcd);
                // int[] elev= fac.Values.Select(s=>s/gcd).ToArray();
            }else{
                if(fac.Values.First()==1) return null;
                return (fac.Keys.First(),fac.Values.First());
            }
            return null;
        }
        public static char toR13(char l){
            char[] bgl = new char[]{
                'A','a'
            };
            char[] endl = new char[]{
                'Z','z'
            };
            char[] midl = new char[]{
                'M','m'
            };
            int i =0;
            if(l>=bgl[0]&&l<=endl[0]) i=0;
            else if(l>=bgl[1]&&l<=endl[1]) i=1;
            else return l;
            if(l>midl[i]) return (char)(l-13);
            else return (char)(l+13);
        }
        public static string Rot13(string input)
        {
            return string.Join("",input.Select(s=>toR13(s)).ToArray());
        }
        static void Main(string[] args)
        {
            System.Console.WriteLine(Rot13("EBG13 rknzcyr."));
            // v.print();
        }
    }
}
