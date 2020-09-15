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
            var s1 = "NOPQRSTUVWXYZABCDEFGHIJKLMnopqrstuvwxyzabcdefghijklm";
            var s2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return string.Join("", input.Select(x => char.IsLetter(x)?s1[s2.IndexOf(x)]:x));
        }
        static Dictionary<char,char[]> Allpos = new Dictionary<char, char[]>{
            {'1',new char[]{'1','2','4'}},
            {'2',new char[]{'1','2','3','5'}},
            {'3',new char[]{'2','3','6'}},
            {'4',new char[]{'1','4','5','7'}},
            {'5',new char[]{'2','4','5','6','8'}},
            {'6',new char[]{'3','5','6','9'}},
            {'7',new char[]{'4','7','8'}},
            {'8',new char[]{'5','7','8','9','0'}},
            {'9',new char[]{'6','8','9'}},
            {'0',new char[]{'8','0'}}
        };
        public static char[] getAllpossibilits(char c){
            return Allpos[c];
        }
        public static List<string> GetPINs(string observed)
        {
            string[] AllPos=new string[]{
                ""
            };
            char[]ch= observed.Select(x=>x).ToArray();
            foreach (var c in ch)
            {
                char[] cha = getAllpossibilits(c);
                AllPos=  (from a in AllPos
                        from cc in cha
                        select a + cc.ToString()).Distinct().ToArray();
            }
            return AllPos.ToList();
        }
    public static Dictionary<string,string> morse = new Dictionary<string, string>(){
            {".-.-.-","."},
            {"-.-.--","!"},
            {"",""},
            {"...---...","SOS"},
            {".-","A"},
            {"-...","B"},
            {"-.-.","C"},
            {"-..","D"},
            {".","E"},
            {"..-.","F"},
            {"--.","G"},
            {"....","H"},
            {"..","I"},
            {".---","J"},
            {"-.-","K"},
            {".-..","L"},
            {"--","M"},
            {"-.","N"},
            {"---","O"},
            {".--.","P"},
            {"--.-","Q"},
            {".-.","R"},
            {"...","S"},
            {"-","T"},
            {"..-","U"},
            {"...-","V"},
            {".--","W"},
            {"-..-","X"},
            {"-.--","Y"},
            {"--..","Z"},
            {".----","1"},
            {"..---","2"},
            {"...--","3"},
            {"....-","4"},
            {".....","5"},
            {"-....","6"},
            {"--...","7"},
            {"---..","8"},
            {"----.","9"},
            {"-----","0"}
        };
        public static string decodeWord(string str){
            string[] st =str.Split(" ");
            return string.Join("",st.Select(s=>morse[s]));
        }
        public static string Decode(string morseCode)
	    {
	    	return string.Join(" ",morseCode.Split("   ").Select(s=>decodeWord(s)).Where(s=>s!="")); 
	    }
        public static int dec(ref long num){
            int subNum=(int)num;
            int m= Enumerable.Range(1,(int)num).Where(s => s*s<=subNum).Last();
            num=num-m*m;
            return m; 
        }
        public static string decompose(long n) {
            List<int> l= new List<int>();
            int m=0;
            n=n*n-1;
            m = dec(ref n);
            l.Add(m);
            n+=1;
            while(n>0){
                m = dec(ref n);
                l.Add(m);
                if(n==0){
                    if(l.GroupBy(s =>s).Select(s => s.Count()).Where(s => s>1).ToArray().Length >0) return "Nothing";
                    return string.Join(" ",l.OrderBy(s => s).Select(s => s.ToString()).ToArray());
                }
            }
            return "Nothing";
        }
        public static int[] ArrayDiff(int[] a, int[] b)
        {
            return a.Where(n => !b.Contains(n)).ToArray();
        }
        public static int Teste(int number) => number >= 10000000 ? -1 : Convert.ToInt32(new string(number.ToString().OrderByDescending(x => x).ToArray()));
        public static void swap<T>(this T[] lis,int posI,int posF ){
            T val = lis[posI];
            lis[posI]=lis[posF];
            lis[posF]=val;
        }
        public static long NextSmaller(long n)
        {
            var ch =n.ToString().ToArray();
            var vall = GeneratePermutations(ch,null).Where(c =>c.ToArray()[0]!='0').
                        Select(c =>long.Parse(string.Join("",c.ToArray()))).
                        OrderBy(c => c).ToArray();
            try
            {
                var val = vall.Where(c => c<n).Last();
                return val;    
            }
            catch (System.Exception)
            {
                
                return -1;
            }
            
        }
       public static IList<T[]> GeneratePermutations<T>(T[] objs, long? limit)
    {
        var result = new List<T[]>();
        long n = Factorial(objs.Length);
        n = (!limit.HasValue || limit.Value > n) ? n : (limit.Value);

        for (long k = 0; k < n; k++)
        {
            T[] kperm = GenerateKthPermutation<T>(k, objs);
            result.Add(kperm);
        }

        return result;
    }

    public static T[] GenerateKthPermutation<T>(long k, T[] objs)
    {
        T[] permutedObjs = new T[objs.Length];

        for (int i = 0; i < objs.Length; i++)
        {
            permutedObjs[i] = objs[i];
        }
        for (int j = 2; j < objs.Length + 1; j++)
        {
            k = k / (j - 1);                      // integer division cuts off the remainder
            long i1 = (k % j);
            long i2 = j - 1;
            if (i1 != i2)
            {
                T tmpObj1 = permutedObjs[i1];
                T tmpObj2 = permutedObjs[i2];
                permutedObjs[i1] = tmpObj2;
                permutedObjs[i2] = tmpObj1;
            }
        }
        return permutedObjs;
    }
      public static long Factorial(int n)
    {
        if (n < 0) { throw new Exception("Unaccepted input for factorial"); }    //error result - undefined
        if (n > 256) { throw new Exception("Input too big for factorial"); }  //error result - input is too big

        if (n == 0) { return 1; }

        // Calculate the factorial iteratively rather than recursively:

        long tempResult = 1;
        for (int i = 1; i <= n; i++)
        {
            tempResult *= i;
        }
        return tempResult;
    }
        static void Main(string[] args)
        {
            // int[]n= new int[]{
            //     1,2
            // };
            // n.swap(0,1);
            // n.print();
            
            
           System.Console.WriteLine(NextSmaller(29009));
        }
    }
}
