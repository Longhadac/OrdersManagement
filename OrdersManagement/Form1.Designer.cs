namespace OrdersManagement
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
            this.tbAliId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddAliInfo = new System.Windows.Forms.Button();
            this.btResetSearch = new System.Windows.Forms.Button();
            this.dgvSkuToLink = new System.Windows.Forms.DataGridView();
            this.tbSkuLink = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btAddSkuLink = new System.Windows.Forms.Button();
            this.tbAliCashAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btUpdateAliCashAmount = new System.Windows.Forms.Button();
            this.btUpdateAliTrackingNumber = new System.Windows.Forms.Button();
            this.tbTrackingNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUpdateAliId = new System.Windows.Forms.Button();
            this.btnDeleteAliId = new System.Windows.Forms.Button();
            this.btUpdateRefund = new System.Windows.Forms.Button();
            this.tbRefund = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnUpdateNote = new System.Windows.Forms.Button();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbSearchAliId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbSearchAsin = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbSearchSku = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.groupBox2.SuspendLayout();
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
            this.dgvOrders.Location = new System.Drawing.Point(13, 105);
            this.dgvOrders.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersWidth = 51;
            this.dgvOrders.RowTemplate.Height = 24;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvOrders.Size = new System.Drawing.Size(1150, 299);
            this.dgvOrders.TabIndex = 3;
            this.dgvOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Location = new System.Drawing.Point(1171, 344);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox2.Size = new System.Drawing.Size(378, 167);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Images";
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
            this.lbAddress.ItemHeight = 20;
            this.lbAddress.Location = new System.Drawing.Point(1171, 183);
            this.lbAddress.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(378, 144);
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
            this.menuStrip1.Size = new System.Drawing.Size(1588, 28);
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
            this.loadDataToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
            this.loadDataToolStripMenuItem.Text = "Load Data";
            // 
            // loadOrdersToolStripMenuItem
            // 
            this.loadOrdersToolStripMenuItem.Name = "loadOrdersToolStripMenuItem";
            this.loadOrdersToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.loadOrdersToolStripMenuItem.Text = "Load Orders";
            this.loadOrdersToolStripMenuItem.Click += new System.EventHandler(this.LoadOrdersToolStripMenuItem_Click);
            // 
            // loadProfilesToolStripMenuItem
            // 
            this.loadProfilesToolStripMenuItem.Name = "loadProfilesToolStripMenuItem";
            this.loadProfilesToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.loadProfilesToolStripMenuItem.Text = "Load Profiles";
            this.loadProfilesToolStripMenuItem.Click += new System.EventHandler(this.LoadProfilesToolStripMenuItem_Click);
            // 
            // loadSkuToolStripMenuItem
            // 
            this.loadSkuToolStripMenuItem.Name = "loadSkuToolStripMenuItem";
            this.loadSkuToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
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
            this.getDataToDBToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.getDataToDBToolStripMenuItem.Text = "Get data to DB";
            // 
            // getAmazonOrdersToolStripMenuItem
            // 
            this.getAmazonOrdersToolStripMenuItem.Name = "getAmazonOrdersToolStripMenuItem";
            this.getAmazonOrdersToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.getAmazonOrdersToolStripMenuItem.Text = "Get Amazon Orders";
            this.getAmazonOrdersToolStripMenuItem.Click += new System.EventHandler(this.GetAmazonOrdersToolStripMenuItem_Click);
            // 
            // getAliTrackingNumberToolStripMenuItem
            // 
            this.getAliTrackingNumberToolStripMenuItem.Name = "getAliTrackingNumberToolStripMenuItem";
            this.getAliTrackingNumberToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.getAliTrackingNumberToolStripMenuItem.Text = "Get Ali Tracking Number";
            this.getAliTrackingNumberToolStripMenuItem.Click += new System.EventHandler(this.GetAliTrackingNumberToolStripMenuItem_Click);
            // 
            // fillTrackingNumberToolStripMenuItem
            // 
            this.fillTrackingNumberToolStripMenuItem.Name = "fillTrackingNumberToolStripMenuItem";
            this.fillTrackingNumberToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.fillTrackingNumberToolStripMenuItem.Text = "Fill Tracking Number";
            this.fillTrackingNumberToolStripMenuItem.Click += new System.EventHandler(this.FillTrackingNumberToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // cbbStatus
            // 
            this.cbbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbStatus.FormattingEnabled = true;
            this.cbbStatus.Location = new System.Drawing.Point(84, 41);
            this.cbbStatus.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cbbStatus.Name = "cbbStatus";
            this.cbbStatus.Size = new System.Drawing.Size(117, 28);
            this.cbbStatus.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(28, 44);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 20);
            this.label11.TabIndex = 15;
            this.label11.Text = "Status";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(972, 44);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(22, 20);
            this.label12.TabIndex = 21;
            this.label12.Text = "Id";
            // 
            // tbSearchOrderId
            // 
            this.tbSearchOrderId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchOrderId.Location = new System.Drawing.Point(1009, 41);
            this.tbSearchOrderId.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tbSearchOrderId.Name = "tbSearchOrderId";
            this.tbSearchOrderId.Size = new System.Drawing.Size(244, 27);
            this.tbSearchOrderId.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(223, 44);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 20);
            this.label6.TabIndex = 28;
            this.label6.Text = "Country";
            // 
            // cbbCountry
            // 
            this.cbbCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbCountry.FormattingEnabled = true;
            this.cbbCountry.Location = new System.Drawing.Point(288, 41);
            this.cbbCountry.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cbbCountry.Name = "cbbCountry";
            this.cbbCountry.Size = new System.Drawing.Size(117, 28);
            this.cbbCountry.TabIndex = 29;
            // 
            // cbbAccount
            // 
            this.cbbAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbAccount.FormattingEnabled = true;
            this.cbbAccount.Location = new System.Drawing.Point(480, 41);
            this.cbbAccount.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cbbAccount.Name = "cbbAccount";
            this.cbbAccount.Size = new System.Drawing.Size(117, 28);
            this.cbbAccount.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(413, 44);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 20);
            this.label7.TabIndex = 30;
            this.label7.Text = "Account";
            // 
            // cbbNote
            // 
            this.cbbNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbNote.FormattingEnabled = true;
            this.cbbNote.Location = new System.Drawing.Point(663, 41);
            this.cbbNote.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cbbNote.Name = "cbbNote";
            this.cbbNote.Size = new System.Drawing.Size(117, 28);
            this.cbbNote.TabIndex = 33;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(617, 44);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 20);
            this.label13.TabIndex = 32;
            this.label13.Text = "Note";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(798, 44);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 20);
            this.label14.TabIndex = 34;
            this.label14.Text = "Trade date";
            // 
            // tbSearchTradeDate
            // 
            this.tbSearchTradeDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchTradeDate.Location = new System.Drawing.Point(884, 41);
            this.tbSearchTradeDate.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tbSearchTradeDate.Name = "tbSearchTradeDate";
            this.tbSearchTradeDate.Size = new System.Drawing.Size(45, 27);
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
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersWidth = 51;
            this.dgvItems.RowTemplate.Height = 24;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvItems.Size = new System.Drawing.Size(1150, 132);
            this.dgvItems.TabIndex = 36;
            this.dgvItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvItems_CellContentClick);
            // 
            // dgvAli
            // 
            this.dgvAli.AllowUserToAddRows = false;
            this.dgvAli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAli.Location = new System.Drawing.Point(13, 546);
            this.dgvAli.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dgvAli.MultiSelect = false;
            this.dgvAli.Name = "dgvAli";
            this.dgvAli.ReadOnly = true;
            this.dgvAli.RowHeadersWidth = 51;
            this.dgvAli.RowTemplate.Height = 24;
            this.dgvAli.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvAli.Size = new System.Drawing.Size(1150, 119);
            this.dgvAli.TabIndex = 37;
            this.dgvAli.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAli_CellContentClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1293, 40);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 29);
            this.btnSearch.TabIndex = 38;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // tbAliId
            // 
            this.tbAliId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAliId.Location = new System.Drawing.Point(1228, 534);
            this.tbAliId.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tbAliId.Name = "tbAliId";
            this.tbAliId.Size = new System.Drawing.Size(244, 27);
            this.tbAliId.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1174, 534);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 41;
            this.label1.Text = "Ali Id";
            // 
            // btnAddAliInfo
            // 
            this.btnAddAliInfo.Location = new System.Drawing.Point(1293, 562);
            this.btnAddAliInfo.Name = "btnAddAliInfo";
            this.btnAddAliInfo.Size = new System.Drawing.Size(70, 30);
            this.btnAddAliInfo.TabIndex = 46;
            this.btnAddAliInfo.Text = "Add";
            this.btnAddAliInfo.UseVisualStyleBackColor = true;
            this.btnAddAliInfo.Click += new System.EventHandler(this.BtnAddAliInfo_Click);
            // 
            // btResetSearch
            // 
            this.btResetSearch.Location = new System.Drawing.Point(1383, 40);
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
            this.dgvSkuToLink.ReadOnly = true;
            this.dgvSkuToLink.RowHeadersWidth = 51;
            this.dgvSkuToLink.RowTemplate.Height = 24;
            this.dgvSkuToLink.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvSkuToLink.Size = new System.Drawing.Size(1150, 119);
            this.dgvSkuToLink.TabIndex = 48;
            this.dgvSkuToLink.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSkuToLink_CellContentClick);
            // 
            // tbSkuLink
            // 
            this.tbSkuLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSkuLink.Location = new System.Drawing.Point(1260, 721);
            this.tbSkuLink.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tbSkuLink.Name = "tbSkuLink";
            this.tbSkuLink.Size = new System.Drawing.Size(302, 27);
            this.tbSkuLink.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1174, 724);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 50;
            this.label3.Text = "New Link";
            // 
            // btAddSkuLink
            // 
            this.btAddSkuLink.Location = new System.Drawing.Point(1190, 758);
            this.btAddSkuLink.Name = "btAddSkuLink";
            this.btAddSkuLink.Size = new System.Drawing.Size(372, 30);
            this.btAddSkuLink.TabIndex = 51;
            this.btAddSkuLink.Text = "Add Link";
            this.btAddSkuLink.UseVisualStyleBackColor = true;
            this.btAddSkuLink.Click += new System.EventHandler(this.btAddSkuLink_Click);
            // 
            // tbAliCashAmount
            // 
            this.tbAliCashAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAliCashAmount.Location = new System.Drawing.Point(1323, 609);
            this.tbAliCashAmount.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tbAliCashAmount.Name = "tbAliCashAmount";
            this.tbAliCashAmount.Size = new System.Drawing.Size(176, 27);
            this.tbAliCashAmount.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1168, 612);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 20);
            this.label2.TabIndex = 53;
            this.label2.Text = "Ali Cash Amount";
            // 
            // btUpdateAliCashAmount
            // 
            this.btUpdateAliCashAmount.Location = new System.Drawing.Point(1506, 605);
            this.btUpdateAliCashAmount.Name = "btUpdateAliCashAmount";
            this.btUpdateAliCashAmount.Size = new System.Drawing.Size(70, 30);
            this.btUpdateAliCashAmount.TabIndex = 54;
            this.btUpdateAliCashAmount.Text = "Update";
            this.btUpdateAliCashAmount.UseVisualStyleBackColor = true;
            this.btUpdateAliCashAmount.Click += new System.EventHandler(this.BtUpdateAliCashAmount_Click);
            // 
            // btUpdateAliTrackingNumber
            // 
            this.btUpdateAliTrackingNumber.Location = new System.Drawing.Point(1506, 641);
            this.btUpdateAliTrackingNumber.Name = "btUpdateAliTrackingNumber";
            this.btUpdateAliTrackingNumber.Size = new System.Drawing.Size(70, 30);
            this.btUpdateAliTrackingNumber.TabIndex = 57;
            this.btUpdateAliTrackingNumber.Text = "Update";
            this.btUpdateAliTrackingNumber.UseVisualStyleBackColor = true;
            this.btUpdateAliTrackingNumber.Click += new System.EventHandler(this.BtUpdateAliTrackingNumber_Click);
            // 
            // tbTrackingNumber
            // 
            this.tbTrackingNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTrackingNumber.Location = new System.Drawing.Point(1323, 645);
            this.tbTrackingNumber.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tbTrackingNumber.Name = "tbTrackingNumber";
            this.tbTrackingNumber.Size = new System.Drawing.Size(176, 27);
            this.tbTrackingNumber.TabIndex = 55;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1171, 648);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 20);
            this.label4.TabIndex = 56;
            this.label4.Text = "Ali Tracking Number";
            // 
            // btnUpdateAliId
            // 
            this.btnUpdateAliId.Location = new System.Drawing.Point(1388, 562);
            this.btnUpdateAliId.Name = "btnUpdateAliId";
            this.btnUpdateAliId.Size = new System.Drawing.Size(70, 30);
            this.btnUpdateAliId.TabIndex = 58;
            this.btnUpdateAliId.Text = "Update";
            this.btnUpdateAliId.UseVisualStyleBackColor = true;
            this.btnUpdateAliId.Click += new System.EventHandler(this.BtnUpdateAliId_Click);
            // 
            // btnDeleteAliId
            // 
            this.btnDeleteAliId.ForeColor = System.Drawing.Color.Red;
            this.btnDeleteAliId.Location = new System.Drawing.Point(1479, 530);
            this.btnDeleteAliId.Name = "btnDeleteAliId";
            this.btnDeleteAliId.Size = new System.Drawing.Size(70, 30);
            this.btnDeleteAliId.TabIndex = 59;
            this.btnDeleteAliId.Text = "Delete";
            this.btnDeleteAliId.UseVisualStyleBackColor = true;
            this.btnDeleteAliId.Click += new System.EventHandler(this.BtnDeleteAliId_Click);
            // 
            // btUpdateRefund
            // 
            this.btUpdateRefund.Location = new System.Drawing.Point(1506, 101);
            this.btUpdateRefund.Name = "btUpdateRefund";
            this.btUpdateRefund.Size = new System.Drawing.Size(70, 30);
            this.btUpdateRefund.TabIndex = 62;
            this.btUpdateRefund.Text = "Update";
            this.btUpdateRefund.UseVisualStyleBackColor = true;
            this.btUpdateRefund.Click += new System.EventHandler(this.BtUpdateRefund_Click);
            // 
            // tbRefund
            // 
            this.tbRefund.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRefund.Location = new System.Drawing.Point(1249, 105);
            this.tbRefund.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tbRefund.Name = "tbRefund";
            this.tbRefund.Size = new System.Drawing.Size(250, 27);
            this.tbRefund.TabIndex = 60;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1187, 108);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 20);
            this.label5.TabIndex = 61;
            this.label5.Text = "Refund";
            // 
            // btnUpdateNote
            // 
            this.btnUpdateNote.Location = new System.Drawing.Point(1506, 137);
            this.btnUpdateNote.Name = "btnUpdateNote";
            this.btnUpdateNote.Size = new System.Drawing.Size(70, 30);
            this.btnUpdateNote.TabIndex = 65;
            this.btnUpdateNote.Text = "Update";
            this.btnUpdateNote.UseVisualStyleBackColor = true;
            this.btnUpdateNote.Click += new System.EventHandler(this.BtnUpdateNote_Click);
            // 
            // tbNote
            // 
            this.tbNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNote.Location = new System.Drawing.Point(1249, 141);
            this.tbNote.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tbNote.Name = "tbNote";
            this.tbNote.Size = new System.Drawing.Size(250, 27);
            this.tbNote.TabIndex = 63;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1187, 144);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 20);
            this.label8.TabIndex = 64;
            this.label8.Text = "Note";
            // 
            // tbSearchAliId
            // 
            this.tbSearchAliId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchAliId.Location = new System.Drawing.Point(84, 78);
            this.tbSearchAliId.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tbSearchAliId.Name = "tbSearchAliId";
            this.tbSearchAliId.Size = new System.Drawing.Size(196, 27);
            this.tbSearchAliId.TabIndex = 66;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(28, 81);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 20);
            this.label9.TabIndex = 67;
            this.label9.Text = "Ali Id";
            // 
            // tbSearchAsin
            // 
            this.tbSearchAsin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchAsin.Location = new System.Drawing.Point(416, 78);
            this.tbSearchAsin.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tbSearchAsin.Name = "tbSearchAsin";
            this.tbSearchAsin.Size = new System.Drawing.Size(196, 27);
            this.tbSearchAsin.TabIndex = 68;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(360, 81);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 20);
            this.label10.TabIndex = 69;
            this.label10.Text = "ASIN";
            // 
            // tbSearchSku
            // 
            this.tbSearchSku.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchSku.Location = new System.Drawing.Point(769, 78);
            this.tbSearchSku.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tbSearchSku.Name = "tbSearchSku";
            this.tbSearchSku.Size = new System.Drawing.Size(196, 27);
            this.tbSearchSku.TabIndex = 70;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(713, 81);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 20);
            this.label15.TabIndex = 71;
            this.label15.Text = "SKU";
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.reportToolStripMenuItem.Text = "Report";
            this.reportToolStripMenuItem.Click += new System.EventHandler(this.ReportToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1588, 805);
            this.Controls.Add(this.tbSearchSku);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tbSearchAsin);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbSearchAliId);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnUpdateNote);
            this.Controls.Add(this.tbNote);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btUpdateRefund);
            this.Controls.Add(this.tbRefund);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnDeleteAliId);
            this.Controls.Add(this.btnUpdateAliId);
            this.Controls.Add(this.btUpdateAliTrackingNumber);
            this.Controls.Add(this.tbTrackingNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btUpdateAliCashAmount);
            this.Controls.Add(this.tbAliCashAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btAddSkuLink);
            this.Controls.Add(this.tbSkuLink);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvSkuToLink);
            this.Controls.Add(this.btResetSearch);
            this.Controls.Add(this.btnAddAliInfo);
            this.Controls.Add(this.tbAliId);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.TextBox tbAliId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddAliInfo;
        private System.Windows.Forms.Button btResetSearch;
        private System.Windows.Forms.DataGridView dgvSkuToLink;
        private System.Windows.Forms.TextBox tbSkuLink;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btAddSkuLink;
        private System.Windows.Forms.ToolStripMenuItem loadSkuToolStripMenuItem;
        private System.Windows.Forms.TextBox tbAliCashAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btUpdateAliCashAmount;
        private System.Windows.Forms.Button btUpdateAliTrackingNumber;
        private System.Windows.Forms.TextBox tbTrackingNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUpdateAliId;
        private System.Windows.Forms.Button btnDeleteAliId;
        private System.Windows.Forms.Button btUpdateRefund;
        private System.Windows.Forms.TextBox tbRefund;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnUpdateNote;
        private System.Windows.Forms.TextBox tbNote;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbSearchAliId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbSearchAsin;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbSearchSku;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
    }
}

