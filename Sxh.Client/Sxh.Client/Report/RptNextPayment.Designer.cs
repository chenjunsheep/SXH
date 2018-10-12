namespace Sxh.Client.Report
{
    partial class RptNextPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RptNextPayment));
            this.pnlMain = new System.Windows.Forms.TableLayoutPanel();
            this.flowButtonGroup = new System.Windows.Forms.FlowLayoutPanel();
            this.txtKeword = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.gridNextPayment = new System.Windows.Forms.DataGridView();
            this.ProjectId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectType = new System.Windows.Forms.DataGridViewImageColumn();
            this.ProjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NextPayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NextPaymentRemain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Freq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fund = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlMain.SuspendLayout();
            this.flowButtonGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNextPayment)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.ColumnCount = 1;
            this.pnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlMain.Controls.Add(this.flowButtonGroup, 0, 0);
            this.pnlMain.Controls.Add(this.gridNextPayment, 0, 1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.RowCount = 2;
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlMain.Size = new System.Drawing.Size(634, 461);
            this.pnlMain.TabIndex = 0;
            // 
            // flowButtonGroup
            // 
            this.flowButtonGroup.Controls.Add(this.txtKeword);
            this.flowButtonGroup.Controls.Add(this.btnRefresh);
            this.flowButtonGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowButtonGroup.Location = new System.Drawing.Point(0, 0);
            this.flowButtonGroup.Margin = new System.Windows.Forms.Padding(0);
            this.flowButtonGroup.Name = "flowButtonGroup";
            this.flowButtonGroup.Size = new System.Drawing.Size(634, 28);
            this.flowButtonGroup.TabIndex = 0;
            // 
            // txtKeword
            // 
            this.txtKeword.Location = new System.Drawing.Point(3, 3);
            this.txtKeword.Name = "txtKeword";
            this.txtKeword.Size = new System.Drawing.Size(100, 23);
            this.txtKeword.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(109, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gridNextPayment
            // 
            this.gridNextPayment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridNextPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridNextPayment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProjectId,
            this.ProjectTypeId,
            this.ProjectType,
            this.ProjectName,
            this.Rate,
            this.PayType,
            this.NextPayment,
            this.NextPaymentRemain,
            this.Freq,
            this.Fund,
            this.Note});
            this.gridNextPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridNextPayment.Location = new System.Drawing.Point(3, 31);
            this.gridNextPayment.Name = "gridNextPayment";
            this.gridNextPayment.RowTemplate.Height = 23;
            this.gridNextPayment.Size = new System.Drawing.Size(628, 427);
            this.gridNextPayment.TabIndex = 1;
            this.gridNextPayment.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridNextPayment_CellFormatting);
            // 
            // ProjectId
            // 
            this.ProjectId.DataPropertyName = "Id";
            this.ProjectId.HeaderText = "ProjectId";
            this.ProjectId.Name = "ProjectId";
            this.ProjectId.Visible = false;
            this.ProjectId.Width = 85;
            // 
            // ProjectTypeId
            // 
            this.ProjectTypeId.DataPropertyName = "ProjectTypeId";
            this.ProjectTypeId.HeaderText = "类型Val";
            this.ProjectTypeId.Name = "ProjectTypeId";
            this.ProjectTypeId.Visible = false;
            this.ProjectTypeId.Width = 75;
            // 
            // ProjectType
            // 
            this.ProjectType.HeaderText = "类型";
            this.ProjectType.Name = "ProjectType";
            this.ProjectType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ProjectType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ProjectType.Width = 57;
            // 
            // ProjectName
            // 
            this.ProjectName.DataPropertyName = "Name";
            this.ProjectName.HeaderText = "项目名";
            this.ProjectName.Name = "ProjectName";
            this.ProjectName.Width = 69;
            // 
            // Rate
            // 
            this.Rate.DataPropertyName = "Rate";
            this.Rate.HeaderText = "年化";
            this.Rate.Name = "Rate";
            this.Rate.Width = 57;
            // 
            // PayType
            // 
            this.PayType.DataPropertyName = "PayType";
            this.PayType.HeaderText = "还款方式";
            this.PayType.Name = "PayType";
            this.PayType.Width = 81;
            // 
            // NextPayment
            // 
            this.NextPayment.DataPropertyName = "NextPayment";
            this.NextPayment.HeaderText = "付息日";
            this.NextPayment.Name = "NextPayment";
            this.NextPayment.Width = 69;
            // 
            // NextPaymentRemain
            // 
            this.NextPaymentRemain.DataPropertyName = "DisplayNextRemainDay";
            this.NextPaymentRemain.HeaderText = "剩余";
            this.NextPaymentRemain.Name = "NextPaymentRemain";
            this.NextPaymentRemain.Width = 57;
            // 
            // Freq
            // 
            this.Freq.DataPropertyName = "Freq";
            this.Freq.HeaderText = "期数";
            this.Freq.Name = "Freq";
            this.Freq.Width = 57;
            // 
            // Fund
            // 
            this.Fund.DataPropertyName = "DisplayFunds";
            this.Fund.HeaderText = "规模";
            this.Fund.Name = "Fund";
            this.Fund.Width = 57;
            // 
            // Note
            // 
            this.Note.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Note.DataPropertyName = "Note";
            this.Note.HeaderText = "备注";
            this.Note.Name = "Note";
            this.Note.ReadOnly = true;
            // 
            // RptNextPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(634, 461);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RptNextPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "下次付息项目报表";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RptNextPayment_Load);
            this.pnlMain.ResumeLayout(false);
            this.flowButtonGroup.ResumeLayout(false);
            this.flowButtonGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNextPayment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pnlMain;
        private System.Windows.Forms.FlowLayoutPanel flowButtonGroup;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView gridNextPayment;
        private System.Windows.Forms.TextBox txtKeword;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectTypeId;
        private System.Windows.Forms.DataGridViewImageColumn ProjectType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayType;
        private System.Windows.Forms.DataGridViewTextBoxColumn NextPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn NextPaymentRemain;
        private System.Windows.Forms.DataGridViewTextBoxColumn Freq;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fund;
        private System.Windows.Forms.DataGridViewTextBoxColumn Note;
    }
}