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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.pnlMain = new System.Windows.Forms.TableLayoutPanel();
            this.flowButtonGroup = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.tabBasic = new System.Windows.Forms.TabPage();
            this.ucSettingBasic = new Sxh.Client.Controls.Settings.UcSettingBasic();
            this.tabProxy = new System.Windows.Forms.TabPage();
            this.ucSettingProxy = new Sxh.Client.Controls.Settings.UcSettingProxy();
            this.tabAcount = new System.Windows.Forms.TabPage();
            this.ucSettingAccount = new Sxh.Client.Controls.Settings.UcSettingAccount();
            this.pnlMain.SuspendLayout();
            this.flowButtonGroup.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.tabBasic.SuspendLayout();
            this.tabProxy.SuspendLayout();
            this.tabAcount.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.ColumnCount = 1;
            this.pnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlMain.Controls.Add(this.flowButtonGroup, 0, 1);
            this.pnlMain.Controls.Add(this.tabSettings, 0, 0);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.RowCount = 2;
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlMain.Size = new System.Drawing.Size(584, 461);
            this.pnlMain.TabIndex = 0;
            // 
            // flowButtonGroup
            // 
            this.flowButtonGroup.Controls.Add(this.btnSave);
            this.flowButtonGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowButtonGroup.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowButtonGroup.Location = new System.Drawing.Point(3, 429);
            this.flowButtonGroup.Name = "flowButtonGroup";
            this.flowButtonGroup.Size = new System.Drawing.Size(578, 29);
            this.flowButtonGroup.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(500, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.tabBasic);
            this.tabSettings.Controls.Add(this.tabProxy);
            this.tabSettings.Controls.Add(this.tabAcount);
            this.tabSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSettings.Location = new System.Drawing.Point(3, 3);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(578, 420);
            this.tabSettings.TabIndex = 11;
            // 
            // tabBasic
            // 
            this.tabBasic.Controls.Add(this.ucSettingBasic);
            this.tabBasic.Location = new System.Drawing.Point(4, 26);
            this.tabBasic.Name = "tabBasic";
            this.tabBasic.Padding = new System.Windows.Forms.Padding(3);
            this.tabBasic.Size = new System.Drawing.Size(570, 390);
            this.tabBasic.TabIndex = 0;
            this.tabBasic.Text = "基本设置";
            this.tabBasic.UseVisualStyleBackColor = true;
            // 
            // ucSettingBasic
            // 
            this.ucSettingBasic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSettingBasic.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucSettingBasic.Location = new System.Drawing.Point(3, 3);
            this.ucSettingBasic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucSettingBasic.Name = "ucSettingBasic";
            this.ucSettingBasic.Size = new System.Drawing.Size(564, 384);
            this.ucSettingBasic.TabIndex = 0;
            // 
            // tabProxy
            // 
            this.tabProxy.Controls.Add(this.ucSettingProxy);
            this.tabProxy.Location = new System.Drawing.Point(4, 26);
            this.tabProxy.Name = "tabProxy";
            this.tabProxy.Padding = new System.Windows.Forms.Padding(3);
            this.tabProxy.Size = new System.Drawing.Size(570, 390);
            this.tabProxy.TabIndex = 1;
            this.tabProxy.Text = "多代理设置";
            this.tabProxy.UseVisualStyleBackColor = true;
            // 
            // ucSettingProxy
            // 
            this.ucSettingProxy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSettingProxy.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucSettingProxy.Location = new System.Drawing.Point(3, 3);
            this.ucSettingProxy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucSettingProxy.Name = "ucSettingProxy";
            this.ucSettingProxy.Size = new System.Drawing.Size(564, 384);
            this.ucSettingProxy.TabIndex = 0;
            // 
            // tabAcount
            // 
            this.tabAcount.Controls.Add(this.ucSettingAccount);
            this.tabAcount.Location = new System.Drawing.Point(4, 26);
            this.tabAcount.Name = "tabAcount";
            this.tabAcount.Padding = new System.Windows.Forms.Padding(3);
            this.tabAcount.Size = new System.Drawing.Size(570, 390);
            this.tabAcount.TabIndex = 2;
            this.tabAcount.Text = "多账号设置";
            this.tabAcount.UseVisualStyleBackColor = true;
            // 
            // ucSettingAccount
            // 
            this.ucSettingAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSettingAccount.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucSettingAccount.Location = new System.Drawing.Point(3, 3);
            this.ucSettingAccount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucSettingAccount.Name = "ucSettingAccount";
            this.ucSettingAccount.Size = new System.Drawing.Size(564, 384);
            this.ucSettingAccount.TabIndex = 0;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Settings_FormClosed);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.pnlMain.ResumeLayout(false);
            this.flowButtonGroup.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.tabBasic.ResumeLayout(false);
            this.tabProxy.ResumeLayout(false);
            this.tabAcount.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pnlMain;
        private System.Windows.Forms.FlowLayoutPanel flowButtonGroup;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage tabBasic;
        private System.Windows.Forms.TabPage tabProxy;
        private System.Windows.Forms.TabPage tabAcount;
        private Controls.Settings.UcSettingBasic ucSettingBasic;
        private Controls.Settings.UcSettingProxy ucSettingProxy;
        private Controls.Settings.UcSettingAccount ucSettingAccount;
    }
}