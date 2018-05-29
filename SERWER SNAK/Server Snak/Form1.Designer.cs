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
            this.listBoxBanDomens = new System.Windows.Forms.ListBox();
            this.listBoxBanProcesses = new System.Windows.Forms.ListBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.listBoxClient4 = new System.Windows.Forms.ListBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.listBoxClient5 = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonAddDomenToList = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxAddDomenToList = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.listBoxClient3 = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.listBoxDomens = new System.Windows.Forms.ListBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labelTextIP = new System.Windows.Forms.Label();
            this.listBoxProces = new System.Windows.Forms.ListBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.comboBoxRodzaj = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.listBoxClient1 = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNazwa = new System.Windows.Forms.TextBox();
            this.comboBoxMode = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxDomena = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listBoxConsole = new System.Windows.Forms.ListBox();
            this.comboBoxChange = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
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
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(833, 326);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Szczegóły klientów";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.listBoxBanDomens);
            this.groupBox8.Controls.Add(this.listBoxBanProcesses);
            this.groupBox8.Location = new System.Drawing.Point(16, 26);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox8.Size = new System.Drawing.Size(417, 297);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "O kliencie";
            // 
            // listBoxBanDomens
            // 
            this.listBoxBanDomens.FormattingEnabled = true;
            this.listBoxBanDomens.Location = new System.Drawing.Point(197, 28);
            this.listBoxBanDomens.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxBanDomens.Name = "listBoxBanDomens";
            this.listBoxBanDomens.Size = new System.Drawing.Size(208, 121);
            this.listBoxBanDomens.TabIndex = 1;
            // 
            // listBoxBanProcesses
            // 
            this.listBoxBanProcesses.FormattingEnabled = true;
            this.listBoxBanProcesses.Location = new System.Drawing.Point(13, 28);
            this.listBoxBanProcesses.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxBanProcesses.Name = "listBoxBanProcesses";
            this.listBoxBanProcesses.Size = new System.Drawing.Size(173, 121);
            this.listBoxBanProcesses.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.listBoxClient4);
            this.groupBox7.Location = new System.Drawing.Point(459, 26);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox7.Size = new System.Drawing.Size(178, 220);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Klienci";
            // 
            // listBoxClient4
            // 
            this.listBoxClient4.FormattingEnabled = true;
            this.listBoxClient4.Location = new System.Drawing.Point(4, 16);
            this.listBoxClient4.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxClient4.Name = "listBoxClient4";
            this.listBoxClient4.Size = new System.Drawing.Size(171, 186);
            this.listBoxClient4.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.groupBox10);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage5.Size = new System.Drawing.Size(833, 326);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Dyski";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.listBoxClient5);
            this.groupBox10.Location = new System.Drawing.Point(503, 16);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox10.Size = new System.Drawing.Size(133, 227);
            this.groupBox10.TabIndex = 0;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Klienci";
            // 
            // listBoxClient5
            // 
            this.listBoxClient5.FormattingEnabled = true;
            this.listBoxClient5.Location = new System.Drawing.Point(5, 17);
            this.listBoxClient5.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxClient5.Name = "listBoxClient5";
            this.listBoxClient5.Size = new System.Drawing.Size(126, 199);
            this.listBoxClient5.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.buttonAddDomenToList);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.textBoxAddDomenToList);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Controls.Add(this.comboBox2);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(833, 326);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Wybierz domeny";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // buttonAddDomenToList
            // 
            this.buttonAddDomenToList.Location = new System.Drawing.Point(217, 276);
            this.buttonAddDomenToList.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddDomenToList.Name = "buttonAddDomenToList";
            this.buttonAddDomenToList.Size = new System.Drawing.Size(54, 20);
            this.buttonAddDomenToList.TabIndex = 7;
            this.buttonAddDomenToList.Text = "Dodaj";
            this.buttonAddDomenToList.UseVisualStyleBackColor = true;
            this.buttonAddDomenToList.Click += new System.EventHandler(this.buttonAddDomenToList_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(65, 280);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Podaj nazwe";
            // 
            // textBoxAddDomenToList
            // 
            this.textBoxAddDomenToList.Location = new System.Drawing.Point(135, 276);
            this.textBoxAddDomenToList.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxAddDomenToList.Name = "textBoxAddDomenToList";
            this.textBoxAddDomenToList.Size = new System.Drawing.Size(68, 20);
            this.textBoxAddDomenToList.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(499, 298);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Wyślij";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.checkBox3);
            this.groupBox6.Controls.Add(this.listBoxClient3);
            this.groupBox6.Location = new System.Drawing.Point(420, 41);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox6.Size = new System.Drawing.Size(217, 220);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Klienci";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(12, 198);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(122, 17);
            this.checkBox3.TabIndex = 1;
            this.checkBox3.Text = "Wyślij do wszystkich";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // listBoxClient3
            // 
            this.listBoxClient3.FormattingEnabled = true;
            this.listBoxClient3.Location = new System.Drawing.Point(12, 22);
            this.listBoxClient3.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxClient3.Name = "listBoxClient3";
            this.listBoxClient3.Size = new System.Drawing.Size(197, 173);
            this.listBoxClient3.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.listBoxDomens);
            this.groupBox5.Location = new System.Drawing.Point(14, 41);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(392, 220);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Lista domen";
            // 
            // listBoxDomens
            // 
            this.listBoxDomens.FormattingEnabled = true;
            this.listBoxDomens.Location = new System.Drawing.Point(13, 35);
            this.listBoxDomens.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxDomens.Name = "listBoxDomens";
            this.listBoxDomens.Size = new System.Drawing.Size(347, 160);
            this.listBoxDomens.TabIndex = 0;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "zabronione",
            "dostępne"});
            this.comboBox2.Location = new System.Drawing.Point(331, 10);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(82, 21);
            this.comboBox2.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(171, 12);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(161, 13);
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
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(833, 326);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Wybierz procesy";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // comboBoxMode1
            // 
            this.comboBoxMode1.FormattingEnabled = true;
            this.comboBoxMode1.Items.AddRange(new object[] {
            "Aktywny",
            "Pasywny"});
            this.comboBoxMode1.Location = new System.Drawing.Point(93, 14);
            this.comboBoxMode1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxMode1.Name = "comboBoxMode1";
            this.comboBoxMode1.Size = new System.Drawing.Size(82, 21);
            this.comboBoxMode1.TabIndex = 10;
            this.comboBoxMode1.Text = "Aktywny";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(33, 16);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 13);
            this.label13.TabIndex = 9;
            this.label13.Text = "Tryb pracy:";
            // 
            // buttonAddProcesToList
            // 
            this.buttonAddProcesToList.Location = new System.Drawing.Point(193, 282);
            this.buttonAddProcesToList.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddProcesToList.Name = "buttonAddProcesToList";
            this.buttonAddProcesToList.Size = new System.Drawing.Size(50, 23);
            this.buttonAddProcesToList.TabIndex = 8;
            this.buttonAddProcesToList.Text = "Dodaj";
            this.buttonAddProcesToList.UseVisualStyleBackColor = true;
            this.buttonAddProcesToList.Click += new System.EventHandler(this.buttonAddProcesToList_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(37, 285);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Podaj nazwe";
            // 
            // textBoxAddProcesToList
            // 
            this.textBoxAddProcesToList.Location = new System.Drawing.Point(108, 285);
            this.textBoxAddProcesToList.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxAddProcesToList.Name = "textBoxAddProcesToList";
            this.textBoxAddProcesToList.Size = new System.Drawing.Size(68, 20);
            this.textBoxAddProcesToList.TabIndex = 6;
            // 
            // buttonSendCommandProces
            // 
            this.buttonSendCommandProces.Location = new System.Drawing.Point(302, 298);
            this.buttonSendCommandProces.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSendCommandProces.Name = "buttonSendCommandProces";
            this.buttonSendCommandProces.Size = new System.Drawing.Size(73, 24);
            this.buttonSendCommandProces.TabIndex = 4;
            this.buttonSendCommandProces.Text = "Wyślij";
            this.buttonSendCommandProces.UseVisualStyleBackColor = true;
            this.buttonSendCommandProces.Click += new System.EventHandler(this.buttonSendCommandProces_Click);
            // 
            // comboBoxChange1
            // 
            this.comboBoxChange1.FormattingEnabled = true;
            this.comboBoxChange1.Items.AddRange(new object[] {
            "zabronione",
            "dostępne"});
            this.comboBoxChange1.Location = new System.Drawing.Point(414, 14);
            this.comboBoxChange1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxChange1.Name = "comboBoxChange1";
            this.comboBoxChange1.Size = new System.Drawing.Size(82, 21);
            this.comboBoxChange1.TabIndex = 3;
            this.comboBoxChange1.Text = "zabronione";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(254, 16);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(161, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Wybierz jakie procesy mają być: ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listBoxBannedPA);
            this.groupBox4.Controls.Add(this.listBoxBannedAK);
            this.groupBox4.Controls.Add(this.listBoxProcesses);
            this.groupBox4.Location = new System.Drawing.Point(15, 36);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(557, 228);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Lista Procesów";
            // 
            // listBoxBannedPA
            // 
            this.listBoxBannedPA.FormattingEnabled = true;
            this.listBoxBannedPA.Location = new System.Drawing.Point(383, 17);
            this.listBoxBannedPA.Name = "listBoxBannedPA";
            this.listBoxBannedPA.Size = new System.Drawing.Size(120, 186);
            this.listBoxBannedPA.TabIndex = 11;
            // 
            // listBoxBannedAK
            // 
            this.listBoxBannedAK.FormattingEnabled = true;
            this.listBoxBannedAK.Location = new System.Drawing.Point(207, 18);
            this.listBoxBannedAK.Name = "listBoxBannedAK";
            this.listBoxBannedAK.Size = new System.Drawing.Size(121, 186);
            this.listBoxBannedAK.TabIndex = 3;
            // 
            // listBoxProcesses
            // 
            this.listBoxProcesses.FormattingEnabled = true;
            this.listBoxProcesses.Location = new System.Drawing.Point(17, 18);
            this.listBoxProcesses.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxProcesses.Name = "listBoxProcesses";
            this.listBoxProcesses.Size = new System.Drawing.Size(144, 186);
            this.listBoxProcesses.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox2);
            this.groupBox3.Controls.Add(this.listBoxClient2);
            this.groupBox3.Location = new System.Drawing.Point(576, 36);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(239, 228);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Klienci";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(23, 207);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(122, 17);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "Wyslij do wszystkich";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // listBoxClient2
            // 
            this.listBoxClient2.FormattingEnabled = true;
            this.listBoxClient2.Location = new System.Drawing.Point(13, 17);
            this.listBoxClient2.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxClient2.Name = "listBoxClient2";
            this.listBoxClient2.Size = new System.Drawing.Size(187, 186);
            this.listBoxClient2.TabIndex = 2;
            this.listBoxClient2.SelectedIndexChanged += new System.EventHandler(this.listBoxClient2_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.labelTextIP);
            this.tabPage1.Controls.Add(this.listBoxProces);
            this.tabPage1.Controls.Add(this.buttonSend);
            this.tabPage1.Controls.Add(this.comboBoxRodzaj);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.textBoxNazwa);
            this.tabPage1.Controls.Add(this.comboBoxMode);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.listBoxDomena);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.listBoxConsole);
            this.tabPage1.Controls.Add(this.comboBoxChange);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(833, 326);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Podsumowanie";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // labelTextIP
            // 
            this.labelTextIP.AutoSize = true;
            this.labelTextIP.Location = new System.Drawing.Point(469, 298);
            this.labelTextIP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTextIP.Name = "labelTextIP";
            this.labelTextIP.Size = new System.Drawing.Size(96, 13);
            this.labelTextIP.TabIndex = 18;
            this.labelTextIP.Text = "Adres IP serwera - ";
            // 
            // listBoxProces
            // 
            this.listBoxProces.FormattingEnabled = true;
            this.listBoxProces.Location = new System.Drawing.Point(121, 33);
            this.listBoxProces.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxProces.Name = "listBoxProces";
            this.listBoxProces.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxProces.Size = new System.Drawing.Size(137, 160);
            this.listBoxProces.TabIndex = 7;
            this.listBoxProces.SelectedIndexChanged += new System.EventHandler(this.listBoxProces_SelectedIndexChanged);
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(6, 174);
            this.buttonSend.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(69, 28);
            this.buttonSend.TabIndex = 2;
            this.buttonSend.Text = "Wyślij";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // comboBoxRodzaj
            // 
            this.comboBoxRodzaj.AutoCompleteCustomSource.AddRange(new string[] {
            "Aktywny",
            "Pasywny"});
            this.comboBoxRodzaj.FormattingEnabled = true;
            this.comboBoxRodzaj.Items.AddRange(new object[] {
            "Proces",
            "Domena"});
            this.comboBoxRodzaj.Location = new System.Drawing.Point(6, 109);
            this.comboBoxRodzaj.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxRodzaj.Name = "comboBoxRodzaj";
            this.comboBoxRodzaj.Size = new System.Drawing.Size(82, 21);
            this.comboBoxRodzaj.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.listBoxClient1);
            this.groupBox1.Location = new System.Drawing.Point(467, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(178, 212);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Klienci";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(8, 182);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(122, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Wyslij do wszystkich";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // listBoxClient1
            // 
            this.listBoxClient1.FormattingEnabled = true;
            this.listBoxClient1.Location = new System.Drawing.Point(5, 17);
            this.listBoxClient1.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxClient1.Name = "listBoxClient1";
            this.listBoxClient1.Size = new System.Drawing.Size(171, 160);
            this.listBoxClient1.TabIndex = 0;
            this.listBoxClient1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 94);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Rodzaj";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(467, 232);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(174, 64);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Serwer";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(65, 42);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(105, 20);
            this.numericUpDown1.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(65, 17);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(106, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "127.0.0.1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 44);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Adres IP:";
            // 
            // textBoxNazwa
            // 
            this.textBoxNazwa.Location = new System.Drawing.Point(6, 148);
            this.textBoxNazwa.Name = "textBoxNazwa";
            this.textBoxNazwa.Size = new System.Drawing.Size(100, 20);
            this.textBoxNazwa.TabIndex = 15;
            this.textBoxNazwa.TextChanged += new System.EventHandler(this.textBoxNazwa_TextChanged);
            // 
            // comboBoxMode
            // 
            this.comboBoxMode.AutoCompleteCustomSource.AddRange(new string[] {
            "Aktywny",
            "Pasywny"});
            this.comboBoxMode.FormattingEnabled = true;
            this.comboBoxMode.Items.AddRange(new object[] {
            "Aktywny",
            "Pasywny"});
            this.comboBoxMode.Location = new System.Drawing.Point(6, 71);
            this.comboBoxMode.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxMode.Name = "comboBoxMode";
            this.comboBoxMode.Size = new System.Drawing.Size(82, 21);
            this.comboBoxMode.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 133);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Nazwa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tryb pracy";
            // 
            // listBoxDomena
            // 
            this.listBoxDomena.FormattingEnabled = true;
            this.listBoxDomena.Location = new System.Drawing.Point(293, 33);
            this.listBoxDomena.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxDomena.Name = "listBoxDomena";
            this.listBoxDomena.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxDomena.Size = new System.Drawing.Size(137, 160);
            this.listBoxDomena.TabIndex = 13;
            this.listBoxDomena.SelectedIndexChanged += new System.EventHandler(this.listBoxDomena_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(118, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Zabronione procesy";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(290, 18);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Zabronione domeny";
            // 
            // listBoxConsole
            // 
            this.listBoxConsole.FormattingEnabled = true;
            this.listBoxConsole.Location = new System.Drawing.Point(6, 208);
            this.listBoxConsole.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxConsole.Name = "listBoxConsole";
            this.listBoxConsole.Size = new System.Drawing.Size(443, 121);
            this.listBoxConsole.TabIndex = 9;
            // 
            // comboBoxChange
            // 
            this.comboBoxChange.FormattingEnabled = true;
            this.comboBoxChange.Items.AddRange(new object[] {
            "Usunięcie",
            "Dodanie"});
            this.comboBoxChange.Location = new System.Drawing.Point(6, 33);
            this.comboBoxChange.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxChange.Name = "comboBoxChange";
            this.comboBoxChange.Size = new System.Drawing.Size(82, 21);
            this.comboBoxChange.TabIndex = 11;
            this.comboBoxChange.SelectedIndexChanged += new System.EventHandler(this.comboBoxChange_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 18);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Modyfikacje";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(11, 8);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(841, 352);
            this.tabControl1.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 366);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Serwer SNAK";
            this.tabPage4.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
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
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ListBox listBoxBanDomens;
        private System.Windows.Forms.ListBox listBoxBanProcesses;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ListBox listBoxClient4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.ListBox listBoxClient5;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button buttonAddDomenToList;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxAddDomenToList;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.ListBox listBoxClient3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListBox listBoxDomens;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonAddProcesToList;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxAddProcesToList;
        private System.Windows.Forms.Button buttonSendCommandProces;
        private System.Windows.Forms.ComboBox comboBoxChange1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox listBoxProcesses;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ListBox listBoxClient2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label labelTextIP;
        private System.Windows.Forms.ListBox listBoxProces;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.ComboBox comboBoxRodzaj;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ListBox listBoxClient1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNazwa;
        private System.Windows.Forms.ComboBox comboBoxMode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxDomena;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBoxConsole;
        private System.Windows.Forms.ComboBox comboBoxChange;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ComboBox comboBoxMode1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListBox listBoxBannedAK;
        private System.Windows.Forms.ListBox listBoxBannedPA;
    }
}

