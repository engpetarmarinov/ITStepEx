using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {

            var hashset = new HashSet<int>();

            var dic = new Dictionary<string, int>();

            //get all words
            foreach (var arg in args)
            {
                var rawWord = arg.ToLower();
                //filter only words
                var word = Regex.Replace(rawWord, @"[^\w]", "");
                if (word == "") continue;

                if (!dic.ContainsKey(word))
                {
                    dic[word] = 0;
                }
                dic[word] ++ ;
            }

            //Sorting dictionary by value using LINQ
            var sortedDict = from entry in dic
                             orderby entry.Value descending
                             select entry;


            var test = from item in dic
                             orderby item.Value descending
                             select  new { Count =  item.Value, Word = item.Key};

            //Print sorted dictionary
            foreach (var item in sortedDict) {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
        }
    }
}
