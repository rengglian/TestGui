using Hardware.Helper;
using System;
using TestGui.Core.UsbDriver;

namespace Hardware.ChillerController
{
    public class Chiller
    {
        private static readonly int VENDOR_ID = 0x0483;
        private static readonly int PRODUCT_ID = 0x5716;

        public UsbDriver Driver { get; set; }

        public Chiller()
        {
            Driver = new UsbDriver(VENDOR_ID, PRODUCT_ID);  
        }

        public void Open()
        {
            Driver.Open();
        }

        public void Close()
        {
            Driver.Close();
        }

        public static ChillerFeedback CMD_GET_FEEDBACK()
        {
            var cmdBuffer = new byte[64];
            cmdBuffer[0] = 0;

            var response = UsbDriver.CMD(cmdBuffer);

            return new ChillerFeedback(response);
        }

        public static string CMD_GET_VERSION()
        {
            var cmdBuffer = new byte[64];
            cmdBuffer[0] = 6;

            var response = UsbDriver.CMD(cmdBuffer);

            var version = new ControllerVersion(response);
            return version.ToString();
        }

        public static void CMD_SET_SETPOINT(double setpoint)
        {
            UInt16 payload = (UInt16)(setpoint * 100);
            var cmdBuffer = new byte[64];
            cmdBuffer[0] = 2;
            cmdBuffer[1] = (byte)(payload >> 8);
            cmdBuffer[2] = (byte)(payload & 0xff);

            UsbDriver.CMD(cmdBuffer);

        }
    }
}
