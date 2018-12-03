using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.DirectInput;
using SharpDX;

namespace sol_Core
{
    public class sol_JoystickListener
    {
        //Variable Decleration

        private DirectInput directInput = new DirectInput();

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

        public sol_JoystickListener()
        {
            directInput = new DirectInput();
        }

        #endregion

        // Read input from a 




        
        public void GetJoystickInput(DeviceInstance device)
        {
            throw new NotImplementedException();

        }


            

    }
}
