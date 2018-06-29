namespace Sxh.Client
{
    partial class Settings
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
            this.pnlMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblKeywords = new System.Windows.Forms.Label();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.lblYijia = new System.Windows.Forms.Label();
            this.txtYijia = new System.Windows.Forms.TextBox();
            this.lblRate = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.flowButtonGroup = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblFreqTranser = new System.Windows.Forms.Label();
            this.txtFreqTranser = new System.Windows.Forms.TextBox();
            this.lblDelay = new System.Windows.Forms.Label();
            this.txtDelayTransfer = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.flowButtonGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.ColumnCount = 2;
            this.pnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.pnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlMain.Controls.Add(this.txtDelayTransfer, 1, 4);
            this.pnlMain.Controls.Add(this.lblDelay, 0, 4);
            this.pnlMain.Controls.Add(this.txtFreqTranser, 1, 3);
            this.pnlMain.Controls.Add(this.lblFreqTranser, 0, 3);
            this.pnlMain.Controls.Add(this.txtRate, 1, 2);
            this.pnlMain.Controls.Add(this.lblRate, 0, 2);
            this.pnlMain.Controls.Add(this.txtYijia, 1, 1);
            this.pnlMain.Controls.Add(this.lblYijia, 0, 1);
            this.pnlMain.Controls.Add(this.lblKeywords, 0, 0);
            this.pnlMain.Controls.Add(this.txtKeyword, 1, 0);
            this.pnlMain.Controls.Add(this.flowButtonGroup, 1, 6);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.RowCount = 7;
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.pnlMain.Size = new System.Drawing.Size(384, 211);
            this.pnlMain.TabIndex = 0;
            // 
            // lblKeywords
            // 
            this.lblKeywords.AutoSize = true;
            this.lblKeywords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKeywords.Location = new System.Drawing.Point(3, 0);
            this.lblKeywords.Name = "lblKeywords";
            this.lblKeywords.Size = new System.Drawing.Size(94, 28);
            this.lblKeywords.TabIndex = 0;
            this.lblKeywords.Text = "关键字";
            this.lblKeywords.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtKeyword
            // 
            this.txtKeyword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKeyword.Location = new System.Drawing.Point(103, 4);
            this.txtKeyword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(278, 23);
            this.txtKeyword.TabIndex = 1;
            // 
            // lblYijia
            // 
            this.lblYijia.AutoSize = true;
            this.lblYijia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblYijia.Location = new System.Drawing.Point(3, 28);
            this.lblYijia.Name = "lblYijia";
            this.lblYijia.Size = new System.Drawing.Size(94, 28);
            this.lblYijia.TabIndex = 2;
            this.lblYijia.Text = "溢价";
            this.lblYijia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtYijia
            // 
            this.txtYijia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtYijia.Location = new System.Drawing.Point(103, 32);
            this.txtYijia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtYijia.Name = "txtYijia";
            this.txtYijia.Size = new System.Drawing.Size(278, 23);
            this.txtYijia.TabIndex = 3;
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRate.Location = new System.Drawing.Point(3, 56);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(94, 28);
            this.lblRate.TabIndex = 4;
            this.lblRate.Text = "年化";
            this.lblRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRate
            // 
            this.txtRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRate.Location = new System.Drawing.Point(103, 60);
            this.txtRate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(278, 23);
            this.txtRate.TabIndex = 5;
            // 
            // flowButtonGroup
            // 
            this.flowButtonGroup.Controls.Add(this.btnSave);
            this.flowButtonGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowButtonGroup.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowButtonGroup.Location = new System.Drawing.Point(103, 179);
            this.flowButtonGroup.Name = "flowButtonGroup";
            this.flowButtonGroup.Size = new System.Drawing.Size(278, 29);
            this.flowButtonGroup.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(200, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblFreqTranser
            // 
            this.lblFreqTranser.AutoSize = true;
            this.lblFreqTranser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFreqTranser.Location = new System.Drawing.Point(3, 84);
            this.lblFreqTranser.Name = "lblFreqTranser";
            this.lblFreqTranser.Size = new System.Drawing.Size(94, 28);
            this.lblFreqTranser.TabIndex = 7;
            this.lblFreqTranser.Text = "搜索频率";
            this.lblFreqTranser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFreqTranser
            // 
            this.txtFreqTranser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFreqTranser.Location = new System.Drawing.Point(103, 88);
            this.txtFreqTranser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFreqTranser.Name = "txtFreqTranser";
            this.txtFreqTranser.Size = new System.Drawing.Size(278, 23);
            this.txtFreqTranser.TabIndex = 8;
            // 
            // lblDelay
            // 
            this.lblDelay.AutoSize = true;
            this.lblDelay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDelay.Location = new System.Drawing.Point(3, 112);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(94, 28);
            this.lblDelay.TabIndex = 9;
            this.lblDelay.Text = "搜索延迟";
            this.lblDelay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDelayTransfer
            // 
            this.txtDelayTransfer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDelayTransfer.Location = new System.Drawing.Point(103, 116);
            this.txtDelayTransfer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDelayTransfer.Name = "txtDelayTransfer";
            this.txtDelayTransfer.Size = new System.Drawing.Size(278, 23);
            this.txtDelayTransfer.TabIndex = 10;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(384, 211);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Settings";
            this.Text = "设置";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Settings_FormClosed);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.flowButtonGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pnlMain;
        private System.Windows.Forms.Label lblKeywords;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Label lblYijia;
        private System.Windows.Forms.TextBox txtYijia;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.FlowLayoutPanel flowButtonGroup;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblFreqTranser;
        private System.Windows.Forms.TextBox txtFreqTranser;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.TextBox txtDelayTransfer;
    }
}