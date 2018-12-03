using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpDX;
using SharpDX.DirectInput;

namespace sol_Core
{
    public class sol_Joystick
    {
        public Guid JoystickGuid { get { return _prop.Guid; } }
        public string JoystickName { get { return _prop.DeviceName; } }
        public DeviceInstance dxInstance { get { return _dxInstance; } }

        public sol_Joystick(sol_JoystickProperties prop, DeviceInstance I)
        {
            _prop = prop;
            _dxInstance = I;
        }

        private readonly sol_JoystickProperties _prop;
        private readonly DeviceInstance _dxInstance;
    }
}
