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
    public partial class Explorer : Form
    {
        public Boolean firstLoad;
        connectSQL sConnect = new connectSQL();
        int colonne, ligne;
        int bouton = 0;
        string textBouton1, textBouton2, textBouton3, textBouton4, textBouton5, textBouton6, textBouton7, textBouton8, textBouton9;
        int? poste, profilPoste, emploi, collaborateur, activites, portefeuilleCompetences;
        public Explorer()
        {
            InitializeComponent();
        }

        private void Explorer_Load(object sender, EventArgs e)
        {
            firstLoad = true;
        }

        private void reset()
        {
            globales.poste = globales.profilPoste = globales.emploi = globales.collaborateur = globales.activites = globales.portefeuilleCompetences = null;
            poste = profilPoste = emploi = collaborateur = activites = portefeuilleCompetences = null;

            dataGridView_profilPoste.Visible = dataGridView_activiteGenerique.Visible = dataGridView_activiteTerrain.Visible = dataGridView_collaborateur.Visible = dataGridView_emploi.Visible = dataGridView_poste.Visible = dataGridView_portefeuilleCompetences.Visible = false;

            button1.Visible = button2.Visible = button3.Visible = button4.Visible = button5.Visible = button6.Visible = button7.Visible = button8.Visible = button9.Visible = false;
            bouton = 0;
            firstLoad = true;
        }

        private void resetDataGrid()
        {
            dataGridView_profilPoste.Visible = dataGridView_activiteGenerique.Visible = dataGridView_activiteTerrain.Visible = dataGridView_collaborateur.Visible = dataGridView_emploi.Visible = dataGridView_poste.Visible = dataGridView_portefeuilleCompetences.Visible = false;
        }

        private void loadButton()
        {
            switch (bouton)
            {
                case 1:
                    if (button1.Text != "")
                    {
                        button1.Visible = true;
                    }
                    break;
                case 2:
                    if (button2.Text != "")
                    {
                        button2.Visible = true;
                    }
                    break;
                case 3:
                    if (button3.Text != "")
                    {
                        button3.Visible = true;
                    }
                    break;
                case 4:
                    if (button4.Text != "")
                    {
                        button4.Visible = true;
                    }
                    break;
                case 5:
                    if (button5.Text != "")
                    {
                        button5.Visible = true;
                    }
                    break;
                case 6:
                    if (button6.Text != "")
                    {
                        button6.Visible = true;
                    }
                    break;
                case 7:
                    if (button7.Text != "")
                    {
                        button7.Visible = true;
                    }
                    break;
                case 8:
                    if (button8.Text != "")
                    {
                        button8.Visible = true;
                    }
                    break;
                case 9:
                    if (button9.Text != "")
                    {
                        button9.Visible = true;
                    }
                    break;
                default:
                    Console.WriteLine(bouton);
                    break;
            }

            bouton = bouton + 1;

        }

        /// <summary>
        /// chargement du texte du bouton
        /// </summary>
        /// <param name="name">nom du bouton</param>
        private void loadTextButton(string name)
        {
            switch (bouton)
            {
                case 1:
                    textBouton1 = name;
                    button1.Text = textBouton1;
                    break;
                case 2:
                    textBouton2 = name;
                    button2.Text = textBouton2;
                    break;
                case 3:
                    textBouton3 = name;
                    button3.Text = textBouton3;
                    break;
                case 4:
                    textBouton4 = name;
                    button4.Text = textBouton4;
                    break;
                case 5:
                    textBouton5 = name;
                    button5.Text = textBouton5;
                    break;
                case 6:
                    textBouton6 = name;
                    button6.Text = textBouton6;
                    break;
                case 7:
                    textBouton7 = name;
                    button7.Text = textBouton7;
                    break;
                case 8:
                    textBouton8 = name;
                    button8.Text = textBouton8;
                    break;
                case 9:
                    textBouton9 = name;
                    button9.Text = textBouton9;
                    break;
                default:
                    Console.WriteLine(bouton);
                    break;
            }
        }

        #region Emploi
        private void emploiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetDataGrid();
            this.dataGridView_emploi.Visible = true;

            //load emplois
            System.Data.DataSet dsListeEmploi = new System.Data.DataSet();

            if (firstLoad == true)
            {
                string queryListeEmploi = "SELECT id_emploi AS idEmploi, emploi_intitule AS Intitule, emploi_description AS Description, emploi_profilPoste AS profilPoste FROM emploi ORDER BY emploi_intitule";
                MySqlDataAdapter daListeEmploi = new MySqlDataAdapter(queryListeEmploi, sConnect.con);
                daListeEmploi.Fill(dsListeEmploi, "emploi");

                if (dsListeEmploi.Tables[0].Rows.Count > 0)
                {
                    this.dataGridView_emploi.DataSource = dsListeEmploi.Tables[0];
                    //mask useless columns
                    this.dataGridView_emploi.Columns[0].Visible = false;
                    this.dataGridView_emploi.Columns[3].Visible = false;
                }
            }
            else
            {
                string queryListeEmploi = "SELECT id_emploi AS idEmploi, emploi_intitule AS Intitule, emploi_description AS Description, emploi_profilPoste AS profilPoste FROM emploi WHERE emploi_profilPoste = ?profilPoste ORDER BY emploi_intitule";
                MySqlDataAdapter daListeEmploi = new MySqlDataAdapter(queryListeEmploi, sConnect.con);
                daListeEmploi.SelectCommand.Parameters.AddWithValue("?profilPoste", profilPoste);
                daListeEmploi.Fill(dsListeEmploi, "emploi");

                if (dsListeEmploi.Tables[0].Rows.Count > 0)
                {
                    this.dataGridView_emploi.DataSource = dsListeEmploi.Tables[0];
                    //mask useless columns
                    this.dataGridView_emploi.Columns[0].Visible = false;
                    this.dataGridView_emploi.Columns[3].Visible = false;
                }
            }
            loadButton();
            firstLoad = false;
        }

        private void dataGridView_emploi_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // si le click est effectué avec le bouton gauche de la souris
            if (e.Button == MouseButtons.Left)
            {
                colonne = e.ColumnIndex;
                ligne = e.RowIndex;
                emploi = Convert.ToInt32(dataGridView_emploi.Rows[ligne].Cells[0].Value.ToString());
                if (dataGridView_emploi.Rows[ligne].Cells[3].Value.ToString() != "")
                {
                    profilPoste = Convert.ToInt32(dataGridView_emploi.Rows[ligne].Cells[3].Value.ToString());
                }
                loadTextButton(dataGridView_emploi.Rows[ligne].Cells[1].Value.ToString());
            }
            if (e.Button == MouseButtons.Right)
            {
                colonne = e.ColumnIndex;
                ligne = e.RowIndex;
                globales.emploi = Convert.ToInt32(dataGridView_emploi.Rows[ligne].Cells[0].Value.ToString());
                Point point = new Point(e.X, e.Y);
                contextMenuStrip1.Show(dataGridView_emploi, point);
            }
        }

        #endregion Emploi

        #region Poste
        private void menuItem_poste_Click(object sender, EventArgs e)
        {
            resetDataGrid();
            this.dataGridView_poste.Visible = true;

            //load postes
            System.Data.DataSet dsListePoste = new System.Data.DataSet();

            if (firstLoad == true)
            {
                string queryListePoste = "SELECT id_poste AS idPoste, poste_intitule AS Intitule, poste_description AS Description, poste_collaborateur AS Collaborateur FROM poste ORDER BY poste_intitule";
                MySqlDataAdapter daListePoste = new MySqlDataAdapter(queryListePoste, sConnect.con);
                daListePoste.Fill(dsListePoste, "poste");

                if (dsListePoste.Tables[0].Rows.Count > 0)
                {
                    this.dataGridView_poste.DataSource = dsListePoste.Tables[0];
                    //mask useless columns
                    this.dataGridView_poste.Columns[0].Visible = false;
                    this.dataGridView_poste.Columns[3].Visible = false;
                }
            }
            else
            {
                if (poste != null)
                {
                    string queryListePoste = "SELECT id_poste AS idPoste, poste_intitule AS Intitule, poste_description AS Description, poste_collaborateur AS Collaborateur FROM poste WHERE id_poste = ?poste ORDER BY poste_intitule";
                    MySqlDataAdapter daListePoste = new MySqlDataAdapter(queryListePoste, sConnect.con);
                    daListePoste.SelectCommand.Parameters.AddWithValue("?poste", poste);
                    daListePoste.Fill(dsListePoste, "poste");

                    if (dsListePoste.Tables[0].Rows.Count > 0)
                    {
                        this.dataGridView_poste.DataSource = dsListePoste.Tables[0];
                        //mask useless columns
                        this.dataGridView_poste.Columns[0].Visible = false;
                        this.dataGridView_poste.Columns[3].Visible = false;
                    }
                }
                if (collaborateur != null)
                {
                    string queryListePoste = "SELECT id_poste AS idPoste, poste_intitule AS Intitule, poste_description AS Description, poste_collaborateur AS Collaborateur FROM poste WHERE poste_collaborateur = ?collaborateur ORDER BY poste_intitule";
                    MySqlDataAdapter daListePoste = new MySqlDataAdapter(queryListePoste, sConnect.con);
                    daListePoste.SelectCommand.Parameters.AddWithValue("?collaborateur", collaborateur);
                    daListePoste.Fill(dsListePoste, "poste");

                    if (dsListePoste.Tables[0].Rows.Count > 0)
                    {
                        this.dataGridView_poste.DataSource = dsListePoste.Tables[0];
                        //mask useless columns
                        this.dataGridView_poste.Columns[0].Visible = false;
                        this.dataGridView_poste.Columns[3].Visible = false;
                    }
                }

            }
            loadButton();
            firstLoad = false;
        }

        private void dataGridView_poste_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // si le click est effectué avec le bouton gauche de la souris
            if (e.Button == MouseButtons.Left)
            {
                colonne = e.ColumnIndex;
                ligne = e.RowIndex;
                poste = Convert.ToInt32(dataGridView_poste.Rows[ligne].Cells[0].Value.ToString());
                if (dataGridView_poste.Rows[ligne].Cells[3].Value.ToString() != "")
                {
                    collaborateur = Convert.ToInt32(dataGridView_poste.Rows[ligne].Cells[3].Value.ToString());
                }
                loadTextButton(dataGridView_poste.Rows[ligne].Cells[1].Value.ToString());
            }
            if (e.Button == MouseButtons.Right)
            {
                colonne = e.ColumnIndex;
                ligne = e.RowIndex;
                globales.poste = Convert.ToInt32(dataGridView_poste.Rows[ligne].Cells[0].Value.ToString());
                Point point = new Point(e.X, e.Y);
                contextMenuStrip1.Show(dataGridView_poste, point);
            }
        }

        #endregion Poste

        #region ProfilPoste
        private void menuItem_profilPoste_Click(object sender, EventArgs e)
        {
            resetDataGrid();
            this.dataGridView_profilPoste.Visible = true;

            //load profils poste
            System.Data.DataSet dsListeProfilPoste = new System.Data.DataSet();
            if (firstLoad == true)
            {
                string queryListeProfilPoste = "SELECT id_profilPoste AS idProfilPoste, profilPoste_appellation AS Appellation, profilPoste_description AS Description, profilPoste_filiere AS Filiere, profilPoste_categorie AS Categorie, profilPoste_gradeMax AS GradeMax, profilPoste_cotationRegime AS CotationRegime, profilPoste_direction AS Direction FROM profilPoste ORDER BY profilPoste_appellation";
                MySqlDataAdapter daListeProfilPoste = new MySqlDataAdapter(queryListeProfilPoste, sConnect.con);
                daListeProfilPoste.Fill(dsListeProfilPoste, "profilPoste");

                if (dsListeProfilPoste.Tables[0].Rows.Count > 0)
                {
                    this.dataGridView_profilPoste.DataSource = dsListeProfilPoste.Tables[0];
                    //mask useless columns
                    this.dataGridView_profilPoste.Columns[0].Visible = false;
                }
            }
            else
            {
                if (profilPoste != null)
                {
                    string queryListeProfilPoste = "SELECT id_profilPoste AS idProfilPoste, profilPoste_appellation AS Appellation, profilPoste_description AS Description, profilPoste_filiere AS Filiere, profilPoste_categorie AS Categorie, profilPoste_gradeMax AS GradeMax, profilPoste_cotationRegime AS CotationRegime, profilPoste_direction AS Direction, profilPoste_poste AS idPoste FROM profilPoste WHERE id_profilPoste = ?profilPoste ORDER BY profilPoste_appellation";
                    MySqlDataAdapter daListeProfilPoste = new MySqlDataAdapter(queryListeProfilPoste, sConnect.con);
                    daListeProfilPoste.SelectCommand.Parameters.AddWithValue("?profilPoste", profilPoste);
                    daListeProfilPoste.Fill(dsListeProfilPoste, "profilPoste");

                    if (dsListeProfilPoste.Tables[0].Rows.Count > 0)
                    {
                        this.dataGridView_profilPoste.DataSource = dsListeProfilPoste.Tables[0];
                        //mask useless columns
                        this.dataGridView_profilPoste.Columns[0].Visible = false;
                        this.dataGridView_profilPoste.Columns[8].Visible = false;
                    }
                }
            }
            loadButton();
            firstLoad = false;
        }

        private void dataGridView_profilPoste_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // si le click est effectué avec le bouton gauche de la souris
            if (e.Button == MouseButtons.Left)
            {
                colonne = e.ColumnIndex;
                ligne = e.RowIndex;
                profilPoste = Convert.ToInt32(dataGridView_profilPoste.Rows[ligne].Cells[0].Value.ToString());
                loadTextButton(dataGridView_profilPoste.Rows[ligne].Cells[1].Value.ToString());
            }
            if (e.Button == MouseButtons.Right)
            {
                colonne = e.ColumnIndex;
                ligne = e.RowIndex;
                globales.profilPoste = Convert.ToInt32(dataGridView_profilPoste.Rows[ligne].Cells[0].Value.ToString());
                Point point = new Point(e.X, e.Y);
                contextMenuStrip1.Show(dataGridView_profilPoste, point);
            }
        }

        #endregion ProfilPoste

        #region Collaborateur
        private void collaborateurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetDataGrid();
            this.dataGridView_collaborateur.Visible = true;
            //load profils poste
            System.Data.DataSet dsListeCollaborateur = new System.Data.DataSet();
            if (firstLoad == true)
            {
                string queryListeCollaborateur = "SELECT id_collaborateur AS idCollaborateur, collaborateur_nom AS Nom, collaborateur_prenom AS Prenom, collaborateur_embauche AS DateEmbauche, collaborateur_civilite AS Civilite, collaborateur_naissance AS DateNaissance, collaborateur_mail AS Email, collaborateur_tel AS Telephone, collaborateur_portefeuilleCompetences AS portefeuilleCompetences FROM collaborateur ORDER BY collaborateur_nom";
                MySqlDataAdapter daListeCollaborateur = new MySqlDataAdapter(queryListeCollaborateur, sConnect.con);
                daListeCollaborateur.Fill(dsListeCollaborateur, "collaborateur");

                if (dsListeCollaborateur.Tables[0].Rows.Count > 0)
                {
                    this.dataGridView_collaborateur.DataSource = dsListeCollaborateur.Tables[0];
                    //mask useless columns
                    this.dataGridView_collaborateur.Columns[0].Visible = false;
                    this.dataGridView_collaborateur.Columns[8].Visible = false;
                }
            }
            else
            {
                if (collaborateur != null)
                {
                    string queryListeCollaborateur = "SELECT id_collaborateur AS idCollaborateur, collaborateur_nom AS Nom, collaborateur_prenom AS Prenom, collaborateur_embauche AS DateEmbauche, collaborateur_mail AS Email, collaborateur_tel AS Telephone FROM collaborateur WHERE id_collaborateur = ?collaborateur ORDER BY collaborateur_nom";
                    MySqlDataAdapter daListeCollaborateur = new MySqlDataAdapter(queryListeCollaborateur, sConnect.con);
                    daListeCollaborateur.SelectCommand.Parameters.AddWithValue("?collaborateur", collaborateur);
                    daListeCollaborateur.Fill(dsListeCollaborateur, "collaborateur");

                    if (dsListeCollaborateur.Tables[0].Rows.Count > 0)
                    {
                        this.dataGridView_collaborateur.DataSource = dsListeCollaborateur.Tables[0];
                        //mask useless columns
                        this.dataGridView_collaborateur.Columns[0].Visible = false;
                    }
                }
                if (portefeuilleCompetences != null)
                {
                    string queryListeCollaborateur = "SELECT id_collaborateur AS idCollaborateur, collaborateur_nom AS Nom, collaborateur_prenom AS Prenom, collaborateur_embauche AS DateEmbauche, collaborateur_mail AS Email, collaborateur_tel AS Telephone FROM collaborateur WHERE collaborateur_portefeuilleCompetences = ?portefeuilleCompetences ORDER BY collaborateur_nom";
                    MySqlDataAdapter daListeCollaborateur = new MySqlDataAdapter(queryListeCollaborateur, sConnect.con);
                    daListeCollaborateur.SelectCommand.Parameters.AddWithValue("?portefeuilleCompetences", portefeuilleCompetences);
                    daListeCollaborateur.Fill(dsListeCollaborateur, "collaborateur");

                    if (dsListeCollaborateur.Tables[0].Rows.Count > 0)
                    {
                        this.dataGridView_collaborateur.DataSource = dsListeCollaborateur.Tables[0];
                        //mask useless columns
                        this.dataGridView_collaborateur.Columns[0].Visible = false;
                    }
                }

            }
            loadButton();
            firstLoad = false;
        }

        private void dataGridView_collaborateur_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // si le click est effectué avec le bouton gauche de la souris
            if (e.Button == MouseButtons.Left)
            {
                colonne = e.ColumnIndex;
                ligne = e.RowIndex;
                collaborateur = Convert.ToInt32(dataGridView_collaborateur.Rows[ligne].Cells[0].Value.ToString());
                if (dataGridView_collaborateur.Rows[ligne].Cells[8].Value.ToString() != "")
                {
                    portefeuilleCompetences = Convert.ToInt32(dataGridView_collaborateur.Rows[ligne].Cells[8].Value.ToString());
                }
                loadTextButton(dataGridView_collaborateur.Rows[ligne].Cells[1].Value.ToString());
            }
            if (e.Button == MouseButtons.Right)
            {
                colonne = e.ColumnIndex;
                ligne = e.RowIndex;
                globales.collaborateur = Convert.ToInt32(dataGridView_collaborateur.Rows[ligne].Cells[0].Value.ToString());
                Point point = new Point(e.X, e.Y);
                contextMenuStrip1.Show(dataGridView_collaborateur, point);
            }
        }
        #endregion Collaborateur

        #region ActiviteGenerique
        private void génériquesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetDataGrid();
            this.dataGridView_activiteGenerique.Visible = true;
            //load profils poste
            System.Data.DataSet dsListeActiviteGenerique = new System.Data.DataSet();
            if (firstLoad == true)
            {
                string queryListeActiviteGenerique = "SELECT id_actGenerique AS idActGenerique, actGenerique_intitule AS Intitule, actGenerique_description AS Description, actGenerique_portefeuilleCompetences AS PortefeuilleCompetences FROM actgenerique ORDER BY actGenerique_intitule";
                MySqlDataAdapter daListeActiviteGenerique = new MySqlDataAdapter(queryListeActiviteGenerique, sConnect.con);
                daListeActiviteGenerique.Fill(dsListeActiviteGenerique, "actgenerique");

                if (dsListeActiviteGenerique.Tables[0].Rows.Count > 0)
                {
                    this.dataGridView_activiteGenerique.DataSource = dsListeActiviteGenerique.Tables[0];
                    //mask useless columns
                    this.dataGridView_activiteGenerique.Columns[0].Visible = false;
                    this.dataGridView_activiteGenerique.Columns[3].Visible = false;
                }
            }
            else
            {
                if (portefeuilleCompetences != null)
                {
                    string queryListeActiviteGenerique = "SELECT id_actGenerique AS idActGenerique, actGenerique_intitule AS Intitule, actGenerique_description AS Description, actGenerique_portefeuilleCompetences AS portefeuilleCompetences FROM actgenerique WHERE actGenerique_portefeuilleCompetences = ?portefeuilleCompetences ORDER BY actGenerique_intitule";
                    MySqlDataAdapter daListeActiviteGenerique = new MySqlDataAdapter(queryListeActiviteGenerique, sConnect.con);
                    daListeActiviteGenerique.SelectCommand.Parameters.AddWithValue("?portefeuilleCompetences", portefeuilleCompetences);
                    daListeActiviteGenerique.Fill(dsListeActiviteGenerique, "actgenerique");

                    if (dsListeActiviteGenerique.Tables[0].Rows.Count > 0)
                    {
                        this.dataGridView_activiteGenerique.DataSource = dsListeActiviteGenerique.Tables[0];
                        //mask useless columns
                        this.dataGridView_activiteGenerique.Columns[0].Visible = false;
                        this.dataGridView_activiteGenerique.Columns[3].Visible = false;
                    }
                }
            }
            loadButton();
            firstLoad = false;
        }
        private void dataGridView_activiteGenerique_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // si le click est effectué avec le bouton gauche de la souris
            if (e.Button == MouseButtons.Left)
            {
                colonne = e.ColumnIndex;
                ligne = e.RowIndex;
                if (dataGridView_activiteGenerique.Rows[ligne].Cells[3].Value.ToString() != "")
                {
                    portefeuilleCompetences = Convert.ToInt32(dataGridView_activiteGenerique.Rows[ligne].Cells[3].Value.ToString());
                }
                loadTextButton(dataGridView_activiteGenerique.Rows[ligne].Cells[1].Value.ToString());
            }
            if (e.Button == MouseButtons.Right)
            {
                colonne = e.ColumnIndex;
                ligne = e.RowIndex;
                globales.actGenerique = Convert.ToInt32(dataGridView_activiteGenerique.Rows[ligne].Cells[0].Value.ToString());
                Point point = new Point(e.X, e.Y);
                contextMenuStrip1.Show(dataGridView_activiteGenerique, point);
            }
        }

        #endregion ActiviteGenerique

        #region ActiviteTerrain
        private void terrainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetDataGrid();
            this.dataGridView_activiteTerrain.Visible = true;
            //load profils poste
            System.Data.DataSet dsListeActiviteTerrain = new System.Data.DataSet();
            if (firstLoad == true)
            {
                string queryListeActiviteTerrain = "SELECT id_actTerrain AS idActTerrain, actTerrain_intitule AS Intitule, actTerrain_description AS Description, actTerrain_poste AS Poste, actTerrain_portefeuilleCompetences AS PortefeuilleCompetences FROM actTerrain ORDER BY actTerrain_intitule";
                MySqlDataAdapter daListeActiviteTerrain = new MySqlDataAdapter(queryListeActiviteTerrain, sConnect.con);
                daListeActiviteTerrain.Fill(dsListeActiviteTerrain, "actterrain");

                if (dsListeActiviteTerrain.Tables[0].Rows.Count > 0)
                {
                    this.dataGridView_activiteTerrain.DataSource = dsListeActiviteTerrain.Tables[0];
                    //mask useless columns
                    this.dataGridView_activiteTerrain.Columns[0].Visible = false;
                    this.dataGridView_activiteTerrain.Columns[3].Visible = false;
                    this.dataGridView_activiteTerrain.Columns[4].Visible = false;
                }
            }
            else
            {
                if (poste != null)
                {
                    string queryListeActiviteTerrain = "SELECT id_actTerrain AS idActTerrain, actTerrain_intitule AS Intitule, actTerrain_description AS Description, actTerrain_poste AS Poste, actTerrain_portefeuilleCompetences AS PortefeuilleCompetences FROM actTerrain WHERE actTerrain_poste = ?poste ORDER BY actTerrain_intitule";
                    MySqlDataAdapter daListeActiviteTerrain = new MySqlDataAdapter(queryListeActiviteTerrain, sConnect.con);
                    daListeActiviteTerrain.SelectCommand.Parameters.AddWithValue("?poste", poste);
                    daListeActiviteTerrain.Fill(dsListeActiviteTerrain, "actterrain");

                    if (dsListeActiviteTerrain.Tables[0].Rows.Count > 0)
                    {
                        this.dataGridView_activiteTerrain.DataSource = dsListeActiviteTerrain.Tables[0];
                        //mask useless columns
                        this.dataGridView_activiteTerrain.Columns[0].Visible = false;
                        this.dataGridView_activiteTerrain.Columns[3].Visible = false;
                        this.dataGridView_activiteTerrain.Columns[4].Visible = false;
                    }
                }
                if (portefeuilleCompetences != null)
                {
                    string queryListeActiviteTerrain = "SELECT id_actTerrain AS idActTerrain, actTerrain_intitule AS Intitule, actTerrain_description AS Description, actTerrain_poste AS Poste, actTerrain_portefeuilleCompetences AS PortefeuilleCompetences FROM actTerrain WHERE actTerrain_portefeuilleCompetences = ?portefeuilleCompetences ORDER BY actTerrain_intitule";
                    MySqlDataAdapter daListeActiviteTerrain = new MySqlDataAdapter(queryListeActiviteTerrain, sConnect.con);
                    daListeActiviteTerrain.SelectCommand.Parameters.AddWithValue("?portefeuilleCompetences", portefeuilleCompetences);
                    daListeActiviteTerrain.Fill(dsListeActiviteTerrain, "actterrain");

                    if (dsListeActiviteTerrain.Tables[0].Rows.Count > 0)
                    {
                        this.dataGridView_activiteTerrain.DataSource = dsListeActiviteTerrain.Tables[0];
                        //mask useless columns
                        this.dataGridView_activiteTerrain.Columns[0].Visible = false;
                        this.dataGridView_activiteTerrain.Columns[3].Visible = false;
                        this.dataGridView_activiteTerrain.Columns[4].Visible = false;
                    }
                }
            }
            loadButton();
            firstLoad = false;
        }

        private void dataGridView_activiteTerrain_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // si le click est effectué avec le bouton gauche de la souris
            if (e.Button == MouseButtons.Left)
            {
                colonne = e.ColumnIndex;
                ligne = e.RowIndex;
                if (dataGridView_activiteTerrain.Rows[ligne].Cells[3].Value.ToString() != "")
                {
                    poste = Convert.ToInt32(dataGridView_activiteTerrain.Rows[ligne].Cells[3].Value.ToString());
                }
                if (dataGridView_activiteTerrain.Rows[ligne].Cells[4].Value.ToString() != "")
                {
                    portefeuilleCompetences = Convert.ToInt32(dataGridView_activiteTerrain.Rows[ligne].Cells[4].Value.ToString());
                }
                loadTextButton(dataGridView_activiteTerrain.Rows[ligne].Cells[1].Value.ToString());
            }
            if (e.Button == MouseButtons.Right)
            {
                colonne = e.ColumnIndex;
                ligne = e.RowIndex;
                globales.actTerrain = Convert.ToInt32(dataGridView_activiteTerrain.Rows[ligne].Cells[0].Value.ToString());
                Point point = new Point(e.X, e.Y);
                contextMenuStrip1.Show(dataGridView_activiteTerrain, point);
            }
        }

        #endregion ActiviteTerrain

        #region PortefeuilleCompetences
        private void portefeuilleDeCompétencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetDataGrid();
            this.dataGridView_portefeuilleCompetences.Visible = true;
            //load profils poste
            System.Data.DataSet dsListePortefeuilleCompetences = new System.Data.DataSet();
            if (firstLoad == true)
            {
                string queryListePortefeuilleCompetences = "SELECT id_portefeuille AS idportefeuille, portefeuille_intitule AS Intitule, portefeuille_description AS Description FROM portefeuillecompetences ORDER BY portefeuille_intitule";
                MySqlDataAdapter daListePortefeuilleCompetences = new MySqlDataAdapter(queryListePortefeuilleCompetences, sConnect.con);
                daListePortefeuilleCompetences.Fill(dsListePortefeuilleCompetences, "portefeuillecompetences");

                if (dsListePortefeuilleCompetences.Tables[0].Rows.Count > 0)
                {
                    this.dataGridView_portefeuilleCompetences.DataSource = dsListePortefeuilleCompetences.Tables[0];
                    //mask useless columns
                    this.dataGridView_portefeuilleCompetences.Columns[0].Visible = false;
                }
            }
            else
            {
                if (portefeuilleCompetences != null)
                {
                    string queryListePortefeuilleCompetences = "SELECT id_portefeuille AS idportefeuille, portefeuille_intitule AS Intitule, portefeuille_description AS Description FROM portefeuillecompetences WHERE id_portefeuille = ?portefeuilleCompetences ORDER BY portefeuille_intitule";
                    MySqlDataAdapter daListePortefeuilleCompetences = new MySqlDataAdapter(queryListePortefeuilleCompetences, sConnect.con);
                    daListePortefeuilleCompetences.SelectCommand.Parameters.AddWithValue("?portefeuilleCompetences", portefeuilleCompetences);
                    daListePortefeuilleCompetences.Fill(dsListePortefeuilleCompetences, "portefeuillecompetences");

                    if (dsListePortefeuilleCompetences.Tables[0].Rows.Count > 0)
                    {
                        this.dataGridView_portefeuilleCompetences.DataSource = dsListePortefeuilleCompetences.Tables[0];
                        //mask useless columns
                        this.dataGridView_portefeuilleCompetences.Columns[0].Visible = false;
                    }
                }
            }
            loadButton();
            firstLoad = false;
        }

        private void dataGridView_portefeuilleCompetences_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // si le click est effectué avec le bouton gauche de la souris
            if (e.Button == MouseButtons.Left)
            {
                colonne = e.ColumnIndex;
                ligne = e.RowIndex;
                portefeuilleCompetences = Convert.ToInt32(dataGridView_portefeuilleCompetences.Rows[ligne].Cells[0].Value.ToString());
                loadTextButton(dataGridView_portefeuilleCompetences.Rows[ligne].Cells[1].Value.ToString());
            }
            if (e.Button == MouseButtons.Right)
            {
                colonne = e.ColumnIndex;
                ligne = e.RowIndex;
                globales.portefeuilleCompetences = Convert.ToInt32(dataGridView_portefeuilleCompetences.Rows[ligne].Cells[0].Value.ToString());
                Point point = new Point(e.X, e.Y);
                contextMenuStrip1.Show(dataGridView_portefeuilleCompetences, point);
            }
        }

        #endregion PortefeuilleCompetences

        private void menuItem_home_Click(object sender, EventArgs e)
        {
            this.reset();
            this.Hide();
        }

        private void rESETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.reset();
        }

        private void toolStripMenuItem_modifierValeurs_Click(object sender, EventArgs e)
        {
            if (globales.portefeuilleCompetences != null)
            {
                Portefeuille_creer portefeuille = new Portefeuille_creer();
                portefeuille.Show();
            }
            if (globales.emploi != null)
            {
                Emploi_creer emploi = new Emploi_creer();
                emploi.Show();
            }
            if (globales.poste != null)
            {
                Poste_creer poste = new Poste_creer();
                poste.Show();
            }
            if (globales.profilPoste != null)
            {
                ProfilPoste_creer profilPoste = new ProfilPoste_creer();
                profilPoste.Show();
            }
            if (globales.collaborateur != null)
            {
                Collaborateur_creer collaborateur = new Collaborateur_creer();
                collaborateur.Show();
            }
            if (globales.actTerrain != null)
            {
                Activite_creer actTerrain = new Activite_creer();
                actTerrain.Show();
            }
            if (globales.actGenerique != null)
            {
                Activite_creer actGenerique = new Activite_creer();
                actGenerique.Show();
            }

        }

        private void toolStripMenuItem_supprimerLigne_Click(object sender, EventArgs e)
        {
            String strConnect = @"server='80.15.195.96'; user id='root'; password='MySq1*'; database='serenade_db'";
            MySqlConnection con = null;

            DialogResult DialogResult = MessageBox.Show("Etes-vous sûr de vouloir supprimer cette donnée ?", "Suppression d'une entrée", MessageBoxButtons.YesNo);
            if (DialogResult == DialogResult.Yes)
            {
                con = new MySqlConnection(strConnect);
                con.Open();
                if (globales.portefeuilleCompetences != null)
                {
                    String CommandTxt = "DELETE FROM portefeuillecompetences WHERE id_portefeuille=?deletedID";
                    MySqlCommand comd = new MySqlCommand(CommandTxt, con);
                    comd.Prepare();
                    comd.Parameters.Add("?deletedID", MySqlDbType.Int16).Value = globales.portefeuilleCompetences;
                    comd.ExecuteNonQuery();
                }
                if (globales.emploi != null)
                {
                    String CommandTxt = "DELETE FROM emploi WHERE id_emploi=?deletedID";
                    MySqlCommand comd = new MySqlCommand(CommandTxt, con);
                    comd.Prepare();
                    comd.Parameters.Add("?deletedID", MySqlDbType.Int16).Value = globales.emploi;
                    comd.ExecuteNonQuery();
                }
                if (globales.poste != null)
                {
                    String CommandTxt = "DELETE FROM poste WHERE id_poste=?deletedID";
                    MySqlCommand comd = new MySqlCommand(CommandTxt, con);
                    comd.Prepare();
                    comd.Parameters.Add("?deletedID", MySqlDbType.Int16).Value = globales.poste;
                    comd.ExecuteNonQuery();
                }
                if (globales.profilPoste != null)
                {
                    String CommandTxt = "DELETE FROM profilposte WHERE id_profilPoste=?deletedID";
                    MySqlCommand comd = new MySqlCommand(CommandTxt, con);
                    comd.Prepare();
                    comd.Parameters.Add("?deletedID", MySqlDbType.Int16).Value = globales.profilPoste;
                    comd.ExecuteNonQuery();
                }
                if (globales.collaborateur != null)
                {
                    String CommandTxt = "DELETE FROM collaborateur WHERE id_collaborateur=?deletedID";
                    MySqlCommand comd = new MySqlCommand(CommandTxt, con);
                    comd.Prepare();
                    comd.Parameters.Add("?deletedID", MySqlDbType.Int16).Value = globales.collaborateur;
                    comd.ExecuteNonQuery();
                }
                if (globales.actTerrain != null)
                {
                    String CommandTxt = "DELETE FROM actterrain WHERE id_actTerrain=?deletedID";
                    MySqlCommand comd = new MySqlCommand(CommandTxt, con);
                    comd.Prepare();
                    comd.Parameters.Add("?deletedID", MySqlDbType.Int16).Value = globales.actTerrain;
                    comd.ExecuteNonQuery();
                }
                if (globales.actGenerique != null)
                {
                    String CommandTxt = "DELETE FROM actgenerique WHERE id_actGenerique=?deletedID";
                    MySqlCommand comd = new MySqlCommand(CommandTxt, con);
                    comd.Prepare();
                    comd.Parameters.Add("?deletedID", MySqlDbType.Int16).Value = globales.actGenerique;
                    comd.ExecuteNonQuery();
                }
            }
        }


    }
}
