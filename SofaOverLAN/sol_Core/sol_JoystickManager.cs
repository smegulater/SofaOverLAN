using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using SharpDX.DirectInput;

namespace sol_Core
{

    public static class sol_JoystickManager
    {
        public static List<sol_Joystick> ConnectedJoysticks
        {
            get
            {
                GetJoysticks();
                return _connectedJoysticks;
            }
        } 


        private static DirectInput _directInput = new DirectInput();
        private static List<sol_Joystick> _connectedJoysticks;

        private enum NameType
        {
            InstanceName,
            ProductName

        }

        private static void GetJoysticks()
        {
            _connectedJoysticks = new List<sol_Joystick>();

            List<DeviceInstance> connectedDevices = GetDeviceInstances(DeviceClass.GameControl, DeviceEnumerationFlags.AttachedOnly);

            foreach (DeviceInstance device in connectedDevices)
            {
                sol_JoystickProperties jProp = GetDeviceProperties(device);
                sol_Joystick joystick = new sol_Joystick(jProp, device);

                    _connectedJoysticks.Add(joystick);

                
            }
        }

        private static sol_JoystickProperties GetDeviceProperties(DeviceInstance Instance)
        {

            Guid deviceGuid = Instance.InstanceGuid;
            string deviceName = Instance.ProductName;
            string sessionName = Instance.InstanceName;

            sol_JoystickProperties dp = new sol_JoystickProperties(deviceGuid, deviceName, sessionName);

            return dp;
        }
        
        /*public static List<sol_JoystickProperties> GetDeviceProperties(List<DeviceInstance> Instances)
        {
            List<sol_JoystickProperties> rv = new List<sol_JoystickProperties>();

            foreach (DeviceInstance device in Instances)
            {
                Guid deviceGuid = device.InstanceGuid;
                string deviceName = device.ProductName;
                string sessionName = device.InstanceName;

                sol_JoystickProperties dp = new sol_JoystickProperties(deviceGuid, deviceName, sessionName);

                rv.Add(dp);
            }

            return rv;
        }
        */
        
        /*private static DeviceInstance GetDeviceInstance(DeviceClass deviceClass, DeviceEnumerationFlags deviceFlag, Guid deviceGuid)
        {
            IList<DeviceInstance> devices = _directInput.GetDevices(deviceClass, deviceFlag);
        
            foreach (DeviceInstance device in devices)
            {
                if(device.InstanceGuid == deviceGuid)
                {
                    return device;
                }
            }
        
            return null;
        }*/
        
        /*public static DeviceInstance GetDeviceInstance(DeviceClass deviceClass, DeviceEnumerationFlags deviceFlag, NameType nameType ,string Name)
        {
            IList<DeviceInstance> devices = _directInput.GetDevices(deviceClass, deviceFlag);
        
            switch (nameType)
            {
                case NameType.InstanceName:
                    foreach (DeviceInstance device in devices)
                    {
                        if (device.InstanceName == Name)
                        {
                            return device;
                        }
                    }
                    return null;
                case NameType.ProductName:
                    foreach (DeviceInstance device in devices)
                    {
                        if (device.ProductName == Name)
                        {
                            return device;
                        }
                    }
                    return null;
                default:
                    throw new Exception("Unhandled search name enum provided. Are you missing a case clause?");
        
            }
        
        }*/

        /*public static List<Guid> GetDeviceGuids()
        {
            List<Guid> rv = new List<Guid>();
            Guid deviceGuid = new Guid();

            List<DeviceInstance> devices = GetDeviceInstances(DeviceClass.GameControl, DeviceEnumerationFlags.AllDevices);

            foreach (DeviceInstance device in devices)
            {
                deviceGuid = device.InstanceGuid;
                rv.Add(deviceGuid);
            }

            return rv;
        }*/


        private static List<DeviceInstance> GetDeviceInstances(DeviceClass deviceClass, DeviceEnumerationFlags deviceFlag)
        {
            List<DeviceInstance> rv = new List<DeviceInstance>();

            IList<DeviceInstance> devices = _directInput.GetDevices(deviceClass, deviceFlag);

            foreach (DeviceInstance device in devices)
            {
                rv.Add(device);
            }

            return rv;
        }







        






    }
}
