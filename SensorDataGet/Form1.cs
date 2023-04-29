using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO.MemoryMappedFiles;
using System.IO;
using System.Xml;
using OpenHardwareMonitor.Hardware;
using System.Management;
using System.Threading;

namespace SensorDataGet
{
    public partial class 電腦數據顯示程式 : Form
    {

        public Dictionary<string, List<XmlNode>> DataDictionaryFromAida64 = new Dictionary<string, List<XmlNode>>();
        public bool Initialize = false;
        public bool LightWeightMode = false;
        private float?[] data = new float?[14];
        public enum Data : int { 
            cpuUtil = 0,
            cpuTemp = 1,
            cpuClock = 2,
            cpuPower = 3,
            gpuUtil = 4,
            gpuTemp = 5,
            gpuClock = 6,
            gpuPower = 7,
            vramUsed = 8,
            vramFree = 9,
            vramUtil = 10,
            ramUsed = 11,
            ramFree = 12,
            ramUtil = 13
        }

        static Computer computer = new Computer()
        {
            GPUEnabled = true,
            CPUEnabled = true,
            RAMEnabled = true, 
            MainboardEnabled = false,  
            HDDEnabled = false, 
        };


        public 電腦數據顯示程式()
        {
            InitializeComponent();
            GetDataFromOpenHardware();
            CheckArduinoConnect();
        }

        private void checkBox_update_0_CheckedChanged(object sender, EventArgs e){
            if (checkBox_update_0.Checked == true)
            {
                checkBox_update_1.Checked = false;
                checkBox_update_3.Checked = false;
                checkBox_update_5.Checked = false;
                checkBox_update_10.Checked = false;
                UpdateTimeChange(500);
            }
        }

        private void checkBox_update_1_CheckedChanged(object sender, EventArgs e){
            if (checkBox_update_1.Checked == true)
            {
                checkBox_update_0.Checked = false;
                checkBox_update_3.Checked = false;
                checkBox_update_5.Checked = false;
                checkBox_update_10.Checked = false;
                UpdateTimeChange(1000);
            }
        }

        private void checkBox_update_3_CheckedChanged(object sender, EventArgs e){
            if (checkBox_update_3.Checked == true)
            {
                checkBox_update_1.Checked = false;
                checkBox_update_0.Checked = false;
                checkBox_update_5.Checked = false;
                checkBox_update_10.Checked = false;
                UpdateTimeChange(3000);
            }
        }

        private void checkBox_update_5_CheckedChanged(object sender, EventArgs e){
            if (checkBox_update_5.Checked == true)
            {
                checkBox_update_1.Checked = false;
                checkBox_update_3.Checked = false;
                checkBox_update_0.Checked = false;
                checkBox_update_10.Checked = false;
                UpdateTimeChange(5000);
            }
        }

        private void checkBox_update_10_CheckedChanged(object sender, EventArgs e){
            if (checkBox_update_10.Checked == true)
            {
                checkBox_update_1.Checked = false;
                checkBox_update_3.Checked = false;
                checkBox_update_5.Checked = false;
                checkBox_update_0.Checked = false;
                UpdateTimeChange(10000);
            }
        }

        private void UpdateTimeChange(int time) {
            timer1.Interval = time;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
<<<<<<< Updated upstream
=======
            CheckArduinoConnect();
            UpdateDataOnGui();
>>>>>>> Stashed changes
            GetDataFromOpenHardware();
            string sendstring = SendDataToArduino();
            label5.Text = sendstring;
        }


<<<<<<< Updated upstream


