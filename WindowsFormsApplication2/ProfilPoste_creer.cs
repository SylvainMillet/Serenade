using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Serenade
{
    public partial class ProfilPoste_creer : Form
    {
        connectSQL sConnect = new connectSQL();
        public ProfilPoste_creer()
        {
            InitializeComponent();
        }

        private void ProfilPoste_creer_Load(object sender, EventArgs e)
        {
            if (globales.profilPoste != null)
            {
                System.Data.DataSet dsListeProfilPoste = new System.Data.DataSet();

                string queryListeProfilPoste = "SELECT id_profilPoste AS idProfilPoste, profilPoste_appellation AS Appellation, profilPoste_description AS Description, profilPoste_filiere AS Filiere, profilPoste_categorie AS Categorie, profilPoste_gradeMax AS GradeMax, profilPoste_cotationRegime AS CotationRegime FROM profilPoste WHERE id_profilPoste = ?profilPoste";
                MySqlDataAdapter daListeProfilPoste = new MySqlDataAdapter(queryListeProfilPoste, sConnect.con);
                daListeProfilPoste.SelectCommand.Parameters.AddWithValue("?profilPoste", globales.profilPoste);
                daListeProfilPoste.Fill(dsListeProfilPoste, "profilPoste");

                textBox_profil_appellation.Text = dsListeProfilPoste.Tables[0].Rows[0][1].ToString();
                textBox_profil_description.Text = dsListeProfilPoste.Tables[0].Rows[0][2].ToString();
                textBox_profil_filiere.Text = dsListeProfilPoste.Tables[0].Rows[0][3].ToString();
                textBox_profil_categorie.Text = dsListeProfilPoste.Tables[0].Rows[0][4].ToString();
                textBox_profil_grade.Text = dsListeProfilPoste.Tables[0].Rows[0][5].ToString();
                textBox_profil_regime.Text = dsListeProfilPoste.Tables[0].Rows[0][6].ToString();
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            globales.profilPoste = null;
            this.Hide();
        }

        private void button_valid_Click(object sender, EventArgs e)
        {
            String strConnect = @"server='80.15.195.96'; user id='root'; password='MySq1*'; database='serenade_db'";
            MySqlConnection con = null;
            if (globales.profilPoste != null)
            {
                try
                {
                    con = new MySqlConnection(strConnect);
                    con.Open();

                    String CommandTxt = "UPDATE profilposte SET profilPoste_appellation = ?appellation, profilPoste_description = ?description, profilPoste_filiere = ?filiere, profilPoste_categorie = ?categorie, profilPoste_gradeMax = ?gradeMax, profilPoste_cotationRegime = ?cotationRegime, profilPoste_direction = ?direction WHERE id_profilPoste = ?profilposte";
                    MySqlCommand comd = new MySqlCommand(CommandTxt, con);
                    comd.Prepare();
                    comd.Parameters.Add("?appellation", MySqlDbType.VarChar).Value = textBox_profil_appellation.Text;
                    comd.Parameters.Add("?description", MySqlDbType.VarChar).Value = textBox_profil_description.Text;
                    comd.Parameters.Add("?filiere", MySqlDbType.VarChar).Value = textBox_profil_filiere.Text;
                    comd.Parameters.Add("?categorie", MySqlDbType.VarChar).Value = textBox_profil_categorie.Text;
                    comd.Parameters.Add("?gradeMax", MySqlDbType.VarChar).Value = textBox_profil_grade.Text;
                    comd.Parameters.Add("?cotationRegime", MySqlDbType.Int16).Value = textBox_profil_regime.Text;
                    comd.Parameters.Add("?direction", MySqlDbType.VarChar).Value = textBox_profil_direction.Text;
                    comd.Parameters.Add("?profilposte", MySqlDbType.Int16).Value = globales.profilPoste;

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

                globales.profilPoste = null;
            }

            else
            {
                try
                {
                    con = new MySqlConnection(strConnect);
                    con.Open();

                    String CommandTxt = "INSERT INTO profilposte(profilPoste_appellation, profilPoste_description, profilPoste_filiere, profilPoste_categorie, profilPoste_gradeMax, profilPoste_cotationRegime, profilPoste_direction) VALUES(?appellation, ?description, ?filiere, ?categorie, ?gradeMax, ?cotationRegime, ?direction)";
                    MySqlCommand comd = new MySqlCommand(CommandTxt, con);
                    comd.Prepare();
                    comd.Parameters.Add("?appellation", MySqlDbType.VarChar).Value = textBox_profil_appellation.Text;
                    comd.Parameters.Add("?description", MySqlDbType.VarChar).Value = textBox_profil_description.Text;
                    comd.Parameters.Add("?filiere", MySqlDbType.VarChar).Value = textBox_profil_filiere.Text;
                    comd.Parameters.Add("?categorie", MySqlDbType.VarChar).Value = textBox_profil_categorie.Text;
                    comd.Parameters.Add("?gradeMax", MySqlDbType.VarChar).Value = textBox_profil_grade.Text;
                    comd.Parameters.Add("?cotationRegime", MySqlDbType.Int16).Value = textBox_profil_regime.Text;
                    comd.Parameters.Add("?direction", MySqlDbType.VarChar).Value = textBox_profil_direction.Text;

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
    }
}
