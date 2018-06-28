namespace Sxh.Client.Controls
{
    partial class UcPoolTranser
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
            this.gridTransferPool = new System.Windows.Forms.DataGridView();
            this.projectId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisplayTransferingRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisplayRealtimeRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transferingCopies = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minTransferingPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.advicePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridTransferPool)).BeginInit();
            this.SuspendLayout();
            // 
            // gridTransferPool
            // 
            this.gridTransferPool.AllowUserToAddRows = false;
            this.gridTransferPool.AllowUserToDeleteRows = false;
            this.gridTransferPool.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridTransferPool.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gridTransferPool.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTransferPool.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.projectId,
            this.projectTitle,
            this.DisplayTransferingRate,
            this.DisplayRealtimeRate,
            this.transferingCopies,
            this.minTransferingPrice,
            this.advicePrice});
            this.gridTransferPool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTransferPool.Location = new System.Drawing.Point(0, 0);
            this.gridTransferPool.Name = "gridTransferPool";
            this.gridTransferPool.ReadOnly = true;
            this.gridTransferPool.RowTemplate.Height = 23;
            this.gridTransferPool.Size = new System.Drawing.Size(200, 50);
            this.gridTransferPool.TabIndex = 0;
            this.gridTransferPool.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridTransferPool_RowHeaderMouseDoubleClick);
            // 
            // projectId
            // 
            this.projectId.DataPropertyName = "projectId";
            this.projectId.Frozen = true;
            this.projectId.HeaderText = "项目ID";
            this.projectId.Name = "projectId";
            this.projectId.ReadOnly = true;
            this.projectId.Visible = false;
            this.projectId.Width = 66;
            // 
            // projectTitle
            // 
            this.projectTitle.DataPropertyName = "projectTitle";
            this.projectTitle.HeaderText = "名称";
            this.projectTitle.Name = "projectTitle";
            this.projectTitle.ReadOnly = true;
            this.projectTitle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.projectTitle.Width = 54;
            // 
            // DisplayTransferingRate
            // 
            this.DisplayTransferingRate.DataPropertyName = "DisplayTransferingRate";
            this.DisplayTransferingRate.HeaderText = "转让年化";
            this.DisplayTransferingRate.Name = "DisplayTransferingRate";
            this.DisplayTransferingRate.ReadOnly = true;
            this.DisplayTransferingRate.Width = 78;
            // 
            // DisplayRealtimeRate
            // 
            this.DisplayRealtimeRate.DataPropertyName = "DisplayRealtimeRate";
            this.DisplayRealtimeRate.HeaderText = "溢折率";
            this.DisplayRealtimeRate.Name = "DisplayRealtimeRate";
            this.DisplayRealtimeRate.ReadOnly = true;
            this.DisplayRealtimeRate.Width = 66;
            // 
            // transferingCopies
            // 
            this.transferingCopies.DataPropertyName = "transferingCopies";
            this.transferingCopies.HeaderText = "转让份数";
            this.transferingCopies.Name = "transferingCopies";
            this.transferingCopies.ReadOnly = true;
            this.transferingCopies.Width = 78;
            // 
            // minTransferingPrice
            // 
            this.minTransferingPrice.DataPropertyName = "minTransferingPrice";
            this.minTransferingPrice.HeaderText = "转让价";
            this.minTransferingPrice.Name = "minTransferingPrice";
            this.minTransferingPrice.ReadOnly = true;
            this.minTransferingPrice.Width = 66;
            // 
            // advicePrice
            // 
            this.advicePrice.DataPropertyName = "advicePrice";
            this.advicePrice.HeaderText = "建议价";
            this.advicePrice.Name = "advicePrice";
            this.advicePrice.ReadOnly = true;
            this.advicePrice.Width = 66;
            // 
            // UcPoolTranser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridTransferPool);
            this.Name = "UcPoolTranser";
            this.Size = new System.Drawing.Size(200, 50);
            this.Load += new System.EventHandler(this.UcPoolTranser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridTransferPool)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView gridTransferPool;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectId;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayTransferingRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayRealtimeRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn transferingCopies;
        private System.Windows.Forms.DataGridViewTextBoxColumn minTransferingPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn advicePrice;
    }
}
