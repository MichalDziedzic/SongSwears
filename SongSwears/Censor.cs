using System.IO;
using System.Text.RegularExpressions;

namespace SongSwears
{
    public class Censor
    {
       protected string[] badWords;

        public Censor()
        {
            var profanitiesFile = File.ReadAllText("profanities.txt");
            profanitiesFile = profanitiesFile.Replace("*", "");
            profanitiesFile = profanitiesFile.Replace("(", "");
            profanitiesFile = profanitiesFile.Replace(")", "");
            profanitiesFile = profanitiesFile.Replace("\"", "");
            badWords = profanitiesFile.Split(',');


        }

        internal string Fix(string tekst)
        {
            foreach (var word in badWords)
            {
                tekst = ReplaceBadWord(tekst, word);
            }
            return tekst;
        }



        private static string ReplaceBadWord(string tekst, string word)
        {
            var pattern = "\\b" + word + "\\b";
            return Regex.Replace(tekst, pattern, "_____",RegexOptions.IgnoreCase);
        }
    }

}
