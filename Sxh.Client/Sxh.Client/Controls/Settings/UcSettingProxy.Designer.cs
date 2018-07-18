namespace Sxh.Client.Controls.Settings
{
    partial class UcSettingProxy
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
            this.flowProxy = new System.Windows.Forms.FlowLayoutPanel();
            this.flowButtonGroup = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLoginBulk = new System.Windows.Forms.Button();
            this.chkLoginProtect = new System.Windows.Forms.CheckBox();
            this.pnlMain.SuspendLayout();
            this.flowButtonGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.ColumnCount = 1;
            this.pnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlMain.Controls.Add(this.flowProxy, 0, 1);
            this.pnlMain.Controls.Add(this.flowButtonGroup, 0, 0);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.RowCount = 2;
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlMain.Size = new System.Drawing.Size(300, 200);
            this.pnlMain.TabIndex = 0;
            // 
            // flowProxy
            // 
            this.flowProxy.AutoScroll = true;
            this.flowProxy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowProxy.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowProxy.Location = new System.Drawing.Point(3, 32);
            this.flowProxy.Name = "flowProxy";
            this.flowProxy.Size = new System.Drawing.Size(294, 165);
            this.flowProxy.TabIndex = 1;
            this.flowProxy.WrapContents = false;
            // 
            // flowButtonGroup
            // 
            this.flowButtonGroup.Controls.Add(this.btnLoginBulk);
            this.flowButtonGroup.Controls.Add(this.chkLoginProtect);
            this.flowButtonGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowButtonGroup.Location = new System.Drawing.Point(0, 0);
            this.flowButtonGroup.Margin = new System.Windows.Forms.Padding(0);
            this.flowButtonGroup.Name = "flowButtonGroup";
            this.flowButtonGroup.Size = new System.Drawing.Size(300, 29);
            this.flowButtonGroup.TabIndex = 2;
            // 
            // btnLoginBulk
            // 
            this.btnLoginBulk.Location = new System.Drawing.Point(3, 3);
            this.btnLoginBulk.Name = "btnLoginBulk";
            this.btnLoginBulk.Size = new System.Drawing.Size(75, 23);
            this.btnLoginBulk.TabIndex = 0;
            this.btnLoginBulk.Text = "批量登陆";
            this.btnLoginBulk.UseVisualStyleBackColor = true;
            this.btnLoginBulk.Click += new System.EventHandler(this.btnLoginBulk_Click);
            // 
            // chkLoginProtect
            // 
            this.chkLoginProtect.AutoSize = true;
            this.chkLoginProtect.Checked = true;
            this.chkLoginProtect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLoginProtect.Location = new System.Drawing.Point(84, 3);
            this.chkLoginProtect.Name = "chkLoginProtect";
            this.chkLoginProtect.Size = new System.Drawing.Size(75, 21);
            this.chkLoginProtect.TabIndex = 1;
            this.chkLoginProtect.Text = "登陆保护";
            this.chkLoginProtect.UseVisualStyleBackColor = true;
            // 
            // UcSettingProxy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UcSettingProxy";
            this.Size = new System.Drawing.Size(300, 200);
            this.Load += new System.EventHandler(this.UcSettingProxy_Load);
            this.pnlMain.ResumeLayout(false);
            this.flowButtonGroup.ResumeLayout(false);
            this.flowButtonGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pnlMain;
        private System.Windows.Forms.FlowLayoutPanel flowProxy;
        private System.Windows.Forms.FlowLayoutPanel flowButtonGroup;
        private System.Windows.Forms.Button btnLoginBulk;
        private System.Windows.Forms.CheckBox chkLoginProtect;
    }
}
