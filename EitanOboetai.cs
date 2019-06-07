using System;
using System.IO;
using System.Text;
using CsvHelper;
using System.Collections.Generic;

namespace eitanOboetai
{
    public class EitanOboetai
    {
        readonly private static String ERROR_MESSAGE = 
            "単語リストの初期化に失敗しました。\r\ncsvファイルに誤りが無いか確認してください。";
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
                try{
                    foreach( var n in list )
                    {
                        vocabularyList.Add(n);
                        return vocabularyList;
                    }
                }catch(Exception e){
                    Console.WriteLine(e);
                    Console.WriteLine(ERROR_MESSAGE);
                }
                return vocabularyList;
            }
        }

        public static void DisplayVocabularyList()
        {
            
            List<Vocabulary> list = GetVocabularyList();
            foreach( var n in list ){
                Console.WriteLine( $"{n.vocabulary}, {n.meaning}, {n.pos}" );
            }
            
        }
    }
}
