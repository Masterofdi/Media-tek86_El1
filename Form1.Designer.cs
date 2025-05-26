namespace Media_tek86
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbl_Login = new Label();
            lbl_psw = new Label();
            txt_Psw = new TextBox();
            txt_Login = new TextBox();
            btn_access = new Button();
            SuspendLayout();
            // 
            // lbl_Login
            // 
            lbl_Login.AutoSize = true;
            lbl_Login.Location = new Point(34, 27);
            lbl_Login.Name = "lbl_Login";
            lbl_Login.Size = new Size(37, 15);
            lbl_Login.TabIndex = 0;
            lbl_Login.Text = "Login";
            // 
            // lbl_psw
            // 
            lbl_psw.AutoSize = true;
            lbl_psw.Location = new Point(43, 66);
            lbl_psw.Name = "lbl_psw";
            lbl_psw.Size = new Size(28, 15);
            lbl_psw.TabIndex = 1;
            lbl_psw.Text = "Psw";
            // 
            // txt_Psw
            // 
            txt_Psw.Location = new Point(124, 63);
            txt_Psw.Name = "txt_Psw";
            txt_Psw.Size = new Size(100, 23);
            txt_Psw.TabIndex = 2;
            // 
            // txt_Login
            // 
            txt_Login.Location = new Point(124, 19);
            txt_Login.Name = "txt_Login";
            txt_Login.Size = new Size(100, 23);
            txt_Login.TabIndex = 3;
            // 
            // btn_access
            // 
            btn_access.Location = new Point(256, 82);
            btn_access.Name = "btn_access";
            btn_access.Size = new Size(38, 23);
            btn_access.TabIndex = 4;
            btn_access.Text = "OK";
            btn_access.UseVisualStyleBackColor = true;
            btn_access.Click += btn_access_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(306, 117);
            Controls.Add(btn_access);
            Controls.Add(txt_Login);
            Controls.Add(txt_Psw);
            Controls.Add(lbl_psw);
            Controls.Add(lbl_Login);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Login;
        private Label lbl_psw;
        private TextBox txt_Psw;
        private TextBox txt_Login;
        private Button btn_access;
    }
}
