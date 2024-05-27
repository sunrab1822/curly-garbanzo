using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Friends_Console
{
    public static class Solution
    {
        public static List<Episode> episodes { get; set; } = Episode.LoadFromJSON("episodes.json");
        public static List<Season> seasons { get; set; } = Season.LoadFromJSON("seasons.json");

        public static List<Episode> getNameContainedTitles()
        {
            return  episodes.Where(x => x.name.Contains("Monica") || x.name.Contains("Rachel") || x.name.Contains("Phoebe") ).ToList();
        }

        public static string getBetweenDayEpisodes() {



            double maxDays = 0;
            Episode SeasonElsoResz = null;
            Episode SeasonUtolsoResz = null;
            Season Season1 = null;
            Season Season2 = null;
            for (int i = 0; i < seasons.Count-1; i++)
            {
                SeasonUtolsoResz = episodes.Where(x => x.seasonId == seasons[i].id).Last();
                SeasonElsoResz = episodes.Where(x => x.seasonId == seasons[i+1].id).First();

                double actKulombseg = Math.Floor((SeasonElsoResz.airstamp - SeasonUtolsoResz.airstamp).TotalDays);
                
                if (actKulombseg > maxDays)
                {
                    maxDays = actKulombseg;
                    Season1 = seasons[i];
                    Season2 = seasons[i+1];

                }
                
            }


            return $"A(z) {Season1.id}. évad utolsó és a(z) {Season2.id} évad első részének megjelenése között telt el a legtöbb idő, {maxDays} nap.";

        }
    }
}
