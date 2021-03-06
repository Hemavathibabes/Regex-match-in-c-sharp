﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Match_and_Replace
{
    class Program
    {
        static void Main(string[] args)
        {

            //Different Match() functions

            //Match(string input)
           String pattern = @"\d+";
            Regex re = new Regex(pattern);
            String input = "The number of chocolates is 232";
            Match match = re.Match(input);

            if(match.Success)
            {
                Console.WriteLine("The decimal number is {0} ",match.Value);
            }
            

            //Match(string input,string pattern,regexoptions)

           
            String pat = @"\ba\w*\b";
             string inp =  "An Extradinory day come soon";
             Match mat = Regex.Match(inp,pat, RegexOptions.IgnoreCase);
             if(mat.Success)
             {
                 Console.WriteLine("The match value '{0}' is found at {1}",mat.Value,mat.Index);
             }


             //Match(string input,string pattern)

            string i= "The sentence matches a string" + " The Sentence contains a word start with s" + "match function recognized the all words contains s";
            string p = @"\b\w*s+\w*\b";
            Match m = Regex.Match(i, p);
            
            
            while(m.Success)
            {
                Console.WriteLine("word found at {0} index, value is {1}", m.Index,m.Value);
                m = m.NextMatch();
            }


            //Matches(string input,string pattern,regexoptions,timespan)

            string patt = @"\b\w+es\b";
            string inpp = "Notes: any notes and comments are optional";
            try
            {
                foreach(Match matt in Regex.Matches(inpp,patt,RegexOptions.IgnoreCase, TimeSpan.FromSeconds(1)))
                {
                    Console.WriteLine("Match found at {0}index value is {1}", matt.Index, matt.Value);
                }

            }
            catch
            {
                Console.WriteLine("Match not found,time expired");
            }

            //Different Replace() functions
            //Replace(string input,string pattern,string replacement)

            string str = "child cry for a Biscuits";
         
            string output = Regex.Replace(str, @"\b\w+ui\w+\b", "icecream");
            Console.WriteLine(output);


            //Replace(string input,string pattern,string replacement,regexopotions)

            string s = "The chief guest gives a award to  VIRAT KOLHI";
            string patte = @"\b\w+ra\w+\s\w+\b";
            string ans = Regex.Replace(s, patte, "ANUSHKA SHARMA", RegexOptions.IgnoreCase);
            Console.WriteLine(ans);

            //Replace(string input,string pattern,string replacement,regexoptions,timespan)

            string sen = "the sentence contains more than hundred words\n" + "the sentence contains more than ten words\n" + "the sentence contains more than one word\n";
            string pan = @"\b\w+re\b"; 
            try
            {
                string answer = Regex.Replace(sen, pan, "less", RegexOptions.IgnoreCase, TimeSpan.FromMinutes(1));
                Console.WriteLine(answer);

            }
            catch
            {
                Console.WriteLine("Timeout!!");
            }

              //MatchEvaluator Delegate..Replace(string input,string pattern,matchevaluator,regexoptions,timespan)

            string text = "aaabbbccddeessskjoeeccdduuullloojjwwddjjjhhhddooouuudd";
            string patternstr = "dd";
            Console.WriteLine("original string :{0}", text);
            Program pr = new Program();
            MatchEvaluator Me = new MatchEvaluator(pr.replacedd);
            string  result= Regex.Replace(text, patternstr, Me, RegexOptions.IgnoreCase,TimeSpan.FromSeconds(1));

            Console.WriteLine("Modified string is {0}", result);


            //Replace(string input,string pattern,matchevaluator)

            string text2 = "the prime minister of india is narendra modi.";
            string patternstr2 = @"\w+";
            Console.WriteLine("original string is :{0}", text2);
            MatchEvaluator Me2 = new MatchEvaluator(pr.changeupper);
            string result2 = Regex.Replace(text2, patternstr2, Me2);
            Console.WriteLine("Modified sentence is :{0}", result2);

            Console.ReadLine();
        }
        
         static int i = 0;
        public string replacedd(Match mat)
        {
            i++;
            return i.ToString() + i.ToString();
        }
        public string changeupper(Match matt)
        {
            string sr = matt.ToString();
            if(char.IsLower(sr[0]))

            {
                return char.ToUpper(sr[0]) + sr.Substring(1, sr.Length - 1);
            }
            return sr;
        }
    }
}
