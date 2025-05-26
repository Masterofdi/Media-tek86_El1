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
            dataGridViewListe = new DataGridView();
            comboBoxTables = new ComboBox();
            Ajouter_Perso = new Label();
            Txt_nom = new TextBox();
            label1 = new Label();
            Prenom = new Label();
            txt_prenom = new TextBox();
            Mail = new Label();
            textBox1 = new TextBox();
            tel = new Label();
            txt_Tel = new TextBox();
            btn_ajouter_pers = new Button();
            combo_box_service = new ComboBox();
            btn_modifier = new Button();
            btn_supprimer = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewListe).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewListe
            // 
            dataGridViewListe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewListe.Location = new Point(180, 12);
            dataGridViewListe.Name = "dataGridViewListe";
            dataGridViewListe.Size = new Size(608, 264);
            dataGridViewListe.TabIndex = 0;
            // 
            // comboBoxTables
            // 
            comboBoxTables.FormattingEnabled = true;
            comboBoxTables.Location = new Point(667, 307);
            comboBoxTables.Name = "comboBoxTables";
            comboBoxTables.Size = new Size(121, 23);
            comboBoxTables.TabIndex = 1;
            comboBoxTables.SelectedIndexChanged += comboBoxTables_SelectedIndexChanged;
            // 
            // Ajouter_Perso
            // 
            Ajouter_Perso.AutoSize = true;
            Ajouter_Perso.Location = new Point(12, 307);
            Ajouter_Perso.Name = "Ajouter_Perso";
            Ajouter_Perso.Size = new Size(46, 15);
            Ajouter_Perso.TabIndex = 2;
            Ajouter_Perso.Text = "Ajouter";
            Ajouter_Perso.Click += Ajouter_Perso_Click;
            // 
            // Txt_nom
            // 
            Txt_nom.Location = new Point(94, 337);
            Txt_nom.Name = "Txt_nom";
            Txt_nom.Size = new Size(169, 23);
            Txt_nom.TabIndex = 3;
            Txt_nom.TextChanged += Txt_nom_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 340);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 4;
            label1.Text = "Nom";
            // 
            // Prenom
            // 
            Prenom.AutoSize = true;
            Prenom.Location = new Point(39, 391);
            Prenom.Name = "Prenom";
            Prenom.Size = new Size(49, 15);
            Prenom.TabIndex = 5;
            Prenom.Text = "Prenom";
            // 
            // txt_prenom
            // 
            txt_prenom.Location = new Point(94, 391);
            txt_prenom.Name = "txt_prenom";
            txt_prenom.Size = new Size(169, 23);
            txt_prenom.TabIndex = 6;
            txt_prenom.TextChanged += txt_prenom_TextChanged;
            // 
            // Mail
            // 
            Mail.AutoSize = true;
            Mail.Location = new Point(298, 340);
            Mail.Name = "Mail";
            Mail.Size = new Size(30, 15);
            Mail.TabIndex = 7;
            Mail.Text = "Mail";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(334, 337);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(169, 23);
            textBox1.TabIndex = 8;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // tel
            // 
            tel.AutoSize = true;
            tel.Location = new Point(307, 394);
            tel.Name = "tel";
            tel.Size = new Size(21, 15);
            tel.TabIndex = 9;
            tel.Text = "Tel";
            // 
            // txt_Tel
            // 
            txt_Tel.Location = new Point(334, 394);
            txt_Tel.Name = "txt_Tel";
            txt_Tel.Size = new Size(169, 23);
            txt_Tel.TabIndex = 10;
            txt_Tel.TextChanged += txt_Tel_TextChanged;
            // 
            // btn_ajouter_pers
            // 
            btn_ajouter_pers.Location = new Point(539, 394);
            btn_ajouter_pers.Name = "btn_ajouter_pers";
            btn_ajouter_pers.Size = new Size(75, 23);
            btn_ajouter_pers.TabIndex = 11;
            btn_ajouter_pers.Text = "Ajouter";
            btn_ajouter_pers.UseVisualStyleBackColor = true;
            // 
            // combo_box_service
            // 
            combo_box_service.FormattingEnabled = true;
            combo_box_service.Location = new Point(539, 340);
            combo_box_service.Name = "combo_box_service";
            combo_box_service.Size = new Size(88, 23);
            combo_box_service.TabIndex = 12;
            combo_box_service.SelectedIndexChanged += combo_box_service_SelectedIndexChanged;
            // 
            // btn_modifier
            // 
            btn_modifier.Location = new Point(620, 394);
            btn_modifier.Name = "btn_modifier";
            btn_modifier.Size = new Size(75, 23);
            btn_modifier.TabIndex = 13;
            btn_modifier.Text = "Modifier";
            btn_modifier.UseVisualStyleBackColor = true;
            btn_modifier.Click += btn_modifier_Click;
            // 
            // btn_supprimer
            // 
            btn_supprimer.Location = new Point(701, 394);
            btn_supprimer.Name = "btn_supprimer";
            btn_supprimer.Size = new Size(75, 23);
            btn_supprimer.TabIndex = 14;
            btn_supprimer.Text = "Supprimer";
            btn_supprimer.UseVisualStyleBackColor = true;
            btn_supprimer.Click += btn_supprimer_Click;
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

        private DataGridView dataGridViewListe;
        private ComboBox comboBoxTables;
        private Label Ajouter_Perso;
        private TextBox Txt_nom;
        private Label label1;
        private Label Prenom;
        private TextBox txt_prenom;
        private Label Mail;
        private TextBox textBox1;
        private Label tel;
        private TextBox txt_Tel;
        private Button btn_ajouter_pers;
        private ComboBox combo_box_service;
        private Button btn_modifier;
        private Button btn_supprimer;
    }
}