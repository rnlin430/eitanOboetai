using System;
using System.IO;
using System.Text;
using CsvHelper;
using System.Collections.Generic;

namespace eitanOboetai
{
    public class EitanOboetai
    {
        static List<Vocabulary> vocabularyList = new List<Vocabulary>();
        public static List<Vocabulary> GetVocabularyList()
        {
            var path = @"tango.csv";
            using ( var csv = new CsvReader( new StreamReader( path ) ) )
            {
                var config = csv.Configuration;
                config.HasHeaderRecord = true;
                config.RegisterClassMap<VocabularyTable>();
                IEnumerable<Vocabulary> list = csv.GetRecords<Vocabulary>();
                foreach( var n in list )
                {
                    // Console.WriteLine( $"{n.vocabulary}, {n.meaning}, {n.pos}" );
                    vocabularyList.Add(n);
                }
                return vocabularyList;
            }
        }

        public static void DisplayVocabularyList()
        {
            
            IEnumerable<Vocabulary> list = GetVocabularyList();
            foreach( var n in list ){
                Console.WriteLine( $"{n.vocabulary}, {n.meaning}, {n.pos}" );
            }
            
        }
    }
}
