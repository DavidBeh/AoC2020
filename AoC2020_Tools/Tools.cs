using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;

namespace AoC2020_Tools
{
    public class Tools
    {
        public static string GetInputs()
        {
            if (File.Exists("input.txt"))
            {
                Console.WriteLine("input.txt found");
                return File.ReadAllText("input.txt");
            }
            else
            {
                Console.WriteLine("input.txt not found in working directory. Pick the file.");
                string filepath = OpenFilePicker();
                if (filepath != null) //If the filepath is null, the pickerdialog has been aborted
                {
                    Console.WriteLine($"You picked {filepath}");
                    return File.ReadAllText(filepath);
                }
                else
                {
                    Console.WriteLine("You did not Pick the file.");
                    PressKeyToExit();
                    return null;
                }
            }
        }

        public static string[] GetInputsByLine()
        {
            if (File.Exists("input.txt"))
            {
                Console.WriteLine("input.txt found");
                return File.ReadAllLines("input.txt");
            }
            else
            {
                Console.WriteLine("input.txt not found in working directory. Pick the file.");
                string filepath = OpenFilePicker();
                if (filepath != null) //If the filepath is null, the pickerdialog has been aborted
                {
                    Console.WriteLine($"You picked {filepath}");
                    return File.ReadAllLines(filepath);
                }
                else
                {
                    Console.WriteLine("You did not Pick the file.");
                    PressKeyToExit();
                    return null;
                }
            }
        }

        private static string OpenFilePicker()
        {
            string filepath = null;
            Thread thread = new Thread(() =>
            {

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "input | *.txt";
                    openFileDialog.FilterIndex = 0;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filepath = openFileDialog.FileName;
                    }
                }
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            return filepath;
        }
        public static void AskCopyClipboard(string _stringToCopy)
        {
            Console.WriteLine($"Do you want to copy {_stringToCopy} to clipboard? y/n");
            ConsoleKeyInfo answer = Console.ReadKey();
            if (answer.Key == ConsoleKey.Y)
            {
                Console.WriteLine("es");
                CopyClipBoard(_stringToCopy);
            }
            else Console.WriteLine("no");
        }
        public static void CopyClipBoard(string _stringToCopy)
        {

            Thread thread = new Thread(() =>
            {
                Clipboard.Clear();
                Clipboard.SetText(_stringToCopy, TextDataFormat.UnicodeText);
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            Console.WriteLine("Copied");

        }
        public static void PressKeyToExit()
        {
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            Environment.Exit(0);
        }

        public static string[] StringToArrayByLine(string _string)
        {
            return _string.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        }
        public static void WriteColor(String _value, ConsoleColor _textCol, ConsoleColor _bgCol)
        {
            var oldBack = Console.BackgroundColor;
            var oldText = Console.ForegroundColor;
            Console.BackgroundColor = _bgCol;
            Console.ForegroundColor = _textCol;
            Console.Write(_value);
            Console.BackgroundColor = oldBack;
            Console.ForegroundColor = oldText;
        }
        #region WriteColor overloads
        public static void WriteColor(object _value, ConsoleColor _textCol, ConsoleColor _bgCol) {
            WriteColor(_value.ToString(), _textCol, _bgCol);
        }
        public static void WriteColor(string _value, ConsoleColor _textCol)
        {
            WriteColor(_value, _textCol, Console.BackgroundColor);
        }
        public static void WriteColor(object _value, ConsoleColor _textCol)
        {
            WriteColor(_value.ToString(), _textCol, Console.BackgroundColor);
        }
        #endregion
        public static void WriteLineColor(String _value, ConsoleColor _textCol, ConsoleColor _bgCol)
        {
            var oldBack = Console.BackgroundColor;
            var oldText = Console.ForegroundColor;
            Console.BackgroundColor = _bgCol;
            Console.ForegroundColor = _textCol;
            Console.WriteLine(_value);
            Console.BackgroundColor = oldBack;
            Console.ForegroundColor = oldText;
        }
        #region WriteLineColor overloads
        public static void WriteLineColor(object _value, ConsoleColor _textCol, ConsoleColor _bgCol)
        {
            WriteLineColor(_value.ToString(), _textCol, _bgCol);
        }
        public static void WriteLineColor(string _value, ConsoleColor _textCol)
        {
            WriteLineColor(_value, _textCol, Console.BackgroundColor);
        }
        public static void WriteLineColor(object _value, ConsoleColor _textCol)
        {
            WriteLineColor(_value.ToString(), _textCol, Console.BackgroundColor);
        }
        #endregion
    }
}
