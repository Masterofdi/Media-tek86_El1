using MySql.Data.MySqlClient;

namespace Media_tek86
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_access_Click(object sender, EventArgs e)
        {
            string login = txt_Login.Text;
            string password = txt_Psw.Text;



            string connectionString = "server=localhost;database=media-tek86;uid=HADES;pwd='SAYHELLO';";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM responsable WHERE login = @login AND pwd = SHA2(@password, 256)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 1)
                    {
                        // Connexion OK → Ouvre Form2
                        Form2 mainApp = new Form2();
                        mainApp.Show();
                        this.Hide(); //  pour fermer la fenêtre de login
                    }
                    else
                    {
                        MessageBox.Show("Login ou mot de passe incorrect.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur de connexion à la base : " + ex.Message);
                }
            }
        }
    }
}
