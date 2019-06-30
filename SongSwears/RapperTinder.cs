using System;
using System.Collections.Generic;

namespace SongSwears
{
    class RapperTinder
    {
         List<RapperSwearStats> rappers;
         Song unknownSong;

        public RapperTinder(List<RapperSwearStats> rappers, Song unknownSong)
        {
            this.rappers = rappers;
            this.unknownSong = unknownSong;

            var songSwearStats = new SwearStatistics();
            songSwearStats.AddSwearsFrom(unknownSong);

            var maxScore = 0;
            var topRapperName = "";

            foreach ( var rapper in rappers)
            {
                    var score = rapper.CompareWith(songSwearStats);
                    Console.WriteLine(rapper.name + ":" + score + "points");

                    if (score > maxScore)
                    {
                        maxScore = score;
                        topRapperName = rapper.name;
                    }
                
            }
            Console.WriteLine($"{topRapperName}");
        }
    }
}
