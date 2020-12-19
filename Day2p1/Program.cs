using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AoC2020_Tools;

namespace Day2p1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Tools.GetInputs();
            var inputList = Tools.StringToArrayByLine(input);
            List<PasswordEntry> validList = new List<PasswordEntry>();
            foreach (var item in inputList)
            {
                var current = new PasswordEntry(item);
                if (current.isValid()) validList.Add(current);
            }
            Tools.WriteLineColor($"There are {validList.Count} valid passwords", ConsoleColor.Green);
            Tools.AskCopyClipboard(validList.Count.ToString());
            Tools.PressKeyToExit();
        }

    }
    public class PasswordEntry
    {
        int pos1;
        int pos2;
        char policy;
        string password;

        public PasswordEntry(int _pos1, int _pos2, char _policy, string _password)
        {
            pos1 = _pos1;
            pos2 = _pos2;
            policy = _policy;
            password = _password;
        }
        public bool isValid()
        {
            return password[pos1 - 1] == policy ^ password[pos2 - 1] == policy;
        }

        public PasswordEntry(string _input)
            : this(int.Parse(Regex.Match(_input, @"\d+(?=-)").Value),
                  int.Parse(Regex.Match(_input, @"(?<=-)\d+").Value),
                  char.Parse(Regex.Match(_input, @".(?=:)").Value),
                  Regex.Match(_input, @"(?<=: ).+").Value)
        { }
    }
}
