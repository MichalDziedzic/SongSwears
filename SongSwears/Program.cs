using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace SongSwears
{
    class Program
    {
        static void Main(string[] args)
        {
            //var eminemSwearStats = new SwearStas();
            var eminemSwearStats = new RapperSwearsStats("Eminem");
            // var song = new Song("Eminem", "Stan");
            // eminemSwearStats.AddSwearsFrom(song);
            eminemSwearStats.AddSong("Stan");

            var twoPacStats = new RapperSwearsStats("2pac");
            twoPacStats.AddSong("changes");
            var rappers = new List<RapperSwearsStats>();
            rappers.Add(eminemSwearStats);
            rappers.Add(twoPacStats);

            var uknowSong = new Song("Eminem","Monster");
            var tinder = new RapperTinder(rappers, uknowSong);



       
            Console.ReadKey();
        }

        
    }

    public class RapperSwearsStats : SwearStas
    {
        public string name;
        public RapperSwearsStats(string name)
        {
            this.name = name;
        }

        public void AddSong(string title)
        {
            var song = new Song(name, title);
            AddSwearsFrom(song);
        }
    }

    public class SwearStas:Censor
    {
        Dictionary<string, int> allSwears = new Dictionary<string, int>();
 
        public void AddSwearsFrom(Song song)
        {
            foreach(var word in badWords)
            {
              var occurences =  song.CountOccurrences(word);
                if (occurences > 0)
                {
                    if (!allSwears.ContainsKey(word))
                        allSwears.Add(word, 0);
                    allSwears[word] += occurences;
                }
            }
        }
 
         public void ShowSummary()
        {
            foreach(var item in allSwears)
            {
                Console.WriteLine(item.Key + "-" + item.Value);
            }
        }

        public int FindCommonSwearsScore(SwearStas anotherStats)
        {
            int score = 0;
           foreach(var myWord in allSwears)
            {
                if(anotherStats.allSwears.ContainsKey(myWord.Key))
                {
                    score++;
                }
                else
                {
                    score--;
                }
            }
            return score;
        }
    }
 
}