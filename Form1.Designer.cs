namespace CS_NVRAM
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DeviceSelection = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MotorTypeSelect = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CANBaudSelect = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CANNodeUpDown = new System.Windows.Forms.NumericUpDown();
            this.NVRAMButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CANNodeUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // DeviceSelection
            // 
            this.DeviceSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceSelection.FormattingEnabled = true;
            this.DeviceSelection.Items.AddRange(new object[] {
            "MC5x113",
            "Juno",
            "Atlas"});
            this.DeviceSelection.Location = new System.Drawing.Point(282, 30);
            this.DeviceSelection.Name = "DeviceSelection";
            this.DeviceSelection.Size = new System.Drawing.Size(257, 37);
            this.DeviceSelection.TabIndex = 1;
            this.DeviceSelection.SelectedIndexChanged += new System.EventHandler(this.DeviceSelection_SelectedIndexChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(170, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Device";
            // 
            // MotorTypeSelect
            // 
            this.MotorTypeSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MotorTypeSelect.FormattingEnabled = true;
            this.MotorTypeSelect.Items.AddRange(new object[] {
            "Do Not Program",
            "3-Phase Brushless",
            "2-Phase MicroStepping",
            "1-Phase Brushed"});
            this.MotorTypeSelect.Location = new System.Drawing.Point(282, 92);
            this.MotorTypeSelect.Name = "MotorTypeSelect";
            this.MotorTypeSelect.Size = new System.Drawing.Size(257, 37);
            this.MotorTypeSelect.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(127, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "MotorType";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(99, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "CAN Node ID";
            // 
            // CANBaudSelect
            // 
            this.CANBaudSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CANBaudSelect.FormattingEnabled = true;
            this.CANBaudSelect.Items.AddRange(new object[] {
            "1M",
            "800K",
            "500K",
            "250K",
            "125K",
            "50K",
            "20K",
            "10K"});
            this.CANBaudSelect.Location = new System.Drawing.Point(282, 229);
            this.CANBaudSelect.Name = "CANBaudSelect";
            this.CANBaudSelect.Size = new System.Drawing.Size(257, 37);
            this.CANBaudSelect.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(132, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 29);
            this.label4.TabIndex = 8;
            this.label4.Text = "CAN Baud";
            // 
            // CANNodeUpDown
            // 
            this.CANNodeUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CANNodeUpDown.Location = new System.Drawing.Point(284, 162);
            this.CANNodeUpDown.Name = "CANNodeUpDown";
            this.CANNodeUpDown.Size = new System.Drawing.Size(255, 35);
            this.CANNodeUpDown.TabIndex = 9;
            // 
            // NVRAMButton
            // 
            this.NVRAMButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NVRAMButton.Location = new System.Drawing.Point(33, 307);
            this.NVRAMButton.Name = "NVRAMButton";
            this.NVRAMButton.Size = new System.Drawing.Size(262, 70);
            this.NVRAMButton.TabIndex = 10;
            this.NVRAMButton.Text = "Program NVRAM";
            this.NVRAMButton.UseVisualStyleBackColor = true;
            this.NVRAMButton.Click += new System.EventHandler(this.NVRAMButton_Click_1);
            // 
            // ExitButton
            // 
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.Location = new System.Drawing.Point(419, 307);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(120, 70);
            this.ExitButton.TabIndex = 11;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 425);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.NVRAMButton);
            this.Controls.Add(this.CANNodeUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CANBaudSelect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MotorTypeSelect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DeviceSelection);
            this.Name = "Form1";
            this.Text = "Device";
            ((System.ComponentModel.ISupportInitialize)(this.CANNodeUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox DeviceSelection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox MotorTypeSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CANBaudSelect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown CANNodeUpDown;
        private System.Windows.Forms.Button NVRAMButton;
        private System.Windows.Forms.Button ExitButton;
    }
}

