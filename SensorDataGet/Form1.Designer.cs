namespace SensorDataGet
{
    partial class 電腦數據顯示程式
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.checkBox_update_0 = new System.Windows.Forms.CheckBox();
            this.checkBox_update_1 = new System.Windows.Forms.CheckBox();
            this.checkBox_update_3 = new System.Windows.Forms.CheckBox();
            this.checkBox_update_5 = new System.Windows.Forms.CheckBox();
            this.checkBox_update_10 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.serialPort_ToArduino = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_openHardware_IsConnect = new System.Windows.Forms.Label();
            this.label_Arduino_IsConnect = new System.Windows.Forms.Label();
            this.treeView = new System.Windows.Forms.TreeView();
            this.dataSet1 = new System.Data.DataSet();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox_update_0
            // 
            this.checkBox_update_0.AutoSize = true;
            this.checkBox_update_0.Font = new System.Drawing.Font("標楷體", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_update_0.Location = new System.Drawing.Point(661, 203);
            this.checkBox_update_0.Name = "checkBox_update_0";
            this.checkBox_update_0.Size = new System.Drawing.Size(183, 52);
            this.checkBox_update_0.TabIndex = 1;
            this.checkBox_update_0.Text = "0.5 秒";
            this.checkBox_update_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox_update_0.UseVisualStyleBackColor = true;
            this.checkBox_update_0.CheckedChanged += new System.EventHandler(this.checkBox_update_0_CheckedChanged);
            // 
            // checkBox_update_1
            // 
            this.checkBox_update_1.AutoSize = true;
            this.checkBox_update_1.Checked = true;
            this.checkBox_update_1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_update_1.Font = new System.Drawing.Font("標楷體", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_update_1.Location = new System.Drawing.Point(661, 279);
            this.checkBox_update_1.Name = "checkBox_update_1";
            this.checkBox_update_1.Size = new System.Drawing.Size(135, 52);
            this.checkBox_update_1.TabIndex = 2;
            this.checkBox_update_1.Text = "1 秒";
            this.checkBox_update_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox_update_1.UseVisualStyleBackColor = true;
            this.checkBox_update_1.CheckedChanged += new System.EventHandler(this.checkBox_update_1_CheckedChanged);
            // 
            // checkBox_update_3
            // 
            this.checkBox_update_3.AutoSize = true;
            this.checkBox_update_3.Font = new System.Drawing.Font("標楷體", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_update_3.Location = new System.Drawing.Point(661, 349);
            this.checkBox_update_3.Name = "checkBox_update_3";
            this.checkBox_update_3.Size = new System.Drawing.Size(135, 52);
            this.checkBox_update_3.TabIndex = 3;
            this.checkBox_update_3.Text = "3 秒";
            this.checkBox_update_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox_update_3.UseVisualStyleBackColor = true;
            this.checkBox_update_3.CheckedChanged += new System.EventHandler(this.checkBox_update_3_CheckedChanged);
            // 
            // checkBox_update_5
            // 
            this.checkBox_update_5.AutoSize = true;
            this.checkBox_update_5.Font = new System.Drawing.Font("標楷體", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_update_5.Location = new System.Drawing.Point(661, 435);
            this.checkBox_update_5.Name = "checkBox_update_5";
            this.checkBox_update_5.Size = new System.Drawing.Size(135, 52);
            this.checkBox_update_5.TabIndex = 4;
            this.checkBox_update_5.Text = "5 秒";
            this.checkBox_update_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox_update_5.UseVisualStyleBackColor = true;
            this.checkBox_update_5.CheckedChanged += new System.EventHandler(this.checkBox_update_5_CheckedChanged);
            // 
            // checkBox_update_10
            // 
            this.checkBox_update_10.AutoSize = true;
            this.checkBox_update_10.Font = new System.Drawing.Font("標楷體", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_update_10.Location = new System.Drawing.Point(661, 511);
            this.checkBox_update_10.Name = "checkBox_update_10";
            this.checkBox_update_10.Size = new System.Drawing.Size(159, 52);
            this.checkBox_update_10.TabIndex = 5;
            this.checkBox_update_10.Text = "10 秒";
            this.checkBox_update_10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox_update_10.UseVisualStyleBackColor = true;
            this.checkBox_update_10.CheckedChanged += new System.EventHandler(this.checkBox_update_10_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("標楷體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(681, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 27);
            this.label1.TabIndex = 8;
            this.label1.Text = "更新時間";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("標楷體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(120, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(334, 27);
            this.label2.TabIndex = 9;
            this.label2.Text = "OpenHardware 獲取的資料";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // serialPort_ToArduino
            // 
            this.serialPort_ToArduino.DiscardNull = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("標楷體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(615, 682);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(306, 27);
            this.label3.TabIndex = 10;
            this.label3.Text = "OpenHardware 連線狀況";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("標楷體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(625, 944);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(236, 27);
            this.label4.TabIndex = 12;
            this.label4.Text = "Arduino 連線狀況";
            // 
            // label_openHardware_IsConnect
            // 
            this.label_openHardware_IsConnect.BackColor = System.Drawing.Color.Red;
            this.label_openHardware_IsConnect.Font = new System.Drawing.Font("標楷體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_openHardware_IsConnect.Location = new System.Drawing.Point(673, 791);
            this.label_openHardware_IsConnect.Name = "label_openHardware_IsConnect";
            this.label_openHardware_IsConnect.Size = new System.Drawing.Size(150, 50);
            this.label_openHardware_IsConnect.TabIndex = 14;
            this.label_openHardware_IsConnect.Text = "未連線";
            this.label_openHardware_IsConnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Arduino_IsConnect
            // 
            this.label_Arduino_IsConnect.BackColor = System.Drawing.Color.Red;
            this.label_Arduino_IsConnect.Font = new System.Drawing.Font("標楷體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Arduino_IsConnect.Location = new System.Drawing.Point(670, 1027);
            this.label_Arduino_IsConnect.Name = "label_Arduino_IsConnect";
            this.label_Arduino_IsConnect.Size = new System.Drawing.Size(150, 50);
            this.label_Arduino_IsConnect.TabIndex = 15;
            this.label_Arduino_IsConnect.Text = "未連線";
            this.label_Arduino_IsConnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // treeView
            // 
            this.treeView.Font = new System.Drawing.Font("標楷體", 12F);
            this.treeView.FullRowSelect = true;
            this.treeView.Location = new System.Drawing.Point(89, 70);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(387, 1064);
            this.treeView.TabIndex = 16;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // label5
            // 
            this.label5.AutoEllipsis = true;
            this.label5.Font = new System.Drawing.Font("標楷體", 12F);
            this.label5.Location = new System.Drawing.Point(1028, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(353, 425);
            this.label5.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoEllipsis = true;
            this.label6.Font = new System.Drawing.Font("標楷體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(1060, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(250, 27);
            this.label6.TabIndex = 19;
            this.label6.Text = "傳給Arduino的資料";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoEllipsis = true;
            this.label7.Font = new System.Drawing.Font("標楷體", 12F);
            this.label7.Location = new System.Drawing.Point(1028, 755);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(400, 200);
            this.label7.TabIndex = 23;
            this.label7.Text = "狀況說明";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("標楷體", 20F);
            this.label9.Location = new System.Drawing.Point(1117, 682);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(180, 27);
            this.label9.TabIndex = 24;
            this.label9.Text = "程式運行狀況";
            // 
            // 電腦數據顯示程式
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1625, 1162);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.label_Arduino_IsConnect);
            this.Controls.Add(this.label_openHardware_IsConnect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_update_10);
            this.Controls.Add(this.checkBox_update_5);
            this.Controls.Add(this.checkBox_update_3);
            this.Controls.Add(this.checkBox_update_1);
            this.Controls.Add(this.checkBox_update_0);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Font = new System.Drawing.Font("標楷體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Name = "電腦數據顯示程式";
            this.Text = "電腦數據顯示程式";
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox checkBox_update_0;
        private System.Windows.Forms.CheckBox checkBox_update_1;
        private System.Windows.Forms.CheckBox checkBox_update_3;
        private System.Windows.Forms.CheckBox checkBox_update_5;
        private System.Windows.Forms.CheckBox checkBox_update_10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.IO.Ports.SerialPort serialPort_ToArduino;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_openHardware_IsConnect;
        private System.Windows.Forms.Label label_Arduino_IsConnect;
        private System.Windows.Forms.TreeView treeView;
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
    }
}

