using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Serenade
{
    public partial class Collaborateur_creer : Form
    {
        connectSQL sConnect = new connectSQL();
        public Collaborateur_creer()
        {
            InitializeComponent();
        }

        private void button_valid_Click(object sender, EventArgs e)
        {
            String strConnect = @"server='80.15.195.96'; user id='root'; password='MySq1*'; database='serenade_db'";
            MySqlConnection con = null;
            if (globales.collaborateur != null)
            {
                try
                {
                    con = new MySqlConnection(strConnect);
                    con.Open();

                    String CommandTxt = "UPDATE collaborateur SET collaborateur_nom = ?nom, collaborateur_prenom = ?prenom, collaborateur_embauche = ?embauche, collaborateur_civilite = ?civilite, collaborateur_naissance = ?naissance, collaborateur_mail = ?mail, collaborateur_tel = ?tel WHERE id_collaborateur = ?collaborateur";
                    MySqlCommand comd = new MySqlCommand(CommandTxt, con);
                    comd.Prepare();
                    // format date : aaaa-mm-jj
                    comd.Parameters.Add("?nom", MySqlDbType.VarChar).Value = textBox_collaborateur_nom.Text;
                    comd.Parameters.Add("?prenom", MySqlDbType.VarChar).Value = textBox_collaborateur_prenom.Text;
                    comd.Parameters.Add("?embauche", MySqlDbType.Date).Value = DateTime.Parse(textBox_collaborateur_annee.Text + "-" + textBox_collaborateur_mois.Text + "-" + textBox_collaborateur_jour.Text);
                    comd.Parameters.Add("?civilite", MySqlDbType.VarChar).Value = comboBox_collaborateur_civilite.Text;
                    comd.Parameters.Add("?naissance", MySqlDbType.Date).Value = DateTime.Parse(textBox_collaborateur_naiss_annee.Text + "-" + textBox_collaborateur_naiss_mois.Text + "-" + textBox_collaborateur_naiss_jour.Text);
                    comd.Parameters.Add("?mail", MySqlDbType.VarChar).Value = textBox_collaborateur_mail.Text;
                    comd.Parameters.Add("?tel", MySqlDbType.VarChar).Value = textBox_collaborateur_tel.Text;
                    comd.Parameters.Add("?collaborateur", MySqlDbType.Int16).Value = globales.collaborateur;

                    comd.ExecuteNonQuery();
                }
                catch (MySqlException err)
                {
                    Console.WriteLine("Error: " + err.ToString());
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close();
                    }
                }
                globales.collaborateur = null;
            }

            else
            {
                try
                {
                    con = new MySqlConnection(strConnect);
                    con.Open();

                    String CommandTxt = "INSERT INTO collaborateur(collaborateur_nom, collaborateur_prenom, collaborateur_embauche, collaborateur_civilite, collaborateur_naissance, collaborateur_mail, collaborateur_tel) VALUES(?nom, ?prenom, ?embauche, ?civilite, ?naissance, ?mail, ?tel)";
                    MySqlCommand comd = new MySqlCommand(CommandTxt, con);
                    comd.Prepare();
                    // format date : aaaa-mm-jj
                    comd.Parameters.Add("?nom", MySqlDbType.VarChar).Value = textBox_collaborateur_nom.Text;
                    comd.Parameters.Add("?prenom", MySqlDbType.VarChar).Value = textBox_collaborateur_prenom.Text;
                    comd.Parameters.Add("?embauche", MySqlDbType.Date).Value = DateTime.Parse(textBox_collaborateur_annee.Text + "-" + textBox_collaborateur_mois.Text + "-" + textBox_collaborateur_jour.Text);
                    comd.Parameters.Add("?civilite", MySqlDbType.VarChar).Value = comboBox_collaborateur_civilite.SelectedItem.ToString();
                    comd.Parameters.Add("?naissance", MySqlDbType.Date).Value = DateTime.Parse(textBox_collaborateur_naiss_annee.Text + "-" + textBox_collaborateur_naiss_mois.Text + "-" + textBox_collaborateur_naiss_jour.Text);
                    comd.Parameters.Add("?mail", MySqlDbType.VarChar).Value = textBox_collaborateur_mail.Text;
                    comd.Parameters.Add("?tel", MySqlDbType.VarChar).Value = textBox_collaborateur_tel.Text;

                    comd.ExecuteNonQuery();
                }
                catch (MySqlException err)
                {
                    Console.WriteLine("Error: " + err.ToString());
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close();
                    }
                }
            }
            this.Hide();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            globales.collaborateur = null;
            this.Hide();
        }

        private void textBox_collaborateur_mail_Leave(object sender, EventArgs e)
        {
            if(!textBox_collaborateur_mail.Text.Contains("@"))
                MessageBox.Show("Email non valide.");
        }

        private void Collaborateur_creer_Load(object sender, EventArgs e)
        {
            if (globales.collaborateur != null)
            {
                System.Data.DataSet dsListeCollaborateur = new System.Data.DataSet();

                string queryListeCollaborateur = "SELECT id_collaborateur AS idCollaborateur, collaborateur_nom AS Nom, collaborateur_prenom AS Prenom, collaborateur_embauche AS DateEmbauche, collaborateur_civilite AS Civilite, collaborateur_naissance AS DateNaissance, collaborateur_mail AS Email, collaborateur_tel AS Telephone FROM collaborateur WHERE id_collaborateur = ?collaborateur";
                MySqlDataAdapter daListeCollaborateur = new MySqlDataAdapter(queryListeCollaborateur, sConnect.con);
                daListeCollaborateur.SelectCommand.Parameters.AddWithValue("?collaborateur", globales.collaborateur);
                daListeCollaborateur.Fill(dsListeCollaborateur, "collaborateur");

                textBox_collaborateur_nom.Text = dsListeCollaborateur.Tables[0].Rows[0][1].ToString();
                textBox_collaborateur_prenom.Text = dsListeCollaborateur.Tables[0].Rows[0][2].ToString();
                //textBox_collaborateur_jour.Text = 
                //textBox_collaborateur_mois.Text = dsListeCollaborateur.Tables[0].Rows[0][3].ToString();
                //textBox_collaborateur_annee.Text = 
                comboBox_collaborateur_civilite.Text = dsListeCollaborateur.Tables[0].Rows[0][4].ToString();
                //textBox_collaborateur_naiss_jour.Text = 
                //textBox_collaborateur_naiss_mois.Text = dsListeCollaborateur.Tables[0].Rows[0][5].ToString();
                //textBox_collaborateur_naiss_annee.Text = 
                textBox_collaborateur_mail.Text = dsListeCollaborateur.Tables[0].Rows[0][6].ToString();
                textBox_collaborateur_tel.Text = dsListeCollaborateur.Tables[0].Rows[0][7].ToString();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
