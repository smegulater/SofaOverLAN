using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InputReader;

namespace Debug
{
    class Program
    {
        static InputListener _inputListener = new InputListener();

        static void Main(string[] args)
        {

            List<DeviceProperties> dp = _inputListener.GetConnectedDevices();

            Console.WriteLine("Getting All Joystick GUID");
            Console.WriteLine("internal name | GUID | Device Name | System Name");
            if(dp.Count > 0)
            {
                for (int i = 0; i < dp.Count; i++)
                {
                    Console.WriteLine("Joystick {0} | {1} | {2} | {3}", i, dp[i].Guid.ToString(), dp[i].DeviceName, dp[i].SessionName);

                }
            }
            else
            {
                Console.WriteLine("No Joysticks detected");
            }


            Console.Read();


            


        }
    }
}
