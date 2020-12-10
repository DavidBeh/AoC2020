using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC2020_Tools;

namespace Day1p2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Tools.GetInputs();
            string[] inputList = Tools.StringToArrayByLine(input);
            List<int> intList = new List<int>();
            foreach (string entry in inputList)
            {
                intList.Add(int.Parse(entry));
            }
            foreach (int item1 in intList)
            {
                foreach (int item2 in intList)
                {
                    foreach (int item3 in intList)
                    {
                        var sum = item1 + item2 + item3;
                        if (sum == 2020)
                        {
                            Tools.WriteLineColor($"{item1} + {item2} + {item3} = {sum}", ConsoleColor.Green);
                            var multi = item1 * item2 * item3;
                            Tools.WriteLineColor($"{item1} * {item2} * {item3} = {multi}", ConsoleColor.Green);
                            Tools.AskCopyClipboard(multi.ToString());
                            Tools.PressKeyToExit();

                        }
                        //else Console.WriteLine($"{item1} + {item2} + {item3} = {sum}");
                    }
                }
            }

        }
    }
}
