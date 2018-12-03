using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sol_Core;

using SharpDX;
using SharpDX.DirectInput;
namespace Debug
{
    class Program
    {
        private static List<sol_Joystick> connectedJoysticks;
        private static sol_Joystick _selectedjoystick;

        private static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;

            ShowMainMenu();

        }

        #region Menus
        private static void ShowMainMenu()
        {
            bool loopMainMenu = true;
            while (loopMainMenu)
            {

                Console.Clear();
                Console.WriteLine(BuildMenuLine(""));
                Console.WriteLine(BuildMenuLine("    Main Menu    "));
                Console.WriteLine(BuildMenuLine(""));

                Console.WriteLine(BuildMenuLine("    [1] - Scan for connected devices    "));
                Console.WriteLine(BuildMenuLine("    [2] - Show connected devices        "));
                Console.WriteLine(BuildMenuLine("    [3] - Select joystick to use        "));
                Console.WriteLine(BuildMenuLine("    [0] - Test Menu                     "));
                Console.WriteLine(BuildMenuLine("    [x] - Exit                          "));

                Console.WriteLine(BuildMenuLine(""));

                ConsoleKeyInfo userInput = Console.ReadKey(true);

                string keyPressed = userInput.KeyChar.ToString().ToUpper();

                switch (keyPressed)
                {
                    case "1":
                        ScanConnectedDevices(false, "    Scan for devices    ");
                        break;
                    case "2":
                        showConnectedDevices(false, "    Connected Devices    ");
                        break;
                    case "3":
                        SelectJoystick(false, "    Joystick Selection    ");
                        break;
                    case "0":
                        MenuTest(false, "");
                        break;
                    case "X":
                        loopMainMenu = !loopMainMenu;
                        break;

                    default:
                        Console.WriteLine();
                        
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(BuildMenuLine(""));
                        Console.WriteLine(BuildMenuLine("     Error! Invalid option (any Key to dismiss)      "));
                        Console.WriteLine(BuildMenuLine(""));
                        Console.ForegroundColor = ConsoleColor.White;
                        
                        Console.Read();
                        break;
                }

            }
        }
        private static void ScanConnectedDevices(bool subMenu, string MenuTitle)
        {
            if (subMenu)
            {
                // This is a main Menu
            }
            else
            {
                bool LoopMenu = true;
                while (LoopMenu)
                {
                    Console.Clear();
                    Console.WriteLine(BuildMenuLine(""));
                    Console.WriteLine(BuildMenuLine(MenuTitle));
                    Console.WriteLine(BuildMenuLine(""));
                    
                    Console.WriteLine();



                    try
                    {
                        connectedJoysticks = sol_JoystickManager.ConnectedJoysticks;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(BuildMenuLine(""));
                        Console.WriteLine(BuildMenuLine("    Scan completed successfully     "));
                        Console.WriteLine(BuildMenuLine(""));


                        string resultLine = "    " + connectedJoysticks.Count + " device(s) were discovered." + "    ";
                        Console.WriteLine(BuildMenuLine(resultLine));
                        Console.WriteLine(BuildMenuLine(""));
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(BuildMenuLine(""));
                        Console.WriteLine(BuildMenuLine("    Scan Failed!                    "));

                        Console.WriteLine(BuildMenuLine(ex.Message));
                        Console.WriteLine(BuildMenuLine(""));
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine();
                    
                    showConnectedDevices(true, "");
                    Console.WriteLine();
                    Console.WriteLine(BuildMenuLine(""));
                    Console.WriteLine(BuildMenuLine("   Press any key to return to the main menu    "));
                    Console.WriteLine(BuildMenuLine(""));
                    Console.ReadKey(true);
                    LoopMenu = !LoopMenu;
                }
            }


        }
        private static void showConnectedDevices(bool subMenu, string MenuTitle)
        {
            if (subMenu)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine(BuildMenuLine(""));

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(BuildMenuLine("    [Joystick Number] - [Joystick Name] - [Joystick Guid]    "));

                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine(BuildMenuLine(""));

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                if (connectedJoysticks != null && connectedJoysticks.Count > 0)
                {

                    for (int i = 0; i < connectedJoysticks.Count; i++)
                    {
                        string resultRow = "    [" + (i + 1).ToString() + "] [" + connectedJoysticks[i].JoystickName + "] [" + connectedJoysticks[i].JoystickGuid.ToString() + "]    ";

                        Console.WriteLine(BuildMenuLine(resultRow));
                    }

                }
                else
                {
                    Console.WriteLine(BuildMenuLine("    [------N/A------] [-----N/A-----] [-----N/A-----]    "));
                }
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine(BuildMenuLine(""));

                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(BuildMenuLine(""));
                Console.WriteLine(BuildMenuLine(MenuTitle));
                Console.WriteLine(BuildMenuLine(""));
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine(BuildMenuLine(""));

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(BuildMenuLine("    [Joystick Number] - [Joystick Name] - [Joystick Guid]    "));

                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine(BuildMenuLine(""));

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                if (connectedJoysticks != null && connectedJoysticks.Count > 0)
                {

                    for (int i = 0; i < connectedJoysticks.Count; i++)
                    {
                        string resultRow = "    [" + (i + 1).ToString() + "] [" + connectedJoysticks[i].JoystickName + "] [" + connectedJoysticks[i].JoystickGuid.ToString() +"]    ";

                        Console.WriteLine(BuildMenuLine(resultRow));
                    }

                }
                else
                {
                    Console.WriteLine(BuildMenuLine("[------N/A------] [-----N/A-----] [-----N/A-----]"));
                }

                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine(BuildMenuLine(""));
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(BuildMenuLine(""));
                Console.WriteLine(BuildMenuLine("    Press any key to return to main menu    "));
                Console.WriteLine(BuildMenuLine(""));
                Console.ReadKey(true);
            }
        }
        private static void SelectJoystick(bool subMenu, string MenuTitle)
        {
            bool loopMenu = true;
            while (loopMenu)
            {
                Console.Clear();
                Console.WriteLine(BuildMenuLine(""));
                Console.WriteLine(BuildMenuLine(MenuTitle));
                Console.WriteLine(BuildMenuLine(""));
                Console.WriteLine();

                showConnectedDevices(true, "");

                Console.WriteLine("");

                if (connectedJoysticks != null && connectedJoysticks.Count > 0)
                {
                    Console.WriteLine(BuildMenuLine(""));
                    Console.WriteLine(BuildMenuLine("                                                      "));
                    Console.WriteLine(BuildMenuLine("    Select which device you would like to Transmit    "));
                    Console.WriteLine(BuildMenuLine("                                                      "));
                    Console.WriteLine(BuildMenuLine(""));
                    Console.WriteLine(BuildMenuLine("                                                      "));
                    Console.WriteLine(BuildMenuLine("                     [X] to exit                      "));
                    Console.WriteLine(BuildMenuLine("                                                      "));
                    Console.WriteLine(BuildMenuLine(""));
                    Console.WriteLine();

                    Char userInput = Console.ReadKey(true).KeyChar;

                    if (userInput.ToString() == "x")
                    {
                        loopMenu = !loopMenu;
                    }
                    if (userInput.ToString() == "s")
                    {
                        loopMenu = !loopMenu;
                    }

                    if (Char.IsNumber(userInput))
                    {
                        string selectedIndex = userInput.ToString();
                        int index = int.Parse(selectedIndex);

                        #region Debug messages
                        //Console.WriteLine("You typed" + index);
                        //Console.WriteLine("Joystick Count: " + connectedJoysticks.Count);
                        //Console.ReadKey(true);
                        #endregion

                        if (index <= connectedJoysticks.Count && index > 0)
                        {
                            _selectedjoystick = connectedJoysticks[index - 1];
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("");
                            Console.WriteLine(BuildMenuLine(""));
                            Console.WriteLine(BuildMenuLine("    Device Selected    "));
                            Console.WriteLine(BuildMenuLine("    GUID: " + _selectedjoystick.JoystickGuid + "    "));
                            Console.WriteLine(BuildMenuLine("    Name: " + _selectedjoystick.JoystickName + "    "));
                            Console.WriteLine(BuildMenuLine(""));
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.WriteLine(BuildMenuLine(""));
                            Console.WriteLine(BuildMenuLine("    Press any key to continue"));
                            Console.WriteLine(BuildMenuLine(""));
                            Console.ReadKey(true);

                            loopMenu = !loopMenu;
                        }
                    }

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(BuildMenuLine(""));
                    Console.WriteLine(BuildMenuLine("    No Joysticks detected. Make sure one is attached    "));
                    Console.WriteLine(BuildMenuLine("    and you have scanned and picked up the joystick     "));
                    Console.WriteLine(BuildMenuLine(""));
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(BuildMenuLine(""));
                    Console.WriteLine(BuildMenuLine("    Press any key to return the main menu               "));
                    Console.WriteLine(BuildMenuLine(""));

                    Console.ReadKey();
                    loopMenu = !loopMenu;
                }

            }

        }

       
        private static void MenuTest(bool subMenu, string MenuTitle)
        {
            if (subMenu)
            {
                // Menu body goes here
            }
            else
            {
                bool LoopMenu = true;
                while (LoopMenu)
                {
                    Console.Clear();
                    Console.WriteLine(BuildMenuLine(MenuTitle));
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("Press any key to return to main menu");

                    Console.ReadKey(true);
                    LoopMenu = !LoopMenu;
        
                }
        
            }
        
        }

