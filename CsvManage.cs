using System;
using System.IO;
using System.Text;

namespace eitanOboetai
{
    
    /// <summary>
    /// 格納用クラス
    /// </summary>
    public class Account
    {
        public string Name { get; set; }
        public string Telephone1 { get; set; }
        public string Address1_city { get; set; }
        public string Primarycontactid { get; set; }
        public string Numberofemloyees { get; set; }
    }

    /// <summary>
    /// マッピング用クラス
    /// </summary>
    class AccountMapper : CsvHelper.Configuration.ClassMap<Account>
    { 
        public AccountMapper()
        {
            Map(x => x.Name).Index(0);
            Map(x => x.Telephone1).Index(1);
            Map(x => x.Address1_city).Index(2);
            Map(x => x.Primarycontactid).Index(3);
            Map(x => x.Numberofemloyees).Index(4);
        }
    }
}