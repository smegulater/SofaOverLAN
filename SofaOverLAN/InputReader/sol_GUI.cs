using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sol_Core
{
    public static class sol_GUI
    {
        

        public static string PaddingCharacter
        {
            get
            {
                return _paddingCharacter;
            }
            set
            {
                if (value.Length == 1)
                {
                    _paddingCharacter = value;
                }
            }
        }
        private static string _paddingCharacter = "░";

        public static ConsoleColor DefaultColor
        {
            get
            {
                return _defaultColor;
            }
            set
            {
                if (value.GetType() == typeof(ConsoleColor))
                {

                }_defaultColor = value;
            }
        }
        private static ConsoleColor _defaultColor = ConsoleColor.White;

        public static int DefaultWidth
        {
            get
            {
                return _defaultWidth;
            }
            set
            {
                if(value > 0)
                {
                    _defaultWidth = value;
                }
            }
        }
        private static int _defaultWidth = Console.BufferWidth - 3;






        public static void WriteLine(string lineText, bool showDebugMessages, ConsoleColor color)
        {
            lineText = PadString(lineText, 4, 4, " ");
            int targetLen = Console.BufferWidth - 3;
            int lineTextLen = lineText.Length;
            int totalPadding = targetLen - lineTextLen;

            if (showDebugMessages)
            {
                Console.WriteLine("lineTextLength:  " + lineText.Length);
                Console.WriteLine("BufferLength: " + Console.BufferWidth);
                Console.WriteLine("totalPadding: " + totalPadding);
                Console.ReadKey(true);
            }


            if (totalPadding % 2 == 0)
            {
                int padding = totalPadding / 2;

                lineText = PadString(lineText, padding, padding, _paddingCharacter);


                if (showDebugMessages)
                {
                    Console.WriteLine("padding divisible by 2");
                    Console.WriteLine("padding amount" + padding);
                    Console.WriteLine(padding);
                    Console.ReadKey(true);
                    Console.WriteLine("lineText unpadded");
                    Console.WriteLine(lineText);
                    Console.WriteLine("lineText padded");
                    Console.WriteLine(lineText);
                    Console.ReadKey(true);
                }
                Console.ForegroundColor = color;
                Console.WriteLine(lineText);
                Console.ForegroundColor = _defaultColor;
            }
            else
            {
                int mid = (int)Math.Round((decimal)totalPadding / 2, MidpointRounding.ToEven);
                int leftPad = (targetLen - mid - lineTextLen);
                int rightPad = mid;

                lineText = PadString(lineText, leftPad, rightPad, _paddingCharacter);


                if (showDebugMessages)
                {
                    Console.WriteLine("padding not divisible by 2");
                    Console.WriteLine("Midpoint: " + mid);
                    Console.WriteLine("left Pad amount: " + leftPad);
                    Console.WriteLine("Right Pad amount: " + rightPad);
                    Console.WriteLine("Pad total: " + (leftPad + rightPad));
                    Console.ReadKey(true);
                    Console.WriteLine("Starting padding");
                    Console.WriteLine("Starting lineText: " + lineText);
                    Console.WriteLine("padded lineText: " + lineText);
                    Console.WriteLine("Finished padding");
                    Console.ReadKey(true);
                }

                Console.ForegroundColor = color;
                Console.WriteLine(lineText);
                Console.ForegroundColor = _defaultColor;


            }
        }
        public static void WriteLine(string lineText, bool showDebugMessages)
        {
            lineText = PadString(lineText, 4, 4, " ");
            int targetLen = Console.BufferWidth - 3;
            int lineTextLen = lineText.Length;
            int totalPadding = targetLen - lineTextLen;

            if (showDebugMessages)
            {
                Console.WriteLine("lineTextLength:  " + lineText.Length);
                Console.WriteLine("BufferLength: " + Console.BufferWidth);
                Console.WriteLine("totalPadding: "+totalPadding);
                Console.ReadKey(true);
            }


            if (totalPadding % 2 == 0)
            {
                int padding = totalPadding / 2;

                lineText = PadString(lineText, padding, padding, _paddingCharacter);

                
                if (showDebugMessages)
                {
                    Console.WriteLine("padding divisible by 2");
                    Console.WriteLine("padding amount" + padding);
                    Console.WriteLine(padding);
                    Console.ReadKey(true);
                    Console.WriteLine("lineText unpadded");
                    Console.WriteLine(lineText);
                    Console.WriteLine("lineText padded");
                    Console.WriteLine(lineText);
                    Console.ReadKey(true);
                }
                Console.WriteLine(lineText);
            }
            else
            {
                int mid = (int)Math.Round((decimal)totalPadding / 2, MidpointRounding.ToEven);
                int leftPad = (targetLen - mid - lineTextLen);
                int rightPad = mid;

                lineText = PadString(lineText, leftPad, rightPad, _paddingCharacter);

                
                if (showDebugMessages)
                {
                    Console.WriteLine("padding not divisible by 2");
                    Console.WriteLine("Midpoint: " + mid);
                    Console.WriteLine("left Pad amount: " + leftPad);
                    Console.WriteLine("Right Pad amount: " + rightPad);
                    Console.WriteLine("Pad total: " + (leftPad + rightPad));
                    Console.ReadKey(true);
                    Console.WriteLine("Starting padding");
                    Console.WriteLine("Starting lineText: " + lineText);
                    Console.WriteLine("padded lineText: " + lineText);
                    Console.WriteLine("Finished padding");
                    Console.ReadKey(true);
                }
                Console.WriteLine(lineText);


            }
        }
        public static void WriteLine(ConsoleColor color)
        {
            int targetLen = Console.BufferWidth - 3;

            string rv = "";
            for (int i = 0; i < targetLen; i++)
            {
                rv += _paddingCharacter;
            }

            Console.ForegroundColor = color;
            Console.WriteLine(rv);
            Console.ForegroundColor = _defaultColor;

        }
        public static void WriteLine()
        {
            int targetLen = Console.BufferWidth - 3;

            string rv = "";
            for (int i = 0; i < targetLen; i++)
            {
                rv += _paddingCharacter;
            }

            Console.ForegroundColor = _defaultColor;
            Console.WriteLine(rv);
            Console.ForegroundColor = _defaultColor;

        }
        public static void WriteMenu(params string[] menuItems)
        {
            
            // pad items with initial space either side
            for (int i = 0; i < menuItems.Length; i++)
            {
                menuItems[i] = PadString(menuItems[i], 4, 4, " ");
            }

            // get longest item
            int highestLength = 0;
            foreach (string line in menuItems)
            {
                if (line.Length > highestLength)
                {
                    highestLength = line.Length;
                }
            }

            // add additional spacing
            for (int i = 0; i < menuItems.Length; i++)
            {
                int _leftPadding;
                int _rightPadding;

                int totalPaddingReq = highestLength - menuItems[i].Length;
                if (DivisibleByTwo(totalPaddingReq))
                {
                    _leftPadding = totalPaddingReq / 2;
                    _rightPadding = totalPaddingReq / 2;
                }
                else
                {
                    int mid = (int)Math.Round((decimal)totalPaddingReq / 2, MidpointRounding.ToEven);

                    _leftPadding = (totalPaddingReq - mid - menuItems[i].Length);
                    _rightPadding = mid;
                }
                
                menuItems[i] = PadString(menuItems[i], _leftPadding, _rightPadding, " ");
            }

            // Write these lines to console
            WriteLine();
            foreach (var line in menuItems)
            {
                WriteLine(line, false);
            }
            WriteLine();
        }
        public static void WriteMenu(ConsoleColor color,params string[] menuItems)
        {

            // pad items with initial space either side
            for (int i = 0; i < menuItems.Length; i++)
            {
                menuItems[i] = PadString(menuItems[i], 4, 4, " ");
            }

            // get longest item
            int highestLength = 0;
            foreach (string line in menuItems)
            {
                if (line.Length > highestLength)
                {
                    highestLength = line.Length;
                }
            }

            // add additional spacing
            for (int i = 0; i < menuItems.Length; i++)
            {
                int _leftPadding;
                int _rightPadding;

                int totalPaddingReq = highestLength - menuItems[i].Length;
                if (DivisibleByTwo(totalPaddingReq))
                {
                    _leftPadding = totalPaddingReq / 2;
                    _rightPadding = totalPaddingReq / 2;
                }
                else
                {
                    int mid = (int)Math.Round((decimal)totalPaddingReq / 2, MidpointRounding.ToEven);

                    _leftPadding = (totalPaddingReq - mid - menuItems[i].Length);
                    _rightPadding = mid;
                }

                menuItems[i] = PadString(menuItems[i], _leftPadding, _rightPadding, " ");
            }

            // Write these lines to console
            WriteLine(color);
            foreach (var line in menuItems)
            {
                WriteLine(line, false, color);
            }
            WriteLine(color);
        }


        private static string PadString(string _string, int LeftAmount, int RightAmount, string PaddingCharacter)
        {
            string leftPadding = "";
            string rightPadding = "";

            for (int i = 0; i < LeftAmount; i++)
            {
                leftPadding = leftPadding + PaddingCharacter;
            }
            for (int i = 0; i < RightAmount; i++)
            {
                rightPadding = rightPadding + PaddingCharacter;
            }

            return leftPadding + _string + rightPadding;
        }
        private static bool DivisibleByTwo(int a)
        {
            if(a % 2 == 0)
            {
                return true;
            }

            return false;
        }
    }
}
