namespace Serenade
{
    partial class Poste_creer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Poste_creer));
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_valid = new System.Windows.Forms.Button();
            this.label_poste_description = new System.Windows.Forms.Label();
            this.textBox_poste_intitule = new System.Windows.Forms.TextBox();
            this.label_poste_intitule = new System.Windows.Forms.Label();
            this.textBox_poste_description = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_cancel
            // 
            this.button_cancel.BackColor = System.Drawing.Color.White;
            this.button_cancel.BackgroundImage = global::Serenade.Properties.Resources.annuler;
            this.button_cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_cancel.FlatAppearance.BorderSize = 0;
            this.button_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cancel.Location = new System.Drawing.Point(102, 216);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 35);
            this.button_cancel.TabIndex = 170;
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
            this.button_valid.Location = new System.Drawing.Point(219, 216);
            this.button_valid.Name = "button_valid";
            this.button_valid.Size = new System.Drawing.Size(75, 35);
            this.button_valid.TabIndex = 169;
            this.button_valid.UseVisualStyleBackColor = false;
            this.button_valid.Click += new System.EventHandler(this.button_valid_Click);
            // 
            // label_poste_description
            // 
            this.label_poste_description.AutoSize = true;
            this.label_poste_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label_poste_description.ForeColor = System.Drawing.Color.Black;
            this.label_poste_description.Location = new System.Drawing.Point(25, 81);
            this.label_poste_description.Name = "label_poste_description";
            this.label_poste_description.Size = new System.Drawing.Size(76, 16);
            this.label_poste_description.TabIndex = 160;
            this.label_poste_description.Text = "Description";
            // 
            // textBox_poste_intitule
            // 
            this.textBox_poste_intitule.Location = new System.Drawing.Point(102, 30);
            this.textBox_poste_intitule.Name = "textBox_poste_intitule";
            this.textBox_poste_intitule.Size = new System.Drawing.Size(379, 20);
            this.textBox_poste_intitule.TabIndex = 159;
            // 
            // label_poste_intitule
            // 
            this.label_poste_intitule.AutoSize = true;
            this.label_poste_intitule.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label_poste_intitule.ForeColor = System.Drawing.Color.Black;
            this.label_poste_intitule.Location = new System.Drawing.Point(25, 34);
            this.label_poste_intitule.Name = "label_poste_intitule";
            this.label_poste_intitule.Size = new System.Drawing.Size(45, 16);
            this.label_poste_intitule.TabIndex = 158;
            this.label_poste_intitule.Text = "Intitulé";
            // 
            // textBox_poste_description
            // 
            this.textBox_poste_description.Location = new System.Drawing.Point(102, 81);
            this.textBox_poste_description.Multiline = true;
            this.textBox_poste_description.Name = "textBox_poste_description";
            this.textBox_poste_description.Size = new System.Drawing.Size(379, 97);
            this.textBox_poste_description.TabIndex = 171;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(366, 201);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(114, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 172;
            this.pictureBox1.TabStop = false;
            // 
            // Poste_creer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(492, 263);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox_poste_description);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_valid);
            this.Controls.Add(this.label_poste_description);
            this.Controls.Add(this.textBox_poste_intitule);
            this.Controls.Add(this.label_poste_intitule);
            this.Name = "Poste_creer";
            this.Text = "Création d\'un poste";
            this.Load += new System.EventHandler(this.Poste_creer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_valid;
        private System.Windows.Forms.Label label_poste_description;
        private System.Windows.Forms.TextBox textBox_poste_intitule;
        private System.Windows.Forms.Label label_poste_intitule;
        private System.Windows.Forms.TextBox textBox_poste_description;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}