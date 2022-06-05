using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace carCapacity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //путь

            string inputpath = "D:\\SolutionsForSpaceApp\\2008\\input.txt";
            string outputpath = "D:\\SolutionsForSpaceApp\\2008\\output.txt";

            //создание файлов
            FileStream fs = new FileStream(inputpath, FileMode.OpenOrCreate);
            fs.Close();
            FileStream fsout = new FileStream(outputpath, FileMode.OpenOrCreate);
            fsout.Close();

            string amountAndCapacity;
            using (var reader = new StreamReader(inputpath))
            {
                amountAndCapacity = reader.ReadLine();
            }
            string[] splitForAmountAndCapacity = amountAndCapacity.Split(' ');

            string secondLine;
            using (var reader = new StreamReader(inputpath))
            {
                reader.ReadLine(); //пропуск 1 строки
                secondLine = reader.ReadLine();  // записываем в переменную
            }
            //запись из строки в массив строк с разделением
            string[] secondLineToInt = secondLine.Split(' ');

            //массивы для действий над числами
            int[] amountAndCap;
            amountAndCap = new int[2];
            int count = 0;
            foreach (var s in splitForAmountAndCapacity)
            {
                amountAndCap[count] = Convert.ToInt32(s);
                count++;
            }
            int amount = amountAndCap[0];
            int capacity = amountAndCap[1];


            List<int> A = new List<int>();

            


            //запись в интовый массив из массива строк
            
            foreach (var s in secondLineToInt)
            {
                A.Add(Convert.ToInt32(s));
                
            }
            int min = A.Min();
            int sum = 0;
            count = 0;
            while(sum<capacity)
            { 
                if (sum + min < capacity)
                {
                    sum = sum + min;
                    A.Remove(min);
                    min = A.Min();
                    count++;
                }
                else
                {
                    break;
                }
            }

            string outputstring = $"{count} {sum}";

            File.WriteAllText(outputpath, outputstring);


        }
    }
}
