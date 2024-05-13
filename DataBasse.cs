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
                File.AppendAllLines("data.txt", new string[] {nick + ": " +  record + Environment.NewLine});
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

        public void writeLvl(string file, int toAdd, int level)
        {
            try
            {
                int current = (int)ReadSingleDigit(file);
                string a = level.ToString();

                switch (level)
                {
                    case 1:
                        if (current == 1) a = (ReadSingleDigit(file) + toAdd).ToString();
                        else if (current == 2) a = "2";
                        else if (current == 3) a = "3";
                        break; 
                    
                    case 2:
                        if (current == 2) a = (ReadSingleDigit(file) + toAdd).ToString();
                        else if (current == 3) a = "3";
                        break;
                    case 3:
                        if (current == 3) a = (ReadSingleDigit(file) + toAdd).ToString();
                        else if (current == 3) a = "3";
                        break;
                }


                File.WriteAllText(file, a);
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

        public List<string> ReadStringArray(string filePath)
        {
            List<string> stringArray = new List<string>();
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                stringArray.AddRange(lines);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Ошибка ввода-вывода: {e.Message}");
            }
            return stringArray;
        }

        public int? ReadSingleDigit(string filePath)
        {
            int? digit = null;
            try
            {
                string digitStr = File.ReadAllText(filePath).Trim();
                if (int.TryParse(digitStr, out int result))
                {
                    digit = result;
                }
                else
                {
                    Console.WriteLine("Файл содержит некорректные данные.");
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Ошибка ввода-вывода: {e.Message}");
            }
            return digit;
        }

    }
}
