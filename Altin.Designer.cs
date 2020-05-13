namespace Ndp_Proje
{
    partial class Altin
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtgram = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCeyrek = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGramal = new System.Windows.Forms.Button();
            this.btnÇeyrekal = new System.Windows.Forms.Button();
            this.txtTC = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Location = new System.Drawing.Point(67, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(628, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "1 GR ALTININ ALIŞ FİYATI 382 TL ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.Location = new System.Drawing.Point(32, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(693, 46);
            this.label2.TabIndex = 0;
            this.label2.Text = "ÇEYREK ALTININ ALIŞ FİYATI 612 TL";
            // 
            // txtgram
            // 
            this.txtgram.Location = new System.Drawing.Point(214, 242);
            this.txtgram.Name = "txtgram";
            this.txtgram.Size = new System.Drawing.Size(100, 22);
            this.txtgram.TabIndex = 1;
            this.txtgram.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtgram_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Gram Altın";
            // 
            // txtCeyrek
            // 
            this.txtCeyrek.Location = new System.Drawing.Point(495, 240);
            this.txtCeyrek.Name = "txtCeyrek";
            this.txtCeyrek.Size = new System.Drawing.Size(100, 22);
            this.txtCeyrek.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(386, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Çeyrek Altın";
            // 
            // btnGramal
            // 
            this.btnGramal.Location = new System.Drawing.Point(148, 293);
            this.btnGramal.Name = "btnGramal";
            this.btnGramal.Size = new System.Drawing.Size(113, 23);
            this.btnGramal.TabIndex = 3;
            this.btnGramal.Text = "AL";
            this.btnGramal.UseVisualStyleBackColor = true;
            this.btnGramal.Click += new System.EventHandler(this.btnGramal_Click);
            // 
            // btnÇeyrekal
            // 
            this.btnÇeyrekal.Location = new System.Drawing.Point(441, 293);
            this.btnÇeyrekal.Name = "btnÇeyrekal";
            this.btnÇeyrekal.Size = new System.Drawing.Size(113, 23);
            this.btnÇeyrekal.TabIndex = 3;
            this.btnÇeyrekal.Text = "AL";
            this.btnÇeyrekal.UseVisualStyleBackColor = true;
            this.btnÇeyrekal.Click += new System.EventHandler(this.btnÇeyrekal_Click);
            // 
            // txtTC
            // 
            this.txtTC.Location = new System.Drawing.Point(369, 180);
            this.txtTC.Name = "txtTC";
            this.txtTC.ReadOnly = true;
            this.txtTC.Size = new System.Drawing.Size(100, 22);
            this.txtTC.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(260, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "TC Kimlik No";
            // 
            // Altin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cyan;
            this.ClientSize = new System.Drawing.Size(749, 420);
            this.Controls.Add(this.btnÇeyrekal);
            this.Controls.Add(this.btnGramal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCeyrek);
            this.Controls.Add(this.txtTC);
            this.Controls.Add(this.txtgram);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Altin";
            this.Text = "Altin";
            this.Load += new System.EventHandler(this.Altin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtgram;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCeyrek;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGramal;
        private System.Windows.Forms.Button btnÇeyrekal;
        private System.Windows.Forms.TextBox txtTC;
        private System.Windows.Forms.Label label5;
    }
}