using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlToDB
{
    [Table("TruckXML")]
    public class TruckXML
    {

        public int ID { get; set; }
        /// <summary>
        /// 操作模式
        /// </summary>
        public string OperatingMode { get; set; }
        /// <summary>
        /// 移动数据标识
        /// </summary>
        public string MobileDataId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ProcessingState { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string GUID { get; set; }


        #region truckinfo

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
        public string DistanceUnit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DistanceValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FuelConsumptionUnit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FuelConsumptionValue { get; set; }

        #endregion


        #region JobTable


        #endregion

    }

    public class JobXML
    {
        public int ID { get; set; }

        public int TruckID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 处理状态
        /// </summary>
        public string ProcessingState { get; set; }
    }


    public class ServiceXML
    {

        public int ID { get; set; }

        public int JobID { get; set; }

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
        public string ContainerNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ContainerType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ContainerPage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ContainerData { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Process { get; set; }

        #region Weight

        /// <summary>
        /// 
        /// </summary>
        public string WeightState { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NetUnit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NetValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TareUnit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TareValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string GrossUnit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string GrossValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string WeightRecordNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WeightRecordTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WeightCRC { get; set; }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public string WeightRecordPrint { get; set; }

        #region GeoPosition

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

        #endregion


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
}
