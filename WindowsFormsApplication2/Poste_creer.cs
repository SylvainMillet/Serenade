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
    public partial class Poste_creer : Form
    {
        connectSQL sConnect = new connectSQL();
        public Poste_creer()
        {
            InitializeComponent();
        }

        private void button_valid_Click(object sender, EventArgs e)
        {
            String strConnect = @"server='80.15.195.96'; user id='root'; password='MySq1*'; database='serenade_db'";
            MySqlConnection con = null;
            if (globales.poste != null)
            {
                try
                {
                    con = new MySqlConnection(strConnect);
                    con.Open();

                    String CommandTxt = "UPDATE poste SET poste_intitule = ?intitule, poste_description = ?description WHERE id_poste = ?poste";
                    MySqlCommand comd = new MySqlCommand(CommandTxt, con);
                    comd.Prepare();
                    comd.Parameters.Add("?intitule", MySqlDbType.VarChar).Value = textBox_poste_intitule.Text;
                    comd.Parameters.Add("?description", MySqlDbType.VarChar).Value = textBox_poste_description.Text;
                    comd.Parameters.Add("?poste", MySqlDbType.Int16).Value = globales.poste;

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

                globales.poste = null;
            }

            else
            {
                try
                {
                    con = new MySqlConnection(strConnect);
                    con.Open();

                    String CommandTxt = "INSERT INTO poste(poste_intitule, poste_description) VALUES(?intitule, ?description)";
                    MySqlCommand comd = new MySqlCommand(CommandTxt, con);
                    comd.Prepare();
                    comd.Parameters.Add("?intitule", MySqlDbType.VarChar).Value = textBox_poste_intitule.Text;
                    comd.Parameters.Add("?description", MySqlDbType.VarChar).Value = textBox_poste_description.Text;

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
            globales.poste = null;
            this.Hide();
        }

        private void Poste_creer_Load(object sender, EventArgs e)
        {
            if (globales.poste != null)
            {
                System.Data.DataSet dsListePoste = new System.Data.DataSet();

                string queryListePoste = "SELECT id_poste AS idPoste, poste_intitule AS Intitule, poste_description AS Description, poste_collaborateur AS Collaborateur FROM poste WHERE id_poste = ?poste";
                MySqlDataAdapter daListePoste = new MySqlDataAdapter(queryListePoste, sConnect.con);
                daListePoste.SelectCommand.Parameters.AddWithValue("?poste", globales.poste);
                daListePoste.Fill(dsListePoste, "poste");


                textBox_poste_intitule.Text = dsListePoste.Tables[0].Rows[0][1].ToString();
                textBox_poste_description.Text = dsListePoste.Tables[0].Rows[0][2].ToString();
            }
        }
    }
}
