using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Media_tek86.dal;
using Media_tek86.model;
using MySql.Data.MySqlClient;

namespace Media_tek86
{

    public partial class Form2 : Form
    {
        private readonly PersonnelDal _persDal = new PersonnelDal();
        private readonly AbsenceDal _absDal = new AbsenceDal();
        private bool _enCoursDEdition = false;
        private int _idPersonnelEnCours = 0;

        public Form2()
        {


            InitializeComponent();

            btn_supprimer.Click += btn_supprimer_Click;

            comboBoxTables_SelectedIndexChanged(this, EventArgs.Empty);
            combo_box_service.Items.Add("1");
            combo_box_service.Items.Add("2");
            combo_box_service.Items.Add("3");
            comboBoxTables.Items.Add("responsable");
            comboBoxTables.Items.Add("absence");
            comboBoxTables.Items.Add("personnel");
            comboBoxTables.Items.Add("motif");
            comboBoxTables.Items.Add("service");
            comboBoxTables.SelectedIndex = 0; // Par défaut, première table sélectionnée



            comboBoxTables.SelectedIndexChanged += comboBoxTables_SelectedIndexChanged;
        }
        private void BtnSupprimerPers_Click(object sender, EventArgs e)
        {
            if (dataGridViewListe.CurrentRow == null) return;
            var row = (Personnel)dataGridViewListe.CurrentRow.DataBoundItem;
            if (row == null) return;

            if (MessageBox.Show("Confirmer suppression ?", "", MessageBoxButtons.YesNo)
                != DialogResult.Yes) return;

            _persDal.Delete(row.IdPersonnel);
            MessageBox.Show("Personnel supprimé.", "Succès");
            dataGridViewListe.DataSource = _persDal.GetAll();
            ClearPersonnelFields();

        }


        private void ClearPersonnelFields()
        {
            Txt_nom.Clear();
            txt_prenom.Clear();
            textBox1.Clear();
            txt_Tel.Clear();
            if (combo_box_service.Items.Count > 0)
                combo_box_service.SelectedIndex = 0;

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxTables_SelectedIndexChanged(object? sender, EventArgs e) // ajout ?
        {
            {
                if (comboBoxTables.SelectedItem == null)
                    return;

                string tableName = comboBoxTables.SelectedItem.ToString().ToLower();

                if (tableName == "personnel")
                {
                    // Lier la grille à List<Personnel>, pas à un DataTable
                    dataGridViewListe.DataSource = _persDal.GetAll();
                    return;
                }
                else if (tableName == "absence")
                {
                    dataGridViewListe.DataSource = _absDal.GetAll();
                    return;
                }

                // Sinon, on reste sur la version "générique" avec DataTable pour les autres tables
                string connectionString = "server=localhost;database=media-tek86;uid=root;pwd='';";
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = $"SELECT * FROM {tableName}";
                    var adapter = new MySqlDataAdapter(sql, conn);
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewListe.DataSource = dt;
                }
            }
        }
        public class ComboBoxItem
        {
            public int Value { get; }
            public string Text { get; }
            public ComboBoxItem(int value, string text)
            {
                Value = value;
                Text = text;
            }
            public override string ToString()
            {
                return Text;
            }
        }


        private void btn_ajouter_pers_Click(object sender, EventArgs e)
        {
            // 1) Validation des champs texte
            if (string.IsNullOrWhiteSpace(Txt_nom.Text) ||
                string.IsNullOrWhiteSpace(txt_prenom.Text) ||
                string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(txt_Tel.Text))
            {
                MessageBox.Show("Tous les champs sont obligatoires.", "Info");
                return;
            }

            // 2) Vérifier qu’un service est bien sélectionné
            if (combo_box_service.SelectedItem == null)
            {
                MessageBox.Show("Sélectionne un service.", "Info");
                return;
            }

            // 3) Récupérer l’ID du service depuis le ValueMember
            int idService = combo_box_service.SelectedIndex;

            // 4) Construire l’objet Personnel
            var nouveau = new Personnel(
                idPersonnel: 0,                         // 0 = nouvel enregistrement
                nom: Txt_nom.Text.Trim(),
                prenom: txt_prenom.Text.Trim(),
                idService: idService,
                mail: textBox1.Text.Trim(),
                telephone: txt_Tel.Text.Trim()
            );

            try
            {
                // 5) Insérer via le DAL
                _persDal.Insert(nouveau);

                MessageBox.Show("Personnel ajouté !", "Succès");

                // 6) Rafraîchir la grille
                dataGridViewListe.DataSource = _persDal.GetAll();

                // 7) Réinitialiser les champs
                Txt_nom.Clear();
                txt_prenom.Clear();
                textBox1.Clear();
                txt_Tel.Clear();
                combo_box_service.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout : " + ex.Message, "Erreur");
            }


        }






        private void Txt_nom_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_prenom_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Tel_TextChanged(object sender, EventArgs e)
        {

        }

