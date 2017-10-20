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
    public partial class Orphan : Form
    {
        int colonne, ligne;
        connectSQL sConnect = new connectSQL();
        public Orphan()
        {
            InitializeComponent();
        }

        private void Orphan_Load(object sender, EventArgs e)
        {
            #region ActiviteGenerique

            //load act generiques
            System.Data.DataSet dsListeActiviteGenerique = new System.Data.DataSet();

            string queryListeActiviteGenerique = "SELECT id_actGenerique AS idActGenerique, actGenerique_intitule AS Intitule, actGenerique_description AS Description FROM actgenerique WHERE actGenerique_portefeuilleCompetences IS NULL ORDER BY actGenerique_intitule";
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
            # region Collaborateur

            //load profils poste
            System.Data.DataSet dsListeCollaborateur = new System.Data.DataSet();

            string queryListeCollaborateur = "SELECT id_collaborateur AS idCollaborateur, collaborateur_nom AS Nom, collaborateur_prenom AS Prenom, collaborateur_embauche AS DateEmbauche, collaborateur_mail AS Email, collaborateur_tel AS Telephone FROM collaborateur LEFT JOIN poste ON poste.poste_collaborateur = id_collaborateur WHERE id_poste IS NULL ORDER BY collaborateur_nom";
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
            #region PortefeuilleCompetences

            //load profils poste
            System.Data.DataSet dsListePortefeuilleCompetences = new System.Data.DataSet();

            string queryListePortefeuilleCompetences = "SELECT id_portefeuille AS idportefeuille, portefeuille_intitule AS Intitule, portefeuille_description AS Description FROM portefeuillecompetences LEFT JOIN collaborateur ON collaborateur.collaborateur_portefeuilleCompetences = id_portefeuille WHERE id_collaborateur IS NULL ORDER BY portefeuille_intitule";
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

            string queryListeEmploi = "SELECT id_emploi AS idEmploi, emploi_intitule AS Intitule, emploi_description AS Description, emploi_profilPoste AS profilPoste FROM emploi WHERE emploi_profilPoste IS NULL";
            MySqlDataAdapter daListeEmploi = new MySqlDataAdapter(queryListeEmploi, sConnect.con);
            daListeEmploi.Fill(dsListeEmploi, "emploi");

            if (dsListeEmploi.Tables[0].Rows.Count > 0)
            {
                this.dataGridView_emploi.Visible = true;
                this.dataGridView_emploi.DataSource = dsListeEmploi.Tables[0];
                //mask useless columns
                //this.dataGridView_emploi.Columns[0].Visible = false;
                //this.dataGridView_emploi.Columns[3].Visible = false;
            }
            #endregion Emploi
            
            

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

            string queryListeProfilPoste = "SELECT id_profilPoste AS idProfilPoste, profilPoste_appellation AS Appellation, profilPoste_description AS Description, profilPoste_filiere AS Filiere, profilPoste_categorie AS Categorie, profilPoste_gradeMax AS GradeMax, profilPoste_cotationRegime AS CotationRegime, profilPoste_direction AS Direction FROM profilPoste LEFT JOIN emploi ON emploi.emploi_profilPoste = id_profilPoste WHERE id_emploi IS NULL ORDER BY profilPoste_appellation";
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

          

            



            #region ActiviteTerrain

            //load profils poste
            System.Data.DataSet dsListeActiviteTerrain = new System.Data.DataSet();

            string queryListeActiviteTerrain = "SELECT id_actTerrain AS idActTerrain, actTerrain_intitule AS Intitule, actTerrain_description AS Description, actTerrain_poste AS Poste FROM actTerrain WHERE actTerrain_portefeuilleCompetences IS NULL ORDER BY actTerrain_intitule";
            MySqlDataAdapter daListeActiviteTerrain = new MySqlDataAdapter(queryListeActiviteTerrain, sConnect.con);
            daListeActiviteTerrain.Fill(dsListeActiviteTerrain, "actterrain");

            if (dsListeActiviteTerrain.Tables[0].Rows.Count > 0)
            {
                this.dataGridView_activiteTerrain.Visible = true;
                this.dataGridView_activiteTerrain.DataSource = dsListeActiviteTerrain.Tables[0];
                //mask useless columns
                this.dataGridView_activiteTerrain.Columns[0].Visible = false;
                this.dataGridView_activiteTerrain.Columns[3].Visible = false;
                this.dataGridView_activiteTerrain.Columns[4].Visible = false;
            }

            #endregion ActiviteTerrain

        }

        #region DoubleClick
        private void dataGridView_portefeuilleCompetences_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            colonne = e.ColumnIndex;
            ligne = e.RowIndex;
            globales.portefeuilleCompetences = Convert.ToInt32(dataGridView_portefeuilleCompetences.Rows[ligne].Cells[0].Value.ToString());
            
            Portefeuille_creer portefeuille = new Portefeuille_creer();
            portefeuille.Show();
        }

        private void dataGridView_collaborateur_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            colonne = e.ColumnIndex;
            ligne = e.RowIndex;
            globales.collaborateur = Convert.ToInt32(dataGridView_collaborateur.Rows[ligne].Cells[0].Value.ToString());

            Collaborateur_creer collaborateur = new Collaborateur_creer();
            collaborateur.Show();
        }

        private void dataGridView_activiteGenerique_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            colonne = e.ColumnIndex;
            ligne = e.RowIndex;
            globales.actGenerique = Convert.ToInt32(dataGridView_activiteGenerique.Rows[ligne].Cells[0].Value.ToString());

            Activite_creer activites = new Activite_creer();
            activites.Show();
        }

        private void dataGridView_activiteTerrain_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            colonne = e.ColumnIndex;
            ligne = e.RowIndex;
            globales.actTerrain = Convert.ToInt32(dataGridView_activiteTerrain.Rows[ligne].Cells[0].Value.ToString());

            Activite_creer activites = new Activite_creer();
            activites.Show();
        }

        private void dataGridView_emploi_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            colonne = e.ColumnIndex;
            ligne = e.RowIndex;
            globales.emploi = Convert.ToInt32(dataGridView_emploi.Rows[ligne].Cells[0].Value.ToString());

            Emploi_creer emploi = new Emploi_creer();
            emploi.Show();
        }

        private void dataGridView_poste_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            colonne = e.ColumnIndex;
            ligne = e.RowIndex;
            globales.poste = Convert.ToInt32(dataGridView_poste.Rows[ligne].Cells[0].Value.ToString());

            Poste_creer poste = new Poste_creer();
            poste.Show();
        }

        private void dataGridView_profilPoste_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            colonne = e.ColumnIndex;
            ligne = e.RowIndex;
            globales.profilPoste = Convert.ToInt32(dataGridView_profilPoste.Rows[ligne].Cells[0].Value.ToString());

            ProfilPoste_creer profilPoste = new ProfilPoste_creer();
            profilPoste.Show();
        }
    
    #endregion DoubleClick
    
    }
}