        #region Menu Utilities
        private static string BuildMenuLine(string title)
        {
            int targetLen = Console.BufferWidth - 3;
            int titleLen = title.Length;
            int totalPadding = targetLen - titleLen;

            //Console.WriteLine("titleLength:  " + title.Length);
            //Console.WriteLine("BufferLength: " + Console.BufferWidth);
            //Console.WriteLine("totalPadding: "+totalPadding);
            //Console.ReadKey(true);

            if (totalPadding % 2 == 0)
            {
                int padding = totalPadding / 2;

                title = PadTitle(title, padding, padding, "░");

                //Console.WriteLine("padding divisible by 2");
                //Console.WriteLine("padding amount" + padding);
                //Console.WriteLine(padding);
                //Console.ReadKey(true);
                //Console.WriteLine("title unpadded");
                //Console.WriteLine(title);
                //Console.WriteLine("title padded");
                //Console.WriteLine(title);
                //Console.ReadKey(true);

                return title;
            }
            else
            {
                int mid = (int)Math.Round((decimal)totalPadding / 2, MidpointRounding.ToEven);
                int leftPad = (targetLen - mid - titleLen);
                int rightPad = mid;

                title = PadTitle(title, leftPad, rightPad, "░");

                //Console.WriteLine("padding not divisible by 2");
                //Console.WriteLine("Midpoint: " + mid);
                //Console.WriteLine("left Pad amount: " + leftPad);
                //Console.WriteLine("Right Pad amount: " + rightPad);
                //Console.WriteLine("Pad total: " + (leftPad + rightPad));
                //Console.ReadKey(true);
                //Console.WriteLine("Starting padding");
                //Console.WriteLine("Starting title: " + title);
                //Console.WriteLine("padded title: " + title);
                //Console.WriteLine("Finished padding");
                //Console.ReadKey(true);

                return title;


            }
        }
        /// Menu Template
        ///private static void __MenuName__(bool subMenu, string MenuTitle)
        ///{
        ///    if (subMenu)
        ///    {
        ///        // Menu body goes here
        ///    }
        ///    else
        ///    {
        ///        bool LoopMenu = true;
        ///        while (LoopMenu)
        ///        {
        ///            Console.Clear();
        ///            Console.WriteLine(BuildMenuTitle(MenuTitle));
        ///            Console.WriteLine("-----------------------------------------------------");
        ///            Console.WriteLine();
        ///            Console.WriteLine("-----------------------------------------------------");
        ///            Console.WriteLine("Press any key to return to main menu");
        ///            Console.ReadKey(true);
        ///
        ///        }
        ///
        ///    }
        ///
        ///}
        ///
        #endregion
        #endregion

        private static string PadTitle(string title, int LeftAmount, int RightAmount,string PaddingCharacter)
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

            return leftPadding + title + rightPadding;
        }
    }
}



/// Menu Item Template
///private static void __MenuName__(bool subMenu, string MenuTitle)
///{
///    if (subMenu)
///    {
///        // Menu body goes here
///    }
///    else
///    {
///        bool LoopMenu = true;
///        while (LoopMenu)
///        {
///            Console.Clear();
///            Console.WriteLine(BuildMenuTitle(MenuTitle));
///            Console.WriteLine("-----------------------------------------------------");
///            Console.WriteLine();
///            Console.WriteLine("-----------------------------------------------------");
///            Console.WriteLine("Press any key to return to main menu");
///            Console.ReadKey(true);
///
///        }
///
///    }
///
///}

