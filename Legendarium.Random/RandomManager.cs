using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LegendariumRandom
{
     
    public class RandomManager
    {
        public static string CreateRandomName()
        {

            string[] boyNames = File.ReadAllLines("boynames.txt");
            string[] girlNames = File.ReadAllLines("girlnames.txt");

            var random = new Random();

            if(random.Next(0,2) == 1)
            {
                Random ran = new Random();
                var index = ran.Next(boyNames.Length);
                return boyNames[index];
            }
            else
            {
                Random ran = new Random();
                var index = ran.Next(girlNames.Length);
                return girlNames[index];
            }
        }

        public static int CreateRandomStat()
        {
            var random = new Random();

            var stat = random.Next(1, 20);
            return stat;
        }
    }
}