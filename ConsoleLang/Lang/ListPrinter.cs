using System;
using System.Collections.Generic;

namespace ConsoleLang.Lang
{
    public class ListPrinter : MyPrinter
    {
        public void print()
        {
            var dbs = new List<string> { "SQLite", "Access", "MySQL", "MariaDB", "PostgreSQL" };

            dbs.Add("Oracle");

            for (var i = 0; i < dbs.Count; i++)
            {
                Console.WriteLine($"{dbs[i]}");
            }

            dbs.Remove("Access");

            dbs.Sort();

            foreach (var db in dbs)
            {
                Console.WriteLine($"{db.ToUpper()}");
            }

            var indexAccess = dbs.IndexOf("Access");
            var indexMySQL = dbs.IndexOf("MySQL");
            Console.WriteLine($"{indexAccess}, {indexMySQL}");
        }
    }
}