        private void combo_box_service_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_modifier_Click(object sender, EventArgs e)
        {

        }

        private void btn_supprimer_Click(object sender, EventArgs e)

        {
            {
                if (dataGridViewListe.CurrentRow == null)
                {
                    MessageBox.Show("Sélectionne d'abord une ligne à supprimer.", "Information");
                    return;
                }

                string table = (comboBoxTables.SelectedItem as string)?.Trim().ToLower();
                if (string.IsNullOrEmpty(table))
                {
                    MessageBox.Show("Aucune table sélectionnée.", "Attention");
                    return;
                }

                // Cas où la grille est liée à List<Personnel>
                if (table == "personnel" && dataGridViewListe.CurrentRow.DataBoundItem is Personnel p)
                {
                    if (MessageBox.Show($"Supprimer {p.Nom} {p.Prenom} ?", "Confirmation", MessageBoxButtons.YesNo)
                        == DialogResult.Yes)
                    {
                        _persDal.Delete(p.IdPersonnel);
                        dataGridViewListe.DataSource = _persDal.GetAll();
                    }
                }
                // Cas où la grille est liée à un DataTable (DataBoundItem est DataRowView)
                else if (table == "personnel" && dataGridViewListe.CurrentRow.DataBoundItem is DataRowView drvPers)
                {
                    // On suppose ici que la colonne clé s'appelle "idPersonnel" dans le DataTable
                    int idPersonnel;
                    try
                    {
                        idPersonnel = Convert.ToInt32(drvPers["idPersonnel"]);
                    }
                    catch
                    {
                        MessageBox.Show("Impossible de lire l’ID du personnel.", "Erreur");
                        return;
                    }

                    if (MessageBox.Show($"Supprimer le personnel d’ID {idPersonnel} ?", "Confirmation", MessageBoxButtons.YesNo)
                        == DialogResult.Yes)
                    {
                        _persDal.Delete(idPersonnel);
                        dataGridViewListe.DataSource = _persDal.GetAll();
                    }
                }
                // Même logique pour la table "absence"
                else if (table == "absence" && dataGridViewListe.CurrentRow.DataBoundItem is Absence a)
                {
                    if (MessageBox.Show($"Supprimer l'absence du {a.DateDebut:d} au {a.DateFin:d} ?",
                                        "Confirmation", MessageBoxButtons.YesNo)
                        == DialogResult.Yes)
                    {

                        dataGridViewListe.DataSource = _absDal.GetAll();
                    }
                }
                else if (table == "absence" && dataGridViewListe.CurrentRow.DataBoundItem is DataRowView drvAbs)
                {
                    // On suppose que la colonne clé s'appelle "idAbsence" dans le DataTable
                    int idAbsence;
                    try
                    {
                        idAbsence = Convert.ToInt32(drvAbs["idAbsence"]);
                    }
                    catch
                    {
                        MessageBox.Show("Impossible de lire l’ID de l’absence.", "Erreur");
                        return;
                    }

                    if (MessageBox.Show($"Supprimer l'absence d’ID {idAbsence} ?", "Confirmation", MessageBoxButtons.YesNo)
                        == DialogResult.Yes)
                    {
                        _absDal.Delete(idAbsence);
                        dataGridViewListe.DataSource = _absDal.GetAll();
                    }
                }
                else
                {
                    MessageBox.Show($"Suppression non implémentée pour « {table} ».", "Info");
                }

            }

        }




