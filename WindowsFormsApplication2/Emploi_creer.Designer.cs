namespace Serenade
{
    partial class Emploi_creer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Emploi_creer));
            this.textBox_emploi_description = new System.Windows.Forms.TextBox();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_valid = new System.Windows.Forms.Button();
            this.label_emploi_description = new System.Windows.Forms.Label();
            this.textBox_emploi_intitule = new System.Windows.Forms.TextBox();
            this.label_emploi_intitule = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_emploi_description
            // 
            this.textBox_emploi_description.Location = new System.Drawing.Point(95, 85);
            this.textBox_emploi_description.Multiline = true;
            this.textBox_emploi_description.Name = "textBox_emploi_description";
            this.textBox_emploi_description.Size = new System.Drawing.Size(379, 97);
            this.textBox_emploi_description.TabIndex = 183;
            // 
            // button_cancel
            // 
            this.button_cancel.BackgroundImage = global::Serenade.Properties.Resources.annuler;
            this.button_cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_cancel.Location = new System.Drawing.Point(95, 223);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 34);
            this.button_cancel.TabIndex = 182;
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_valid
            // 
            this.button_valid.BackgroundImage = global::Serenade.Properties.Resources.valider;
            this.button_valid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_valid.Location = new System.Drawing.Point(214, 223);
            this.button_valid.Name = "button_valid";
            this.button_valid.Size = new System.Drawing.Size(75, 35);
            this.button_valid.TabIndex = 181;
            this.button_valid.UseVisualStyleBackColor = true;
            this.button_valid.Click += new System.EventHandler(this.button_valid_Click);
            // 
            // label_emploi_description
            // 
            this.label_emploi_description.AutoSize = true;
            this.label_emploi_description.Location = new System.Drawing.Point(18, 85);
            this.label_emploi_description.Name = "label_emploi_description";
            this.label_emploi_description.Size = new System.Drawing.Size(60, 13);
            this.label_emploi_description.TabIndex = 180;
            this.label_emploi_description.Text = "Description";
            // 
            // textBox_emploi_intitule
            // 
            this.textBox_emploi_intitule.Location = new System.Drawing.Point(95, 34);
            this.textBox_emploi_intitule.Name = "textBox_emploi_intitule";
            this.textBox_emploi_intitule.Size = new System.Drawing.Size(379, 20);
            this.textBox_emploi_intitule.TabIndex = 179;
            // 
            // label_emploi_intitule
            // 
            this.label_emploi_intitule.AutoSize = true;
            this.label_emploi_intitule.Location = new System.Drawing.Point(18, 41);
            this.label_emploi_intitule.Name = "label_emploi_intitule";
            this.label_emploi_intitule.Size = new System.Drawing.Size(38, 13);
            this.label_emploi_intitule.TabIndex = 178;
            this.label_emploi_intitule.Text = "Intitulé";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(362, 208);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(114, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 184;
            this.pictureBox1.TabStop = false;
            // 
            // Emploi_creer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(488, 270);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox_emploi_description);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_valid);
            this.Controls.Add(this.label_emploi_description);
            this.Controls.Add(this.textBox_emploi_intitule);
            this.Controls.Add(this.label_emploi_intitule);
            this.Name = "Emploi_creer";
            this.Text = "Création d\'un emploi";
            this.Load += new System.EventHandler(this.Emploi_creer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_emploi_description;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_valid;
        private System.Windows.Forms.Label label_emploi_description;
        private System.Windows.Forms.TextBox textBox_emploi_intitule;
        private System.Windows.Forms.Label label_emploi_intitule;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}