using System;
using System.IO;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using System.Linq;
using System.Collections.Generic;

namespace eitanOboetai
{
    
    /// <summary>
    /// 単語を格納するクラス
    /// </summary>
    public class Vocabulary
    {
        public string vocabulary { get; set; }
        public string meaning { get; set; }
        public string pos { get; set; }
    }

    /// <summary>
    /// マッピングルールを定義するクラス
    /// </summary>
    public class VocabularyTable : ClassMap<Vocabulary>
    {
        private VocabularyTable()
        {
            Map( c => c.vocabulary ).Index( 0 );
            Map( c => c.meaning ).Index( 1 );
            Map( c => c.pos ).Index( 2 );
        }
    }
}   