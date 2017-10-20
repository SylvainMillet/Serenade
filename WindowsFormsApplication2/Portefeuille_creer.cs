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
    public partial class Portefeuille_creer : Form
    {
        connectSQL sConnect = new connectSQL();
        public Portefeuille_creer()
        {
            InitializeComponent();
        }

        private void button_valid_Click(object sender, EventArgs e)
        {
            String strConnect = @"server='80.15.195.96'; user id='root'; password='MySq1*'; database='serenade_db'";
            MySqlConnection con = null;
            if (globales.portefeuilleCompetences != null)
            {
                try
                {
                    con = new MySqlConnection(strConnect);
                    con.Open();

                    String CommandTxt = "UPDATE portefeuillecompetences SET portefeuille_intitule = ?intitule, portefeuille_description = ?description WHERE id_portefeuille = ?portefeuillecompetences";
                    MySqlCommand comd = new MySqlCommand(CommandTxt, con);
                    comd.Prepare();
                    comd.Parameters.Add("?intitule", MySqlDbType.VarChar).Value = textBox_portefeuille_intitule.Text;
                    comd.Parameters.Add("?description", MySqlDbType.VarChar).Value = textBox_portefeuille_description.Text;
                    comd.Parameters.Add("?portefeuillecompetences", MySqlDbType.Int16).Value = globales.portefeuilleCompetences;

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

                globales.portefeuilleCompetences = null;
            }

            else
            {
                try
                {
                    con = new MySqlConnection(strConnect);
                    con.Open();

                    String CommandTxt = "INSERT INTO portefeuillecompetences(portefeuille_intitule, portefeuille_description) VALUES(?intitule, ?description)";
                    MySqlCommand comd = new MySqlCommand(CommandTxt, con);
                    comd.Prepare();
                    comd.Parameters.Add("?intitule", MySqlDbType.VarChar).Value = textBox_portefeuille_intitule.Text;
                    comd.Parameters.Add("?description", MySqlDbType.VarChar).Value = textBox_portefeuille_description.Text;

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
            globales.portefeuilleCompetences = null;
            this.Hide();
        }

        private void Portefeuille_creer_Load(object sender, EventArgs e)
        {
            if (globales.portefeuilleCompetences != null)
            {
                System.Data.DataSet dsListePortefeuilleCompetences = new System.Data.DataSet();

                string queryListePortefeuilleCompetences = "SELECT id_portefeuille, portefeuille_intitule, portefeuille_description FROM portefeuillecompetences WHERE id_portefeuille = ?portefeuilleCompetences";
                MySqlDataAdapter daListePortefeuilleCompetences = new MySqlDataAdapter(queryListePortefeuilleCompetences, sConnect.con);
                daListePortefeuilleCompetences.SelectCommand.Parameters.AddWithValue("?portefeuilleCompetences", globales.portefeuilleCompetences);
                daListePortefeuilleCompetences.Fill(dsListePortefeuilleCompetences, "portefeuillecompetences");

                textBox_portefeuille_intitule.Text = dsListePortefeuilleCompetences.Tables[0].Rows[0][1].ToString();
                textBox_portefeuille_description.Text = dsListePortefeuilleCompetences.Tables[0].Rows[0][2].ToString();
            }
        }

        private void label_portefeuille_intitule_Click(object sender, EventArgs e)
        {

        }

        private void label_portefeuille_description_Click(object sender, EventArgs e)
        {

        }
    }
}
