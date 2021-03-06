﻿namespace Sxh.Client.Controls
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
            this.minTransferingRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Yijia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NextRemainDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectType = new System.Windows.Forms.DataGridViewImageColumn();
            this.DisplayProjectTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisplayTransferingRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisplayYijia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisplayNextRemainDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transferingCopies = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minTransferingPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.advicePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.minTransferingRate,
            this.Yijia,
            this.NextRemainDay,
            this.ProjectTypeId,
            this.projectTitle,
            this.ProjectType,
            this.DisplayProjectTitle,
            this.DisplayTransferingRate,
            this.DisplayYijia,
            this.DisplayNextRemainDay,
            this.transferingCopies,
            this.minTransferingPrice,
            this.advicePrice,
            this.Notes});
            this.gridTransferPool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTransferPool.Location = new System.Drawing.Point(0, 0);
            this.gridTransferPool.Name = "gridTransferPool";
            this.gridTransferPool.ReadOnly = true;
            this.gridTransferPool.RowTemplate.Height = 23;
            this.gridTransferPool.Size = new System.Drawing.Size(200, 50);
            this.gridTransferPool.TabIndex = 0;
            this.gridTransferPool.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridTransferPool_CellFormatting);
            this.gridTransferPool.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridTransferPool_DataBindingComplete);
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
            // minTransferingRate
            // 
            this.minTransferingRate.DataPropertyName = "minTransferingRate";
            this.minTransferingRate.HeaderText = "转让年化Val";
            this.minTransferingRate.Name = "minTransferingRate";
            this.minTransferingRate.ReadOnly = true;
            this.minTransferingRate.Visible = false;
            this.minTransferingRate.Width = 96;
            // 
            // Yijia
            // 
            this.Yijia.DataPropertyName = "Yijia";
            this.Yijia.HeaderText = "溢价率Val";
            this.Yijia.Name = "Yijia";
            this.Yijia.ReadOnly = true;
            this.Yijia.Visible = false;
            this.Yijia.Width = 84;
            // 
            // NextRemainDay
            // 
            this.NextRemainDay.DataPropertyName = "NextRemainDay";
            this.NextRemainDay.HeaderText = "下次付息Val";
            this.NextRemainDay.Name = "NextRemainDay";
            this.NextRemainDay.ReadOnly = true;
            this.NextRemainDay.Visible = false;
            this.NextRemainDay.Width = 96;
            // 
            // ProjectTypeId
            // 
            this.ProjectTypeId.DataPropertyName = "ProjectTypeId";
            this.ProjectTypeId.HeaderText = "ProjectTypeId";
            this.ProjectTypeId.Name = "ProjectTypeId";
            this.ProjectTypeId.ReadOnly = true;
            this.ProjectTypeId.Visible = false;
            this.ProjectTypeId.Width = 108;
            // 
            // projectTitle
            // 
            this.projectTitle.DataPropertyName = "projectTitle";
            this.projectTitle.HeaderText = "名称Raw";
            this.projectTitle.Name = "projectTitle";
            this.projectTitle.ReadOnly = true;
            this.projectTitle.Visible = false;
            this.projectTitle.Width = 72;
            // 
            // ProjectType
            // 
            this.ProjectType.HeaderText = "类型";
            this.ProjectType.Name = "ProjectType";
            this.ProjectType.ReadOnly = true;
            this.ProjectType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ProjectType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ProjectType.Width = 54;
            // 
            // DisplayProjectTitle
            // 
            this.DisplayProjectTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DisplayProjectTitle.DataPropertyName = "DisplayProjectTitle";
            this.DisplayProjectTitle.HeaderText = "名称";
            this.DisplayProjectTitle.Name = "DisplayProjectTitle";
            this.DisplayProjectTitle.ReadOnly = true;
            this.DisplayProjectTitle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DisplayProjectTitle.Width = 54;
            // 
            // DisplayTransferingRate
            // 
            this.DisplayTransferingRate.DataPropertyName = "DisplayTransferingRate";
            this.DisplayTransferingRate.HeaderText = "转让年化";
            this.DisplayTransferingRate.Name = "DisplayTransferingRate";
            this.DisplayTransferingRate.ReadOnly = true;
            this.DisplayTransferingRate.Width = 78;
            // 
            // DisplayYijia
            // 
            this.DisplayYijia.DataPropertyName = "DisplayYijia";
            this.DisplayYijia.HeaderText = "溢折率";
            this.DisplayYijia.Name = "DisplayYijia";
            this.DisplayYijia.ReadOnly = true;
            this.DisplayYijia.Width = 66;
            // 
            // DisplayNextRemainDay
            // 
            this.DisplayNextRemainDay.DataPropertyName = "DisplayNextRemainDay";
            this.DisplayNextRemainDay.HeaderText = "下次付息";
            this.DisplayNextRemainDay.Name = "DisplayNextRemainDay";
            this.DisplayNextRemainDay.ReadOnly = true;
            this.DisplayNextRemainDay.Width = 78;
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
            // Notes
            // 
            this.Notes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Notes.DataPropertyName = "notes";
            this.Notes.HeaderText = "备注";
            this.Notes.Name = "Notes";
            this.Notes.ReadOnly = true;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn minTransferingRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Yijia;
        private System.Windows.Forms.DataGridViewTextBoxColumn NextRemainDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectTitle;
        private System.Windows.Forms.DataGridViewImageColumn ProjectType;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayProjectTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayTransferingRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayYijia;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayNextRemainDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn transferingCopies;
        private System.Windows.Forms.DataGridViewTextBoxColumn minTransferingPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn advicePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notes;
    }
}
