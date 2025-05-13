using System;
using System.Collections.Generic;

namespace OMMAuto
{
    public class Global
    {
        public static List<PlcInfo> PlcInfos = new List<PlcInfo>();

        public static List<CfgInfo> CfgInfos = new List<CfgInfo>();
    }

    public class PlcInfo
    {
        public string PlcName { get; set; }

        public int Address { get; set; }

        public int Count { get; set; }
    }

    public class CfgInfo
    {
        public string Key { get; set; }

        public string Value { get; set; }
    }

    public class Request
    {
        public int Status { get; set; }
        public string Ip { get; set; }
        public ImageData ImageData { get; set; }
    }

    public struct ImageData
    {
        public IntPtr Image;
        public int Width;
        public int Height;
        public int Channels;
    }

    public class Response
    {
        public string ResultStatus { get; set; }
        public string ReceivedMessage { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class InspectRunStatus
    {
        public string deviceId { get; set; }
        public string runStatus { get; set; }
    }

    public class RequestIwpFiles
    {
        public string deviceId { get; set; }
        public string fileName { get; set; }
        public string MeasurementNo { get; set; }
    }

    public class ResponseIwpFiles
    {
        public string status { get; set; }
        public string message { get; set; }
    }

    public class MeasuredResult
    {
        public string deviceId { get; set; }
        public string result { get; set; }
    }

    public class MachineReadyResult
    {
        public string deviceId { get; set; }
        public string isReady { get; set; }
    }

    public class RequestMeasuringSignal
    {
        public string deviceId { get; set; }
        public string signal { get; set; }
    }

    public class ResponseMeasuringSignal
    {
        public string status { get; set; }
        public string message { get; set; }
    }

    public class RequestLoadingUnloading
    {
        public string deviceId { get; set; }
        public string value { get; set; }
    }

    public class ResponseLoadingUnloading
    {
        public string status { get; set; }
        public string message { get; set; }
    }
}
