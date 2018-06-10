namespace Server_Snak
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda obsługi projektanta — nie należy modyfikować 
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.listBoxBanDomensPA = new System.Windows.Forms.ListBox();
            this.listBoxBanProcessesPA = new System.Windows.Forms.ListBox();
            this.listBoxBanDomensAK = new System.Windows.Forms.ListBox();
            this.listBoxBanProcessesAK = new System.Windows.Forms.ListBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.listBoxClient4 = new System.Windows.Forms.ListBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.listBoxClient5 = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.buttonAddDomenToList = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxAddDomenToList = new System.Windows.Forms.TextBox();
            this.buttonSendCommandDomena = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.listBoxClient3 = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.listBoxBannedDomenaPA = new System.Windows.Forms.ListBox();
            this.listBoxBannedDomenaAK = new System.Windows.Forms.ListBox();
            this.listBoxDomens = new System.Windows.Forms.ListBox();
            this.comboBoxChange2 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboBoxMode1 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.buttonAddProcesToList = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxAddProcesToList = new System.Windows.Forms.TextBox();
            this.buttonSendCommandProces = new System.Windows.Forms.Button();
            this.comboBoxChange1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listBoxBannedPA = new System.Windows.Forms.ListBox();
            this.listBoxBannedAK = new System.Windows.Forms.ListBox();
            this.listBoxProcesses = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.listBoxClient2 = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.label1 = new System.Windows.Forms.Label();
            this.labelIPSerwera = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage4.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox8);
            this.tabPage4.Controls.Add(this.groupBox7);
            this.tabPage4.Location = new System.Drawing.Point(4, 34);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1442, 542);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Szczegóły klientów";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.pictureBox1);
            this.groupBox8.Controls.Add(this.label18);
            this.groupBox8.Controls.Add(this.label17);
            this.groupBox8.Controls.Add(this.label16);
            this.groupBox8.Controls.Add(this.label15);
            this.groupBox8.Controls.Add(this.listBoxBanDomensPA);
            this.groupBox8.Controls.Add(this.listBoxBanProcessesPA);
            this.groupBox8.Controls.Add(this.listBoxBanDomensAK);
            this.groupBox8.Controls.Add(this.listBoxBanProcessesAK);
            this.groupBox8.Location = new System.Drawing.Point(24, 3);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(903, 494);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Zablokowane listy";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(530, 71);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 138);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(246, 251);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(168, 25);
            this.label18.TabIndex = 7;
            this.label18.Text = "Domeny pasywne";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(246, 20);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(162, 25);
            this.label17.TabIndex = 6;
            this.label17.Text = "Domeny aktywne";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 251);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(166, 25);
            this.label16.TabIndex = 5;
            this.label16.Text = "Procesy pasywne";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(15, 23);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(160, 25);
            this.label15.TabIndex = 4;
            this.label15.Text = "Procesy aktywne";
            // 
            // listBoxBanDomensPA
            // 
            this.listBoxBanDomensPA.FormattingEnabled = true;
            this.listBoxBanDomensPA.ItemHeight = 25;
            this.listBoxBanDomensPA.Location = new System.Drawing.Point(250, 274);
            this.listBoxBanDomensPA.Name = "listBoxBanDomensPA";
            this.listBoxBanDomensPA.Size = new System.Drawing.Size(180, 154);
            this.listBoxBanDomensPA.TabIndex = 3;
            // 
            // listBoxBanProcessesPA
            // 
            this.listBoxBanProcessesPA.FormattingEnabled = true;
            this.listBoxBanProcessesPA.ItemHeight = 25;
            this.listBoxBanProcessesPA.Location = new System.Drawing.Point(20, 274);
            this.listBoxBanProcessesPA.Name = "listBoxBanProcessesPA";
            this.listBoxBanProcessesPA.Size = new System.Drawing.Size(180, 154);
            this.listBoxBanProcessesPA.TabIndex = 2;
            // 
            // listBoxBanDomensAK
            // 
            this.listBoxBanDomensAK.FormattingEnabled = true;
            this.listBoxBanDomensAK.ItemHeight = 25;
            this.listBoxBanDomensAK.Location = new System.Drawing.Point(250, 43);
            this.listBoxBanDomensAK.Name = "listBoxBanDomensAK";
            this.listBoxBanDomensAK.Size = new System.Drawing.Size(180, 154);
            this.listBoxBanDomensAK.TabIndex = 1;
            // 
            // listBoxBanProcessesAK
            // 
            this.listBoxBanProcessesAK.FormattingEnabled = true;
            this.listBoxBanProcessesAK.ItemHeight = 25;
            this.listBoxBanProcessesAK.Location = new System.Drawing.Point(20, 43);
            this.listBoxBanProcessesAK.Name = "listBoxBanProcessesAK";
            this.listBoxBanProcessesAK.Size = new System.Drawing.Size(180, 154);
            this.listBoxBanProcessesAK.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.checkBox4);
            this.groupBox7.Controls.Add(this.listBoxClient4);
            this.groupBox7.Location = new System.Drawing.Point(950, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(273, 375);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Klienci";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(6, 335);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(267, 29);
            this.checkBox4.TabIndex = 2;
            this.checkBox4.Text = "Zabronione dla wszystkich";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // listBoxClient4
            // 
            this.listBoxClient4.FormattingEnabled = true;
            this.listBoxClient4.ItemHeight = 25;
            this.listBoxClient4.Location = new System.Drawing.Point(6, 45);
            this.listBoxClient4.Name = "listBoxClient4";
            this.listBoxClient4.Size = new System.Drawing.Size(254, 254);
            this.listBoxClient4.TabIndex = 0;
            this.listBoxClient4.SelectedIndexChanged += new System.EventHandler(this.listBoxClient4_SelectedIndexChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.groupBox10);
            this.tabPage5.Location = new System.Drawing.Point(4, 34);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage5.Size = new System.Drawing.Size(1442, 542);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Dyski";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.listBoxClient5);
            this.groupBox10.Location = new System.Drawing.Point(754, 25);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(200, 349);
            this.groupBox10.TabIndex = 0;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Klienci";
            // 
            // listBoxClient5
            // 
            this.listBoxClient5.FormattingEnabled = true;
            this.listBoxClient5.ItemHeight = 20;
            this.listBoxClient5.Location = new System.Drawing.Point(8, 26);
            this.listBoxClient5.Name = "listBoxClient5";
            this.listBoxClient5.Size = new System.Drawing.Size(187, 304);
            this.listBoxClient5.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.comboBox1);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.buttonAddDomenToList);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.textBoxAddDomenToList);
            this.tabPage3.Controls.Add(this.buttonSendCommandDomena);
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Controls.Add(this.comboBoxChange2);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1442, 542);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Wybierz domeny";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Aktywny",
            "Pasywny"});
            this.comboBox1.Location = new System.Drawing.Point(140, 22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 33);
            this.comboBox1.TabIndex = 11;
            this.comboBox1.Text = "Aktywny";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(50, 25);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(111, 25);
            this.label14.TabIndex = 10;
            this.label14.Text = "Tryb pracy:";
            // 
            // buttonAddDomenToList
            // 
            this.buttonAddDomenToList.Location = new System.Drawing.Point(326, 425);
            this.buttonAddDomenToList.Name = "buttonAddDomenToList";
            this.buttonAddDomenToList.Size = new System.Drawing.Size(81, 31);
            this.buttonAddDomenToList.TabIndex = 7;
            this.buttonAddDomenToList.Text = "Dodaj";
            this.buttonAddDomenToList.UseVisualStyleBackColor = true;
            this.buttonAddDomenToList.Click += new System.EventHandler(this.buttonAddDomenToList_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(98, 431);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(124, 25);
            this.label12.TabIndex = 6;
            this.label12.Text = "Podaj nazwe";
            // 
            // textBoxAddDomenToList
            // 
            this.textBoxAddDomenToList.Location = new System.Drawing.Point(202, 425);
            this.textBoxAddDomenToList.Name = "textBoxAddDomenToList";
            this.textBoxAddDomenToList.Size = new System.Drawing.Size(100, 30);
            this.textBoxAddDomenToList.TabIndex = 5;
            // 
            // buttonSendCommandDomena
            // 
            this.buttonSendCommandDomena.Location = new System.Drawing.Point(446, 463);
            this.buttonSendCommandDomena.Name = "buttonSendCommandDomena";
            this.buttonSendCommandDomena.Size = new System.Drawing.Size(116, 35);
            this.buttonSendCommandDomena.TabIndex = 4;
            this.buttonSendCommandDomena.Text = "Wyślij";
            this.buttonSendCommandDomena.UseVisualStyleBackColor = true;
            this.buttonSendCommandDomena.Click += new System.EventHandler(this.buttonSendCommandDomena_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.checkBox3);
            this.groupBox6.Controls.Add(this.listBoxClient3);
            this.groupBox6.Location = new System.Drawing.Point(864, 55);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(358, 351);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Klienci";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(34, 318);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(216, 29);
            this.checkBox3.TabIndex = 1;
            this.checkBox3.Text = "Wyślij do wszystkich";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // listBoxClient3
            // 
            this.listBoxClient3.FormattingEnabled = true;
            this.listBoxClient3.ItemHeight = 25;
            this.listBoxClient3.Location = new System.Drawing.Point(20, 26);
            this.listBoxClient3.Name = "listBoxClient3";
            this.listBoxClient3.Size = new System.Drawing.Size(278, 279);
            this.listBoxClient3.TabIndex = 0;
            this.listBoxClient3.SelectedIndexChanged += new System.EventHandler(this.listBoxClient3_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.listBoxBannedDomenaPA);
            this.groupBox5.Controls.Add(this.listBoxBannedDomenaAK);
            this.groupBox5.Controls.Add(this.listBoxDomens);
            this.groupBox5.Location = new System.Drawing.Point(22, 55);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(836, 351);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Lista domen";
            // 
            // listBoxBannedDomenaPA
            // 
            this.listBoxBannedDomenaPA.FormattingEnabled = true;
            this.listBoxBannedDomenaPA.ItemHeight = 25;
            this.listBoxBannedDomenaPA.Location = new System.Drawing.Point(574, 26);
            this.listBoxBannedDomenaPA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBoxBannedDomenaPA.Name = "listBoxBannedDomenaPA";
            this.listBoxBannedDomenaPA.Size = new System.Drawing.Size(178, 279);
            this.listBoxBannedDomenaPA.TabIndex = 12;
            // 
            // listBoxBannedDomenaAK
            // 
            this.listBoxBannedDomenaAK.FormattingEnabled = true;
            this.listBoxBannedDomenaAK.ItemHeight = 25;
            this.listBoxBannedDomenaAK.Location = new System.Drawing.Point(310, 28);
            this.listBoxBannedDomenaAK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBoxBannedDomenaAK.Name = "listBoxBannedDomenaAK";
            this.listBoxBannedDomenaAK.Size = new System.Drawing.Size(180, 279);
            this.listBoxBannedDomenaAK.TabIndex = 4;
            // 
            // listBoxDomens
            // 
            this.listBoxDomens.FormattingEnabled = true;
            this.listBoxDomens.ItemHeight = 25;
            this.listBoxDomens.Location = new System.Drawing.Point(26, 28);
            this.listBoxDomens.Name = "listBoxDomens";
            this.listBoxDomens.Size = new System.Drawing.Size(214, 279);
            this.listBoxDomens.TabIndex = 0;
            // 
            // comboBoxChange2
            // 
            this.comboBoxChange2.FormattingEnabled = true;
            this.comboBoxChange2.Items.AddRange(new object[] {
            "zabronione",
            "dostępne"});
            this.comboBoxChange2.Location = new System.Drawing.Point(621, 22);
            this.comboBoxChange2.Name = "comboBoxChange2";
            this.comboBoxChange2.Size = new System.Drawing.Size(121, 33);
            this.comboBoxChange2.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(381, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(298, 25);
            this.label11.TabIndex = 0;
            this.label11.Text = "Wybierz jakie domeny mają być: ";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.comboBoxMode1);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.buttonAddProcesToList);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.textBoxAddProcesToList);
            this.tabPage2.Controls.Add(this.buttonSendCommandProces);
            this.tabPage2.Controls.Add(this.comboBoxChange1);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(1442, 542);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Wybierz procesy";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // comboBoxMode1
            // 
            this.comboBoxMode1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxMode1.FormattingEnabled = true;
            this.comboBoxMode1.Items.AddRange(new object[] {
            "Aktywny",
            "Pasywny"});
            this.comboBoxMode1.Location = new System.Drawing.Point(240, 22);
            this.comboBoxMode1.Name = "comboBoxMode1";
            this.comboBoxMode1.Size = new System.Drawing.Size(150, 33);
            this.comboBoxMode1.TabIndex = 10;
            this.comboBoxMode1.Text = "Aktywny";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label13.Location = new System.Drawing.Point(100, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(111, 25);
            this.label13.TabIndex = 9;
            this.label13.Text = "Tryb pracy:";
            // 
            // buttonAddProcesToList
            // 
            this.buttonAddProcesToList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonAddProcesToList.Location = new System.Drawing.Point(320, 470);
            this.buttonAddProcesToList.Name = "buttonAddProcesToList";
            this.buttonAddProcesToList.Size = new System.Drawing.Size(150, 50);
            this.buttonAddProcesToList.TabIndex = 8;
            this.buttonAddProcesToList.Text = "Dodaj";
            this.buttonAddProcesToList.UseVisualStyleBackColor = true;
            this.buttonAddProcesToList.Click += new System.EventHandler(this.buttonAddProcesToList_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(26, 483);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 25);
            this.label10.TabIndex = 7;
            this.label10.Text = "Podaj nazwe";
            // 
            // textBoxAddProcesToList
            // 
            this.textBoxAddProcesToList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxAddProcesToList.Location = new System.Drawing.Point(160, 473);
            this.textBoxAddProcesToList.Multiline = true;
            this.textBoxAddProcesToList.Name = "textBoxAddProcesToList";
            this.textBoxAddProcesToList.Size = new System.Drawing.Size(150, 44);
            this.textBoxAddProcesToList.TabIndex = 6;
            // 
            // buttonSendCommandProces
            // 
            this.buttonSendCommandProces.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSendCommandProces.Location = new System.Drawing.Point(1180, 470);
            this.buttonSendCommandProces.Name = "buttonSendCommandProces";
            this.buttonSendCommandProces.Size = new System.Drawing.Size(150, 50);
            this.buttonSendCommandProces.TabIndex = 4;
            this.buttonSendCommandProces.Text = "Wyślij";
            this.buttonSendCommandProces.UseVisualStyleBackColor = true;
            this.buttonSendCommandProces.Click += new System.EventHandler(this.buttonSendCommandProces_Click);
            // 
            // comboBoxChange1
            // 
            this.comboBoxChange1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxChange1.FormattingEnabled = true;
            this.comboBoxChange1.Items.AddRange(new object[] {
            "zabronione",
            "dostępne"});
            this.comboBoxChange1.Location = new System.Drawing.Point(900, 22);
            this.comboBoxChange1.Name = "comboBoxChange1";
            this.comboBoxChange1.Size = new System.Drawing.Size(150, 33);
            this.comboBoxChange1.TabIndex = 3;
            this.comboBoxChange1.Text = "zabronione";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(580, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(297, 25);
            this.label9.TabIndex = 2;
            this.label9.Text = "Wybierz jakie procesy mają być: ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.listBoxBannedPA);
            this.groupBox4.Controls.Add(this.listBoxBannedAK);
            this.groupBox4.Controls.Add(this.listBoxProcesses);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(22, 55);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1027, 405);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Lista Procesów";
            // 
            // listBoxBannedPA
            // 
            this.listBoxBannedPA.FormattingEnabled = true;
            this.listBoxBannedPA.ItemHeight = 25;
            this.listBoxBannedPA.Location = new System.Drawing.Point(710, 64);
            this.listBoxBannedPA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBoxBannedPA.Name = "listBoxBannedPA";
            this.listBoxBannedPA.Size = new System.Drawing.Size(280, 304);
            this.listBoxBannedPA.TabIndex = 11;
            // 
            // listBoxBannedAK
            // 
            this.listBoxBannedAK.FormattingEnabled = true;
            this.listBoxBannedAK.ItemHeight = 25;
            this.listBoxBannedAK.Location = new System.Drawing.Point(391, 64);
            this.listBoxBannedAK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBoxBannedAK.Name = "listBoxBannedAK";
            this.listBoxBannedAK.Size = new System.Drawing.Size(280, 304);
            this.listBoxBannedAK.TabIndex = 3;
            // 
            // listBoxProcesses
            // 
            this.listBoxProcesses.FormattingEnabled = true;
            this.listBoxProcesses.ItemHeight = 25;
            this.listBoxProcesses.Location = new System.Drawing.Point(41, 64);
            this.listBoxProcesses.Name = "listBoxProcesses";
            this.listBoxProcesses.Size = new System.Drawing.Size(280, 304);
            this.listBoxProcesses.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox2);
            this.groupBox3.Controls.Add(this.listBoxClient2);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox3.Location = new System.Drawing.Point(1066, 55);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(360, 405);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Klienci";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(80, 368);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(216, 29);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "Wyslij do wszystkich";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // listBoxClient2
            // 
            this.listBoxClient2.FormattingEnabled = true;
            this.listBoxClient2.ItemHeight = 25;
            this.listBoxClient2.Location = new System.Drawing.Point(16, 64);
            this.listBoxClient2.Name = "listBoxClient2";
            this.listBoxClient2.Size = new System.Drawing.Size(328, 304);
            this.listBoxClient2.TabIndex = 2;
            this.listBoxClient2.SelectedIndexChanged += new System.EventHandler(this.listBoxClient2_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1450, 580);
            this.tabControl1.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(1200, 606);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "IP Serwera:";
            // 
            // labelIPSerwera
            // 
            this.labelIPSerwera.AutoSize = true;
            this.labelIPSerwera.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelIPSerwera.Location = new System.Drawing.Point(1320, 605);
            this.labelIPSerwera.Name = "labelIPSerwera";
            this.labelIPSerwera.Size = new System.Drawing.Size(64, 25);
            this.labelIPSerwera.TabIndex = 12;
            this.labelIPSerwera.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(386, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Tryb aktywny";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(705, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Tryb pasywny";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 25);
            this.label4.TabIndex = 14;
            this.label4.Text = "Dostępne procesy";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1474, 640);
            this.Controls.Add(this.labelIPSerwera);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Serwer SNAK";
            this.tabPage4.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ListBox listBoxBanDomensPA;
        private System.Windows.Forms.ListBox listBoxBanProcessesPA;
        private System.Windows.Forms.ListBox listBoxBanDomensAK;
        private System.Windows.Forms.ListBox listBoxBanProcessesAK;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.ListBox listBoxClient4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.ListBox listBoxClient5;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button buttonAddDomenToList;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxAddDomenToList;
        private System.Windows.Forms.Button buttonSendCommandDomena;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.ListBox listBoxClient3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListBox listBoxBannedDomenaPA;
        private System.Windows.Forms.ListBox listBoxBannedDomenaAK;
        private System.Windows.Forms.ListBox listBoxDomens;
        private System.Windows.Forms.ComboBox comboBoxChange2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox comboBoxMode1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button buttonAddProcesToList;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxAddProcesToList;
        private System.Windows.Forms.Button buttonSendCommandProces;
        private System.Windows.Forms.ComboBox comboBoxChange1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox listBoxBannedPA;
        private System.Windows.Forms.ListBox listBoxBannedAK;
        private System.Windows.Forms.ListBox listBoxProcesses;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ListBox listBoxClient2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelIPSerwera;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}