        private void combo_box_service_SelectedIndexChanged_1(object? sender, EventArgs e)
        {
            if (combo_box_service != null)


            {
                string idservice = combo_box_service.SelectedItem.ToString()!; // ajout ! 


                string connectionString = "server=localhost;database=media-tek86;uid=root;pwd='';";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string sql = $"SELECT * FROM `personnel` ORDER BY `idservice` ";
                        MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridViewListe.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur lors du chargement : " + ex.Message);
                    }
                }

            }
            else
            {
                MessageBox.Show("Aucun ID sélectionné !");
            }


        }
        private void comboBoxTables_SelectedIndexChanged_1(object? sender, EventArgs e)
        {


        }


        private void btn_modifier_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewListe.CurrentRow == null)
            {
                MessageBox.Show("Sélectionnez d'abord une ligne à modifier.", "Info");
                return;
            }

            string table = comboBoxTables.SelectedItem?.ToString().ToLower();
            if (table == "personnel")
            {
                // --- Modification pour la table Personnel (uniquement si la DataSource est List<Personnel>) ---
                if (dataGridViewListe.CurrentRow.DataBoundItem is Personnel p)
                {
                    string nouveauNom = Microsoft.VisualBasic.Interaction.InputBox(
                        $"Nom (actuel : {p.Nom}) :",
                        "Modifier nom",
                        p.Nom);
                    if (string.IsNullOrWhiteSpace(nouveauNom)) return;

                    string nouveauPrenom = Microsoft.VisualBasic.Interaction.InputBox(
                        $"Prénom (actuel : {p.Prenom}) :",
                        "Modifier prénom",
                        p.Prenom);
                    if (string.IsNullOrWhiteSpace(nouveauPrenom)) return;

                    string nouveauMail = Microsoft.VisualBasic.Interaction.InputBox(
                        $"Email (actuel : {p.Mail}) :",
                        "Modifier email",
                        p.Mail);
                    if (string.IsNullOrWhiteSpace(nouveauMail)) return;

                    string nouveauTel = Microsoft.VisualBasic.Interaction.InputBox(
                        $"Téléphone (actuel : {p.Telephone}) :",
                        "Modifier téléphone",
                        p.Telephone);
                    if (string.IsNullOrWhiteSpace(nouveauTel)) return;

                    string ancienService = p.IdService.ToString();
                    string nouveauService = Microsoft.VisualBasic.Interaction.InputBox(
                        $"ID du service (actuel : {ancienService}) :",
                        "Modifier service",
                        ancienService);
                    if (!int.TryParse(nouveauService, out int idServiceModif)) return;

                    // Reconstruire l'objet complet avec tous les champs modifiés
                    var modifP = new Personnel(
                        idPersonnel: p.IdPersonnel,
                        nom: nouveauNom.Trim(),
                        prenom: nouveauPrenom.Trim(),
                        idService: idServiceModif,
                        mail: nouveauMail.Trim(),
                        telephone: nouveauTel.Trim()
                    );

                    // Appel à la méthode Update(int, Personnel)
                  
                    MessageBox.Show("Personnel mis à jour.", "Succès");
                    RefreshCurrentTable();
                }
                else
                {
                    MessageBox.Show("Pour modifier, assurez-vous que la DataSource du DataGridView soit une liste de Personnel.", "Info");
                }
            }
            else if (table == "absence")
            {
                // --- Modification pour la table Absence (uniquement si la DataSource est List<Absence>) ---
                if (dataGridViewListe.CurrentRow.DataBoundItem is Absence a)
                {
                    string ancienIdPers = a.IdPersonnel.ToString();
                    string nouveauIdPers = Microsoft.VisualBasic.Interaction.InputBox(
                        $"ID du personnel (actuel : {ancienIdPers}) :",
                        "Modifier ID personnel",
                        ancienIdPers);
                    if (!int.TryParse(nouveauIdPers, out int idPersModif)) return;

                    string ancienDebut = a.DateDebut.ToString("yyyy-MM-dd");
                    string nouvelleDateDebut = Microsoft.VisualBasic.Interaction.InputBox(
                        $"Date de début (actuelle : {ancienDebut}) :",
                        "Modifier date début",
                        ancienDebut);
                    if (!DateTime.TryParse(nouvelleDateDebut, out DateTime dateDebutModif)) return;

                    string ancienFin = a.DateFin.ToString("yyyy-MM-dd");
                    string nouvelleDateFin = Microsoft.VisualBasic.Interaction.InputBox(
                        $"Date de fin (actuelle : {ancienFin}) :",
                        "Modifier date fin",
                        ancienFin);
                    if (!DateTime.TryParse(nouvelleDateFin, out DateTime dateFinModif)) return;

                    string ancienMotif = a.IdMotif.ToString();
                    string nouveauMotif = Microsoft.VisualBasic.Interaction.InputBox(
                        $"ID du motif (actuel : {ancienMotif}) :",
                        "Modifier ID motif",
                        ancienMotif);
                    if (!int.TryParse(nouveauMotif, out int idMotifModif)) return;

                    // Reconstruire l'objet complet avec tous les champs modifiés
                    var modifA = new Absence(
                        
                        idPersonnel: idPersModif,
                        dateDebut: dateDebutModif,
                        dateFin: dateFinModif,
                        idMotif: idMotifModif
                    );

                    // Appel à la méthode Update(int, Absence)
                    

                    MessageBox.Show("Absence mise à jour.", "Succès");
                    RefreshCurrentTable();
                }
                else
                {
                    MessageBox.Show("Pour modifier, assurez-vous que la DataSource du DataGridView soit une liste d’Absence.", "Info");
                }
            }
            else
            {
                MessageBox.Show($"Modification non implémentée pour « {table} ».", "Info");
            }

        }








        
        private void RefreshCurrentTable()
        {
            string tableName = comboBoxTables.SelectedItem.ToString().ToLower();

            switch (tableName)
            {
                case "personnel":
                    combo_box_service.Enabled = true;
                    dataGridViewListe.DataSource = _persDal.GetAll();
                    break;

                case "absence":
                    combo_box_service.Enabled = false;
                    dataGridViewListe.DataSource = _absDal.GetAll();
                    break;

                default:
                    combo_box_service.Enabled = false;
                    var genericDal = new GenericDal();
                    DataTable dt = genericDal.GetAllFromTable(tableName);
                    dataGridViewListe.DataSource = dt;
                    break;
            }
        }
    }
}

