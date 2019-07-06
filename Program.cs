using System;
using System.Threading;

namespace eitanOboetai
{
    /// <summary>
    /// メインクラス
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     エントリポイント
        ///     <param name="args">与えられた引数</param>
        /// </summary>
        private static void Main(string[] args)
        {
            var eo = new EitanOboetai();
            eo.DisplayVocabularyList();
            // eo.GetVocabularyList();   
  
            if(args.Length >= 1)
            {
                Console.WriteLine(args.Length);
            }
            for (int i = 10; 0 <= i; i--)
            {      
                Console.CursorLeft = 0;
                Console.Write("カウンタ：");
                if (i <= 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write("{0:D2}", i);
            
                Console.ForegroundColor = ConsoleColor.Gray;
                Thread.Sleep(1000);
            }
        }
    }
}
