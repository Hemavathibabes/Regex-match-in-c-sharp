using System;
using System.Text.RegularExpressions;
namespace Regex_match
{
    class Program
    {
        static void Main(string[] args)
        {

            // Match the word contains "M"  or "m"
           
            String pattern = @"\b[M]\w+";
            Regex rx = new Regex(pattern,RegexOptions.IgnoreCase);

            String authors = "Kalgi,Manivannan,Mike gold,Marshall troll,maya,raj kumar";

            MatchCollection match = rx.Matches(authors);

            for(int count=0;count<match.Count;count++)
            {
                Console.WriteLine("{0} ", match[count].Value);
            }

            //found the Repeated words

            String sentence = "The the boy was roaming around the area area";
         
            String pat = @"\b(?<word>\w+)\s+(\k<word>)\b";
            Regex reg = new Regex(pat,RegexOptions.IgnoreCase);

            MatchCollection matches = reg.Matches(sentence);
            Console.WriteLine("No of repeated words:{0}", matches.Count);
            foreach(Match mat in matches)
            {
                GroupCollection group = mat.Groups;
                Console.WriteLine("{0}", group["word"].Value);
            }


            //Replace() method

            String str = "The sentence has  a more white spaces ";
            String newstr = Regex.Replace(str,"\\s+", " ");
            Console.WriteLine("The cleaned string is {0}", newstr);


            //split() method
            String azpattern = "[a-z]+";
            String s = "Asd2323b0900c1234Def5678Ghi9012Jklm";
            String[] result = Regex.Split(s, azpattern, RegexOptions.IgnoreCase);
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine("{0}", result[i]);
                if (i < result.Length - 1)
                {
                    Console.Write(" ");
                }
            }
                //valid phone number checking

                Regex r = new Regex(@"^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}");

                string[] numbers = { "+91-9678967101", "9678967101", "+91-9678-967101", "+91-96789-67101", "+919678967101","88709031" };

                foreach(String no in numbers)
                {
                    Console.WriteLine("{0} {1} a valid mobile number", no, r.IsMatch(no) ? "is" : "isnot");
                }

            //verify Name and address using Regex

            Console.WriteLine("Enter the name:");
            String name = Console.ReadLine();
           
            if(Regex.Match(name,@"^[A-Z]+\s[a-zA-Z]*$").Success)
            {
                Console.WriteLine("Valid Name");
            }
            else
            {
                Console.WriteLine("Name is not in tha correct format eg: A Hemavathi");

            }
            Console.WriteLine("Enter the Address:");
            String address = Console.ReadLine();
            if(Regex.Match(address,@"^[0-9]+\s+([A-Za-z]+|[A-Za-z]+\s[a-zA-Z]+)*$").Success)
            {
                Console.WriteLine("Valid Address");
            }
            else
            {
                Console.WriteLine("Addres is not in the correct formate eg:24 Murugan nagar");
            }

        }
    }
}
