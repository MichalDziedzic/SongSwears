using System;
using System.Collections.Generic;

namespace SongSwears
{
     public class SwearStatistics :Censor
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

        public int CompareWith(SwearStatistics anotherStats)
        {
            int score = 0;
            foreach(var myWord in allSwears)
            {
                if (anotherStats.allSwears.ContainsKey(myWord.Key))
                    score++;
                //else
                   // score--;
            }
            return score;
        }
    }

}
