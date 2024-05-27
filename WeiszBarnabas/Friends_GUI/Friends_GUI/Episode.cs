using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Friends_WPF.Models
{
    public class Episode
    {
        public int id { get; private set; }
        public string name { get; private set; }
        public int seasonId { get; private set; }
        public int number { get; private set; }
        public DateTime airstamp { get; private set; }
        public int runtime { get; private set; }
        public string img { get; private set; }
        public string summary { get; private set; }
    }
}
