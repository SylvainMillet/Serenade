namespace Serenade
{
    partial class Portefeuille_creer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Portefeuille_creer));
            this.textBox_portefeuille_description = new System.Windows.Forms.TextBox();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_valid = new System.Windows.Forms.Button();
            this.label_portefeuille_description = new System.Windows.Forms.Label();
            this.textBox_portefeuille_intitule = new System.Windows.Forms.TextBox();
            this.label_portefeuille_intitule = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_portefeuille_description
            // 
            this.textBox_portefeuille_description.Location = new System.Drawing.Point(82, 69);
            this.textBox_portefeuille_description.Multiline = true;
            this.textBox_portefeuille_description.Name = "textBox_portefeuille_description";
            this.textBox_portefeuille_description.Size = new System.Drawing.Size(379, 97);
            this.textBox_portefeuille_description.TabIndex = 189;
            // 
            // button_cancel
            // 
            this.button_cancel.BackColor = System.Drawing.Color.White;
            this.button_cancel.BackgroundImage = global::Serenade.Properties.Resources.annuler;
            this.button_cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_cancel.FlatAppearance.BorderSize = 0;
            this.button_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cancel.Location = new System.Drawing.Point(82, 199);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 35);
            this.button_cancel.TabIndex = 188;
            this.button_cancel.UseVisualStyleBackColor = false;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_valid
            // 
            this.button_valid.BackColor = System.Drawing.Color.White;
            this.button_valid.BackgroundImage = global::Serenade.Properties.Resources.valider;
            this.button_valid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_valid.FlatAppearance.BorderSize = 0;
            this.button_valid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_valid.Location = new System.Drawing.Point(201, 198);
            this.button_valid.Name = "button_valid";
            this.button_valid.Size = new System.Drawing.Size(75, 35);
            this.button_valid.TabIndex = 187;
            this.button_valid.UseVisualStyleBackColor = false;
            this.button_valid.Click += new System.EventHandler(this.button_valid_Click);
            // 
            // label_portefeuille_description
            // 
            this.label_portefeuille_description.AutoSize = true;
            this.label_portefeuille_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label_portefeuille_description.ForeColor = System.Drawing.Color.Black;
            this.label_portefeuille_description.Location = new System.Drawing.Point(5, 69);
            this.label_portefeuille_description.Name = "label_portefeuille_description";
            this.label_portefeuille_description.Size = new System.Drawing.Size(76, 16);
            this.label_portefeuille_description.TabIndex = 186;
            this.label_portefeuille_description.Text = "Description";
            this.label_portefeuille_description.Click += new System.EventHandler(this.label_portefeuille_description_Click);
            // 
            // textBox_portefeuille_intitule
            // 
            this.textBox_portefeuille_intitule.Location = new System.Drawing.Point(82, 18);
            this.textBox_portefeuille_intitule.Name = "textBox_portefeuille_intitule";
            this.textBox_portefeuille_intitule.Size = new System.Drawing.Size(379, 20);
            this.textBox_portefeuille_intitule.TabIndex = 185;
            // 
            // label_portefeuille_intitule
            // 
            this.label_portefeuille_intitule.AutoSize = true;
            this.label_portefeuille_intitule.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label_portefeuille_intitule.ForeColor = System.Drawing.Color.Black;
            this.label_portefeuille_intitule.Location = new System.Drawing.Point(5, 25);
            this.label_portefeuille_intitule.Name = "label_portefeuille_intitule";
            this.label_portefeuille_intitule.Size = new System.Drawing.Size(45, 16);
            this.label_portefeuille_intitule.TabIndex = 184;
            this.label_portefeuille_intitule.Text = "Intitulé";
            this.label_portefeuille_intitule.Click += new System.EventHandler(this.label_portefeuille_intitule_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(347, 183);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(114, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 190;
            this.pictureBox1.TabStop = false;
            // 
            // Portefeuille_creer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(473, 245);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox_portefeuille_description);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_valid);
            this.Controls.Add(this.label_portefeuille_description);
            this.Controls.Add(this.textBox_portefeuille_intitule);
            this.Controls.Add(this.label_portefeuille_intitule);
            this.Name = "Portefeuille_creer";
            this.Text = "Portefeuille_creer";
            this.Load += new System.EventHandler(this.Portefeuille_creer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_portefeuille_description;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_valid;
        private System.Windows.Forms.Label label_portefeuille_description;
        private System.Windows.Forms.TextBox textBox_portefeuille_intitule;
        private System.Windows.Forms.Label label_portefeuille_intitule;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}