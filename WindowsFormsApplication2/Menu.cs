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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button_creer_emploi_Click(object sender, EventArgs e)
        {
            Emploi_creer emploi = new Emploi_creer();
            emploi.Show();
        }

        private void button_creer_collaborateur_Click(object sender, EventArgs e)
        {
            Collaborateur_creer collaborateur = new Collaborateur_creer();
            collaborateur.Show();
        }

        private void button_creer_profil_Click(object sender, EventArgs e)
        {
            Poste_creer poste = new Poste_creer();
            poste.Show();
        }

        private void button_creer_profilPoste_Click(object sender, EventArgs e)
        {
            ProfilPoste_creer profilPoste = new ProfilPoste_creer();
            profilPoste.Show();
        }

        private void button_explorer_donnees_Click(object sender, EventArgs e)
        {
            Explorer explorer = new Explorer();
            explorer.Show();
        }

        private void button_manipuler_donnees_Click(object sender, EventArgs e)
        {
            Manipulate manipulate = new Manipulate();
            manipulate.Show();
        }

        private void button_creer_portefeuilleCompetences_Click_1(object sender, EventArgs e)
        {
            Portefeuille_creer portefeuille = new Portefeuille_creer();
            portefeuille.Show();
        }

        private void button_creer_actTerrain_Click_1(object sender, EventArgs e)
        {
            Activite_creer terrain = new Activite_creer();
            terrain.Show();
        }

        private void button_creer_actGenerique_Click_1(object sender, EventArgs e)
        {
            Activite_creer generique = new Activite_creer();
            generique.Show();
        }

        private void button_orphan_Click(object sender, EventArgs e)
        {
            Orphan orphan = new Orphan();
            orphan.Show();
        }

     
    }
}
