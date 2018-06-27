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
            this.pnlMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.ucDetailPool = new Sxh.Client.Controls.UcDetailPool();
            this.ucLogs = new Sxh.Client.Controls.UcLogs();
            this.pnlMain.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.ColumnCount = 1;
            this.pnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlMain.Controls.Add(this.pnlButtons, 0, 1);
            this.pnlMain.Controls.Add(this.ucDetailPool, 0, 0);
            this.pnlMain.Controls.Add(this.ucLogs, 0, 2);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.RowCount = 3;
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.pnlMain.Size = new System.Drawing.Size(484, 261);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnStart);
            this.pnlButtons.Controls.Add(this.btnStop);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlButtons.Location = new System.Drawing.Point(3, 129);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(478, 29);
            this.pnlButtons.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(400, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(319, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // ucDetailPool
            // 
            this.ucDetailPool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDetailPool.Location = new System.Drawing.Point(3, 4);
            this.ucDetailPool.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucDetailPool.Name = "ucDetailPool";
            this.ucDetailPool.Size = new System.Drawing.Size(478, 118);
            this.ucDetailPool.TabIndex = 1;
            // 
            // ucLogs
            // 
            this.ucLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucLogs.Location = new System.Drawing.Point(3, 165);
            this.ucLogs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucLogs.Name = "ucLogs";
            this.ucLogs.Size = new System.Drawing.Size(478, 92);
            this.ucLogs.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pnlMain;
        private Controls.UcDetailPool ucDetailPool;
        private System.Windows.Forms.FlowLayoutPanel pnlButtons;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private Controls.UcLogs ucLogs;
    }
}