﻿namespace juegoDeLaVida
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            random = new Button();
            iniciar = new Button();
            pausa = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            colorDialog1 = new ColorDialog();
            colorButton = new Button();
            hScrollBar1 = new HScrollBar();
            porcentajeLbl = new Label();
            fondoButton = new Button();
            hScrollBar2 = new HScrollBar();
            velLbl = new Label();
            Nmax = new ComboBox();
            label1 = new Label();
            lblSmin = new Label();
            Smin = new ComboBox();
            lblSmax = new Label();
            Smax = new ComboBox();
            lblNmin = new Label();
            Nmin = new ComboBox();
            limpiarBtn = new Button();
            graphBtn = new Button();
            label2 = new Label();
            hScrollBar3 = new HScrollBar();
            label3 = new Label();
            label4 = new Label();
            bTxtbx = new TextBox();
            label5 = new Label();
            sTxtbx = new TextBox();
            ntacionIni = new Button();
            label6 = new Label();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            atractComboBox = new ComboBox();
            timer2 = new System.Windows.Forms.Timer(components);
            label7 = new Label();
            guardarImg = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // random
            // 
            random.Location = new Point(1023, 67);
            random.Name = "random";
            random.Size = new Size(75, 23);
            random.TabIndex = 1;
            random.Text = "Random";
            random.UseVisualStyleBackColor = true;
            random.Click += random_Click;
            // 
            // iniciar
            // 
            iniciar.Location = new Point(1023, 9);
            iniciar.Name = "iniciar";
            iniciar.Size = new Size(75, 23);
            iniciar.TabIndex = 2;
            iniciar.Text = "Iniciar";
            iniciar.UseVisualStyleBackColor = true;
            iniciar.Click += iniciar_Click;
            // 
            // pausa
            // 
            pausa.Location = new Point(1023, 38);
            pausa.Name = "pausa";
            pausa.Size = new Size(75, 23);
            pausa.TabIndex = 3;
            pausa.Text = "Pausa";
            pausa.UseVisualStyleBackColor = true;
            pausa.Click += pausa_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // colorButton
            // 
            colorButton.Location = new Point(1023, 96);
            colorButton.Name = "colorButton";
            colorButton.Size = new Size(75, 23);
            colorButton.TabIndex = 4;
            colorButton.Text = "Color";
            colorButton.UseVisualStyleBackColor = true;
            colorButton.Click += colorButton_Click;
            // 
            // hScrollBar1
            // 
            hScrollBar1.Location = new Point(1113, 95);
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new Size(88, 24);
            hScrollBar1.TabIndex = 5;
            hScrollBar1.Scroll += hScrollBar1_Scroll;
            // 
            // porcentajeLbl
            // 
            porcentajeLbl.AutoSize = true;
            porcentajeLbl.Location = new Point(1113, 67);
            porcentajeLbl.Name = "porcentajeLbl";
            porcentajeLbl.Size = new Size(88, 15);
            porcentajeLbl.TabIndex = 6;
            porcentajeLbl.Text = "Porcentaje 50%";
            // 
            // fondoButton
            // 
            fondoButton.Location = new Point(1023, 125);
            fondoButton.Name = "fondoButton";
            fondoButton.Size = new Size(75, 23);
            fondoButton.TabIndex = 7;
            fondoButton.Text = "Fondo";
            fondoButton.UseVisualStyleBackColor = true;
            fondoButton.Click += fondoButton_Click;
            // 
            // hScrollBar2
            // 
            hScrollBar2.Location = new Point(1120, 38);
            hScrollBar2.Name = "hScrollBar2";
            hScrollBar2.Size = new Size(80, 23);
            hScrollBar2.TabIndex = 8;
            hScrollBar2.Scroll += hScrollBar2_Scroll;
            // 
            // velLbl
            // 
            velLbl.AutoSize = true;
            velLbl.Location = new Point(1104, 13);
            velLbl.Name = "velLbl";
            velLbl.Size = new Size(97, 15);
            velLbl.TabIndex = 9;
            velLbl.Text = "Velocidad t = 100";
            // 
            // Nmax
            // 
            Nmax.FormattingEnabled = true;
            Nmax.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8" });
            Nmax.Location = new Point(1023, 331);
            Nmax.Name = "Nmax";
            Nmax.Size = new Size(177, 23);
            Nmax.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1023, 313);
            label1.Name = "label1";
            label1.Size = new Size(184, 15);
            label1.TabIndex = 11;
            label1.Text = "Ingrese Nmax (Nacimientos Max)";
            // 
            // lblSmin
            // 
            lblSmin.AutoSize = true;
            lblSmin.Location = new Point(1020, 151);
            lblSmin.Name = "lblSmin";
            lblSmin.Size = new Size(183, 15);
            lblSmin.TabIndex = 12;
            lblSmin.Text = "Ingrese Smin (Supervivencia min)";
            // 
            // Smin
            // 
            Smin.FormattingEnabled = true;
            Smin.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8" });
            Smin.Location = new Point(1027, 169);
            Smin.Name = "Smin";
            Smin.Size = new Size(174, 23);
            Smin.TabIndex = 13;
            // 
            // lblSmax
            // 
            lblSmax.AutoSize = true;
            lblSmax.Location = new Point(1020, 204);
            lblSmax.Name = "lblSmax";
            lblSmax.Size = new Size(187, 15);
            lblSmax.TabIndex = 14;
            lblSmax.Text = "Ingrese Smax (Supervivencia max)";
            // 
            // Smax
            // 
            Smax.FormattingEnabled = true;
            Smax.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8" });
            Smax.Location = new Point(1027, 222);
            Smax.Name = "Smax";
            Smax.Size = new Size(173, 23);
            Smax.TabIndex = 15;
            // 
            // lblNmin
            // 
            lblNmin.AutoSize = true;
            lblNmin.Location = new Point(1020, 258);
            lblNmin.Name = "lblNmin";
            lblNmin.Size = new Size(175, 15);
            lblNmin.TabIndex = 16;
            lblNmin.Text = "Ingrese Nmin (Nacimiento min)";
            // 
            // Nmin
            // 
            Nmin.FormattingEnabled = true;
            Nmin.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8" });
            Nmin.Location = new Point(1027, 276);
            Nmin.Name = "Nmin";
            Nmin.Size = new Size(174, 23);
            Nmin.TabIndex = 17;
            // 
            // limpiarBtn
            // 
            limpiarBtn.Location = new Point(1113, 125);
            limpiarBtn.Name = "limpiarBtn";
            limpiarBtn.Size = new Size(87, 23);
            limpiarBtn.TabIndex = 18;
            limpiarBtn.Text = "Limpiar";
            limpiarBtn.UseVisualStyleBackColor = true;
            limpiarBtn.Click += limpiarBtn_Click;
            // 
            // graphBtn
            // 
            graphBtn.Location = new Point(1077, 360);
            graphBtn.Name = "graphBtn";
            graphBtn.Size = new Size(75, 23);
            graphBtn.TabIndex = 21;
            graphBtn.Text = "Graficas";
            graphBtn.UseVisualStyleBackColor = true;
            graphBtn.Click += graphBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1069, 425);
            label2.Name = "label2";
            label2.Size = new Size(99, 15);
            label2.TabIndex = 23;
            label2.Text = "Escala: 1000x1000";
            // 
            // hScrollBar3
            // 
            hScrollBar3.Location = new Point(1028, 440);
            hScrollBar3.Name = "hScrollBar3";
            hScrollBar3.Size = new Size(173, 21);
            hScrollBar3.TabIndex = 24;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1069, 480);
            label3.Name = "label3";
            label3.Size = new Size(83, 15);
            label3.TabIndex = 25;
            label3.Text = "Notación B/S: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1028, 518);
            label4.Name = "label4";
            label4.Size = new Size(14, 15);
            label4.TabIndex = 26;
            label4.Text = "B";
            // 
            // bTxtbx
            // 
            bTxtbx.Location = new Point(1039, 515);
            bTxtbx.Name = "bTxtbx";
            bTxtbx.Size = new Size(59, 23);
            bTxtbx.TabIndex = 27;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1104, 518);
            label5.Name = "label5";
            label5.Size = new Size(18, 15);
            label5.TabIndex = 28;
            label5.Text = "/S";
            // 
            // sTxtbx
            // 
            sTxtbx.Location = new Point(1120, 515);
            sTxtbx.Name = "sTxtbx";
            sTxtbx.Size = new Size(75, 23);
            sTxtbx.TabIndex = 29;
            // 
            // ntacionIni
            // 
            ntacionIni.Location = new Point(1069, 554);
            ntacionIni.Name = "ntacionIni";
            ntacionIni.Size = new Size(97, 23);
            ntacionIni.TabIndex = 30;
            ntacionIni.Text = "Iniciar B3/S23";
            ntacionIni.UseVisualStyleBackColor = true;
            ntacionIni.Click += ntacionIni_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1054, 686);
            label6.Name = "label6";
            label6.Size = new Size(0, 15);
            label6.TabIndex = 31;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(12, 9);
            panel1.Name = "panel1";
            panel1.Size = new Size(1001, 1001);
            panel1.TabIndex = 32;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1000, 1000);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.LoadCompleted += pictureBox1_LoadCompleted;
            pictureBox1.MouseDown += pictureBox1_MouseDown_1;
            pictureBox1.MouseMove += pictureBox1_MouseMove_1;
            pictureBox1.MouseUp += pictureBox1_MouseUp_1;
            // 
            // button1
            // 
            button1.Location = new Point(1069, 647);
            button1.Name = "button1";
            button1.Size = new Size(84, 23);
            button1.TabIndex = 33;
            button1.Text = "Calcular";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // atractComboBox
            // 
            atractComboBox.FormattingEnabled = true;
            atractComboBox.Items.AddRange(new object[] { "2", "3", "4", "5" });
            atractComboBox.Location = new Point(1039, 618);
            atractComboBox.Name = "atractComboBox";
            atractComboBox.Size = new Size(151, 23);
            atractComboBox.TabIndex = 34;
            // 
            // timer2
            // 
            timer2.Interval = 1;
            timer2.Tick += timer2_Tick;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1039, 600);
            label7.Name = "label7";
            label7.Size = new Size(142, 15);
            label7.TabIndex = 35;
            label7.Text = "Calcular atractores de 2x2";
            // 
            // guardarImg
            // 
            guardarImg.Location = new Point(1078, 389);
            guardarImg.Name = "guardarImg";
            guardarImg.Size = new Size(75, 23);
            guardarImg.TabIndex = 36;
            guardarImg.Text = "Guardar Imagen";
            guardarImg.UseVisualStyleBackColor = true;
            guardarImg.Click += guardarImg_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1208, 1061);
            Controls.Add(guardarImg);
            Controls.Add(label7);
            Controls.Add(atractComboBox);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(label6);
            Controls.Add(ntacionIni);
            Controls.Add(sTxtbx);
            Controls.Add(label5);
            Controls.Add(bTxtbx);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(hScrollBar3);
            Controls.Add(label2);
            Controls.Add(graphBtn);
            Controls.Add(limpiarBtn);
            Controls.Add(Nmin);
            Controls.Add(lblNmin);
            Controls.Add(Smax);
            Controls.Add(lblSmax);
            Controls.Add(Smin);
            Controls.Add(lblSmin);
            Controls.Add(label1);
            Controls.Add(Nmax);
            Controls.Add(velLbl);
            Controls.Add(hScrollBar2);
            Controls.Add(fondoButton);
            Controls.Add(porcentajeLbl);
            Controls.Add(hScrollBar1);
            Controls.Add(colorButton);
            Controls.Add(pausa);
            Controls.Add(iniciar);
            Controls.Add(random);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            KeyPress += Form1_KeyPress;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button random;
        private Button iniciar;
        private Button pausa;
        private System.Windows.Forms.Timer timer1;
        private ColorDialog colorDialog1;
        private Button colorButton;
        private HScrollBar hScrollBar1;
        private Label porcentajeLbl;
        private Button fondoButton;
        private HScrollBar hScrollBar2;
        private Label velLbl;
        private ComboBox Nmax;
        private Label label1;
        private Label lblSmin;
        private ComboBox Smin;
        private Label lblSmax;
        private ComboBox Smax;
        private Label lblNmin;
        private ComboBox Nmin;
        private Button limpiarBtn;
        private Button graphBtn;
        private Label label2;
        private HScrollBar hScrollBar3;
        private Label label3;
        private Label label4;
        private TextBox bTxtbx;
        private Label label5;
        private TextBox sTxtbx;
        private Button ntacionIni;
        private Label label6;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Button button1;
        private ComboBox atractComboBox;
        private System.Windows.Forms.Timer timer2;
        private Label label7;
        private Button guardarImg;
    }
}