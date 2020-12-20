using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC2020_Tools;

namespace Day5p1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Tools.GetInputsByLine();
            //F = 0, B = 1
            List<BoardingPass> passList = new List<BoardingPass>();
            BoardingPass maxPass = null;
            foreach (var item in input)
            {
                passList.Add(new BoardingPass(item));
                if (passList.Last().seatID > (maxPass?.seatID ?? 0))
                {
                    maxPass = passList.Last();
                }
            }
            Tools.WriteLineColor($"Max Seat ID is {maxPass.seatID}", ConsoleColor.Green);
            Tools.AskCopyClipboard(maxPass.seatID.ToString());

            Tools.WriteLineColor("PART TWO", ConsoleColor.Cyan);
            List<BoardingPass> sortedList = passList.OrderBy(o => o.seatID).ToList();
            int mySeatID = 0;
            for (int i = sortedList.First().seatID; i <= sortedList.Last().seatID; i++)
            {
                if (sortedList.Find(e => e.seatID == i) == null) {
                    mySeatID = i;
                    break;
                }
            }
            Tools.WriteLineColor($"My Seat ID is {mySeatID}", ConsoleColor.Green);
            Tools.AskCopyClipboard(mySeatID.ToString());


            Tools.PressKeyToExit();

        }
    }
    public class BoardingPass
    {
        public int row;
        public int column;
        public int seatID;
        public BoardingPass(string binCode)
        {
            binCode = binCode.Replace('F', '0').Replace('B', '1').Replace('L', '0').Replace('R', '1');
            row = Convert.ToInt32(binCode.Substring(0, 7), 2);
            column = Convert.ToInt32(binCode.Substring(7, 3), 2);
            seatID = row * 8 + column;
        }
    }
}
