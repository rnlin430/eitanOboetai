using System;
using System.IO;
using System.Text;

using System.Collections.Generic;

namespace eitanOboetai
{
    class CsvManagement
    {
        public CsvManagement()
        {
        }
        /// <summary>
        /// エントリポイント
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("test");
            EitanOboetai eo = new EitanOboetai();
            Console.WriteLine(eo.Name);
            
            using(var streamWriter = new StreamWriter("people.csv"))
            using (var csv = new CsvHelper.CsvWriter(streamWriter))
            {
                csv.WriteRecord(new { a = 1, b = "b1" });
                csv.WriteRecord(new { a = 2, b = "b2" });
            }
            
            using (var sr = new StreamReader("tango.csv", UnicodeEncoding.Unicode))
            {
                using (var csv = new CsvHelper.CsvReader(sr))
                {   
                    // ヘッダー無しcsv
                    csv.Configuration.HasHeaderRecord = false;
                    // マッピングルールを登録
                    csv.Configuration.RegisterClassMap<VocabularyMaMapper>();
                    // データ読み出し
                    IEnumerable<VocabularyData> records = csv.GetRecords<VocabularyData>();
                    foreach(var data in records)
                    {
                        Console.WriteLine("{0} : {1} : {2} : {3}",data.Vocabulary, data.Meaning,data.Pos);
                    }
                    Console.ReadKey();
                }
            }
        }

    }
}
