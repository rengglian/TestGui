using System;
using System.Collections.Generic;
using System.Text;

namespace Hardware.Helper
{
    public class ControllerVersion
    {
        private int Major { get; set; } = 0;
        private int Minor { get; set; } = 0;
        private int Patch { get; set; } = 0;
        private DateTime DateTime { get; set; } = new DateTime();
        private string Release { get; set; }

        public ControllerVersion(byte[] response)
        {
            if(response[0] == 'V' && response[1] == 'E' && response[2] == 'R')
            {
                Major = response[3];
                Minor = response[4];
                Patch = response[5];
            }
        }

        public override string ToString()
        {
            string ver = Major.ToString() + "." + Minor.ToString() + "." + Patch.ToString();
            return ver;
        }
    }
}
