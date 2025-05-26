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

namespace Media_tek86
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            comboBoxTables.Items.Add("responsable");
            comboBoxTables.Items.Add("absence");
            comboBoxTables.Items.Add("personnel");
            comboBoxTables.Items.Add("motif");
            comboBoxTables.Items.Add("service");
            comboBoxTables.SelectedIndex = 0; // Par défaut, première table sélectionnée

            comboBoxTables.SelectedIndexChanged += comboBoxTables_SelectedIndexChanged;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            combo_box_service.Items.Clear();

            if (combo_box_service.Items.Count > 0)
            {
                combo_box_service.SelectedIndex = 0;
            }
        }

        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTables.SelectedItem != null)

            {
                string tableName = comboBoxTables.SelectedItem.ToString();
                string connectionString = "server=localhost;database=media-tek86;uid=root;pwd='';";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string sql = $"SELECT * FROM {tableName}";
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
                MessageBox.Show("Aucune table sélectionnée !");
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
        private void RafraichirPersonnel()
        {
            string connectionString = "server=localhost;database=media-tek86;uid=root;pwd='';";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM personnel", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewListe.DataSource = dt;
            }
        }

        private void Ajouter_Perso_Click(object sender, EventArgs e)
        {
            {
                string nom = Txt_nom.Text.Trim();
                string mail = textBox1.Text.Trim();
                string telephone = txt_Tel.Text.Trim();


                if (combo_box_service.SelectedItem is ComboBoxItem serviceItem)
                {
                    int idservice = serviceItem.Value;
                    string connectionString = "server=localhost;database=media-tek86;uid=mediauser;pwd=superpass;";
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            conn.Open();
                            string sql = "INSERT INTO personnel (nom, prenom, idservice, mail, telephone) VALUES (@nom, @prenom, @idservice, @mail, @telephone)";
                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@nom", nom);
                            cmd.Parameters.AddWithValue("@prenom", Prenom);
                            cmd.Parameters.AddWithValue("@idservice", idservice);
                            cmd.Parameters.AddWithValue("@mail", mail);
                            cmd.Parameters.AddWithValue("@telephone", telephone);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Personnel ajouté !");
                            RafraichirPersonnel();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erreur : " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Sélectionne un service.");
                }
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

        }
    }
}