        private void GetDataFromOpenHardware()
        {
            try { computer.Open(); } catch { label_openHardware_IsConnect.Text = "未連線"; label_openHardware_IsConnect.BackColor = Color.Red; }
            label_openHardware_IsConnect.Text = "已連線"; label_openHardware_IsConnect.BackColor = Color.Green;
            treeView.Nodes.Clear();
=======

        private void UpdateDataOnGui() {

            try
            {
                computer.Open();
                label_openHardware_IsConnect.Text = "已連線";
                label_openHardware_IsConnect.BackColor = Color.Green;
            }
            catch
            {
                label_openHardware_IsConnect.Text = "未連線";
                label_openHardware_IsConnect.BackColor = Color.Red;
            }


            foreach (var Hardware in computer.Hardware)
            {
                TreeNode HardwareNode;
                if (treeView.Nodes.ContainsKey(Hardware.Name))
                    HardwareNode = treeView.Nodes.Find(Hardware.Name,true)[0];
                else
                    HardwareNode = new TreeNode(Hardware.Name);

                HardwareNode.Name = Hardware.Name;
                Hardware.Update();

                //建立要傳給treenode的資料
                foreach (var Sensor in Hardware.Sensors)
                {
                    string unit = " ";
                    switch (Sensor.SensorType)
                    {
                        case SensorType.Clock:
                            unit = "Hz";
                            break;
                        case SensorType.Data:
                            unit = "GB";
                            break;
                        case SensorType.Fan:
                            unit = "RPM";
                            break;
                        case SensorType.Load:
                            unit = "%";
                            break;
                        case SensorType.Power:
                            unit = "W";
                            break;
                        case SensorType.SmallData:
                            unit = "MB";
                            break;
                        case SensorType.Temperature:
                            unit = "°C";
                            break;
                        case SensorType.Throughput:
                            unit = "MB/s";
                            break;
                        case SensorType.Voltage:
                            unit = "V";
                            break;
                    }
                    if (HardwareNode.Nodes.ContainsKey(Sensor.SensorType.ToString()))
                    {
                        if (HardwareNode.Nodes.Find(Sensor.SensorType.ToString(), true)[0].Nodes.ContainsKey(Sensor.SensorType.ToString() + "/" + Sensor.Name.ToString()))
                            HardwareNode.Nodes.Find(Sensor.SensorType.ToString() + "/" + Sensor.Name.ToString(), true)[0].Text = Sensor.Name + ":" + string.Format("{0:0.00}", Sensor.Value) + " " + unit;
                        else
                        {
                            TreeNode DataNode = new TreeNode(Sensor.Name.ToString());
                            DataNode.Name = Sensor.SensorType.ToString() + "/" + Sensor.Name.ToString();
                            DataNode.Text = Sensor.Name + ":" + string.Format("{0:0.00}", Sensor.Value) + " " + unit;
                            HardwareNode.Nodes.Find(Sensor.SensorType.ToString(), true)[0].Nodes.Add(DataNode);
                        }
                    }
                    else
                    {
                        TreeNode hardwareNode = new TreeNode(Sensor.SensorType.ToString());
                        TreeNode DataNode = new TreeNode(Sensor.Name.ToString());

                        hardwareNode.Name = Sensor.SensorType.ToString();
                        hardwareNode.Expand();

                        DataNode.Name = Sensor.SensorType.ToString() + "/" + Sensor.Name.ToString();
                        DataNode.Text = Sensor.Name + ":" + string.Format("{0:0.00}", Sensor.Value) + " " + unit;

                        hardwareNode.Nodes.Add(DataNode);
                        HardwareNode.Nodes.Add(hardwareNode);
                    }
                }


                HardwareNode.Expand();
                if(!treeView.Nodes.ContainsKey(Hardware.Name))
                    treeView.Nodes.Add(HardwareNode);
            }
            

        }



        private void GetDataFromOpenHardware()
        {
            try { 
                computer.Open();
                label_openHardware_IsConnect.Text = "已連線"; 
                label_openHardware_IsConnect.BackColor = Color.Green;
            } catch { 
                label_openHardware_IsConnect.Text = "未連線"; 
                label_openHardware_IsConnect.BackColor = Color.Red; 
            }

            //treeView.Nodes.Clear();

>>>>>>> Stashed changes
            foreach (var Hardware in computer.Hardware) {
                //建立要傳給Arduino的資料
                TreeNode HardwareNode = new TreeNode(Hardware.Name);
                Hardware.Update();
                if (Hardware.HardwareType == HardwareType.CPU)
                {
                    float highestClock = 0;
                    float highestTemp = 0;
                    foreach (var Sensor in Hardware.Sensors)
                    {
                        if (Sensor.SensorType == SensorType.Clock)
                            highestClock = (Sensor.Value > highestClock) ? (float)Sensor.Value : highestClock;
                        if (Sensor.SensorType == SensorType.Temperature)
                            highestTemp = (Sensor.Value > highestTemp) ? (float)Sensor.Value : highestTemp;
                        if (Sensor.Name == "CPU Package" && Sensor.SensorType == SensorType.Power)
                            data[(int)Data.cpuPower] = (float)Sensor.Value;
                        if (Sensor.Name == "CPU Total" && Sensor.SensorType == SensorType.Load)
                            data[(int)Data.cpuUtil] = (float)Sensor.Value;
                        data[(int)Data.cpuClock] = highestClock;
                        data[(int)Data.cpuTemp] = highestTemp;
                    }
                }
                if (Hardware.HardwareType == HardwareType.GpuNvidia)
                {
                    foreach (var Sensor in Hardware.Sensors)
                    {
                        if (Sensor.Name == "GPU Core" && Sensor.SensorType == SensorType.Clock)
                            data[(int)Data.gpuClock] = (float)Sensor.Value;
                        if (Sensor.Name == "GPU Core" && Sensor.SensorType == SensorType.Temperature)
                            data[(int)Data.gpuTemp] = (float)Sensor.Value;
                        //if (Sensor.SensorType == SensorType.Power)
<<<<<<< Updated upstream
                            data[(int)Data.gpuPower] = (float)100;
=======
                        //    data[(int)Data.gpuPower] = (float)100;
>>>>>>> Stashed changes
                        if (Sensor.Name == "GPU Core" && Sensor.SensorType == SensorType.Load)
                            data[(int)Data.gpuUtil] = (float)Sensor.Value;
                        if (Sensor.Name == "GPU Memory Free" && Sensor.SensorType == SensorType.SmallData)
                            data[(int)Data.vramFree] = (float)Sensor.Value;
                        if (Sensor.Name == "GPU Memory Used" && Sensor.SensorType == SensorType.SmallData)
                            data[(int)Data.vramUsed] = (float)Sensor.Value;
                        if (Sensor.Name == "GPU Memory" && Sensor.SensorType == SensorType.Load)
                            data[(int)Data.vramUtil] = (float)Sensor.Value;
                    }
                }
                if (Hardware.HardwareType == HardwareType.RAM)
                {
                    foreach (var Sensor in Hardware.Sensors)
                    {
                        if (Sensor.Name == "Used Memory" && Sensor.SensorType == SensorType.Data)
                            data[(int)Data.ramFree] = (float)Sensor.Value;
                        if (Sensor.Name == "Available Memory" && Sensor.SensorType == SensorType.Data)
                            data[(int)Data.ramUsed] = (float)Sensor.Value;
                        if (Sensor.Name == "Memory" && Sensor.SensorType == SensorType.Load)
                            data[(int)Data.ramUtil] = (float)Sensor.Value;

                    }
                }
<<<<<<< Updated upstream

                //建立要傳給treenode的資料
                foreach (var Sensor in Hardware.Sensors) {
                    string unit = " ";
                    switch (Sensor.SensorType)
                    {
                        case SensorType.Clock:
                            unit = "Hz";
                            break;
                        case SensorType.Data:
                            unit = "GB";
                            break;
                        case SensorType.Fan:
                            unit = "RPM";
                            break;
                        case SensorType.Load:
                            unit = "%";
                            break;
                        case SensorType.Power:
                            unit = "W";
                            break;
                        case SensorType.SmallData:
                            unit = "MB";
                            break;
                        case SensorType.Temperature:
                            unit = "°C";
                            break;
                        case SensorType.Throughput:
                            unit = "MB/s";
                            break;
                        case SensorType.Voltage:
                            unit = "V";
                            break;
                    }
                    if (HardwareNode.Nodes.ContainsKey(Sensor.SensorType.ToString()))
                         HardwareNode.Nodes.Find(Sensor.SensorType.ToString(), true)[0].Nodes.Add(new TreeNode(Sensor.Name + ":" + string.Format("{0:0.00}", Sensor.Value) + " " + unit));
                     else
                     {
                         TreeNode hardwareNode = new TreeNode(Sensor.SensorType.ToString());
                         hardwareNode.Name = Sensor.SensorType.ToString();
                         hardwareNode.Expand();
                         
                         hardwareNode.Nodes.Add(new TreeNode(Sensor.Name + ":" + string.Format("{0:0.00}", Sensor.Value) + " " + unit));
                         HardwareNode.Nodes.Add(hardwareNode);
                     }
                }


                HardwareNode.Expand();
                treeView.Nodes.Add(HardwareNode);
=======
                
>>>>>>> Stashed changes
            }
                

        }
        

        private String SendDataToArduino() {

            string StringToSent = "";

            for (int i = 0; i < Enum.GetNames(typeof(Data)).Length; i++) {
                string temp = i +":"+ string.Format("{0:0.00}",data[i])+",";
                StringToSent += temp;
                if (serialPort_ToArduino.IsOpen)
                {
                    serialPort_ToArduino.WriteLine(temp);
                    Thread.Sleep(10);
                }
                else {
                    label_Arduino_IsConnect.Text = "未連線";
                    label_Arduino_IsConnect.BackColor = Color.Red;
<<<<<<< Updated upstream
                    CheckArduinoConnect();
=======
>>>>>>> Stashed changes
                }
            }


            return StringToSent;
        }

 
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
        private void treeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode ChildNode in e.Node.Nodes) {
                ChildNode.Checked = e.Node.Checked;
            }
        }



