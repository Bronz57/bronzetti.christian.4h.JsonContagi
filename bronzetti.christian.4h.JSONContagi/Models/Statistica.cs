using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace bronzetti.christian._4h.JSONContagi
{
    class Statistica
    {
        public string Data { get; set; }
        public int Progressivo { get; set; }
        public int Contagi { get; set; }

        //costruttore con parametri
        public Statistica(string d, int p, int c)
        {
            Data = d;
            Progressivo = p;
            Contagi = c;
        }

        public Statistica() { }
       public void TrasformaDataInFormatoItaliano()
       {

            //prendo la data in string e la converto in dateTime
            DateTime retVal = DateTime.ParseExact(Data.ToString(), "M/d/yy", CultureInfo.GetCultureInfoByIetfLanguageTag("en-GB"));

            //per ogni componente della data salvo i dati
            int giorno = retVal.Day;
            int mese = retVal.Month;
            int anno = retVal.Year;

            //riscrivo
            Data = $"{giorno}/{mese}/{anno}";
       }
    }
}
