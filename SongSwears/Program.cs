using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SongSwears
{
    class Program
    {
        static void Main(string[] args)
        {
            //var songAnalysis = new SongAnalysis("Kazik", "12 groszy");
            //var songAnalysis = new SongAnalysis("2pac", "changes");
            var tekst = "kurwa zgaduje!";
            var censor = new Censor();
            Console.WriteLine(censor.Fix(tekst));

            Console.ReadLine();
        }
    }

    internal class Censor
    {
        string[] badwords;
        public Censor()
        {
            var profanitesFile = File.ReadAllText("profanities.txt");
            profanitesFile = profanitesFile.Replace("*", "");
            profanitesFile = profanitesFile.Replace("(", "");
            profanitesFile = profanitesFile.Replace(")", "");
            profanitesFile = profanitesFile.Replace("\"", "");
            badwords = profanitesFile.Split(',');

            
        }

        public string Fix(string tekst)
        {
            foreach(var word in badwords)
            {
                tekst = ReplaceBadWord(tekst, word);
            }
            return tekst;
        }

        private static string ReplaceBadWord(string tekst, string word)
        {
            var pattern = "\\b" + word + "\\b";
            return Regex.Replace(tekst, pattern, "____",RegexOptions.IgnoreCase);

            //tekst = tekst.Replace(word, "WSEI");
            //return tekst;
        }
    }
    
}