        private String FindArduino()
        {
            ManagementScope managementScope = new ManagementScope();
            SelectQuery selectQuery = new SelectQuery("SELECT * FROM Win32_SerialPort");
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(managementScope, selectQuery);
            try
            {
                foreach (ManagementObject item in managementObjectSearcher.Get())
                 {
                     string devices = item["Description"].ToString();
                     string deviceid = item["DeviceID"].ToString();
                     if (devices.Contains("CH340"))
                     {
                         return deviceid;
                     }
                 }
            }
            catch (ManagementException e) { }
            return null;
        }//https://stackoverflow.com/questions/3293889/how-to-auto-detect-arduino-com-port
        //只能自動找到正版Arduino 盜版的不行

        private void CheckArduinoConnect()
        {
            String PortName = FindArduino();
            if (!serialPort_ToArduino.IsOpen)
            {
<<<<<<< Updated upstream
                serialPort_ToArduino.PortName = "COM3";//正版Arduino的改成PortName;即可自動偵測 盜版的請自行輸入
                serialPort_ToArduino.BaudRate = 115200;
                serialPort_ToArduino.ReadTimeout = 300;
=======
>>>>>>> Stashed changes
                try
                {
                    serialPort_ToArduino.PortName = "COM3";//正版Arduino的改成PortName;即可自動偵測 盜版的請自行輸入
                    serialPort_ToArduino.BaudRate = 115200;
                    serialPort_ToArduino.ReadTimeout = 300;
                    label7.Text = PortName;
                    serialPort_ToArduino.Open();
                    if (serialPort_ToArduino.IsOpen)
                    {
                        label_Arduino_IsConnect.Text = "已連線";
                        label_Arduino_IsConnect.BackColor = Color.Green;
                    }
                }
                catch (Exception e) {
<<<<<<< Updated upstream
                    label_Arduino_IsConnect.Text = "未連線";
                    label_Arduino_IsConnect.BackColor = Color.Red;
                }
=======
                    serialPort_ToArduino.Close();
                    label_Arduino_IsConnect.Text = "未連線";
                    label_Arduino_IsConnect.BackColor = Color.Red;
                }
            }
            else {
                label7.Text = PortName;
>>>>>>> Stashed changes
            }
        }
<<<<<<< Updated upstream
=======


>>>>>>> Stashed changes
    }
}
