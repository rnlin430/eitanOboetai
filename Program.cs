using System;
using System.IO;
using System.Text;

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
            Console.WriteLine("Hello World!");
            EitanOboetai eo = new EitanOboetai();
            Console.WriteLine(eo.Name);

            using (var sr = new StreamReader("account.csv", UnicodeEncoding.Unicode))
            using (var csv = new CsvHelper.CsvReader(sr))
            {
                csv.Configuration.RegisterClassMap<AccountMapper>();

                var records = csv.GetRecords<Account>();
                
                foreach(var data in records)
                {
                    Console.WriteLine("{0} : {1} : {2} : {3}",data.Name, data.Telephone1,data.Address1_city,data.Primarycontactid);
                }

                Console.ReadKey();
            }
        }
    }

}
