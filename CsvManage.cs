using System;
using System.IO;
using System.Text;

using System.Linq;
using System.Collections.Generic;

namespace eitanOboetai
{
    
    /// <summary>
    /// 格納用クラス
    /// </summary>
    public class Account
    {
        public string Vocabulary { get; set; }
        public string Meaning { get; set; }
        public string Pos { get; set; }
    }

    /// <summary>
    /// マッピング用クラス
    /// </summary>
    class VocabularyMaMapper : CsvHelper.Configuration.ClassMap<Account>
    { 
        public VocabularyMaMapper()
        {
            Map(x => x.Vocabulary).Index(0);
            Map(x => x.Meaning).Index(1);
            Map(x => x.Pos).Index(2);       
        }
    }
}