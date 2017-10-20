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
    public partial class Emploi_creer : Form
    {
        connectSQL sConnect = new connectSQL();
        public Emploi_creer()
        {
            InitializeComponent();
        }

        private void button_valid_Click(object sender, EventArgs e)
        {
            String strConnect = @"server='80.15.195.96'; user id='root'; password='MySq1*'; database='serenade_db'";
            MySqlConnection con = null;
            if (globales.emploi != null)
            {
                try
                {
                    con = new MySqlConnection(strConnect);
                    con.Open();

                    String CommandTxt = "UPDATE emploi SET emploi_intitule = ?intitule, emploi_description = ?description WHERE id_emploi = ?emploi";
                    MySqlCommand comd = new MySqlCommand(CommandTxt, con);
                    comd.Prepare();
                    comd.Parameters.Add("?intitule", MySqlDbType.VarChar).Value = textBox_emploi_intitule.Text;
                    comd.Parameters.Add("?description", MySqlDbType.VarChar).Value = textBox_emploi_description.Text;
                    comd.Parameters.Add("?emploi", MySqlDbType.Int16).Value = globales.emploi;

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

                globales.emploi = null;
            }

            else
            {
                try
                {
                    con = new MySqlConnection(strConnect);
                    con.Open();

                    String CommandTxt = "INSERT INTO emploi(emploi_intitule, emploi_description) VALUES(?intitule, ?description)";
                    MySqlCommand comd = new MySqlCommand(CommandTxt, con);
                    comd.Prepare();
                    comd.Parameters.Add("?intitule", MySqlDbType.VarChar).Value = textBox_emploi_intitule.Text;
                    comd.Parameters.Add("?description", MySqlDbType.VarChar).Value = textBox_emploi_description.Text;

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
            globales.emploi = null;
            this.Hide();
        }

        private void Emploi_creer_Load(object sender, EventArgs e)
        {
            if (globales.emploi != null)
            {
                System.Data.DataSet dsListeEmploi = new System.Data.DataSet();

                string queryListeEmploi = "SELECT id_emploi AS idEmploi, emploi_intitule AS Intitule, emploi_description AS Description FROM emploi WHERE id_emploi = ?emploi";
                MySqlDataAdapter daListeEmploi = new MySqlDataAdapter(queryListeEmploi, sConnect.con);
                daListeEmploi.SelectCommand.Parameters.AddWithValue("?emploi", globales.emploi);
                daListeEmploi.Fill(dsListeEmploi, "emploi");

                textBox_emploi_intitule.Text = dsListeEmploi.Tables[0].Rows[0][1].ToString();
                textBox_emploi_description.Text = dsListeEmploi.Tables[0].Rows[0][2].ToString();
            }
        }
    }
}
