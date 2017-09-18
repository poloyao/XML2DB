using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.Serialization;

namespace XmlToDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        [Serializable]
        public class aaaa
        {
            /// <summary>
            /// 操作模式
            /// </summary>
            public string OperatingMode { get; set; }
            /// <summary>
            /// 移动数据标识
            /// </summary>
            public string MobileDataId { get; set; }
        }

        List<ProcessItem> pis = new List<ProcessItem>();
        List<TruckXML> trucks = new List<TruckXML>();
        List<JobXML> jobs = new List<JobXML>();
        List<ServiceXML> servs = new List<ServiceXML>();

        string DBIP, DBName, UseName, UsePws = "";
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请选择数据源文件");
                return;
            }
            //@"F:\Samples\卡车\Mawis_M_309_LBK3446_20170721141202.xml"
            XDocument document = XDocument.Load(@textBox1.Text);
            string xml = document.ToString();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            string json = Newtonsoft.Json.JsonConvert.SerializeXmlNode(doc);
            var ssahh = json.Replace("}},\"ProcessingState\"", "}]},\"ProcessingState\"");
            var asdjj = ssahh.Replace("\"Service\":{", "\"Service\":[{");
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(asdjj)))
            {
                System.Runtime.Serialization.Json.DataContractJsonSerializer dcj = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(Root));
                
                var veh = (Root)dcj.ReadObject(ms);

                //单独的字典表
                var process = veh.ROOT.Tour.ProcessTable;
                pis = veh.ROOT.Tour.ProcessTable.Process;
                using (CodeDBContext db = new CodeDBContext($"Data Source={DBIP};Initial Catalog={DBName};Persist Security Info=True;User ID={UseName};password={UsePws}"))
                {
                    var query = db.Process.ToList();
                    //数据不对称则清空重新填入
                    if (query.Count != pis.Count)
                    {
                        db.Process.RemoveRange(query);
                        db.SaveChanges();
                        foreach (var item in pis)
                        {
                            db.Process.Add(item);
                        }
                        db.SaveChanges();
                    }
                }


                TruckXML truck = new TruckXML();

                #region 组合
                
                truck.OperatingMode = veh.ROOT.OperatingMode;
                truck.MobileDataId = veh.ROOT.MobileDataId;
                truck.Number = veh.ROOT.Tour.Number;
                truck.ProcessingState = veh.ROOT.Tour.ProcessingState;
                truck.GUID = veh.ROOT.Tour.GUID;

                truck.TruckId = veh.ROOT.Tour.TruckInfo.TruckId;
                truck.StartDateTime = veh.ROOT.Tour.TruckInfo.StartDateTime;
                truck.EndDateTime = veh.ROOT.Tour.TruckInfo.EndDateTime;
                truck.CollectingTime = veh.ROOT.Tour.TruckInfo.CollectingTime;
                truck.DriveTime = veh.ROOT.Tour.TruckInfo.DriveTime;
                truck.DistanceUnit = veh.ROOT.Tour.TruckInfo.Distance.Unit;
                truck.DistanceValue = veh.ROOT.Tour.TruckInfo.Distance.Value;
                truck.FuelConsumptionUnit = veh.ROOT.Tour.TruckInfo.FuelConsumption.Unit;
                truck.FuelConsumptionValue = veh.ROOT.Tour.TruckInfo.FuelConsumption.Value;

                #endregion

                using (CodeDBContext db = new CodeDBContext($"Data Source={DBIP};Initial Catalog={DBName};Persist Security Info=True;User ID={UseName};password={UsePws}"))
                {
                    var truckSaved = db.TruckXML.Add(truck);
                    db.SaveChanges();
                    foreach (var item in veh.ROOT.Tour.JobTable.Job)
                    {
                        JobXML job = new JobXML();

                        job.TruckID = truckSaved.ID;

                        job.Number = item.Number;
                        job.ProcessingState = item.ProcessingState;

                        var jobSaved = db.JobXML.Add(job);
                        db.SaveChanges();
                        if (item.ServiceTable == null)
                            continue;
                        foreach (var service in item.ServiceTable.Service)
                        {
                            ServiceXML serTemp = new ServiceXML();

                            #region 组合

                            serTemp.ActualDate = service.ActualDate;
                            if (service.Container != null)
                            {
                                serTemp.ContainerData = service.Container.Identification.Id.Data;
                                serTemp.ContainerPage = service.Container.Identification.Id.Page;
                                serTemp.ContainerType = service.Container.Identification.Type;
                                serTemp.ContainerNumber = service.Container.Number;
                            }
                            serTemp.GUID = service.GUID;

                            serTemp.EW = service.GeoPosition.EW;
                            serTemp.Latitude = service.GeoPosition.Latitude;
                            serTemp.Longitude = service.GeoPosition.Longitude;
                            serTemp.NS = service.GeoPosition.NS;
                            serTemp.Quality = service.GeoPosition.Quality;

                            serTemp.Number = service.Number;
                            serTemp.Process = service.Process;
                            serTemp.ProcessingState = service.ProcessingState;
                            serTemp.Result = service.Result;
                            if (service.Scale != null)
                            {
                                serTemp.WeightCRC = service.Scale.Weight.CRC;
                                if (service.Scale.Weight.Gross != null)
                                {
                                    serTemp.GrossUnit = service.Scale.Weight.Gross.Unit;
                                    serTemp.GrossValue = service.Scale.Weight.Gross.Value;
                                }
                                if (service.Scale.Weight.Net != null)
                                {
                                    serTemp.NetUnit = service.Scale.Weight.Net.Unit;
                                    serTemp.NetValue = service.Scale.Weight.Net.Value;
                                }
                                serTemp.WeightRecordNo = service.Scale.Weight.RecordNo;
                                serTemp.WeightRecordTime = service.Scale.Weight.RecordTime;
                                serTemp.WeightState = service.Scale.Weight.State;
                                if (service.Scale.Weight.Tare != null)
                                {
                                    serTemp.TareUnit = service.Scale.Weight.Tare.Unit;
                                    serTemp.TareValue = service.Scale.Weight.Tare.Value;
                                }
                                serTemp.WeightRecordPrint = service.Scale.WeightRecordPrint;
                            }
                            #endregion

                            serTemp.JobID = jobSaved.ID;

                            db.ServiceXML.Add(serTemp);
                        }
                    }
                    db.SaveChanges();
                    MessageBox.Show("数据导入完成");
                }
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] files = e.Data.GetData(DataFormats.FileDrop, false) as string[];
                foreach (string srcfile in files)
                {
                    textBox1.Text = srcfile;
                    break;
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, " Error ",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DBIP = textBox_IP.Text;
            DBName = textBox_DBname.Text;
            UseName = textBox_Name.Text;
            UsePws = textBox_Pws.Text;

            try
            {
                using (CodeDBContext db = new CodeDBContext($"Data Source={DBIP};Initial Catalog={DBName};Persist Security Info=True;User ID={UseName};password={UsePws}"))
                {
                    db.Process.ToList();
                    button1.Enabled = true;
                    label7.Visible = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("数据库连接失败");
            }

        }
    }
}
