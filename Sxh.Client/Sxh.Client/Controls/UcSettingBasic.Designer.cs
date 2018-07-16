namespace Sxh.Client.Controls
{
    partial class UcSettingBasic
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblAuto = new System.Windows.Forms.Label();
            this.txtDelayTransfer = new System.Windows.Forms.TextBox();
            this.lblDelay = new System.Windows.Forms.Label();
            this.txtFreqTranser = new System.Windows.Forms.TextBox();
            this.lblFreqTranser = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.lblRate = new System.Windows.Forms.Label();
            this.txtYijia = new System.Windows.Forms.TextBox();
            this.lblYijia = new System.Windows.Forms.Label();
            this.lblKeyword = new System.Windows.Forms.Label();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.chkAutoAcquire = new System.Windows.Forms.CheckBox();
            this.lblTotalPage = new System.Windows.Forms.Label();
            this.txtTotalPage = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.ColumnCount = 2;
            this.pnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.pnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlMain.Controls.Add(this.txtTotalPage, 1, 5);
            this.pnlMain.Controls.Add(this.lblTotalPage, 0, 5);
            this.pnlMain.Controls.Add(this.lblAuto, 0, 6);
            this.pnlMain.Controls.Add(this.txtDelayTransfer, 1, 4);
            this.pnlMain.Controls.Add(this.lblDelay, 0, 4);
            this.pnlMain.Controls.Add(this.txtFreqTranser, 1, 3);
            this.pnlMain.Controls.Add(this.lblFreqTranser, 0, 3);
            this.pnlMain.Controls.Add(this.txtRate, 1, 2);
            this.pnlMain.Controls.Add(this.lblRate, 0, 2);
            this.pnlMain.Controls.Add(this.txtYijia, 1, 1);
            this.pnlMain.Controls.Add(this.lblYijia, 0, 1);
            this.pnlMain.Controls.Add(this.lblKeyword, 0, 0);
            this.pnlMain.Controls.Add(this.txtKeyword, 1, 0);
            this.pnlMain.Controls.Add(this.chkAutoAcquire, 1, 6);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.RowCount = 8;
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlMain.Size = new System.Drawing.Size(240, 228);
            this.pnlMain.TabIndex = 0;
            // 
            // lblAuto
            // 
            this.lblAuto.AutoSize = true;
            this.lblAuto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAuto.Location = new System.Drawing.Point(3, 168);
            this.lblAuto.Name = "lblAuto";
            this.lblAuto.Size = new System.Drawing.Size(94, 28);
            this.lblAuto.TabIndex = 12;
            this.lblAuto.Text = "自动收购";
            this.lblAuto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDelayTransfer
            // 
            this.txtDelayTransfer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDelayTransfer.Location = new System.Drawing.Point(103, 118);
            this.txtDelayTransfer.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtDelayTransfer.Name = "txtDelayTransfer";
            this.txtDelayTransfer.Size = new System.Drawing.Size(134, 23);
            this.txtDelayTransfer.TabIndex = 11;
            // 
            // lblDelay
            // 
            this.lblDelay.AutoSize = true;
            this.lblDelay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDelay.Location = new System.Drawing.Point(3, 112);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(94, 28);
            this.lblDelay.TabIndex = 10;
            this.lblDelay.Text = "搜索延迟";
            this.lblDelay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFreqTranser
            // 
            this.txtFreqTranser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFreqTranser.Location = new System.Drawing.Point(103, 90);
            this.txtFreqTranser.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtFreqTranser.Name = "txtFreqTranser";
            this.txtFreqTranser.Size = new System.Drawing.Size(134, 23);
            this.txtFreqTranser.TabIndex = 9;
            // 
            // lblFreqTranser
            // 
            this.lblFreqTranser.AutoSize = true;
            this.lblFreqTranser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFreqTranser.Location = new System.Drawing.Point(3, 84);
            this.lblFreqTranser.Name = "lblFreqTranser";
            this.lblFreqTranser.Size = new System.Drawing.Size(94, 28);
            this.lblFreqTranser.TabIndex = 8;
            this.lblFreqTranser.Text = "搜索频率";
            this.lblFreqTranser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRate
            // 
            this.txtRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRate.Location = new System.Drawing.Point(103, 62);
            this.txtRate.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(134, 23);
            this.txtRate.TabIndex = 6;
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRate.Location = new System.Drawing.Point(3, 56);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(94, 28);
            this.lblRate.TabIndex = 5;
            this.lblRate.Text = "年化";
            this.lblRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtYijia
            // 
            this.txtYijia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtYijia.Location = new System.Drawing.Point(103, 34);
            this.txtYijia.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtYijia.Name = "txtYijia";
            this.txtYijia.Size = new System.Drawing.Size(134, 23);
            this.txtYijia.TabIndex = 4;
            // 
            // lblYijia
            // 
            this.lblYijia.AutoSize = true;
            this.lblYijia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblYijia.Location = new System.Drawing.Point(3, 28);
            this.lblYijia.Name = "lblYijia";
            this.lblYijia.Size = new System.Drawing.Size(94, 28);
            this.lblYijia.TabIndex = 3;
            this.lblYijia.Text = "溢价";
            this.lblYijia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblKeyword
            // 
            this.lblKeyword.AutoSize = true;
            this.lblKeyword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKeyword.Location = new System.Drawing.Point(3, 0);
            this.lblKeyword.Name = "lblKeyword";
            this.lblKeyword.Size = new System.Drawing.Size(94, 28);
            this.lblKeyword.TabIndex = 0;
            this.lblKeyword.Text = "关键字";
            this.lblKeyword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtKeyword
            // 
            this.txtKeyword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKeyword.Location = new System.Drawing.Point(103, 4);
            this.txtKeyword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(134, 23);
            this.txtKeyword.TabIndex = 1;
            // 
            // chkAutoAcquire
            // 
            this.chkAutoAcquire.AutoSize = true;
            this.chkAutoAcquire.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkAutoAcquire.Location = new System.Drawing.Point(103, 171);
            this.chkAutoAcquire.Name = "chkAutoAcquire";
            this.chkAutoAcquire.Size = new System.Drawing.Size(15, 22);
            this.chkAutoAcquire.TabIndex = 13;
            this.chkAutoAcquire.UseVisualStyleBackColor = true;
            // 
            // lblTotalPage
            // 
            this.lblTotalPage.AutoSize = true;
            this.lblTotalPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalPage.Location = new System.Drawing.Point(3, 140);
            this.lblTotalPage.Name = "lblTotalPage";
            this.lblTotalPage.Size = new System.Drawing.Size(94, 28);
            this.lblTotalPage.TabIndex = 14;
            this.lblTotalPage.Text = "总页数";
            this.lblTotalPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotalPage
            // 
            this.txtTotalPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTotalPage.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtTotalPage.Location = new System.Drawing.Point(103, 146);
            this.txtTotalPage.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtTotalPage.Name = "txtTotalPage";
            this.txtTotalPage.Size = new System.Drawing.Size(134, 23);
            this.txtTotalPage.TabIndex = 15;
            this.txtTotalPage.Text = "1";
            // 
            // UcSettingBasic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UcSettingBasic";
            this.Size = new System.Drawing.Size(240, 228);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pnlMain;
        private System.Windows.Forms.Label lblKeyword;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Label lblYijia;
        private System.Windows.Forms.TextBox txtYijia;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label lblFreqTranser;
        private System.Windows.Forms.TextBox txtFreqTranser;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.TextBox txtDelayTransfer;
        private System.Windows.Forms.Label lblAuto;
        private System.Windows.Forms.CheckBox chkAutoAcquire;
        private System.Windows.Forms.Label lblTotalPage;
        private System.Windows.Forms.TextBox txtTotalPage;
    }
}
