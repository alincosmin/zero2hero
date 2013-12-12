using System.Collections.Generic;

namespace FinallySomethingNew.Models
{
    public class Moto
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Image { get; set; }
    }

    public class MotoList
    {
        public static List<Moto> List { get; set; }
    }
}