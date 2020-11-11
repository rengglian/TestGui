using Hardware.ChillerController;
using TestGui.Core.DeviceNet;
using Prism.Commands;
using Prism.Mvvm;

namespace Hardware.ViewModels
{
    public class ChillerHardwareViewModel : BindableBase
    {
        public DelegateCommand OpenDeviceCommand { get; private set; }
        public DelegateCommand GetVersionCommand { get; private set; }
        public DelegateCommand GetFeedbackCommand { get; private set; }
        public DelegateCommand CloseDeviceCommand { get; private set; }

        public DelegateCommand SetSetPointCommand { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }


        private string _version;
        public string Version
        {
            get { return _version; }
            set { SetProperty(ref _version, value); }
        }


        private Chiller _chiller;
        public Chiller Chiller
        {
            get { return _chiller; }
            set { SetProperty(ref _chiller, value); }
        }

        private ChillerFeedback _chillerFeedback;
        public ChillerFeedback ChillerFeedback
        {
            get { return _chillerFeedback; }
            set { SetProperty(ref _chillerFeedback, value); }
        }

        private double _setPoint;
        public double SetPoint
        {
            get { return _setPoint; }
            set { SetProperty(ref _setPoint, value); }
        }

        private DeviceDriver test = new DeviceDriver();

        public ChillerHardwareViewModel()
        {
            Title = "Chiller Hardware Module";

            //test.FindUsbDevice();

            Chiller = new Chiller();

            OpenDeviceCommand = new DelegateCommand(OpenDeviceHandler);
            GetVersionCommand = new DelegateCommand(GetVersionHandler);
            GetFeedbackCommand = new DelegateCommand(GetFeedbackHandler);
            CloseDeviceCommand = new DelegateCommand(CloseDeviceHandler);
            SetSetPointCommand = new DelegateCommand(SetSetPointHandler);

            SetPoint = 27.85;
        }

        private void OpenDeviceHandler()
        {
            Chiller.Open();
        }

        private void GetVersionHandler()
        {
            Version = Chiller.CMD_GET_VERSION();
        }

        private void GetFeedbackHandler()
        {
            ChillerFeedback = Chiller.CMD_GET_FEEDBACK();
        }

        private void CloseDeviceHandler()
        {
            Chiller.Close();
        }

        private void SetSetPointHandler()
        {
            Chiller.CMD_SET_SETPOINT(SetPoint);
        }

    }
}
