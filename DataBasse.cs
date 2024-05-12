using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace game1
{
    internal class DataBasse
    {
        public void write(string nick, int record)
        {
            try
            {
                StreamWriter sw = new StreamWriter("data.txt");
                sw.WriteLine(nick + "; " + record);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        public string[] getAllData()
        {
            string[] lines = File.ReadAllLines("data.txt");
            return lines;
        }

    }
}
