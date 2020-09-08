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
        static void Main(string[] args)
        {
            System.Console.WriteLine(AlphabetPosition("The sunset sets at twelve o' clock."));
        }
    }
}
