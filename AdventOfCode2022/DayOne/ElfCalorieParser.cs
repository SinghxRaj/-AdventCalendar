using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventCalendar.DayOne
{
    internal class ElfCalorieParser
    {
        public static int CalorieParser(string filePath)
        {
            var lines = File.ReadAllLines(filePath).ToList();
            int maxCaloriesCarriedByElf = int.MinValue;
            int currentCaloriesCarriedByElf = 0;
            for (int i = 0; i < lines.Count(); i++)
            {
                if (string.IsNullOrEmpty(lines[i]))
                {
                    maxCaloriesCarriedByElf = Math.Max(maxCaloriesCarriedByElf, currentCaloriesCarriedByElf);
                    currentCaloriesCarriedByElf = 0;
                } 
                else
                {
                    currentCaloriesCarriedByElf += int.Parse(lines[i]);
                }
            }
            return maxCaloriesCarriedByElf;
        }

        public static int SumOfTopThree(string filePath)
        {
            var lines = File.ReadLines(filePath).ToList();
            var totalCaloriesPerElf = new List<int>();
            int currentCaloriesPerElf = 0;
            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    totalCaloriesPerElf.Add(currentCaloriesPerElf);
                    currentCaloriesPerElf = 0;
                } else
                {
                    currentCaloriesPerElf += int.Parse(line);
                }

            }
            // Gotta learn that LINQ
            var result = totalCaloriesPerElf.OrderByDescending(x => x).Take(3).Sum();
            return result;
        }
    }
}
