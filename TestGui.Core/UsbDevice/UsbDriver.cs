using LibUsbDotNet.LibUsb;
using LibUsbDotNet.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestGui.Core.UsbDriver
{
    public class UsbDriver
    {
        private static IUsbDevice Driver = null;

        private static UsbEndpointReader EndpointReader = null;
        private static UsbEndpointWriter EndpointWriter = null;
        public UsbDriverInformation DeviceInfo { get; set; }

        public UsbDriver(int vid, int pid)
        {
            using UsbContext context = new UsbContext();
            var usbDeviceCollection = context.List();

            Driver = usbDeviceCollection.FirstOrDefault(d => d.ProductId == pid && d.VendorId == vid);

            if (Driver != null)
            { 
                DeviceInfo = new UsbDriverInformation
                {
                    PID = pid,
                    VID = vid,
                    Ready = Driver.IsOpen
                };
            }
        }

        public void Open()
        {
            if (!Driver.IsOpen)
            {
                Driver.Open();
                //Get the first config number of the interface
                Driver.ClaimInterface(Driver.Configs[0].Interfaces[0].Number);
                EndpointWriter = Driver.OpenEndpointWriter(WriteEndpointID.Ep01);
                EndpointReader = Driver.OpenEndpointReader(ReadEndpointID.Ep01);

                DeviceInfo.Manufacturer = Driver.Info.Manufacturer;
                DeviceInfo.Product = Driver.Info.Product;
                DeviceInfo.SerialNumber = Driver.Info.SerialNumber;
            }
            DeviceInfo.Ready = Driver.IsOpen;
        }

        public void Close()
        {
            if (Driver.IsOpen)
            {
                Driver.Close();
            }
            DeviceInfo.Ready = Driver.IsOpen;
        }

        public byte[] CMD(byte[] cmdBuffer)
        {
            if (Driver.IsOpen)
            {
                //Write three bytes
                var write_error = EndpointWriter.Write(cmdBuffer, 3000, out var bytesWritten);

                var readBuffer = new byte[64];
                var error = EndpointReader.Read(readBuffer, 3000, out var readBytes);

                return readBuffer;
            }
            
            return new byte[0];
        }
    }
}
