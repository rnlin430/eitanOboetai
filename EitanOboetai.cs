using System;
using System.IO;
using System.Text;
using CsvHelper;
using System.Collections.Generic;

namespace eitanOboetai
{
    public class EitanOboetai
    {
        public static IEnumerable<Vocabulary> GetVocabularyList()
        {
            var path = @"tango.csv";
            using ( var csv = new CsvReader( new StreamReader( path ) ) )
            {
                var config = csv.Configuration;
                config.HasHeaderRecord = true;
                config.RegisterClassMap<VocabularyTable>();
                IEnumerable<Vocabulary> list = csv.GetRecords<Vocabulary>();
                return list;
            }
        }

        public static void DisplayVocabularyList()
        {
            IEnumerable<Vocabulary> gvl = GetVocabularyList();
            foreach( var n in gvl ){
                Console.WriteLine( $"{n.vocabulary}, {n.meaning}, {n.pos}" );
            }
        }
    }
}
