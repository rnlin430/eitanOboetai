using System;
using System.IO;
using System.Text;
using CsvHelper;
using System.Linq;
using System.Collections.Generic;

namespace eitanOboetai
{
    public class EitanOboetai
    {
        readonly private static String ERROR_MESSAGE = 
            @"単語リストの初期化に失敗しました。\r\ncsvファイルに誤りが無いか確認してください。";
        private List<Vocabulary> vocabularyList = new List<Vocabulary>();
        private int index = 0;

        // constructor
        public EitanOboetai()
        {
            this.GetVocabularyList();
        }

        /// <summary>
        ///     tango.csvから単語を読み込みリストを返します。
        ///     <returns>List<Vocabulary>を返します。</returns>
        /// </summary>
        public List<Vocabulary> GetVocabularyList()
        {
            var path = @"tango.csv";
            using (var csv = new CsvReader(new StreamReader(path)))
            {
                var config = csv.Configuration;
                config.HasHeaderRecord = true;
                config.RegisterClassMap<VocabularyTable>();
                IEnumerable<Vocabulary> list = csv.GetRecords<Vocabulary>();
                try {
                    foreach (var n in list) {
                        vocabularyList.Add(n);
                    }
                    return vocabularyList;
                } catch (Exception e) {
                    Console.WriteLine(e);
                    Console.WriteLine(ERROR_MESSAGE);
                    Console.ReadKey();
                    return vocabularyList;
                }          
            }
        }

        public void DisplayVocabularyList()
        {
            List<Vocabulary> list = GetVocabularyList();
            foreach(var n in list)
            {
                Console.WriteLine($"{n.vocabulary}, {n.meaning}, {n.pos}");
            }
            Console.WriteLine("Count: " + list.Count());       
        }

        /// <summary>
        ///     Vocabularyクラスを取得します。
        ///     <param name="random">
        ///         Vocabularyクラスをランダムで取得します。falseの場合は0から順番に返します。
        ///     </param>
        /// </summary>
        public Vocabulary GetVocabularyClass(Boolean random)
        {
            if (random)
            {
                int length = this.vocabularyList.Count();
                var rdm = new Random();
                int result = rdm.Next(length);
                Vocabulary v = this.vocabularyList[result];
                return v;
            } else {
                int length = this.vocabularyList.Count();
                Vocabulary v = this.vocabularyList[index];
                if (length - index <= 1)
                {
                    index = 0;
                    return v;
                }
                index++;
                return v;
            }
        }
    }
}
