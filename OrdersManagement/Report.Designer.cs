namespace OrdersManagement
{
    partial class Report
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbCan2Usd = new System.Windows.Forms.TextBox();
            this.tbMex2Usd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btUpdate = new System.Windows.Forms.Button();
            this.lbTotalAli = new System.Windows.Forms.Label();
            this.lbTotalAmz = new System.Windows.Forms.Label();
            this.lbTotalRefund = new System.Windows.Forms.Label();
            this.lbRoi = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Canada To USD";
            // 
            // tbCan2Usd
            // 
            this.tbCan2Usd.Location = new System.Drawing.Point(183, 21);
            this.tbCan2Usd.Name = "tbCan2Usd";
            this.tbCan2Usd.Size = new System.Drawing.Size(100, 22);
            this.tbCan2Usd.TabIndex = 1;
            // 
            // tbMex2Usd
            // 
            this.tbMex2Usd.Location = new System.Drawing.Point(442, 21);
            this.tbMex2Usd.Name = "tbMex2Usd";
            this.tbMex2Usd.Size = new System.Drawing.Size(100, 22);
            this.tbMex2Usd.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(322, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mexico To USD";
            // 
            // btUpdate
            // 
            this.btUpdate.Location = new System.Drawing.Point(563, 19);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(75, 26);
            this.btUpdate.TabIndex = 4;
            this.btUpdate.Text = "Update";
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.BtUpdate_Click);
            // 
            // lbTotalAli
            // 
            this.lbTotalAli.AutoSize = true;
            this.lbTotalAli.Location = new System.Drawing.Point(55, 71);
            this.lbTotalAli.Name = "lbTotalAli";
            this.lbTotalAli.Size = new System.Drawing.Size(63, 17);
            this.lbTotalAli.TabIndex = 5;
            this.lbTotalAli.Text = "Total Ali:";
            // 
            // lbTotalAmz
            // 
            this.lbTotalAmz.AutoSize = true;
            this.lbTotalAmz.Location = new System.Drawing.Point(273, 71);
            this.lbTotalAmz.Name = "lbTotalAmz";
            this.lbTotalAmz.Size = new System.Drawing.Size(75, 17);
            this.lbTotalAmz.TabIndex = 6;
            this.lbTotalAmz.Text = "Total Amz:";
            // 
            // lbTotalRefund
            // 
            this.lbTotalRefund.AutoSize = true;
            this.lbTotalRefund.Location = new System.Drawing.Point(514, 71);
            this.lbTotalRefund.Name = "lbTotalRefund";
            this.lbTotalRefund.Size = new System.Drawing.Size(94, 17);
            this.lbTotalRefund.TabIndex = 7;
            this.lbTotalRefund.Text = "Total Refund:";
            // 
            // lbRoi
            // 
            this.lbRoi.AutoSize = true;
            this.lbRoi.Location = new System.Drawing.Point(761, 71);
            this.lbRoi.Name = "lbRoi";
            this.lbRoi.Size = new System.Drawing.Size(40, 17);
            this.lbRoi.TabIndex = 8;
            this.lbRoi.Text = "ROI: ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 109);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1362, 510);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1404, 651);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lbRoi);
            this.Controls.Add(this.lbTotalRefund);
            this.Controls.Add(this.lbTotalAmz);
            this.Controls.Add(this.lbTotalAli);
            this.Controls.Add(this.btUpdate);
            this.Controls.Add(this.tbMex2Usd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCan2Usd);
            this.Controls.Add(this.label1);
            this.Name = "Report";
            this.Text = "Report";
            this.Load += new System.EventHandler(this.Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCan2Usd;
        private System.Windows.Forms.TextBox tbMex2Usd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.Label lbTotalAli;
        private System.Windows.Forms.Label lbTotalAmz;
        private System.Windows.Forms.Label lbTotalRefund;
        private System.Windows.Forms.Label lbRoi;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}