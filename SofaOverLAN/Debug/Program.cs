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
            Console.ForegroundColor = sol_GUI.DefaultColor;

            ShowMainMenu();

        }

        #region Menus
        private static void ShowMainMenu()
        {
            bool loopMainMenu = true;
            while (loopMainMenu)
            {

                Console.Clear();
                sol_GUI.WriteLine();
                sol_GUI.WriteLine("Main Menu",false);
                sol_GUI.WriteLine();
                sol_GUI.WriteMenu(
                    "  ",
                    "[1] - Scan for connected devices",
                    "[2] - Show connected devices",
                    "[3] - Select joystick to use",
                    "[4] - Joystick Diagnostics",
                    "[x] - Exit",
                    "  "
                    );


                ConsoleKeyInfo userInput = Console.ReadKey(true);

                string keyPressed = userInput.KeyChar.ToString().ToUpper();

                switch (keyPressed)
                {
                    case "1":
                        ScanConnectedDevices(false, "Scan for devices");
                        break;
                    case "2":
                        showConnectedDevices(false, "Connected Devices");
                        break;
                    case "3":
                        SelectJoystick(false, "Joystick Selection");
                        break;
                    case "4":
                        ShowJoystickInput(false, "Joystick Diagnostics");
                        break;
                    case "X":
                        loopMainMenu = !loopMainMenu;
                        break;
                    case "0":
                    default:
                        Console.WriteLine();
                        
                        sol_GUI.WriteLine(ConsoleColor.Red);
                        sol_GUI.WriteLine("Error! Invalid option (any Key to dismiss)",false,ConsoleColor.Red);
                        sol_GUI.WriteLine(ConsoleColor.Red);
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
                    sol_GUI.WriteLine();
                    sol_GUI.WriteLine(MenuTitle,false);
                    sol_GUI.WriteLine();
                    
                    Console.WriteLine();

                    try
                    {
                        connectedJoysticks = sol_JoystickManager.ConnectedJoysticks;

                        string resultLine = connectedJoysticks.Count + " device(s) were discovered";

                        sol_GUI.WriteMenu(ConsoleColor.Green, "  ", "Scan completed successfully", resultLine, "  ");

                                                
                    }
                    catch (Exception ex)
                    {

                        sol_GUI.WriteLine(ConsoleColor.Red);
                        sol_GUI.WriteLine("Scan failed!!!", false,ConsoleColor.Red);
                        Console.WriteLine(ex.Message, false, ConsoleColor.Red);
                        sol_GUI.WriteLine(ConsoleColor.Red);
                        
                    }
                    Console.WriteLine();
                    
                    showConnectedDevices(true, "");
                    Console.WriteLine();
                    sol_GUI.WriteLine();
                    sol_GUI.WriteLine("Press any key to return to the main menu",false);
                    sol_GUI.WriteLine();
                    Console.ReadKey(true);
                    LoopMenu = !LoopMenu;
                }
            }


        }
        private static void showConnectedDevices(bool subMenu, string MenuTitle)
        {
            if (subMenu)
            {
                
                sol_GUI.WriteLine(ConsoleColor.DarkMagenta);
                                
                sol_GUI.WriteLine("[Joystick Number] [Joystick Name] [Joystick Guid]",false , ConsoleColor.Cyan);

                sol_GUI.WriteLine(ConsoleColor.DarkMagenta);

                if (connectedJoysticks != null && connectedJoysticks.Count > 0)
                {
                    List<string> rowItems = new List<string>();

                    rowItems.Add("  ");
                    for (int i = 0; i < connectedJoysticks.Count; i++)
                    {
                        string resultRow = "[" + (i + 1).ToString() + "] [" + connectedJoysticks[i].JoystickName + "] [" + connectedJoysticks[i].JoystickGuid.ToString() + "]";

                        rowItems.Add(resultRow);
                    }
                    rowItems.Add("  ");

                    sol_GUI.WriteMenu(ConsoleColor.DarkYellow, rowItems.ToArray<string>());

                }
                else
                {
                    sol_GUI.WriteMenu(ConsoleColor.DarkYellow, "  ","[------N/A------] [-----N/A-----] [-----N/A-----]","  ");
                    
                }
                
                sol_GUI.WriteLine(ConsoleColor.DarkMagenta);

            }
            else
            {
                Console.Clear();

                sol_GUI.WriteLine();
                sol_GUI.WriteLine(MenuTitle, false);
                sol_GUI.WriteLine();

                Console.WriteLine();

                sol_GUI.WriteLine(ConsoleColor.DarkMagenta);

                sol_GUI.WriteLine("[Joystick Number] [Joystick Name] [Joystick Guid]", false, ConsoleColor.Cyan);
                
                sol_GUI.WriteLine(ConsoleColor.DarkMagenta);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                if (connectedJoysticks != null && connectedJoysticks.Count > 0)
                {
                    List<string> rowItems = new List<string>();
                    rowItems.Add("  ");
                    for (int i = 0; i < connectedJoysticks.Count; i++)
                    {
                        string resultRow = "[" + (i + 1).ToString() + "] [" + connectedJoysticks[i].JoystickName + "] [" + connectedJoysticks[i].JoystickGuid.ToString() +"]";

                        rowItems.Add(resultRow);
                    }
                    rowItems.Add("  ");

                    sol_GUI.WriteMenu(ConsoleColor.DarkYellow, rowItems.ToArray<string>());
                }
                else
                {
                    sol_GUI.WriteMenu(ConsoleColor.DarkYellow,"  ","[------N/A------] [-----N/A-----] [-----N/A-----]","  ");

                }


                sol_GUI.WriteLine(ConsoleColor.DarkMagenta);
                Console.WriteLine();

                sol_GUI.WriteLine();
                sol_GUI.WriteLine("Press any key to return to main menu", false);
                sol_GUI.WriteLine();

                Console.ReadKey(true);
            }
        }
        private static void SelectJoystick(bool subMenu, string MenuTitle)
        {
            bool loopMenu = true;
            while (loopMenu)
            {
                Console.Clear();
                sol_GUI.WriteLine();
                sol_GUI.WriteLine(MenuTitle,false);
                sol_GUI.WriteLine();
                Console.WriteLine();

                showConnectedDevices(true, "");

                Console.WriteLine();

                if (connectedJoysticks != null && connectedJoysticks.Count > 0)
                {
                    sol_GUI.WriteMenu("  ", "Select which device you would like to Transmit", "  ","[X] Exit","  ");

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

                            Console.WriteLine();

                            sol_GUI.WriteLine(ConsoleColor.Green);
                            sol_GUI.WriteMenu(ConsoleColor.Green,
                                "  ",
                                "Device Selected",
                                "---------------",
                                "  ",
                                ("GUID: " + _selectedjoystick.JoystickGuid),
                                ("Name: " + _selectedjoystick.JoystickName),
                                "  "
                                );


                            sol_GUI.WriteLine();
                            sol_GUI.WriteLine("Press any key to continue", false);
                            sol_GUI.WriteLine();
                            Console.ReadKey(true);

                            loopMenu = !loopMenu;
                        }
                    }

                }
                else
                {
                    sol_GUI.WriteMenu(ConsoleColor.Red, "  ", "No Joysticks detected. Make sure one is attached", "and you have scanned and picked up the joystick", "  ");

                    Console.WriteLine();

                    sol_GUI.WriteLine();
                    sol_GUI.WriteLine("Press any key to return the main menu",false);
                    sol_GUI.WriteLine();

                    Console.ReadKey();
                    loopMenu = !loopMenu;
                }

            }

        }
        private static void ShowJoystickInput(bool subMenu, string MenuTitle)
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

                    #region Header

                    sol_GUI.WriteLine();
                    sol_GUI.WriteLine("Joystick Diagnostics", false);
                    sol_GUI.WriteLine();

                    Console.WriteLine();

                    #endregion

                    #region Body

                    sol_GUI.WriteMenu(ConsoleColor.Blue, "  ", "[S] Start / Stop Diagnostics", "[X] Exit to main menu", "  ");
                    Console.WriteLine();


                    //ConsoleKeyInfo rawInput = Console.ReadKey(true);
                    //string input = rawInput.KeyChar.ToString();


                    #endregion

                    #region Footer

                    Console.WriteLine();
                    sol_GUI.WriteLine();
                    sol_GUI.WriteLine("Press any key to return to main menu", false);
                    sol_GUI.WriteLine();

                    #endregion

                    Console.ReadKey(true);
                    LoopMenu = !LoopMenu;

                }

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







    }

}



// //Menu Item Template
//private static void __MenuName__(bool subMenu, string MenuTitle)
//{
//    if (subMenu)
//    {
//        // Menu body goes here
//    }
//    else
//    {
//        bool LoopMenu = true;
//        while (LoopMenu)
//        {
//            Console.Clear();
//            Console.WriteLine(BuildMenuTitle(MenuTitle));
//            Console.WriteLine("-----------------------------------------------------");
//            Console.WriteLine();
//            Console.WriteLine("-----------------------------------------------------");
//            Console.WriteLine("Press any key to return to main menu");
//            Console.ReadKey(true);
//
//        }
//
//    }
//
//}

