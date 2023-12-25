namespace juegoDeLaVida.App
{
    partial class Graficos
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
            components = new System.ComponentModel.Container();
            cartesianChart1 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            unosBtn = new Button();
            logBtn = new Button();
            shannBtn = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // cartesianChart1
            // 
            cartesianChart1.Location = new Point(12, 12);
            cartesianChart1.Name = "cartesianChart1";
            cartesianChart1.Size = new Size(844, 598);
            cartesianChart1.TabIndex = 0;
            // 
            // unosBtn
            // 
            unosBtn.Location = new Point(956, 12);
            unosBtn.Name = "unosBtn";
            unosBtn.Size = new Size(75, 23);
            unosBtn.TabIndex = 1;
            unosBtn.Text = "Unos";
            unosBtn.UseVisualStyleBackColor = true;
            unosBtn.Click += unosBtn_Click;
            // 
            // logBtn
            // 
            logBtn.Location = new Point(956, 41);
            logBtn.Name = "logBtn";
            logBtn.Size = new Size(75, 23);
            logBtn.TabIndex = 2;
            logBtn.Text = "Unos Log";
            logBtn.UseVisualStyleBackColor = true;
            logBtn.Click += logBtn_Click;
            // 
            // shannBtn
            // 
            shannBtn.Location = new Point(956, 70);
            shannBtn.Name = "shannBtn";
            shannBtn.Size = new Size(75, 41);
            shannBtn.TabIndex = 3;
            shannBtn.Text = "Entriopia Shannon";
            shannBtn.UseVisualStyleBackColor = true;
            shannBtn.Click += shannBtn_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Graficos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1049, 638);
            Controls.Add(shannBtn);
            Controls.Add(logBtn);
            Controls.Add(unosBtn);
            Controls.Add(cartesianChart1);
            Name = "Graficos";
            Text = "Graficos";
            ResumeLayout(false);
        }

        #endregion

        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart1;
        private Button unosBtn;
        private Button logBtn;
        private Button shannBtn;
        private System.Windows.Forms.Timer timer1;
    }
}