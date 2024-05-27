using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Friends_Console
{
    public class Season
    {
        public int id { get; set; }
        public string season { get; set; }
        public string years { get; set; }

        public static List<Season> LoadFromJSON(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            string json = sr.ReadToEnd();
            return JsonSerializer.Deserialize<List<Season>>(json);

        }


    }
}
