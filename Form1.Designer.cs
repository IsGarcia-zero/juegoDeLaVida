namespace juegoDeLaVida
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
            pictureBox1 = new PictureBox();
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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(800, 800);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // random
            // 
            random.Location = new Point(818, 70);
            random.Name = "random";
            random.Size = new Size(75, 23);
            random.TabIndex = 1;
            random.Text = "Random";
            random.UseVisualStyleBackColor = true;
            random.Click += random_Click;
            // 
            // iniciar
            // 
            iniciar.Location = new Point(818, 12);
            iniciar.Name = "iniciar";
            iniciar.Size = new Size(75, 23);
            iniciar.TabIndex = 2;
            iniciar.Text = "Iniciar";
            iniciar.UseVisualStyleBackColor = true;
            iniciar.Click += iniciar_Click;
            // 
            // pausa
            // 
            pausa.Location = new Point(818, 41);
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
            colorButton.Location = new Point(818, 99);
            colorButton.Name = "colorButton";
            colorButton.Size = new Size(75, 23);
            colorButton.TabIndex = 4;
            colorButton.Text = "Color";
            colorButton.UseVisualStyleBackColor = true;
            colorButton.Click += colorButton_Click;
            // 
            // hScrollBar1
            // 
            hScrollBar1.Location = new Point(908, 98);
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new Size(88, 24);
            hScrollBar1.TabIndex = 5;
            hScrollBar1.Scroll += hScrollBar1_Scroll;
            // 
            // porcentajeLbl
            // 
            porcentajeLbl.AutoSize = true;
            porcentajeLbl.Location = new Point(908, 70);
            porcentajeLbl.Name = "porcentajeLbl";
            porcentajeLbl.Size = new Size(88, 15);
            porcentajeLbl.TabIndex = 6;
            porcentajeLbl.Text = "Porcentaje 50%";
            // 
            // fondoButton
            // 
            fondoButton.Location = new Point(818, 128);
            fondoButton.Name = "fondoButton";
            fondoButton.Size = new Size(75, 23);
            fondoButton.TabIndex = 7;
            fondoButton.Text = "Fondo";
            fondoButton.UseVisualStyleBackColor = true;
            fondoButton.Click += fondoButton_Click;
            // 
            // hScrollBar2
            // 
            hScrollBar2.Location = new Point(915, 41);
            hScrollBar2.Name = "hScrollBar2";
            hScrollBar2.Size = new Size(80, 23);
            hScrollBar2.TabIndex = 8;
            hScrollBar2.Scroll += hScrollBar2_Scroll;
            // 
            // velLbl
            // 
            velLbl.AutoSize = true;
            velLbl.Location = new Point(899, 16);
            velLbl.Name = "velLbl";
            velLbl.Size = new Size(97, 15);
            velLbl.TabIndex = 9;
            velLbl.Text = "Velocidad t = 100";
            // 
            // Nmax
            // 
            Nmax.FormattingEnabled = true;
            Nmax.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8" });
            Nmax.Location = new Point(818, 334);
            Nmax.Name = "Nmax";
            Nmax.Size = new Size(177, 23);
            Nmax.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(818, 316);
            label1.Name = "label1";
            label1.Size = new Size(184, 15);
            label1.TabIndex = 11;
            label1.Text = "Ingrese Nmax (Nacimientos Max)";
            // 
            // lblSmin
            // 
            lblSmin.AutoSize = true;
            lblSmin.Location = new Point(815, 154);
            lblSmin.Name = "lblSmin";
            lblSmin.Size = new Size(183, 15);
            lblSmin.TabIndex = 12;
            lblSmin.Text = "Ingrese Smin (Supervivencia min)";
            // 
            // Smin
            // 
            Smin.FormattingEnabled = true;
            Smin.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8" });
            Smin.Location = new Point(822, 172);
            Smin.Name = "Smin";
            Smin.Size = new Size(174, 23);
            Smin.TabIndex = 13;
            // 
            // lblSmax
            // 
            lblSmax.AutoSize = true;
            lblSmax.Location = new Point(815, 207);
            lblSmax.Name = "lblSmax";
            lblSmax.Size = new Size(187, 15);
            lblSmax.TabIndex = 14;
            lblSmax.Text = "Ingrese Smax (Supervivencia max)";
            // 
            // Smax
            // 
            Smax.FormattingEnabled = true;
            Smax.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8" });
            Smax.Location = new Point(822, 225);
            Smax.Name = "Smax";
            Smax.Size = new Size(173, 23);
            Smax.TabIndex = 15;
            // 
            // lblNmin
            // 
            lblNmin.AutoSize = true;
            lblNmin.Location = new Point(815, 261);
            lblNmin.Name = "lblNmin";
            lblNmin.Size = new Size(175, 15);
            lblNmin.TabIndex = 16;
            lblNmin.Text = "Ingrese Nmin (Nacimiento min)";
            // 
            // Nmin
            // 
            Nmin.FormattingEnabled = true;
            Nmin.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8" });
            Nmin.Location = new Point(822, 279);
            Nmin.Name = "Nmin";
            Nmin.Size = new Size(174, 23);
            Nmin.TabIndex = 17;
            // 
            // limpiarBtn
            // 
            limpiarBtn.Location = new Point(908, 128);
            limpiarBtn.Name = "limpiarBtn";
            limpiarBtn.Size = new Size(87, 23);
            limpiarBtn.TabIndex = 18;
            limpiarBtn.Text = "Limpiar";
            limpiarBtn.UseVisualStyleBackColor = true;
            limpiarBtn.Click += limpiarBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1004, 844);
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
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
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
    }
}