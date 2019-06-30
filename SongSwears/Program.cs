using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchingCurses;


namespace SongSwears
{
    class Program
    {
        static void Main(string[] args)
        {

            var eminemSwearStats = new RapperSwearStats(name: "Eminem");
            eminemSwearStats.AddSong(title: "Stan");
            eminemSwearStats.AddSong(title: "Lose Yourself");
            eminemSwearStats.AddSong(title: "Not Afraid");
            eminemSwearStats.AddSong(title: "The Real Slim Shady");
            eminemSwearStats.AddSong(title: "When I'm gone");
            eminemSwearStats.AddSong(title: "Killshot");

            var twoPacStats = new RapperSwearStats(name: "2Pac");
            twoPacStats.AddSong(title: "Changes");
            twoPacStats.AddSong(title: "Dear Mama");
            twoPacStats.AddSong(title: "Hail Mary");
            twoPacStats.AddSong(title: "Against All Odds");
            twoPacStats.AddSong(title: "Ain't Hard 2 Find");
            twoPacStats.AddSong(title: "Changed Man");

            var KanyeWestStats = new RapperSwearStats(name: "Kanye_West");
            KanyeWestStats.AddSong(title: "Stronger");
            KanyeWestStats.AddSong(title: "Gold_digger");
            KanyeWestStats.AddSong(title: "Ni**as_in_paris");
            KanyeWestStats.AddSong(title: "Mercy");
            KanyeWestStats.AddSong(title: "Otis");
            KanyeWestStats.AddSong(title: "Famous");

            var six9ineStats = new RapperSwearStats(name: "6ix9ine");
            six9ineStats.AddSong(title: "Billy");
            six9ineStats.AddSong(title: "Gotti");
            six9ineStats.AddSong(title: "Tati");
            six9ineStats.AddSong(title: "Kooda");
            six9ineStats.AddSong(title: "Gummo");
            six9ineStats.AddSong(title: "Fefe");








            string pastedText = "";
                
                    Console.WriteLine("wpisz text");
                    
                while (true)
                {
                string line = Console.ReadLine();
                pastedText += line;

                    if (line.ToUpper() == "F")
                    {

                        break;
                    }
                    
                }

                    var rappers = new List<RapperSwearStats>();
                    rappers.Add(eminemSwearStats);
                    rappers.Add(twoPacStats);
                     rappers.Add(KanyeWestStats);
                     rappers.Add(six9ineStats);
                    


                    var unknownSong = new Song(pastedText);
                    var tinder = new RapperTinder(rappers, unknownSong);
            Console.ReadLine();

                    

                }

            
        
        
    }

    public class RapperSwearStats : SwearStatistics
    {
       public string name;
        public RapperSwearStats(string name)
        {
            this.name = name;
        }
        
        public void AddSong(string title)
        {
            var song = new Song(band: name, songName:title);
            AddSwearsFrom(song);
        }
    }
}
