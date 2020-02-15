using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.MemoryMappedFiles;
using System.IO;
using System.Xml;

namespace SensorDataGet
{
    public partial class 電腦數據顯示程式 : Form
    {

        public Dictionary<string, List<XmlNode>> DataDictionaryFromAida64 = new Dictionary<string, List<XmlNode>>();
        public bool Initialize = false;
        public bool LightWeightMode = false;
        private int DataSetRowCount = 0;

        public 電腦數據顯示程式()
        {
            InitializeComponent();
            GetDataFromAIDA64();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetDataFromAIDA64();
            label5.Text = SendToArduino();
        }

        private String SendToArduino() {

            String StringToSend = "";
            for (int x = 0; x < treeView.Nodes.Count; x++)
            {
                for (int y = 0; y < treeView.Nodes[x].Nodes.Count; y++) {
                    if (treeView.Nodes[x].Nodes[y].Checked) {
                        StringToSend += "<" + treeView.Nodes[x].Text + ">" + DataDictionaryFromAida64[treeView.Nodes[x].Text][y].ChildNodes[1].InnerText + ":" + DataDictionaryFromAida64[treeView.Nodes[x].Text][y].ChildNodes[2].InnerText+"\n";
                    }
                }
            }
            return StringToSend;
        }

        private void InitializeForm() {
            treeView.Nodes.Clear();
            foreach (KeyValuePair<string,List<XmlNode>> item in DataDictionaryFromAida64){
                TreeNode mainNode = new TreeNode(item.Key) {Checked = true};
                foreach (XmlNode node in item.Value) {
                    TreeNode newNode = new TreeNode(node.ChildNodes[1].InnerText) {Checked = true};
                    mainNode.Nodes.Add(newNode);
                }
                treeView.Nodes.Add(mainNode);
            }
            Initialize = true;
        }

        private XmlDocument GetDataFromAIDA64() {

            String data = "";
            XmlDocument DataXml = new XmlDocument();
            try
            {
                MemoryMappedFile Aida64_Data = MemoryMappedFile.OpenExisting("AIDA64_SensorValues");
                MemoryMappedViewStream stream = Aida64_Data.CreateViewStream();
                StreamReader reader = new StreamReader(stream);
                data = "<Root>" + reader.ReadToEnd() + "</Root>";
                label_AIDA64_IsConnect.Text = "已連線";
                label_AIDA64_IsConnect.BackColor = Color.Green;
                data = data.Replace("\0", " ");
                
                if (data != "")
                {
                    try
                    {
                        //XML讀取                  
                        DataXml.LoadXml(data);
                        label7.Text = "狀態正常";
                    }
                    catch(Exception e) { label7.Text = "error\n (等待數秒直到錯誤解除,等太久就重開)"+"\n"+e.Message; reader.DiscardBufferedData(); stream.Flush(); return new XmlDocument(); }
                    DataDictionaryFromAida64.Clear();
                    foreach (XmlNode xmlNode in DataXml.FirstChild.ChildNodes) {
                        if (!DataDictionaryFromAida64.ContainsKey(xmlNode.Name)){
                            DataDictionaryFromAida64.Add(xmlNode.Name, new List<XmlNode>() {xmlNode});
                        }
                        else {
                            DataDictionaryFromAida64[xmlNode.Name].Add(xmlNode);
                        }
                    }

                    if (!Initialize)
                        InitializeForm();

                    if (!LightWeightMode)
                    {
                        dataSet1.Clear();
                        dataSet1.ReadXml(new XmlNodeReader(DataXml));
                        for (int x = 0; x < (dataSet1.Tables.Count - 1); x++)
                        {
                            dataSet1.Tables[0].Merge(dataSet1.Tables[x + 1]);
                        }
                        dataGridView1.DataSource = dataSet1.Tables[0];

                        if (DataSetRowCount != dataGridView1.RowCount) {
                            DataSetRowCount = dataGridView1.RowCount;
                            InitializeForm();
                        }
                    }
                    else {
                        dataGridView1.DataSource = null;
                    }
                }
            }
            catch (FileNotFoundException) {
                label_AIDA64_IsConnect.Text = "未連線";
                label_AIDA64_IsConnect.BackColor = Color.Red;

            }
            return DataXml;
        }

        private void treeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode ChildNode in e.Node.Nodes) {
                ChildNode.Checked = e.Node.Checked;
            }
        }

        private void checkBox_lightweightMode_CheckedChanged(object sender, EventArgs e)
        {
            LightWeightMode = checkBox_lightweightMode.Checked;
        }

    }
}
