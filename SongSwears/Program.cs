using SearchingCurses;
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
            
             var eminemSwearStats = new RapperSwearsStats("Eminem");
            
             eminemSwearStats.AddSong("Stan");
           // eminemSwearStats.AddSong("Stan");
            eminemSwearStats.AddSong("Lose Yourself");
            eminemSwearStats.AddSong("Not afraid");
            eminemSwearStats.AddSong("The Real Slim Shady");
            eminemSwearStats.AddSong("When I'm Gone");

            var twoPacStats = new RapperSwearsStats("2pac");
             twoPacStats.AddSong("changes");
            twoPacStats.AddSong("Dear Mama");
            twoPacStats.AddSong("Hail Mary");

            var rappers = new List<RapperSwearsStats>();
             rappers.Add(eminemSwearStats);
             rappers.Add(twoPacStats);

             var uknowSong = new Song("Eminem","Monster");
             var tinder = new RapperTinder(rappers, uknowSong);




            //Console.ReadKey();
            //  Console.WriteLine(WebCache.GetOrDownload("https://wtfismyip.com/text"));
            /*
             *var eminemSwearStats = new RaperSwearStats("Eminem");
              eminemSwearStats.AddSong("Stan");
              eminemSwearStats.AddSong("Lose Yourself");
              eminemSwearStats.AddSong("Not afraid");
              eminemSwearStats.AddSong("The Real Slim Shady");

              var twoPackStats = new RaperSwearStats("2Pac");
              twoPackStats.AddSong("Changes");
              twoPackStats.AddSong("Changes");
              twoPackStats.AddSong("Changes");

              var rapers = new List<RaperSwearStats>();
              rapers.Add(eminemSwearStats);
              rapers.Add(twoPackStats);

              var unknownSong = new Song(band: "Eminem", song: "Monster");
              var tinder = new RaperTinder(rapers, unknownSong);

              Console.ReadKey();
             */
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
              //  else
                //{
                 //   score--;
                //}
            }
            return score;
        }
    }
 
}