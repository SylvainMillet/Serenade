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
    public partial class Manipulate : Form
    {
        connectSQL sConnect = new connectSQL();
        int colonne, ligne;
        int? poste, profilPoste, emploi, collaborateur, actTerrain, actGenerique, portefeuilleCompetences;
        //String strConnect = "Server=80.15.195.96;Database=serenade_db;Uid=root;Pwd=MySq1*;";
        String strConnect = @"server='80.15.195.96'; user id='root'; password='MySq1*'; database='serenade_db'";
        MySqlConnection con = null;
        public Manipulate()
        {
            InitializeComponent();
        }

        private void Manipulate_Load(object sender, EventArgs e)
        {
            #region PortefeuilleCompetences

            //load profils poste
            System.Data.DataSet dsListePortefeuilleCompetences = new System.Data.DataSet();

            string queryListePortefeuilleCompetences = "SELECT * FROM portefeuillecompetences";
            MySqlDataAdapter daListePortefeuilleCompetences = new MySqlDataAdapter(queryListePortefeuilleCompetences, sConnect.con);
            daListePortefeuilleCompetences.Fill(dsListePortefeuilleCompetences, "portefeuillecompetences");

            if (dsListePortefeuilleCompetences.Tables[0].Rows.Count > 0)
            {
                this.dataGridView_portefeuilleCompetences.Visible = true;
                this.dataGridView_portefeuilleCompetences.DataSource = dsListePortefeuilleCompetences.Tables[0];
                //mask useless columns
                this.dataGridView_portefeuilleCompetences.Columns[0].Visible = false;
            }

            #endregion PortefeuilleCompetences

            # region Emploi

            //load emplois
            System.Data.DataSet dsListeEmploi = new System.Data.DataSet();

            string queryListeEmploi = "SELECT id_emploi AS idEmploi, emploi_intitule AS Intitule, emploi_description AS Description, emploi_profilPoste AS profilPoste FROM emploi";
            MySqlDataAdapter daListeEmploi = new MySqlDataAdapter(queryListeEmploi, sConnect.con);
            daListeEmploi.Fill(dsListeEmploi, "emploi");

            if (dsListeEmploi.Tables[0].Rows.Count > 0)
            {
                this.dataGridView_emploi.Visible = true;
                this.dataGridView_emploi.DataSource = dsListeEmploi.Tables[0];
                //mask useless columns
                this.dataGridView_emploi.Columns[0].Visible = false;
                this.dataGridView_emploi.Columns[3].Visible = false;
            }
            #endregion Emploi

            # region Collaborateur

            //load profils poste
            System.Data.DataSet dsListeCollaborateur = new System.Data.DataSet();

            string queryListeCollaborateur = "SELECT id_collaborateur AS idCollaborateur, collaborateur_nom AS Nom, collaborateur_prenom AS Prenom, collaborateur_mail AS Email FROM collaborateur LEFT JOIN poste ON poste.poste_collaborateur = id_collaborateur ORDER BY collaborateur_nom";
            MySqlDataAdapter daListeCollaborateur = new MySqlDataAdapter(queryListeCollaborateur, sConnect.con);
            daListeCollaborateur.Fill(dsListeCollaborateur, "collaborateur");

            if (dsListeCollaborateur.Tables[0].Rows.Count > 0)
            {
                this.dataGridView_collaborateur.Visible = true;
                this.dataGridView_collaborateur.DataSource = dsListeCollaborateur.Tables[0];
                //mask useless columns
                this.dataGridView_collaborateur.Columns[0].Visible = false;
            }
            #endregion Collaborateur

            #region Poste

            //load postes
            System.Data.DataSet dsListePoste = new System.Data.DataSet();

            string queryListePoste = "SELECT id_poste AS idPoste, poste_intitule AS Intitule, poste_description AS Description, poste_collaborateur AS Collaborateur FROM poste ORDER BY poste_intitule";
            MySqlDataAdapter daListePoste = new MySqlDataAdapter(queryListePoste, sConnect.con);
            daListePoste.Fill(dsListePoste, "poste");

            if (dsListePoste.Tables[0].Rows.Count > 0)
            {
                this.dataGridView_poste.Visible = true;
                this.dataGridView_poste.DataSource = dsListePoste.Tables[0];
                //mask useless columns
                this.dataGridView_poste.Columns[0].Visible = false;
                this.dataGridView_poste.Columns[3].Visible = false;
            }

            #endregion Poste

            #region ProfilPoste

            //load profils poste
            System.Data.DataSet dsListeProfilPoste = new System.Data.DataSet();

            string queryListeProfilPoste = "SELECT id_profilPoste AS idProfilPoste, profilPoste_appellation AS Appellation, profilPoste_description AS Description FROM profilPoste LEFT JOIN emploi ON emploi.emploi_profilPoste = id_profilPoste ORDER BY profilPoste_appellation";
            MySqlDataAdapter daListeProfilPoste = new MySqlDataAdapter(queryListeProfilPoste, sConnect.con);
            daListeProfilPoste.Fill(dsListeProfilPoste, "profilPoste");

            if (dsListeProfilPoste.Tables[0].Rows.Count > 0)
            {
                this.dataGridView_profilPoste.Visible = true;
                this.dataGridView_profilPoste.DataSource = dsListeProfilPoste.Tables[0];
                //mask useless columns
                this.dataGridView_profilPoste.Columns[0].Visible = false;
            }

            #endregion ProfilPoste

            #region ActiviteGenerique

            //load profils poste
            System.Data.DataSet dsListeActiviteGenerique = new System.Data.DataSet();

            string queryListeActiviteGenerique = "SELECT id_actGenerique AS idActGenerique, actGenerique_intitule AS Intitule, actGenerique_description AS Description FROM actgenerique ORDER BY actGenerique_intitule";
            MySqlDataAdapter daListeActiviteGenerique = new MySqlDataAdapter(queryListeActiviteGenerique, sConnect.con);
            daListeActiviteGenerique.Fill(dsListeActiviteGenerique, "actgenerique");

            if (dsListeActiviteGenerique.Tables[0].Rows.Count > 0)
            {
                this.dataGridView_activiteGenerique.Visible = true;
                this.dataGridView_activiteGenerique.DataSource = dsListeActiviteGenerique.Tables[0];
                //mask useless columns
                this.dataGridView_activiteGenerique.Columns[0].Visible = false;
            }

            #endregion ActiviteGenerique

            #region ActiviteTerrain

            //load profils poste
            System.Data.DataSet dsListeActiviteTerrain = new System.Data.DataSet();

            string queryListeActiviteTerrain = "SELECT id_actTerrain AS idActTerrain, actTerrain_intitule AS Intitule, actTerrain_description AS Description, actTerrain_poste AS Poste FROM actTerrain ORDER BY actTerrain_intitule";
            MySqlDataAdapter daListeActiviteTerrain = new MySqlDataAdapter(queryListeActiviteTerrain, sConnect.con);
            daListeActiviteTerrain.Fill(dsListeActiviteTerrain, "actterrain");

            if (dsListeActiviteTerrain.Tables[0].Rows.Count > 0)
            {
                this.dataGridView_activiteTerrain.Visible = true;
                this.dataGridView_activiteTerrain.DataSource = dsListeActiviteTerrain.Tables[0];
                //mask useless columns
                this.dataGridView_activiteTerrain.Columns[0].Visible = false;
                this.dataGridView_activiteTerrain.Columns[3].Visible = false;
            }

            #endregion ActiviteTerrain
        }

        private void dataGridView_collaborateur_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            colonne = e.ColumnIndex;
            ligne = e.RowIndex;
            collaborateur = Convert.ToInt32(dataGridView_collaborateur.Rows[ligne].Cells[0].Value.ToString());
        }

        private void dataGridView_portefeuilleCompetences_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            colonne = e.ColumnIndex;
            ligne = e.RowIndex;
            portefeuilleCompetences = Convert.ToInt32(dataGridView_portefeuilleCompetences.Rows[ligne].Cells[0].Value.ToString());
        }

        private void dataGridView_activiteGenerique_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            colonne = e.ColumnIndex;
            ligne = e.RowIndex;
            actGenerique = Convert.ToInt32(dataGridView_activiteGenerique.Rows[ligne].Cells[0].Value.ToString());
        }

        private void dataGridView_activiteTerrain_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            colonne = e.ColumnIndex;
            ligne = e.RowIndex;
            actTerrain = Convert.ToInt32(dataGridView_activiteTerrain.Rows[ligne].Cells[0].Value.ToString());
        }

        private void dataGridView_poste_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            colonne = e.ColumnIndex;
            ligne = e.RowIndex;
            poste = Convert.ToInt32(dataGridView_poste.Rows[ligne].Cells[0].Value.ToString());
        }

        private void dataGridView_profilPoste_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            colonne = e.ColumnIndex;
            ligne = e.RowIndex;
            profilPoste = Convert.ToInt32(dataGridView_profilPoste.Rows[ligne].Cells[0].Value.ToString());
        }

        private void dataGridView_emploi_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            colonne = e.ColumnIndex;
            ligne = e.RowIndex;
            emploi = Convert.ToInt32(dataGridView_emploi.Rows[ligne].Cells[0].Value.ToString());
        }

        #region Boutons

        private void button_lier_collaborateur_portefeuille_Click(object sender, EventArgs e)
        {
            if (collaborateur != null && portefeuilleCompetences != null)
            {
                DialogResult DialogResult = MessageBox.Show("Etes-vous sûr de vouloir appliquer cette liaison ?", "Nouvelle liaison", MessageBoxButtons.YesNo);
                if (DialogResult == DialogResult.Yes)
                {
                    try
                    {
                        con = new MySqlConnection(strConnect);
                        con.Open();

                        String CommandTxt = "UPDATE collaborateur SET collaborateur_portefeuilleCompetences = ?portefeuilleCompetences WHERE id_collaborateur = ?collaborateur";
                        MySqlCommand comd = new MySqlCommand(CommandTxt, con);
                        comd.Prepare();
                        comd.Parameters.Add("?collaborateur", MySqlDbType.Int16).Value = collaborateur;
                        comd.Parameters.Add("?portefeuilleCompetences", MySqlDbType.Int16).Value = portefeuilleCompetences;

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
            }
        }

        private void button_delier_collaborateur_portefeuille_Click(object sender, EventArgs e)
        {
            if (collaborateur != null && portefeuilleCompetences != null)
            {
                DialogResult DialogResult = MessageBox.Show("Etes-vous sûr de vouloir supprimer cette liaison ?", "Suppression de liaison", MessageBoxButtons.YesNo);
                if (DialogResult == DialogResult.Yes)
                {
                    try
                    {
                        con = new MySqlConnection(strConnect);
                        con.Open();

                        String CommandTxt = "UPDATE collaborateur SET collaborateur_portefeuilleCompetences = null WHERE id_collaborateur = ?collaborateur";
                        MySqlCommand comd = new MySqlCommand(CommandTxt, con);
                        comd.Prepare();
                        comd.Parameters.Add("?collaborateur", MySqlDbType.Int16).Value = collaborateur;

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
            }
        }

        private void button_lier_portefeuille_actGenerique_Click(object sender, EventArgs e)
        {
            if (actGenerique != null && portefeuilleCompetences != null)
            {
                DialogResult DialogResult = MessageBox.Show("Etes-vous sûr de vouloir appliquer cette liaison ?", "Nouvelle liaison", MessageBoxButtons.YesNo);
                if (DialogResult == DialogResult.Yes)
                {
                    try
                    {
                        con = new MySqlConnection(strConnect);
                        con.Open();

                        String CommandTxt = "UPDATE actgenerique SET actGenerique_portefeuilleCompetences = ?portefeuilleCompetences WHERE id_actgenerique = ?actGenerique";
                        MySqlCommand comd = new MySqlCommand(CommandTxt, con);
                        comd.Prepare();
                        comd.Parameters.Add("?actGenerique", MySqlDbType.Int16).Value = actGenerique;
                        comd.Parameters.Add("?portefeuilleCompetences", MySqlDbType.Int16).Value = portefeuilleCompetences;

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
            }
        }

        private void button_delier_portefeuille_actGenerique_Click(object sender, EventArgs e)
        {
            if (actGenerique != null && portefeuilleCompetences != null)
            {
                DialogResult DialogResult = MessageBox.Show("Etes-vous sûr de vouloir supprimer cette liaison ?", "Suppression de liaison", MessageBoxButtons.YesNo);
                if (DialogResult == DialogResult.Yes)
                {
                    try
                    {
                        con = new MySqlConnection(strConnect);
                        con.Open();

                        String CommandTxt = "UPDATE actgenerique SET actGenerique_portefeuilleCompetences = null WHERE id_actgenerique = ?actGenerique";
                        MySqlCommand comd = new MySqlCommand(CommandTxt, con);
                        comd.Prepare();
                        comd.Parameters.Add("?actGenerique", MySqlDbType.Int16).Value = actGenerique;

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
            }
        }

        private void button_lier_collaborateur_poste_Click(object sender, EventArgs e)
        {
            if (poste != null && collaborateur != null)
            {
                DialogResult DialogResult = MessageBox.Show("Etes-vous sûr de vouloir appliquer cette liaison ?", "Nouvelle liaison", MessageBoxButtons.YesNo);
                if (DialogResult == DialogResult.Yes)
                {
                    try
                    {
                        con = new MySqlConnection(strConnect);
                        con.Open();

                        String CommandTxt = "UPDATE poste SET poste_collaborateur = ?collaborateur WHERE id_poste = ?poste";
                        MySqlCommand comd = new MySqlCommand(CommandTxt, con);
                        comd.Prepare();
                        comd.Parameters.Add("?poste", MySqlDbType.Int16).Value = poste;
                        comd.Parameters.Add("?collaborateur", MySqlDbType.Int16).Value = collaborateur;

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
            }
        }

        private void button_delier_collaborateur_poste_Click(object sender, EventArgs e)
        {
            if (poste != null && collaborateur != null)
            {
                DialogResult DialogResult = MessageBox.Show("Etes-vous sûr de vouloir supprimer cette liaison ?", "Suppression de liaison", MessageBoxButtons.YesNo);
                if (DialogResult == DialogResult.Yes)
                {
                    try
                    {
                        con = new MySqlConnection(strConnect);
                        con.Open();

                        String CommandTxt = "UPDATE poste SET poste_collaborateur = null WHERE id_poste = ?poste";
                        MySqlCommand comd = new MySqlCommand(CommandTxt, con);
                        comd.Prepare();
                        comd.Parameters.Add("?poste", MySqlDbType.Int16).Value = poste;

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
            }
        }

        private void button_lier_poste_actTerrain_Click(object sender, EventArgs e)
        {
            if (poste != null && actTerrain != null)
            {
                DialogResult DialogResult = MessageBox.Show("Etes-vous sûr de vouloir appliquer cette liaison ?", "Nouvelle liaison", MessageBoxButtons.YesNo);
                if (DialogResult == DialogResult.Yes)
                {
                    try
                    {
                        con = new MySqlConnection(strConnect);
                        con.Open();

                        String CommandTxt = "UPDATE actterrain SET actTerrain_poste = ?poste WHERE id_actTerrain = ?actTerrain";
                        MySqlCommand comd = new MySqlCommand(CommandTxt, con);
                        comd.Prepare();
                        comd.Parameters.Add("?poste", MySqlDbType.Int16).Value = poste;
                        comd.Parameters.Add("?actTerrain", MySqlDbType.Int16).Value = actTerrain;

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
            }
        }

        private void button_delier_poste_actTerrain_Click(object sender, EventArgs e)
        {
            if (poste != null && actTerrain != null)
            {
                DialogResult DialogResult = MessageBox.Show("Etes-vous sûr de vouloir supprimer cette liaison ?", "Suppression de liaison", MessageBoxButtons.YesNo);
                if (DialogResult == DialogResult.Yes)
                {
                    try
                    {
                        con = new MySqlConnection(strConnect);
                        con.Open();

                        String CommandTxt = "UPDATE actterrain SET actTerrain_poste = null WHERE id_actTerrain = ?actTerrain";
                        MySqlCommand comd = new MySqlCommand(CommandTxt, con);
                        comd.Prepare();
                        comd.Parameters.Add("?actTerrain", MySqlDbType.Int16).Value = actTerrain;

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
            }
        }

        private void button_lier_portefeuille_actTerrain_Click(object sender, EventArgs e)
        {
            if (portefeuilleCompetences != null && actTerrain != null)
            {
                DialogResult DialogResult = MessageBox.Show("Etes-vous sûr de vouloir appliquer cette liaison ?", "Nouvelle liaison", MessageBoxButtons.YesNo);
                if (DialogResult == DialogResult.Yes)
                {
                    try
                    {
                        con = new MySqlConnection(strConnect);
                        con.Open();

                        String CommandTxt = "UPDATE actterrain SET actTerrain_portefeuilleCompetences = ?portefeuilleCompetences WHERE id_actTerrain = ?actTerrain";
                        MySqlCommand comd = new MySqlCommand(CommandTxt, con);
                        comd.Prepare();
                        comd.Parameters.Add("?portefeuilleCompetences", MySqlDbType.Int16).Value = portefeuilleCompetences;
                        comd.Parameters.Add("?actTerrain", MySqlDbType.Int16).Value = actTerrain;

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
            }
        }

        private void button_delier_portefeuille_actTerrain_Click(object sender, EventArgs e)
        {
            if (portefeuilleCompetences != null && actTerrain != null)
            {
                DialogResult DialogResult = MessageBox.Show("Etes-vous sûr de vouloir supprimer cette liaison ?", "Suppression de liaison", MessageBoxButtons.YesNo);
                if (DialogResult == DialogResult.Yes)
                {
                    try
                    {
                        con = new MySqlConnection(strConnect);
                        con.Open();

                        String CommandTxt = "UPDATE actterrain SET actTerrain_portefeuilleCompetences = null WHERE id_actTerrain = ?actTerrain";
                        MySqlCommand comd = new MySqlCommand(CommandTxt, con);
                        comd.Prepare();
                        comd.Parameters.Add("?actTerrain", MySqlDbType.Int16).Value = actTerrain;

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
            }
        }

        private void button_lier_profilPoste_emploi_Click(object sender, EventArgs e)
        {
            if (emploi != null && profilPoste != null)
            {
                DialogResult DialogResult = MessageBox.Show("Etes-vous sûr de vouloir appliquer cette liaison ?", "Nouvelle liaison", MessageBoxButtons.YesNo);
                if (DialogResult == DialogResult.Yes)
                {
                    try
                    {
                        con = new MySqlConnection(strConnect);
                        con.Open();

                        String CommandTxt = "UPDATE emploi SET emploi_profilPoste = ?profilPoste WHERE id_emploi = ?emploi";
                        MySqlCommand comd = new MySqlCommand(CommandTxt, con);
                        comd.Prepare();
                        comd.Parameters.Add("?emploi", MySqlDbType.Int16).Value = emploi;
                        comd.Parameters.Add("?profilPoste", MySqlDbType.Int16).Value = profilPoste;

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
            }
        }

        private void button_delier_profilPoste_emploi_Click(object sender, EventArgs e)
        {
            if (emploi != null && profilPoste != null)
            {
                DialogResult DialogResult = MessageBox.Show("Etes-vous sûr de vouloir supprimer cette liaison ?", "Suppression de liaison", MessageBoxButtons.YesNo);
                if (DialogResult == DialogResult.Yes)
                {
                    try
                    {
                        con = new MySqlConnection(strConnect);
                        con.Open();

                        String CommandTxt = "UPDATE emploi SET emploi_profilPoste = null WHERE id_emploi = ?emploi";
                        MySqlCommand comd = new MySqlCommand(CommandTxt, con);
                        comd.Prepare();
                        comd.Parameters.Add("?emploi", MySqlDbType.Int16).Value = emploi;

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
            }
        }

        private void button_lier_profilPoste_actTerrain_Click(object sender, EventArgs e)
        {
            if (actTerrain != null && profilPoste != null)
            {
                DialogResult DialogResult = MessageBox.Show("Etes-vous sûr de vouloir appliquer cette liaison ?", "Nouvelle liaison", MessageBoxButtons.YesNo);
                if (DialogResult == DialogResult.Yes)
                {
                    try
                    {
                        con = new MySqlConnection(strConnect);
                        con.Open();

                        String CommandTxt = "UPDATE actterrain SET emploi_profilPoste = ?profilPoste WHERE id_emploi = ?emploi";
                        MySqlCommand comd = new MySqlCommand(CommandTxt, con);
                        comd.Prepare();
                        comd.Parameters.Add("?emploi", MySqlDbType.Int16).Value = emploi;
                        comd.Parameters.Add("?profilPoste", MySqlDbType.Int16).Value = profilPoste;

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
            }
        }

        private void button_delier_profilPoste_actTerrain_Click(object sender, EventArgs e)
        {
            if (emploi != null && profilPoste != null)
            {
                DialogResult DialogResult = MessageBox.Show("Etes-vous sûr de vouloir supprimer cette liaison ?", "Suppression de liaison", MessageBoxButtons.YesNo);
                if (DialogResult == DialogResult.Yes)
                {
                    try
                    {
                        con = new MySqlConnection(strConnect);
                        con.Open();

                        String CommandTxt = "UPDATE emploi SET emploi_profilPoste = null WHERE id_emploi = ?emploi";
                        MySqlCommand comd = new MySqlCommand(CommandTxt, con);
                        comd.Prepare();
                        comd.Parameters.Add("?emploi", MySqlDbType.Int16).Value = emploi;

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
            }
        }

        #endregion Boutons




    }
}
