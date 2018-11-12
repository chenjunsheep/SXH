namespace Sxh.Client.Report
{
    partial class RptProjects
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RptProjects));
            this.pnlMain = new System.Windows.Forms.TableLayoutPanel();
            this.gridProjects = new System.Windows.Forms.DataGridView();
            this.pnlButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectType = new System.Windows.Forms.DataGridViewImageColumn();
            this.ProjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deadline = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalFunds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProjects)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.ColumnCount = 1;
            this.pnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlMain.Controls.Add(this.gridProjects, 0, 1);
            this.pnlMain.Controls.Add(this.pnlButtons, 0, 0);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.RowCount = 2;
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlMain.Size = new System.Drawing.Size(634, 461);
            this.pnlMain.TabIndex = 0;
            // 
            // gridProjects
            // 
            this.gridProjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProjects.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.ProjectTypeId,
            this.ProjectType,
            this.ProjectName,
            this.StatusName,
            this.PayTypeName,
            this.Rate,
            this.Deadline,
            this.TotalFunds,
            this.Note});
            this.gridProjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridProjects.Location = new System.Drawing.Point(3, 31);
            this.gridProjects.Name = "gridProjects";
            this.gridProjects.RowTemplate.Height = 23;
            this.gridProjects.Size = new System.Drawing.Size(628, 427);
            this.gridProjects.TabIndex = 0;
            this.gridProjects.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridProjects_CellFormatting);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.txtKeyword);
            this.pnlButtons.Controls.Add(this.btnRefresh);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtons.Location = new System.Drawing.Point(0, 0);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(0);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(634, 28);
            this.pnlButtons.TabIndex = 1;
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(3, 3);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(100, 23);
            this.txtKeyword.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(109, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // ProjectTypeId
            // 
            this.ProjectTypeId.DataPropertyName = "ProjectTypeId";
            this.ProjectTypeId.HeaderText = "ProjectTypeId";
            this.ProjectTypeId.Name = "ProjectTypeId";
            this.ProjectTypeId.Visible = false;
            // 
            // ProjectType
            // 
            this.ProjectType.HeaderText = "类型";
            this.ProjectType.Name = "ProjectType";
            this.ProjectType.Width = 50;
            // 
            // ProjectName
            // 
            this.ProjectName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ProjectName.DataPropertyName = "Name";
            this.ProjectName.HeaderText = "项目名";
            this.ProjectName.Name = "ProjectName";
            this.ProjectName.Width = 69;
            // 
            // StatusName
            // 
            this.StatusName.DataPropertyName = "StatusName";
            this.StatusName.HeaderText = "状态";
            this.StatusName.Name = "StatusName";
            this.StatusName.Width = 60;
            // 
            // PayTypeName
            // 
            this.PayTypeName.DataPropertyName = "PayTypeName";
            this.PayTypeName.HeaderText = "还款方式";
            this.PayTypeName.Name = "PayTypeName";
            this.PayTypeName.Width = 90;
            // 
            // Rate
            // 
            this.Rate.DataPropertyName = "Rate";
            this.Rate.HeaderText = "年化";
            this.Rate.Name = "Rate";
            this.Rate.Width = 60;
            // 
            // Deadline
            // 
            this.Deadline.DataPropertyName = "Deadline";
            this.Deadline.HeaderText = "期限";
            this.Deadline.Name = "Deadline";
            this.Deadline.Width = 60;
            // 
            // TotalFunds
            // 
            this.TotalFunds.DataPropertyName = "TotalFunds";
            this.TotalFunds.HeaderText = "规模";
            this.TotalFunds.Name = "TotalFunds";
            this.TotalFunds.Width = 70;
            // 
            // Note
            // 
            this.Note.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Note.DataPropertyName = "Note";
            this.Note.HeaderText = "备注";
            this.Note.Name = "Note";
            // 
            // RptProjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(634, 461);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RptProjects";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "项目一览表";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RptProjects_Load);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridProjects)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pnlMain;
        private System.Windows.Forms.DataGridView gridProjects;
        private System.Windows.Forms.FlowLayoutPanel pnlButtons;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectTypeId;
        private System.Windows.Forms.DataGridViewImageColumn ProjectType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Deadline;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalFunds;
        private System.Windows.Forms.DataGridViewTextBoxColumn Note;
    }
}