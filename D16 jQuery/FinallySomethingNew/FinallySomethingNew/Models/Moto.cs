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
        private static List<Moto> mList { get; set; }

        public static List<Moto> List()
        {
            if (mList == null)
            {
                mList = new List<Moto>();
                return mList;
            }

            return mList;
        }

        public static void Add(Moto moto)
        {
            if (mList == null)
                mList = new List<Moto>();
            mList.Add(moto);
        }
    }
}