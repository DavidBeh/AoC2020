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
        int min;
        int max;
        char policy;
        string password;

        public PasswordEntry(int _min, int _max, char _policy, string _password)
        {
            min = _min;
            max = _max;
            policy = _policy;
            password = _password;
        }
        public bool isValid()
        {

            int count = password.Length - password.Replace(policy.ToString(), "").Length;
            if (count < min || count > max)
            {
                return false;
            }
            else return true;
        }

        public PasswordEntry(string _input)
            : this(int.Parse(Regex.Match(_input, @"\d+(?=-)").Value),
                  int.Parse(Regex.Match(_input, @"(?<=-)\d+").Value),
                  char.Parse(Regex.Match(_input, @".(?=:)").Value),
                  Regex.Match(_input, @"(?<=: ).+").Value)
        { }
    }
}
