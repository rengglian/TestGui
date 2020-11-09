using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestGui.Core.UsbDriver
{
    public class UsbDriverInformation : BindableBase
    {

        private string _manufacturer;
        public string Manufacturer
        {
            get { return _manufacturer; }
            set { SetProperty(ref _manufacturer, value); }
        }

        private string _product;
        public string Product
        {
            get { return _product; }
            set { SetProperty(ref _product, value); }
        }

        private string _serialNumber;
        public string SerialNumber
        {
            get { return _serialNumber; }
            set { SetProperty(ref _serialNumber, value); }
        }

        private int _pid;
        public int PID
        {
            get { return _pid; }
            set { SetProperty(ref _pid, value); }
        }

        private int _vid;
        public int VID
        {
            get { return _vid; }
            set { SetProperty(ref _vid, value); }
        }

        private bool _ready;
        public bool Ready
        {
            get { return _ready; }
            set { SetProperty(ref _ready, value); }
        }
    }
}
