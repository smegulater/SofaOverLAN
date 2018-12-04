using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.DirectInput;
using SharpDX;

namespace sol_Core
{
    /// <summary>
    ///  TODO
    /// 
    /// Need to start the joystick capture methods 
    /// 
    /// </summary>
    public class sol_JoystickListener
    {
        //Variable Decleration

        private DirectInput _directInput;
        private sol_Joystick _joystick;

        #region Property Declaration

        public DeviceInstance currentDevice
        {
            get { return _currentDevice; }
        }

        #endregion
        #region Field Declaration
        private DeviceInstance _currentDevice;
        #endregion


        #region Constructor

        public sol_JoystickListener(sol_Joystick joystick)
        {
            _directInput = new DirectInput();
            _joystick = joystick;
        }

        #endregion

               
        public void GetJoystickInput(DeviceInstance device)
        {
            throw new NotImplementedException();

        }


            

    }
}
