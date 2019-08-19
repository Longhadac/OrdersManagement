﻿namespace OrdersManagement
{
    partial class Form1
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
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbAddress = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadProfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSkuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getDataToDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getAmazonOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getAliTrackingNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillTrackingNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbbStatus = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbSearchOrderId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbbCountry = new System.Windows.Forms.ComboBox();
            this.cbbAccount = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbbNote = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tbSearchTradeDate = new System.Windows.Forms.TextBox();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.dgvAli = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.tbAliId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAliCashAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddAliInfo = new System.Windows.Forms.Button();
            this.btResetSearch = new System.Windows.Forms.Button();
            this.dgvSkuToLink = new System.Windows.Forms.DataGridView();
            this.tbSkuLink = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btAddSkuLink = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSkuToLink)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(13, 90);
            this.dgvOrders.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.RowHeadersWidth = 51;
            this.dgvOrders.RowTemplate.Height = 24;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(1150, 314);
            this.dgvOrders.TabIndex = 3;
            this.dgvOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox4);
            this.groupBox2.Controls.Add(this.pictureBox3);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Location = new System.Drawing.Point(1442, 91);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox2.Size = new System.Drawing.Size(281, 309);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Images";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(139, 155);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(125, 125);
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.PictureBox4_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(8, 155);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(125, 125);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.PictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(139, 26);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(125, 125);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.PictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 26);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 125);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // lbAddress
            // 
            this.lbAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAddress.FormattingEnabled = true;
            this.lbAddress.ItemHeight = 17;
            this.lbAddress.Location = new System.Drawing.Point(1181, 90);
            this.lbAddress.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(232, 310);
            this.lbAddress.TabIndex = 26;
            this.lbAddress.SelectedIndexChanged += new System.EventHandler(this.LbAddress_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDataToolStripMenuItem,
            this.getDataToDBToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(10, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1745, 24);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loadDataToolStripMenuItem
            // 
            this.loadDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadOrdersToolStripMenuItem,
            this.loadProfilesToolStripMenuItem,
            this.loadSkuToolStripMenuItem});
            this.loadDataToolStripMenuItem.Name = "loadDataToolStripMenuItem";
            this.loadDataToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.loadDataToolStripMenuItem.Text = "Load Data";
            // 
            // loadOrdersToolStripMenuItem
            // 
            this.loadOrdersToolStripMenuItem.Name = "loadOrdersToolStripMenuItem";
            this.loadOrdersToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.loadOrdersToolStripMenuItem.Text = "Load Orders";
            this.loadOrdersToolStripMenuItem.Click += new System.EventHandler(this.LoadOrdersToolStripMenuItem_Click);
            // 
            // loadProfilesToolStripMenuItem
            // 
            this.loadProfilesToolStripMenuItem.Name = "loadProfilesToolStripMenuItem";
            this.loadProfilesToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.loadProfilesToolStripMenuItem.Text = "Load Profiles";
            this.loadProfilesToolStripMenuItem.Click += new System.EventHandler(this.LoadProfilesToolStripMenuItem_Click);
            // 
            // loadSkuToolStripMenuItem
            // 
            this.loadSkuToolStripMenuItem.Name = "loadSkuToolStripMenuItem";
            this.loadSkuToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.loadSkuToolStripMenuItem.Text = "Load Sku";
            this.loadSkuToolStripMenuItem.Click += new System.EventHandler(this.LoadSkuToolStripMenuItem_Click);
            // 
            // getDataToDBToolStripMenuItem
            // 
            this.getDataToDBToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getAmazonOrdersToolStripMenuItem,
            this.getAliTrackingNumberToolStripMenuItem,
            this.fillTrackingNumberToolStripMenuItem});
            this.getDataToDBToolStripMenuItem.Name = "getDataToDBToolStripMenuItem";
            this.getDataToDBToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.getDataToDBToolStripMenuItem.Text = "Get data to DB";
            // 
            // getAmazonOrdersToolStripMenuItem
            // 
            this.getAmazonOrdersToolStripMenuItem.Name = "getAmazonOrdersToolStripMenuItem";
            this.getAmazonOrdersToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.getAmazonOrdersToolStripMenuItem.Text = "Get Amazon Orders";
            this.getAmazonOrdersToolStripMenuItem.Click += new System.EventHandler(this.GetAmazonOrdersToolStripMenuItem_Click);
            // 
            // getAliTrackingNumberToolStripMenuItem
            // 
            this.getAliTrackingNumberToolStripMenuItem.Name = "getAliTrackingNumberToolStripMenuItem";
            this.getAliTrackingNumberToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.getAliTrackingNumberToolStripMenuItem.Text = "Get Ali Tracking Number";
            this.getAliTrackingNumberToolStripMenuItem.Click += new System.EventHandler(this.GetAliTrackingNumberToolStripMenuItem_Click);
            // 
            // fillTrackingNumberToolStripMenuItem
            // 
            this.fillTrackingNumberToolStripMenuItem.Name = "fillTrackingNumberToolStripMenuItem";
            this.fillTrackingNumberToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.fillTrackingNumberToolStripMenuItem.Text = "Fill Tracking Number";
            this.fillTrackingNumberToolStripMenuItem.Click += new System.EventHandler(this.FillTrackingNumberToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // cbbStatus
            // 
            this.cbbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbStatus.FormattingEnabled = true;
            this.cbbStatus.Location = new System.Drawing.Point(93, 41);
            this.cbbStatus.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cbbStatus.Name = "cbbStatus";
            this.cbbStatus.Size = new System.Drawing.Size(117, 25);
            this.cbbStatus.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(28, 44);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 17);
            this.label11.TabIndex = 15;
            this.label11.Text = "Status";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(1082, 45);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(19, 17);
            this.label12.TabIndex = 21;
            this.label12.Text = "Id";
            // 
            // tbSearchOrderId
            // 
            this.tbSearchOrderId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchOrderId.Location = new System.Drawing.Point(1112, 42);
            this.tbSearchOrderId.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tbSearchOrderId.Name = "tbSearchOrderId";
            this.tbSearchOrderId.Size = new System.Drawing.Size(244, 23);
            this.tbSearchOrderId.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(254, 44);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 17);
            this.label6.TabIndex = 28;
            this.label6.Text = "Country";
            // 
            // cbbCountry
            // 
            this.cbbCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbCountry.FormattingEnabled = true;
            this.cbbCountry.Location = new System.Drawing.Point(329, 41);
            this.cbbCountry.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cbbCountry.Name = "cbbCountry";
            this.cbbCountry.Size = new System.Drawing.Size(117, 25);
            this.cbbCountry.TabIndex = 29;
            // 
            // cbbAccount
            // 
            this.cbbAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbAccount.FormattingEnabled = true;
            this.cbbAccount.Location = new System.Drawing.Point(556, 41);
            this.cbbAccount.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cbbAccount.Name = "cbbAccount";
            this.cbbAccount.Size = new System.Drawing.Size(117, 25);
            this.cbbAccount.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(481, 44);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 17);
            this.label7.TabIndex = 30;
            this.label7.Text = "Account";
            // 
            // cbbNote
            // 
            this.cbbNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbNote.FormattingEnabled = true;
            this.cbbNote.Location = new System.Drawing.Point(766, 41);
            this.cbbNote.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cbbNote.Name = "cbbNote";
            this.cbbNote.Size = new System.Drawing.Size(117, 25);
            this.cbbNote.TabIndex = 33;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(714, 44);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 17);
            this.label13.TabIndex = 32;
            this.label13.Text = "Note";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(915, 44);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 17);
            this.label14.TabIndex = 34;
            this.label14.Text = "Trade date";
            // 
            // tbSearchTradeDate
            // 
            this.tbSearchTradeDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchTradeDate.Location = new System.Drawing.Point(1012, 42);
            this.tbSearchTradeDate.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tbSearchTradeDate.Name = "tbSearchTradeDate";
            this.tbSearchTradeDate.Size = new System.Drawing.Size(45, 23);
            this.tbSearchTradeDate.TabIndex = 35;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Location = new System.Drawing.Point(13, 410);
            this.dgvItems.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersWidth = 51;
            this.dgvItems.RowTemplate.Height = 24;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvItems.Size = new System.Drawing.Size(1150, 132);
            this.dgvItems.TabIndex = 36;
            // 
            // dgvAli
            // 
            this.dgvAli.AllowUserToAddRows = false;
            this.dgvAli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAli.Location = new System.Drawing.Point(13, 546);
            this.dgvAli.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dgvAli.MultiSelect = false;
            this.dgvAli.Name = "dgvAli";
            this.dgvAli.RowHeadersWidth = 51;
            this.dgvAli.RowTemplate.Height = 24;
            this.dgvAli.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvAli.Size = new System.Drawing.Size(1150, 119);
            this.dgvAli.TabIndex = 37;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1387, 40);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 29);
            this.btnSearch.TabIndex = 38;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(1191, 741);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(532, 52);
            this.btnSubmit.TabIndex = 39;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // tbAliId
            // 
            this.tbAliId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAliId.Location = new System.Drawing.Point(1319, 426);
            this.tbAliId.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tbAliId.Name = "tbAliId";
            this.tbAliId.Size = new System.Drawing.Size(244, 23);
            this.tbAliId.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1188, 429);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 41;
            this.label1.Text = "Ali Id";
            // 
            // tbAliCashAmount
            // 
            this.tbAliCashAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAliCashAmount.Location = new System.Drawing.Point(1319, 469);
            this.tbAliCashAmount.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tbAliCashAmount.Name = "tbAliCashAmount";
            this.tbAliCashAmount.Size = new System.Drawing.Size(244, 23);
            this.tbAliCashAmount.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1188, 472);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 17);
            this.label2.TabIndex = 43;
            this.label2.Text = "Ali Cash Amount";
            // 
            // btnAddAliInfo
            // 
            this.btnAddAliInfo.Location = new System.Drawing.Point(1191, 512);
            this.btnAddAliInfo.Name = "btnAddAliInfo";
            this.btnAddAliInfo.Size = new System.Drawing.Size(372, 30);
            this.btnAddAliInfo.TabIndex = 46;
            this.btnAddAliInfo.Text = "Add";
            this.btnAddAliInfo.UseVisualStyleBackColor = true;
            this.btnAddAliInfo.Click += new System.EventHandler(this.BtnAddAliInfo_Click);
            // 
            // btResetSearch
            // 
            this.btResetSearch.Location = new System.Drawing.Point(1500, 42);
            this.btResetSearch.Name = "btResetSearch";
            this.btResetSearch.Size = new System.Drawing.Size(75, 29);
            this.btResetSearch.TabIndex = 47;
            this.btResetSearch.Text = "Reset";
            this.btResetSearch.UseVisualStyleBackColor = true;
            this.btResetSearch.Click += new System.EventHandler(this.BtResetSearch_Click);
            // 
            // dgvSkuToLink
            // 
            this.dgvSkuToLink.AllowUserToAddRows = false;
            this.dgvSkuToLink.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSkuToLink.Location = new System.Drawing.Point(13, 669);
            this.dgvSkuToLink.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dgvSkuToLink.MultiSelect = false;
            this.dgvSkuToLink.Name = "dgvSkuToLink";
            this.dgvSkuToLink.RowHeadersWidth = 51;
            this.dgvSkuToLink.RowTemplate.Height = 24;
            this.dgvSkuToLink.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvSkuToLink.Size = new System.Drawing.Size(1150, 119);
            this.dgvSkuToLink.TabIndex = 48;
            // 
            // tbSkuLink
            // 
            this.tbSkuLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSkuLink.Location = new System.Drawing.Point(1261, 588);
            this.tbSkuLink.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tbSkuLink.Name = "tbSkuLink";
            this.tbSkuLink.Size = new System.Drawing.Size(302, 23);
            this.tbSkuLink.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1188, 591);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 50;
            this.label3.Text = "New Link";
            // 
            // btAddSkuLink
            // 
            this.btAddSkuLink.Location = new System.Drawing.Point(1191, 616);
            this.btAddSkuLink.Name = "btAddSkuLink";
            this.btAddSkuLink.Size = new System.Drawing.Size(372, 30);
            this.btAddSkuLink.TabIndex = 51;
            this.btAddSkuLink.Text = "Add Link";
            this.btAddSkuLink.UseVisualStyleBackColor = true;
            this.btAddSkuLink.Click += new System.EventHandler(this.btAddSkuLink_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1745, 805);
            this.Controls.Add(this.btAddSkuLink);
            this.Controls.Add(this.tbSkuLink);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvSkuToLink);
            this.Controls.Add(this.btResetSearch);
            this.Controls.Add(this.btnAddAliInfo);
            this.Controls.Add(this.tbAliCashAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbAliId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvAli);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.tbSearchTradeDate);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cbbNote);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cbbAccount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbbCountry);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbAddress);
            this.Controls.Add(this.tbSearchOrderId);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbbStatus);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSkuToLink)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox lbAddress;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem getDataToDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getAmazonOrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getAliTrackingNumberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fillTrackingNumberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadOrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadProfilesToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbbStatus;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbSearchOrderId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbbCountry;
        private System.Windows.Forms.ComboBox cbbAccount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbbNote;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbSearchTradeDate;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.DataGridView dgvAli;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox tbAliId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAliCashAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddAliInfo;
        private System.Windows.Forms.Button btResetSearch;
        private System.Windows.Forms.DataGridView dgvSkuToLink;
        private System.Windows.Forms.TextBox tbSkuLink;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btAddSkuLink;
        private System.Windows.Forms.ToolStripMenuItem loadSkuToolStripMenuItem;
    }
}

