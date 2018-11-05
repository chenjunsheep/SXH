namespace Sxh.Client
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlMain = new System.Windows.Forms.TableLayoutPanel();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.pnlDashboard = new System.Windows.Forms.TableLayoutPanel();
            this.ucPoolTranser = new Sxh.Client.Controls.UcPoolTranser();
            this.pnlButtonGroup = new System.Windows.Forms.TableLayoutPanel();
            this.flowRight = new System.Windows.Forms.FlowLayoutPanel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.flowLeft = new System.Windows.Forms.FlowLayoutPanel();
            this.cbReport = new System.Windows.Forms.ComboBox();
            this.btnLogs = new System.Windows.Forms.Button();
            this.btnMonitor = new System.Windows.Forms.Button();
            this.ucLogs = new Sxh.Client.Controls.UcLogs();
            this.flowMessageGroups = new System.Windows.Forms.FlowLayoutPanel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblHighlight = new System.Windows.Forms.Label();
            this.notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.pnlDashboard.SuspendLayout();
            this.pnlButtonGroup.SuspendLayout();
            this.flowRight.SuspendLayout();
            this.flowLeft.SuspendLayout();
            this.flowMessageGroups.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.ColumnCount = 1;
            this.pnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlMain.Controls.Add(this.splitMain, 0, 1);
            this.pnlMain.Controls.Add(this.flowMessageGroups, 0, 0);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.RowCount = 2;
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlMain.Size = new System.Drawing.Size(934, 561);
            this.pnlMain.TabIndex = 0;
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(3, 31);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.pnlDashboard);
            this.splitMain.Panel1MinSize = 1;
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.ucLogs);
            this.splitMain.Panel2MinSize = 1;
            this.splitMain.Size = new System.Drawing.Size(928, 527);
            this.splitMain.SplitterDistance = 413;
            this.splitMain.TabIndex = 4;
            // 
            // pnlDashboard
            // 
            this.pnlDashboard.ColumnCount = 1;
            this.pnlDashboard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlDashboard.Controls.Add(this.ucPoolTranser, 0, 0);
            this.pnlDashboard.Controls.Add(this.pnlButtonGroup, 0, 1);
            this.pnlDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDashboard.Location = new System.Drawing.Point(0, 0);
            this.pnlDashboard.Name = "pnlDashboard";
            this.pnlDashboard.RowCount = 2;
            this.pnlDashboard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlDashboard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.pnlDashboard.Size = new System.Drawing.Size(928, 413);
            this.pnlDashboard.TabIndex = 0;
            // 
            // ucPoolTranser
            // 
            this.ucPoolTranser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPoolTranser.Location = new System.Drawing.Point(3, 3);
            this.ucPoolTranser.Name = "ucPoolTranser";
            this.ucPoolTranser.Size = new System.Drawing.Size(922, 377);
            this.ucPoolTranser.TabIndex = 4;
            // 
            // pnlButtonGroup
            // 
            this.pnlButtonGroup.ColumnCount = 2;
            this.pnlButtonGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.pnlButtonGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlButtonGroup.Controls.Add(this.flowRight, 1, 0);
            this.pnlButtonGroup.Controls.Add(this.flowLeft, 0, 0);
            this.pnlButtonGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtonGroup.Location = new System.Drawing.Point(0, 383);
            this.pnlButtonGroup.Margin = new System.Windows.Forms.Padding(0);
            this.pnlButtonGroup.Name = "pnlButtonGroup";
            this.pnlButtonGroup.RowCount = 1;
            this.pnlButtonGroup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlButtonGroup.Size = new System.Drawing.Size(928, 30);
            this.pnlButtonGroup.TabIndex = 5;
            // 
            // flowRight
            // 
            this.flowRight.Controls.Add(this.btnStart);
            this.flowRight.Controls.Add(this.btnStop);
            this.flowRight.Controls.Add(this.btnSettings);
            this.flowRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowRight.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowRight.Location = new System.Drawing.Point(300, 0);
            this.flowRight.Margin = new System.Windows.Forms.Padding(0);
            this.flowRight.Name = "flowRight";
            this.flowRight.Size = new System.Drawing.Size(628, 30);
            this.flowRight.TabIndex = 6;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(550, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(469, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(388, 3);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSettings.TabIndex = 2;
            this.btnSettings.Text = "设置";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // flowLeft
            // 
            this.flowLeft.Controls.Add(this.cbReport);
            this.flowLeft.Controls.Add(this.btnLogs);
            this.flowLeft.Controls.Add(this.btnMonitor);
            this.flowLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLeft.Location = new System.Drawing.Point(0, 0);
            this.flowLeft.Margin = new System.Windows.Forms.Padding(0);
            this.flowLeft.Name = "flowLeft";
            this.flowLeft.Size = new System.Drawing.Size(300, 30);
            this.flowLeft.TabIndex = 0;
            // 
            // cbReport
            // 
            this.cbReport.FormattingEnabled = true;
            this.cbReport.Location = new System.Drawing.Point(3, 3);
            this.cbReport.Name = "cbReport";
            this.cbReport.Size = new System.Drawing.Size(75, 25);
            this.cbReport.TabIndex = 2;
            this.cbReport.SelectedIndexChanged += new System.EventHandler(this.cbReport_SelectedIndexChanged);
            // 
            // btnLogs
            // 
            this.btnLogs.Location = new System.Drawing.Point(84, 3);
            this.btnLogs.Name = "btnLogs";
            this.btnLogs.Size = new System.Drawing.Size(75, 23);
            this.btnLogs.TabIndex = 0;
            this.btnLogs.Text = "日志";
            this.btnLogs.UseVisualStyleBackColor = true;
            this.btnLogs.Click += new System.EventHandler(this.btnLogs_Click);
            // 
            // btnMonitor
            // 
            this.btnMonitor.Location = new System.Drawing.Point(165, 3);
            this.btnMonitor.Name = "btnMonitor";
            this.btnMonitor.Size = new System.Drawing.Size(75, 23);
            this.btnMonitor.TabIndex = 1;
            this.btnMonitor.Text = "监视器";
            this.btnMonitor.UseVisualStyleBackColor = true;
            this.btnMonitor.Click += new System.EventHandler(this.btnMonitor_Click);
            // 
            // ucLogs
            // 
            this.ucLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucLogs.Location = new System.Drawing.Point(0, 0);
            this.ucLogs.Name = "ucLogs";
            this.ucLogs.Size = new System.Drawing.Size(928, 110);
            this.ucLogs.TabIndex = 3;
            // 
            // flowMessageGroups
            // 
            this.flowMessageGroups.Controls.Add(this.lblMessage);
            this.flowMessageGroups.Controls.Add(this.lblHighlight);
            this.flowMessageGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowMessageGroups.Location = new System.Drawing.Point(0, 3);
            this.flowMessageGroups.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.flowMessageGroups.Name = "flowMessageGroups";
            this.flowMessageGroups.Size = new System.Drawing.Size(934, 25);
            this.flowMessageGroups.TabIndex = 6;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMessage.Location = new System.Drawing.Point(3, 4);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(56, 17);
            this.lblMessage.TabIndex = 6;
            this.lblMessage.Text = "一般信息";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHighlight
            // 
            this.lblHighlight.AutoSize = true;
            this.lblHighlight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblHighlight.Location = new System.Drawing.Point(62, 4);
            this.lblHighlight.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.lblHighlight.Name = "lblHighlight";
            this.lblHighlight.Size = new System.Drawing.Size(56, 17);
            this.lblHighlight.TabIndex = 7;
            this.lblHighlight.Text = "高亮信息";
            this.lblHighlight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // notify
            // 
            this.notify.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notify.Icon = ((System.Drawing.Icon)(resources.GetObject("notify.Icon")));
            this.notify.Text = "SXH";
            this.notify.DoubleClick += new System.EventHandler(this.notify_DoubleClick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(934, 561);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主界面";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
            this.pnlMain.ResumeLayout(false);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.pnlDashboard.ResumeLayout(false);
            this.pnlButtonGroup.ResumeLayout(false);
            this.flowRight.ResumeLayout(false);
            this.flowLeft.ResumeLayout(false);
            this.flowMessageGroups.ResumeLayout(false);
            this.flowMessageGroups.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pnlMain;
        private System.Windows.Forms.SplitContainer splitMain;
        private Controls.UcLogs ucLogs;
        private System.Windows.Forms.TableLayoutPanel pnlDashboard;
        private Controls.UcPoolTranser ucPoolTranser;
        private System.Windows.Forms.TableLayoutPanel pnlButtonGroup;
        private System.Windows.Forms.FlowLayoutPanel flowRight;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.FlowLayoutPanel flowLeft;
        private System.Windows.Forms.Button btnLogs;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.NotifyIcon notify;
        private System.Windows.Forms.FlowLayoutPanel flowMessageGroups;
        private System.Windows.Forms.Label lblHighlight;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnMonitor;
        private System.Windows.Forms.ComboBox cbReport;
    }
}