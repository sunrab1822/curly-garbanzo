using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Friends_Console
{
    public class Episode
    {
        public int id { get; set; }
        public string name { get; set; }
        public int seasonId { get; set; }
        public int number { get; set; }
        public DateTime airstamp { get; set; }
        public int runtime { get; set; }
        public string img { get; set; }
        public string summary { get; set; }


        public static List<Episode> LoadFromJSON(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            string json = sr.ReadToEnd();
            return JsonSerializer.Deserialize<List<Episode>>(json);

        }
    }
}
