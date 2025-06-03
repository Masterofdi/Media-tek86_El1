namespace Media_tek86
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_supprimer = new Button();
            btn_modifier = new Button();
            combo_box_service = new ComboBox();
            btn_ajouter_pers = new Button();
            txt_Tel = new TextBox();
            tel = new Label();
            textBox1 = new TextBox();
            Mail = new Label();
            txt_prenom = new TextBox();
            Prenom = new Label();
            label1 = new Label();
            Txt_nom = new TextBox();
            Ajouter_Perso = new Label();
            comboBoxTables = new ComboBox();
            dataGridViewListe = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewListe).BeginInit();
            SuspendLayout();
            // 
            // btn_supprimer
            // 
            btn_supprimer.Location = new Point(701, 405);
            btn_supprimer.Name = "btn_supprimer";
            btn_supprimer.Size = new Size(75, 23);
            btn_supprimer.TabIndex = 29;
            btn_supprimer.Text = "Supprimer";
            btn_supprimer.UseVisualStyleBackColor = true;
            // 
            // btn_modifier
            // 
            btn_modifier.Location = new Point(620, 405);
            btn_modifier.Name = "btn_modifier";
            btn_modifier.Size = new Size(75, 23);
            btn_modifier.TabIndex = 28;
            btn_modifier.Text = "Modifier";
            btn_modifier.UseVisualStyleBackColor = true;
            btn_modifier.Click += btn_modifier_Click_1;
            // 
            // combo_box_service
            // 
            combo_box_service.FormattingEnabled = true;
            combo_box_service.Location = new Point(539, 351);
            combo_box_service.Name = "combo_box_service";
            combo_box_service.Size = new Size(88, 23);
            combo_box_service.TabIndex = 27;
            combo_box_service.SelectedIndexChanged += combo_box_service_SelectedIndexChanged_1;
            // 
            // btn_ajouter_pers
            // 
            btn_ajouter_pers.Location = new Point(539, 405);
            btn_ajouter_pers.Name = "btn_ajouter_pers";
            btn_ajouter_pers.Size = new Size(75, 23);
            btn_ajouter_pers.TabIndex = 26;
            btn_ajouter_pers.Text = "Ajouter";
            btn_ajouter_pers.UseVisualStyleBackColor = true;
            btn_ajouter_pers.Click += btn_ajouter_pers_Click;
            // 
            // txt_Tel
            // 
            txt_Tel.Location = new Point(334, 405);
            txt_Tel.Name = "txt_Tel";
            txt_Tel.Size = new Size(169, 23);
            txt_Tel.TabIndex = 25;
            // 
            // tel
            // 
            tel.AutoSize = true;
            tel.Location = new Point(307, 405);
            tel.Name = "tel";
            tel.Size = new Size(21, 15);
            tel.TabIndex = 24;
            tel.Text = "Tel";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(334, 348);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(169, 23);
            textBox1.TabIndex = 23;
            // 
            // Mail
            // 
            Mail.AutoSize = true;
            Mail.Location = new Point(298, 351);
            Mail.Name = "Mail";
            Mail.Size = new Size(30, 15);
            Mail.TabIndex = 22;
            Mail.Text = "Mail";
            // 
            // txt_prenom
            // 
            txt_prenom.Location = new Point(94, 402);
            txt_prenom.Name = "txt_prenom";
            txt_prenom.Size = new Size(169, 23);
            txt_prenom.TabIndex = 21;
            // 
            // Prenom
            // 
            Prenom.AutoSize = true;
            Prenom.Location = new Point(39, 402);
            Prenom.Name = "Prenom";
            Prenom.Size = new Size(49, 15);
            Prenom.TabIndex = 20;
            Prenom.Text = "Prenom";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 351);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 19;
            label1.Text = "Nom";
            // 
            // Txt_nom
            // 
            Txt_nom.Location = new Point(94, 348);
            Txt_nom.Name = "Txt_nom";
            Txt_nom.Size = new Size(169, 23);
            Txt_nom.TabIndex = 18;
            // 
            // Ajouter_Perso
            // 
            Ajouter_Perso.AutoSize = true;
            Ajouter_Perso.Location = new Point(12, 318);
            Ajouter_Perso.Name = "Ajouter_Perso";
            Ajouter_Perso.Size = new Size(128, 15);
            Ajouter_Perso.TabIndex = 17;
            Ajouter_Perso.Text = "Gestion des utilisateurs";
            // 
            // comboBoxTables
            // 
            comboBoxTables.FormattingEnabled = true;
            comboBoxTables.Location = new Point(667, 318);
            comboBoxTables.Name = "comboBoxTables";
            comboBoxTables.Size = new Size(121, 23);
            comboBoxTables.TabIndex = 16;
            comboBoxTables.SelectedIndexChanged += comboBoxTables_SelectedIndexChanged_1;
            // 
            // dataGridViewListe
            // 
            dataGridViewListe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewListe.Location = new Point(109, 12);
            dataGridViewListe.Name = "dataGridViewListe";
            dataGridViewListe.Size = new Size(608, 264);
            dataGridViewListe.TabIndex = 15;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_supprimer);
            Controls.Add(btn_modifier);
            Controls.Add(combo_box_service);
            Controls.Add(btn_ajouter_pers);
            Controls.Add(txt_Tel);
            Controls.Add(tel);
            Controls.Add(textBox1);
            Controls.Add(Mail);
            Controls.Add(txt_prenom);
            Controls.Add(Prenom);
            Controls.Add(label1);
            Controls.Add(Txt_nom);
            Controls.Add(Ajouter_Perso);
            Controls.Add(comboBoxTables);
            Controls.Add(dataGridViewListe);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewListe).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btn_supprimer;
        private Button btn_modifier;
        private ComboBox combo_box_service;
        private Button btn_ajouter_pers;
        private TextBox txt_Tel;
        private Label tel;
        private TextBox textBox1;
        private Label Mail;
        private TextBox txt_prenom;
        private Label Prenom;
        private Label label1;
        private TextBox Txt_nom;
        private Label Ajouter_Perso;
        private ComboBox comboBoxTables;
        private DataGridView dataGridViewListe;
    }
}