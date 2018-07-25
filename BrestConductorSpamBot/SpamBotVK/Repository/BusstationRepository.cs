using System;
using System.Collections.Generic;

namespace SpamBotVK.Repository
{
    public class BusstationRepository: IRepository
    {
        private Dictionary<int, Tuple<string, string>> db;

        public Dictionary<int, Tuple<string, string>> GetBusstations()
        {
            InitializeBusstations();
            return db;
        }

        public void InitializeBusstations()
        {
            db = new Dictionary<int, Tuple<string, string>>();
            db.Add(1, new Tuple<string, string>("гузнянская", "ковалево"));
            db.Add(2, new Tuple<string, string>("пугачево", "ковалево"));
            db.Add(3, new Tuple<string, string>("гузнянская", "партизанский"));
            db.Add(4, new Tuple<string, string>("пугачево", "восток"));
            db.Add(5, new Tuple<string, string>("микс", "ковалево"));
            db.Add(6, new Tuple<string, string>("московская алми", "цгб"));
            db.Add(7, new Tuple<string, string>("ленина", "цум"));
            db.Add(8, new Tuple<string, string>("московская универ", "цум"));
            db.Add(9, new Tuple<string, string>("ленина", "парк"));
            db.Add(10, new Tuple<string, string>("парк воинов-интернационалистов", "цгб"));
            db.Add(11, new Tuple<string, string>("гребной", "цум"));
            db.Add(12, new Tuple<string, string>("парк воинов-интернационалистов", "цум"));
            db.Add(13, new Tuple<string, string>("гребной", "ковалево"));
            db.Add(14, new Tuple<string, string>("цум", "московская"));
            db.Add(15, new Tuple<string, string>("микс", "цум"));
            db.Add(16, new Tuple<string, string>("цум", "ленина"));
        }
    }
}