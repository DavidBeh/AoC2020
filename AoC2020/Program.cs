using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AoC2020_Tools;

namespace AoC2020
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
                    int sum = item1 + item2;
                    
                    
                    if (sum == 2020)
                    {
                        int multi = item1 * item2;
                        Tools.WriteLineColor($"{item1} + {item2} = {sum}\n" +
                            $"{item1} * {item2} = {multi}", ConsoleColor.Green);
                        Tools.AskCopyClipboard(multi.ToString());
                        Tools.PressKeyToExit();
                    }
                    else Console.WriteLine($"{item1} + {item2} = {sum}");

                }
            }
            //end
            Tools.PressKeyToExit();
        }

    }
}
