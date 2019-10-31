using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino
{
    partial class ControllerTemplate
    {
        private ArduinoData m_data;
        public ControllerTemplate(ArduinoData data) { this.m_data = data; }
    }
}
