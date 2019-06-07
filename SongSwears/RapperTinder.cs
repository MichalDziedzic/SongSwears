using System;
using System.Collections.Generic;

namespace SongSwears
{
    internal class RapperTinder
    {
        private List<RapperSwearsStats> rappers;
        private Song uknowSong;

        public RapperTinder(List<RapperSwearsStats> rappers, Song uknowSong)
        {
            this.rappers = rappers;
            this.uknowSong = uknowSong;


            var songSwearStats = new SwearStas();
            songSwearStats.AddSwearsFrom(uknowSong);

            foreach(var rapper in rappers)
            {
                var score = rapper.FindCommonSwearsScore(songSwearStats);
                Console.WriteLine(rapper.name + ":" + score + "points.");
            }

        }
    }
}