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
    public partial class Activite_creer : Form
    {
        connectSQL sConnect = new connectSQL();
        public Activite_creer()
        {
            InitializeComponent();
        }

        string activite = "";
        string table = "";

        private void Form_Activite_Load(object sender, EventArgs e)
        {
            if (globales.actTerrain != null && globales.actGenerique == null)
            {
                System.Data.DataSet dsListeActTerrain = new System.Data.DataSet();

                string queryListeActTerrain = "SELECT id_actTerrain AS idActTerrain, actTerrain_intitule AS Intitule, actTerrain_description AS Description FROM actTerrain WHERE id_actTerrain = ?actTerrain";
                MySqlDataAdapter daListeActTerrain = new MySqlDataAdapter(queryListeActTerrain, sConnect.con);
                daListeActTerrain.SelectCommand.Parameters.AddWithValue("?actTerrain", globales.actTerrain);
                daListeActTerrain.Fill(dsListeActTerrain, "actTerrain");

                textBox_activite_intitule.Text = dsListeActTerrain.Tables[0].Rows[0][1].ToString();
                textBox_activite_description.Text = dsListeActTerrain.Tables[0].Rows[0][2].ToString();
                radioButton_terrain.Checked = true;
                radioButton_terrain.Enabled = radioButton_generique.Enabled = false;
                globales.activites = globales.actTerrain;
                globales.actTerrain = null;
            }
            if (globales.actGenerique != null && globales.actTerrain == null)
            {
                System.Data.DataSet dsListeActGenerique = new System.Data.DataSet();

                string queryListeActGenerique = "SELECT id_actGenerique AS idActGenerique, actGenerique_intitule AS Intitule, actGenerique_description AS Description FROM actGenerique WHERE id_actGenerique = ?actGenerique";
                MySqlDataAdapter daListeActGenerique = new MySqlDataAdapter(queryListeActGenerique, sConnect.con);
                daListeActGenerique.SelectCommand.Parameters.AddWithValue("?actGenerique", globales.actGenerique);
                daListeActGenerique.Fill(dsListeActGenerique, "actGenerique");

                textBox_activite_intitule.Text = dsListeActGenerique.Tables[0].Rows[0][1].ToString();
                textBox_activite_description.Text = dsListeActGenerique.Tables[0].Rows[0][2].ToString();
                radioButton_generique.Checked = true;
                radioButton_terrain.Enabled = radioButton_generique.Enabled = false;
                globales.activites = globales.actGenerique;
                globales.actGenerique = null;
            }

        }


        private void button_fidelity_valid_Click_1(object sender, EventArgs e)
        {
            if (radioButton_generique.Checked)
            {
                activite = "actGenerique";
                table = "actgenerique";
            }
            else
            {
                activite = "actTerrain";
                table = "actterrain";
            }

            String strConnect = @"server='80.15.195.96'; user id='root'; password='MySq1*'; database='serenade_db'";
            MySqlConnection con = null;

            if (globales.activites == null)
            {
                try
                {
                    con = new MySqlConnection(strConnect);
                    con.Open();

                    String CommandTxt = "INSERT INTO " + table + "(" + activite + "_intitule, " + activite + "_description) VALUES(?intitule, ?description)";
                    MySqlCommand comd = new MySqlCommand(CommandTxt, con);
                    comd.Prepare();
                    comd.Parameters.Add("?intitule", MySqlDbType.VarChar).Value = textBox_activite_intitule.Text;
                    comd.Parameters.Add("?description", MySqlDbType.VarChar).Value = textBox_activite_description.Text;

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

            else
            {
                try
                {
                    con = new MySqlConnection(strConnect);
                    con.Open();

                    String CommandTxt = "UPDATE " + table + "SET " + activite + "_intitule = ?intitule, " + activite + "_description = ?description WHERE id_" + activite + " = ?activite";
                    MySqlCommand comd = new MySqlCommand(CommandTxt, con);
                    comd.Prepare();
                    comd.Parameters.Add("?intitule", MySqlDbType.VarChar).Value = textBox_activite_intitule.Text;
                    comd.Parameters.Add("?description", MySqlDbType.VarChar).Value = textBox_activite_description.Text;
                    comd.Parameters.Add("?activite", MySqlDbType.Int16).Value = globales.activites;

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
            globales.activites = null;
            radioButton_terrain.Enabled = radioButton_generique.Enabled = true;
            this.Hide();
        }

        private void button_fidelity_cancel_Click(object sender, EventArgs e)
        {
            globales.activites = null;
            this.Hide();
        }
    }
}
