using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace negocio
{
    public partial class adminUser : Form
    {
        public adminUser()
        {
            InitializeComponent();
        }
        private void adminUser_Load(object sender, EventArgs e)
        {
            var usernames = ConnectionDB.ExecuteQuery("SELECT username FROM public.user");
            var usernamescombo = new List<string>();

            foreach (DataRow dr in usernames.Rows)
            {
                usernamescombo.Add(dr[0].ToString());
            }
            
            var usernamescombo2 = new List<string>();

            foreach (DataRow dr in usernames.Rows)
            {
                usernamescombo2.Add(dr[0].ToString());
            }

            comboBox1.DataSource = usernamescombo;
            comboBox2.DataSource = usernamescombo2;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") ||
                textBox2.Text.Equals(""))
            {
                MessageBox.Show("No deje los campos vacios");
            }
            else
            {
                try
                {
                    if (checkBox1.Checked)
                    {
                        ConnectionDB.ExecuteNonQuery($"INSERT INTO public.user VALUES(" +
                                                     $"'{textBox1.Text}'," +
                                                     $"'{textBox2.Text}'," +
                                                     $"{true})");
                    }
                    else
                    {
                        ConnectionDB.ExecuteNonQuery($"INSERT INTO public.user VALUES(" +
                                                     $"'{textBox1.Text}'," +
                                                     $"'{textBox2.Text}'," +
                                                     $"{false})");
                    }

                    MessageBox.Show("Se ha creado el usuario correctamente!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error!");
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}