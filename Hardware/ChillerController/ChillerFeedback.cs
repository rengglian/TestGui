using System;
using System.Collections.Generic;
using System.Text;

namespace Hardware.ChillerController
{
    public class ChillerFeedback
    {
        public DateTime TimeStamp { get; set; }
        public double InTemperature { get; set; } = 0;
        public double OutTemperature { get; set; } = 0;
        public double TargetTemperature { get; set; } = 0;
        public double CoolingLevel { get; set; } = 0;
        public double PeltierCurrentBank1 { get; set; } = 0;
        public double PeltierCurrentBank2 { get; set; } = 0;
        public double PeltierCurrentBank3 { get; set; } = 0;
        public double WaterPumpCurrent { get; set; } = 0;
        public double WaterPumpDutyCyle { get; set; } = 0;
        public double PeltierVoltagePercentage { get; set; } = 0;
        public double OperationMode { get; set; } = 0;
        public double MainVoltage { get; set; } = 0;
        public double PeltierVoltage { get; set; } = 0;
        public double FlowMeter { get; set; } = 0;
        public double MainFanSpeed {get; set; } = 0;
        public double ChillerFanSpeed { get; set; } = 0;
        public double WaterPumpSpeed1 { get; set; } = 0;
        public double WaterPumpSpeed2 { get; set; } = 0;
        public UInt32 ErrorFlags { get; set; } = 0;

        public ChillerFeedback(byte[] response)
        {
            var index = 0;
            if (response[index++] == 'F' && response[index++] == 'B' && response[index++] == 'K')
            {
                TimeStamp = DateTime.UtcNow;
                InTemperature = (double)(((UInt16)response[index++] << 8) | response[index++])/100.0;
                OutTemperature = (double)(((UInt16)response[index++] << 8) | response[index++]) / 100.0;
                TargetTemperature = (double)(((UInt16)response[index++] << 8) | response[index++]) / 100.0;
                CoolingLevel = (double)(((UInt16)response[index++] << 8) | response[index++]) / 10.0;
                PeltierCurrentBank1 = (double)(((UInt16)response[index++] << 8) | response[index++]) / 10.0;
                PeltierCurrentBank2 = (double)(((UInt16)response[index++] << 8) | response[index++]) / 10.0;
                PeltierCurrentBank3 = (double)(((UInt16)response[index++] << 8) | response[index++]) / 10.0;
                WaterPumpCurrent = (double)(((UInt16)response[index++] << 8) | response[index++]) / 10.0;
                WaterPumpDutyCyle = (double)(((UInt16)response[index++] << 8) | response[index++]) / 10.0;
                PeltierVoltagePercentage = (double)(((UInt16)response[index++] << 8) | response[index++]) / 10.0;
                OperationMode = (double)(((UInt16)response[index++] << 8) | response[index++]) / 10.0;
                MainVoltage = (double)(((UInt16)response[index++] << 8) | response[index++]) / 10.0;
                PeltierVoltage = (double)(((UInt16)response[index++] << 8) | response[index++]) / 10.0;
                FlowMeter = (double)(((UInt16)response[index++] << 8) | response[index++]) / 10.0;
                MainFanSpeed = (double)(((UInt16)response[index++] << 8) | response[index++]) / 10.0;
                ChillerFanSpeed = (double)(((UInt16)response[index++] << 8) | response[index++]) / 10.0;
                WaterPumpSpeed1 = (double)(((UInt16)response[index++] << 8) | response[index++]) / 10.0;
                WaterPumpSpeed2 = (double)(((UInt16)response[index++] << 8) | response[index++]) / 10.0;
                ErrorFlags = ((UInt32)response[index++] << 24) | ((UInt32)response[index++] << 16) | ((UInt32)response[index++] << 8) | response[index++];
            }
        }
    }
}
