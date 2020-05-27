using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace negocio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void login()
        {
            try
            {
                string query =
                    $"SELECT * FROM public.user WHERE username='{UserTextBox.Text}' AND password='{PasswordTxt.Text}'";

                var dt = ConnectionDB.ExecuteQuery(query);
                bool admin = Convert.ToBoolean(dt.Rows[0][2].ToString());

                if (dt.Rows.Count == 1)
                {
                    Hide();
                    if (admin)
                    {
                        new adminUser().Show();
                    }
                    else
                    {
                        new normalUser(dt.Rows[0][0].ToString()).Show();
                    }
                }
                else
                {
                    MessageBox.Show("Usuario y/o Contraseña Incorrecta");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login();
        }
    }
}