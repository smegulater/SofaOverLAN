using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sol_Core
{
    public class sol_JoystickProperties
    {
        public sol_JoystickProperties(Guid g, string deviceName, string sessionName)
        {
            _guid = g;
            _deviceName = deviceName;
            _sessionName = sessionName;

        }

        public Guid Guid { get{ return _guid; }}
        private Guid _guid;

        public string DeviceName{ get{ return _deviceName; }}
        private string _deviceName;

        public string SessionName { get { return _sessionName; } }
        private string _sessionName;
    }
}
