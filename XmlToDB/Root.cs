using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlToDB
{
    /// <summary>
    /// 距离
    /// </summary>
    public class Distance
    {
        /// <summary>
        /// 
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Value { get; set; }
    }

    /// <summary>
    /// 燃油消耗
    /// </summary>
    public class FuelConsumption
    {
        /// <summary>
        /// 
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Value { get; set; }
    }

    /// <summary>
    /// 卡车信息
    /// </summary>
    public class TruckInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string TruckId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string StartDateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EndDateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CollectingTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DriveTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Distance Distance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FuelConsumption FuelConsumption { get; set; }
    }

    public class Id
    {
        /// <summary>
        /// 
        /// </summary>
        public string Page { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Data { get; set; }
    }

    public class Identification
    {
        /// <summary>
        /// 
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Id Id { get; set; }
    }

    public class Container
    {
        /// <summary>
        /// 
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Identification Identification { get; set; }
    }

    public class Net
    {
        /// <summary>
        /// 
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Value { get; set; }
    }

    /// <summary>
    /// 皮重
    /// </summary>
    public class Tare
    {
        /// <summary>
        /// 
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Value { get; set; }
    }
    /// <summary>
    /// 毛重
    /// </summary>
    public class Gross
    {
        /// <summary>
        /// 
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Value { get; set; }
    }
    /// <summary>
    /// 重量
    /// </summary>
    public class Weight
    {
        /// <summary>
        /// 
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Net Net { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Tare Tare { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Gross Gross { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RecordNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RecordTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CRC { get; set; }
    }

    /// <summary>
    /// 规格
    /// </summary>
    public class Scale
    {
        /// <summary>
        /// 
        /// </summary>
        public Weight Weight { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WeightRecordPrint { get; set; }
    }

    /// <summary>
    /// 地理位置
    /// </summary>
    public class GeoPosition
    {
        /// <summary>
        /// 
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EW { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Quality { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ServiceItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ActualDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Container Container { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Process { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Scale Scale { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public GeoPosition GeoPosition { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProcessingState { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string GUID { get; set; }
    }

    public class ServiceTable
    {
        /// <summary>
        /// 
        /// </summary>
        public string GUID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ServiceItem> Service { get; set; }


    }

    public class JobItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ServiceTable ServiceTable { get; set; }
        /// <summary>
        /// 处理状态
        /// </summary>
        public string ProcessingState { get; set; }
    }

    public class JobTable
    {
        /// <summary>
        /// 
        /// </summary>
        public List<JobItem> Job { get; set; }
    }



    
    public class ProcessItem
    {
        public int ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string StringID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string StringText { get; set; }
    }

    public class ProcessTable
    {
        /// <summary>
        /// 
        /// </summary>
        public List<ProcessItem> Process { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class Tour
    {
        /// <summary>
        /// 
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TruckInfo TruckInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public JobTable JobTable { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ProcessTable ProcessTable { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProcessingState { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string GUID { get; set; }
    }

    public class ROOT
    {
        /// <summary>
        /// 操作模式
        /// </summary>
        public string OperatingMode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Tour Tour { get; set; }
        /// <summary>
        /// 移动数据标识
        /// </summary>
        public string MobileDataId { get; set; }
    }

    public class Root
    {
        /// <summary>
        /// 
        /// </summary>
        public ROOT ROOT { get; set; }
    }
}
