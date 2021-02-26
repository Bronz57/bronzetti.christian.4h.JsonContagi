using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
namespace bronzetti.christian._4h.JSONContagi
{
    //1. Trasformare il file JSON fornito in un secondo file in cui il formato Data risulta conforme allo
    //standard italiano.
    class Program
    {
        static string LeggiFileJson(string path)
        {
            using (StreamReader sr = new StreamReader(path))
                return sr.ReadToEnd();
        }

        static void Main(string[] args)
        {
            //percoso del file
            string path = @"ContagiRimini.json";

            //copio tutto il file json in una stringa
            string statisticheJson = LeggiFileJson(path);

            //deserializzo
            var objectDeserialized = JsonConvert.DeserializeObject<List<Statistica>>(statisticheJson);

            //per ogni data la converto nello stile italiano
            foreach (var s in objectDeserialized)
                s.TrasformaDataInFormatoItaliano();

            //riserializzo tutto
             string prova = JsonConvert.SerializeObject(objectDeserialized, Formatting.Indented);
            
            //scrivo nel file nuovo 
            File.WriteAllText("ContagiRiminiRiformattato.json", prova.ToString());

            Console.WriteLine("Dati salvati... Controllare nel seguente percoso bin/debug/'ContagiRiminiRiformattato.json'");
        }
    }
}
