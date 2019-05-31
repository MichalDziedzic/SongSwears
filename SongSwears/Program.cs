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
            //var song = new Song("2pac", "changes");
            var song = new Song("Eminem", "Stan");
            // var tekst = "kurwa zgaduje!";
            var censor = new Censor();

            var eminemSwearStats = new SwearStats();
            eminemSwearStats.AddSwearsFrom(song);
            Console.WriteLine(censor.Fix(song.lyrics));

            Console.ReadLine();
        }
    }

    public class SwearStats:Censor
    {
        public SwearStats()
        {
            Dictionary<string, int> allSwears = new Dictionary<string, int>();
        }

        public void AddSwearsFrom(Song song)
        {
            foreach (var word in badWords)
        {
            song.occurrences = song.CountOccurrences(word);
        }
        }
    }

    public class Censor
    {
        string[] badwords;
        protected Censor()
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
