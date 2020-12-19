using AoC2020_Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace Day4p1
{
    class Program
    {
        static void Main(string[] args)
        {
            string rawinput = Tools.GetInputs();
            string[] passportsStr = rawinput.Split(new[] { "\n\n"}, StringSplitOptions.RemoveEmptyEntries);
            List<Passport> validPassports = new List<Passport>();
            foreach (var item in passportsStr)
            {
                var pass = new Passport(item);
                if (pass.checkValid()) validPassports.Add(pass);
            }
            Tools.WriteLineColor($"Found {validPassports.Count} valid passports", ConsoleColor.Green);
            Tools.AskCopyClipboard(validPassports.Count.ToString());
            Tools.WriteLineColor("PART TWO", ConsoleColor.Cyan);
            List<Passport> reallyValidPassports = new List<Passport>();
            foreach (var item in validPassports)
            {
                if (item.checkValidPart2()) reallyValidPassports.Add(item);
            }
            Tools.WriteLineColor($"Found {reallyValidPassports.Count} valid passports (part two)", ConsoleColor.Green);
            Tools.AskCopyClipboard(reallyValidPassports.Count.ToString());
            Tools.PressKeyToExit();
        }
    }

    class Passport
    {
        public string byr, iyr, eyr, hgt, hcl, ecl, pid, cid;
        public Passport(string regexInput)
        {
            byr = Regex.Match(regexInput, @"(?<= byr:)\S+", RegexOptions.IgnorePatternWhitespace).TryGetValue();
            iyr = Regex.Match(regexInput, @"(?<= iyr:)\S+", RegexOptions.IgnorePatternWhitespace).TryGetValue();
            eyr = Regex.Match(regexInput, @"(?<= eyr:)\S+", RegexOptions.IgnorePatternWhitespace).TryGetValue();
            hgt = Regex.Match(regexInput, @"(?<= hgt:)\S+", RegexOptions.IgnorePatternWhitespace).TryGetValue();
            hcl = Regex.Match(regexInput, @"(?<= hcl:)\S+", RegexOptions.IgnorePatternWhitespace).TryGetValue();
            ecl = Regex.Match(regexInput, @"(?<= ecl:)\S+", RegexOptions.IgnorePatternWhitespace).TryGetValue();
            pid = Regex.Match(regexInput, @"(?<= pid:)\S+", RegexOptions.IgnorePatternWhitespace).TryGetValue();
            cid = Regex.Match(regexInput, @"(?<= cid:)\S+", RegexOptions.IgnorePatternWhitespace).TryGetValue();
        }
        public bool checkValid()
        {
            return byr != null && iyr != null && eyr != null && hgt != null && hcl != null && ecl != null && pid != null;
        }
        public bool checkValidPart2()
        {
            if (1920 <= int.Parse(byr) && int.Parse(byr) <= 2020) { } else return false;
            if (2010 <= int.Parse(iyr) && int.Parse(iyr) <= 2020) { } else return false;
            if (2020 <= int.Parse(eyr) && int.Parse(eyr) <= 2030) { } else return false;
            if (hgt.EndsWith("cm"))
            {
                int iHgt = int.Parse(hgt.Remove(hgt.Length - 2, 2));
                if (150 <= iHgt && iHgt <= 193) { } else return false;
            }
            else if (hgt.EndsWith("in"))
            {
                int iHgt = int.Parse(hgt.Remove(hgt.Length - 2, 2));
                if (59 <= iHgt && iHgt <= 76) { } else return false;
            }
            else return false;
            if (Regex.Match(hcl, @"^#[0-9a-f]{6}$").Success) { } else return false;
            if (ecl == "amb" || ecl == "blu" || ecl == "brn" || ecl == "gry" || ecl == "grn" || ecl == "hzl" || ecl == "oth") { } else return false;
            if (Regex.Match(pid, @"^\d{9}$").Success) { } else return false;
            return true;
        }
    }
    public static class Extensions
    {
        public static string TryGetValue(this Match match)
        {
            return match.Value == "" ? null : match.Value;
        }
    }
}
