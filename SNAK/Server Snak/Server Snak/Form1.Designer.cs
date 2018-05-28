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
            this.buttonSend = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.listBoxClient1 = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.listBoxProces = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listBoxConsole = new System.Windows.Forms.ListBox();
            this.comboBoxChange = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxMode = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.listBoxDomena = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxNazwa = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxRodzaj = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labelTextIP = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.listBoxClient2 = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.listBoxClient3 = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.listBox5 = new System.Windows.Forms.ListBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.listBoxClient4 = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(9, 268);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(104, 43);
            this.buttonSend.TabIndex = 2;
            this.buttonSend.Text = "Wyślij";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.listBoxClient1);
            this.groupBox1.Location = new System.Drawing.Point(700, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 326);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Klienci";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 280);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(175, 24);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Wyslij do wszystkich";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // listBoxClient1
            // 
            this.listBoxClient1.FormattingEnabled = true;
            this.listBoxClient1.ItemHeight = 20;
            this.listBoxClient1.Location = new System.Drawing.Point(8, 26);
            this.listBoxClient1.Name = "listBoxClient1";
            this.listBoxClient1.Size = new System.Drawing.Size(254, 244);
            this.listBoxClient1.TabIndex = 0;
            this.listBoxClient1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(700, 357);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(261, 98);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Serwer";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(98, 65);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(158, 26);
            this.numericUpDown1.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(98, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(157, 26);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "127.0.0.1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Adres IP:";
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
            // listBoxProces
            // 
            this.listBoxProces.FormattingEnabled = true;
            this.listBoxProces.ItemHeight = 20;
            this.listBoxProces.Location = new System.Drawing.Point(182, 51);
            this.listBoxProces.Name = "listBoxProces";
            this.listBoxProces.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxProces.Size = new System.Drawing.Size(204, 244);
            this.listBoxProces.TabIndex = 7;
            this.listBoxProces.SelectedIndexChanged += new System.EventHandler(this.listBoxProces_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(177, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Zabronione procesy";
            // 
            // listBoxConsole
            // 
            this.listBoxConsole.FormattingEnabled = true;
            this.listBoxConsole.ItemHeight = 20;
            this.listBoxConsole.Location = new System.Drawing.Point(9, 320);
            this.listBoxConsole.Name = "listBoxConsole";
            this.listBoxConsole.Size = new System.Drawing.Size(662, 184);
            this.listBoxConsole.TabIndex = 9;
            // 
            // comboBoxChange
            // 
            this.comboBoxChange.FormattingEnabled = true;
            this.comboBoxChange.Items.AddRange(new object[] {
            "Usunięcie",
            "Dodanie"});
            this.comboBoxChange.Location = new System.Drawing.Point(9, 51);
            this.comboBoxChange.Name = "comboBoxChange";
            this.comboBoxChange.Size = new System.Drawing.Size(121, 28);
            this.comboBoxChange.TabIndex = 11;
            this.comboBoxChange.SelectedIndexChanged += new System.EventHandler(this.comboBoxChange_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Modyfikacje";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tryb pracy";
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
            this.comboBoxMode.Location = new System.Drawing.Point(9, 109);
            this.comboBoxMode.Name = "comboBoxMode";
            this.comboBoxMode.Size = new System.Drawing.Size(121, 28);
            this.comboBoxMode.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(435, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Zabronione domeny";
            // 
            // listBoxDomena
            // 
            this.listBoxDomena.FormattingEnabled = true;
            this.listBoxDomena.ItemHeight = 20;
            this.listBoxDomena.Location = new System.Drawing.Point(440, 51);
            this.listBoxDomena.Name = "listBoxDomena";
            this.listBoxDomena.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxDomena.Size = new System.Drawing.Size(204, 244);
            this.listBoxDomena.TabIndex = 13;
            this.listBoxDomena.SelectedIndexChanged += new System.EventHandler(this.listBoxDomena_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Nazwa";
            // 
            // textBoxNazwa
            // 
            this.textBoxNazwa.Location = new System.Drawing.Point(9, 228);
            this.textBoxNazwa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxNazwa.Name = "textBoxNazwa";
            this.textBoxNazwa.Size = new System.Drawing.Size(148, 26);
            this.textBoxNazwa.TabIndex = 15;
            this.textBoxNazwa.TextChanged += new System.EventHandler(this.textBoxNazwa_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Rodzaj";
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
            this.comboBoxRodzaj.Location = new System.Drawing.Point(9, 168);
            this.comboBoxRodzaj.Name = "comboBoxRodzaj";
            this.comboBoxRodzaj.Size = new System.Drawing.Size(121, 28);
            this.comboBoxRodzaj.TabIndex = 17;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(16, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(988, 542);
            this.tabControl1.TabIndex = 18;
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
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(980, 509);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Podsumowanie";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // labelTextIP
            // 
            this.labelTextIP.AutoSize = true;
            this.labelTextIP.Location = new System.Drawing.Point(704, 458);
            this.labelTextIP.Name = "labelTextIP";
            this.labelTextIP.Size = new System.Drawing.Size(143, 20);
            this.labelTextIP.TabIndex = 18;
            this.labelTextIP.Text = "Adres IP serwera - ";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(980, 509);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Wybierz procesy";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(174, 437);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 20);
            this.label10.TabIndex = 7;
            this.label10.Text = "Podaj nazwe";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(284, 432);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 26);
            this.textBox2.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(440, 466);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 37);
            this.button1.TabIndex = 4;
            this.button1.Text = "Wyślij";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "zabronione",
            "dostępne"});
            this.comboBox1.Location = new System.Drawing.Point(494, 18);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 28);
            this.comboBox1.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(226, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(234, 20);
            this.label9.TabIndex = 2;
            this.label9.Text = "Wybierz jakie procesy mają być: ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listBox3);
            this.groupBox4.Location = new System.Drawing.Point(22, 55);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(578, 351);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Lista Procesów";
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 20;
            this.listBox3.Items.AddRange(new object[] {
            "netbeans",
            "calculator",
            "firefox",
            "cmd",
            "chrome",
            "VSHub"});
            this.listBox3.Location = new System.Drawing.Point(26, 28);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(523, 284);
            this.listBox3.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox2);
            this.groupBox3.Controls.Add(this.listBoxClient2);
            this.groupBox3.Location = new System.Drawing.Point(626, 55);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(322, 351);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Klienci";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(34, 318);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(175, 24);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "Wyslij do wszystkich";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // listBoxClient2
            // 
            this.listBoxClient2.FormattingEnabled = true;
            this.listBoxClient2.ItemHeight = 20;
            this.listBoxClient2.Location = new System.Drawing.Point(22, 28);
            this.listBoxClient2.Name = "listBoxClient2";
            this.listBoxClient2.Size = new System.Drawing.Size(278, 284);
            this.listBoxClient2.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.textBox3);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Controls.Add(this.comboBox2);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(980, 509);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Wybierz domeny";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(292, 432);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 20);
            this.label12.TabIndex = 6;
            this.label12.Text = "Z poza listy";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(386, 425);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 26);
            this.textBox3.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(748, 458);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 35);
            this.button2.TabIndex = 4;
            this.button2.Text = "Wyślij";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.checkBox3);
            this.groupBox6.Controls.Add(this.listBoxClient3);
            this.groupBox6.Location = new System.Drawing.Point(630, 63);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(326, 338);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Klienci";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(18, 305);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(175, 24);
            this.checkBox3.TabIndex = 1;
            this.checkBox3.Text = "Wyślij do wszystkich";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // listBoxClient3
            // 
            this.listBoxClient3.FormattingEnabled = true;
            this.listBoxClient3.ItemHeight = 20;
            this.listBoxClient3.Location = new System.Drawing.Point(18, 34);
            this.listBoxClient3.Name = "listBoxClient3";
            this.listBoxClient3.Size = new System.Drawing.Size(294, 264);
            this.listBoxClient3.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.listBox5);
            this.groupBox5.Location = new System.Drawing.Point(21, 63);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(588, 338);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Lista domen";
            // 
            // listBox5
            // 
            this.listBox5.FormattingEnabled = true;
            this.listBox5.ItemHeight = 20;
            this.listBox5.Location = new System.Drawing.Point(20, 54);
            this.listBox5.Name = "listBox5";
            this.listBox5.Size = new System.Drawing.Size(518, 244);
            this.listBox5.TabIndex = 0;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "zabronione",
            "dostępne"});
            this.comboBox2.Location = new System.Drawing.Point(496, 15);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 28);
            this.comboBox2.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(256, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(235, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "Wybierz jakie domeny mają być: ";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox8);
            this.tabPage4.Controls.Add(this.groupBox7);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(980, 509);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Szczegóły klientów";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Location = new System.Drawing.Point(24, 40);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(626, 338);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "O kliencie";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.listBoxClient4);
            this.groupBox7.Location = new System.Drawing.Point(688, 40);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(267, 338);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Klienci";
            // 
            // listBoxClient4
            // 
            this.listBoxClient4.FormattingEnabled = true;
            this.listBoxClient4.ItemHeight = 20;
            this.listBoxClient4.Location = new System.Drawing.Point(6, 25);
            this.listBoxClient4.Name = "listBoxClient4";
            this.listBoxClient4.Size = new System.Drawing.Size(254, 284);
            this.listBoxClient4.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 563);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Serwer SNAK";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBoxClient1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.ListBox listBoxProces;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBoxConsole;
        private System.Windows.Forms.ComboBox comboBoxChange;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxMode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBoxDomena;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxNazwa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxRodzaj;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ListBox listBoxClient2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.ListBox listBoxClient3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListBox listBox5;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ListBox listBoxClient4;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label labelTextIP;
        private System.Windows.Forms.Label label10;
    }
}

