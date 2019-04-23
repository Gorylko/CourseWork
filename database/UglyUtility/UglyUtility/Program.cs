using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace UglyUtility
{
    sealed class Program
    {
        private static void Main()
        {
            Console.WriteLine("Введите строку подключения");
            var queryContext = new QueryContext(Console.ReadLine());
            queryContext.CreateAllTables();
            queryContext.InsertAll();
            Console.WriteLine("Успех!");
            Thread.Sleep(1000);
        }
    }
}
