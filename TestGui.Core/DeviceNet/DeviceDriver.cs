using Device.Net;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usb.Net;
using Usb.Net.Windows;

namespace TestGui.Core.DeviceNet
{

    public static class GetFactoryExtensions
    {
        public static IDeviceFactory GetUsbDeviceFactory(this FilterDeviceDefinition filterDeviceDefinition) =>

            filterDeviceDefinition.CreateWindowsUsbDeviceFactory();

    }

    public class DeviceDriver
    {
        private static readonly uint VENDOR_ID = 0x0483;
        private static readonly uint PRODUCT_ID = 0x5716;

        public async Task FindUsbDevice()
        {

   
            var deviceFactory = new FilterDeviceDefinition(VENDOR_ID, PRODUCT_ID)
                .CreateWindowsUsbDeviceFactory(classGuid: WindowsDeviceConstants.GUID_DEVINTERFACE_USB_DEVICE);

            var devices = await deviceFactory.GetConnectedDeviceDefinitionsAsync();

            //Get the first available device
            var deviceDefinition = devices.FirstOrDefault();
                                     
            const string deviceID = @"\\?\usb#vid_0483&pid_5716#338a39613338#{a5dcbf10-6530-11d2-901f-00c04fb951ed}";
            var windowsUsbDevice = new UsbDevice(deviceID, new WindowsUsbInterfaceManager(deviceID));
            await windowsUsbDevice.InitializeAsync();

            Console.WriteLine("test");

        }

    }
}
