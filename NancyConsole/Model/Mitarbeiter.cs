using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NancyConsole.Model
{
    public class Mitarbeiter
    {
        private static List<Mitarbeiter> mMITARBEITER = null;
        public static List<Mitarbeiter> GetList()
        {
            if (mMITARBEITER == null)
            {
                mMITARBEITER = new List<Mitarbeiter>();
                mMITARBEITER.Add(new Mitarbeiter()
                {
                    Vorname = "Karl",
                    Name = "Sparwald"
                });
            }
            return mMITARBEITER;
        }

        public string Vorname { get; set; }
        public string Name { get; set; }
    }
}
