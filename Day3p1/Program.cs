using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC2020_Tools;

namespace Day3p1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Tools.GetInputs();
            var inputList = Tools.StringToArrayByLine(input);
            Forest forest = new Forest();
            foreach (String inputRow in inputList)
            {
                TreeRow c_row = new TreeRow();
                forest.treeRows.Add(c_row);
                foreach (char cell in inputRow)
                {
                    bool isTree = cell == '#';
                    c_row.treeRow.Add(isTree);
                }
            }
            Vector2 vec = new Vector2();
            int treeCount = 0;
            while (vec.y < forest.treeRows.Count())
            {
                if (forest.treeRows[vec.y].getRepeating(vec.x))
                {
                    treeCount++;
                }
                vec.Translate(3, 1);
            }
            Tools.WriteLineColor($"found {treeCount} tress", ConsoleColor.Green);
            Tools.AskCopyClipboard(treeCount.ToString());
            Tools.WriteLineColor("Part Two", ConsoleColor.Cyan);


            Tools.PressKeyToExit();
        }
    }

    class Vector2
    {
        public int x;
        public int y;
        public Vector2() : this(0, 0) { }
        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void Translate(int x, int y)
        {
            this.x += x;
            this.y += y;
        }
    }
    class Forest
    {
        public List<TreeRow> treeRows = new List<TreeRow>();
    }
    class TreeRow
    {
        public List<bool> treeRow = new List<bool>();
        public bool getRepeating(int index)
        {
            return treeRow[index % treeRow.Count()];
        }
    }
}
