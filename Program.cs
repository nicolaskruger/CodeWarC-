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
            var N = n.ToString();
            for (int i = N.Length-2; i >=0; i--)
            {
                try
                {
                    string sub = N.Substring(i+1);
                    char d = sub.Where(c => c<N[i]).OrderBy(c => c).Last();
                    int index = sub.IndexOf(d)+1+i;
                    char [] ch =N.ToArray();
                    ch.swap(i,index);
                    if(ch[0]=='0') throw new Exception();
                    List<char> li1 = ch.Take(i+1).ToList();
                    List<char> li2 = ch.Skip(i+1).OrderByDescending(c=>c).ToList();
                    li1= li1.Concat(li2).ToList();
                    return long.Parse(string.Join("",li1));
                }
                catch (System.Exception)
                {
                    
                }
                
            }
            
            return -1;
            
        }
        public static string splitBy(string text, string[] commentSymbols){
            try
            {
                int index= commentSymbols.Select(c =>text.IndexOf(c)).Where(c => c!=-1).OrderBy(c => c).First();
                return text.Substring(0,index).TrimEnd();    
            }
            catch (System.Exception)
            {
                
                return text.TrimEnd();
            }
            
        }
        public static string StripComments(string text, string[] commentSymbols)
        {
            return string.Join("\n",text.Split("\n").Select(c => splitBy(c,commentSymbols)));
        }
        public static string UInt32ToIP(uint ip)
        {
          uint mask = (1<<8)-1;
          List<string> list = new List<string>();
          for (int i = 3; i >= 0; i--)
          {
              uint n = (ip>>((i)*8))&mask;
              list.Add(n.ToString());
          }
          return string.Join(".",list);
        }
        public static bool ehPrimo(int n){
            if(n==2)return true;
            var arr= Enumerable.Range(2,(n-2)).Where(s =>((n%s)==0)).ToArray();//.Length==0;
            return arr.Length==0;
        }
        public static Dictionary<int,int> todosOsPrimos(int n){
            Dictionary<int,int> dic = new Dictionary<int, int>();
            foreach (var item in Enumerable.Range(2,n).Where(s =>ehPrimo(s)))
            {
                dic[item]=0;
            } 
            return dic;
        }
        public static int lDiv(this int n){
            for (int i = n-1; i >0; i--)
            {
                if(n%i==0)return i;
            }
            return 0;
        }
        public static string sumOfDivided(int[] lst) {
                int val = lst.OrderBy(c => c).Last();
                if(val<0) val =-lst.OrderBy(c => c).First();
               Dictionary<int,int> prim = todosOsPrimos(val);
                HashSet<int> toch=new HashSet<int>();
                foreach (var l in lst)
                {
                    prim =
                    prim.ToDictionary(k => k.Key,k => {
                        if(l%k.Key==0){
                            toch.Add(k.Key);
                            return k.Value+l/k.Key;
                        }
                        return k.Value;
                    });
                } 

                return string.Join("",prim.Where(k =>toch.Contains(k.Key)).OrderBy(k=>k.Key).Select(k => $"({k.Key} {k.Key*k.Value})")); 
           
        }
        public delegate void func(string str,string val);
        public static int pos=0;
        public static Dictionary<string,int> regS=new Dictionary<string, int>();
        public static Dictionary<string,func> oper= new Dictionary<string, func>(){
            {"mov",mov},
            {"inc",inc},
            {"dec",dec},
            {"jnz",jnz}
        };
        public static void mov(string str,string val){
            if(regS.ContainsKey(val)){
                regS[str]=regS[val];
            }else{
                regS[str]=int.Parse(val);
            }
        }
        public static void inc(string str,string val){
            if(regS.ContainsKey(str))
                regS[str]+=1;
            else
                regS[str]=1;
        }
        public static void dec(string str,string val){
            if(regS.ContainsKey(str))
                regS[str]-=1;
            else
                regS[str]=-1;
        }
        public static void jnz(string str,string val){
            int strV = regS.ContainsKey(str)?regS[str]:int.Parse(str);
            int valV = regS.ContainsKey(val)?regS[val]:int.Parse(val);
            if(strV==0) return;
            pos +=valV-1;
        }
        
        public static Dictionary<string, int> Interpret(string[] program)
        {
            regS.Clear();
            pos=0;
           List<string[]> memoria = program.Select(
               s =>{
                   string[] ss = s.Split(" ");
                   try
                   {
                       return new string[]{
                           ss[0],ss[1],ss[2]
                       };
                   }
                   catch (System.Exception)
                   {
                       return new string[]{
                           ss[0],ss[1],"0"
                       };
                   }
               }
           ).ToList();
           while(pos<memoria.Count){
               oper[memoria[pos][0]](memoria[pos][1],memoria[pos][2]);
               pos++;
           }
           return regS;
        }
        public static bool validWord(string str){
            if(str=="")return false;
            bool b =true;
            while(b){
                int index = str.IndexOf('\'');
                if(index==-1)return true;
                try
                {
                    char a =str[index-1];
                    char c =str[index+1]; 
                    if((str[index-1]>='a'&&str[index-1]<='z')||
                        (str[index+1]>='a'&&str[index+1]<='z')){

                    }else{
                        return false;
                    }
                    str =str.Substring(index+1);
                }
                catch (System.Exception)
                {
                    
                    return false;
                }
            }
            return true;
        }
        public static List<string> Top3(string s)
        {
            return string.Join("", s.ToLower().Select((c) =>{
                if((c>='a'&&c<='z')||c=='\''){
                    return c;
                }
                return ' ';
            })
            ).Split(" ").Where(c=>validWord(c)).GroupBy(c =>c).ToDictionary(x => x.First(),x =>x.Count()).OrderByDescending(x => x.Value).Take(3).Select(x=>x.Key).ToList();
        }
        static void Main(string[] args)
        {
            // for (int i = 2; i < 10; i++)
            // {
            //     ehPrimo(i);
            // }
        //    System.Console.WriteLine(sumOfDivided(new int[] {107, 158, 204, 100, 118, 123, 126, 110, 116, 100}));
            // Interpret(new[] {"mov a 5", "inc a", "dec a", "dec a", "jnz a -1", "inc a"}).print();
            Top3("  //wont won't won't ").print();
        }
    }
}
