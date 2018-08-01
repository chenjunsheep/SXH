namespace Sxh.Client
{
    partial class Monitor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Monitor));
            this.pnlMain = new System.Windows.Forms.TableLayoutPanel();
            this.ucProjectInvestmentMonth = new Sxh.Client.Controls.Monitor.UcProjectInvestmentMonth();
            this.ucProjectReverse = new Sxh.Client.Controls.Monitor.UcProjectReverse();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.ColumnCount = 1;
            this.pnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlMain.Controls.Add(this.ucProjectInvestmentMonth, 0, 0);
            this.pnlMain.Controls.Add(this.ucProjectReverse, 0, 1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.RowCount = 3;
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlMain.Size = new System.Drawing.Size(334, 93);
            this.pnlMain.TabIndex = 0;
            // 
            // ucProjectInvestmentMonth
            // 
            this.ucProjectInvestmentMonth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucProjectInvestmentMonth.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucProjectInvestmentMonth.Location = new System.Drawing.Point(0, 0);
            this.ucProjectInvestmentMonth.Margin = new System.Windows.Forms.Padding(0);
            this.ucProjectInvestmentMonth.Name = "ucProjectInvestmentMonth";
            this.ucProjectInvestmentMonth.Size = new System.Drawing.Size(334, 46);
            this.ucProjectInvestmentMonth.TabIndex = 0;
            // 
            // ucProjectReverse
            // 
            this.ucProjectReverse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucProjectReverse.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucProjectReverse.Location = new System.Drawing.Point(0, 46);
            this.ucProjectReverse.Margin = new System.Windows.Forms.Padding(0);
            this.ucProjectReverse.Name = "ucProjectReverse";
            this.ucProjectReverse.Size = new System.Drawing.Size(334, 46);
            this.ucProjectReverse.TabIndex = 1;
            // 
            // Monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(334, 93);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Monitor";
            this.Opacity = 0.8D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "监视器";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Monitor_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Monitor_FormClosed);
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pnlMain;
        private Controls.Monitor.UcProjectInvestmentMonth ucProjectInvestmentMonth;
        private Controls.Monitor.UcProjectReverse ucProjectReverse;
    }
}