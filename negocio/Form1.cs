using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace negocio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new adminUser();
            form.Show();
            /*
            if (textBox1.Text.Equals("") ||
                textBox2.Text.Equals(""))
            {
                MessageBox.Show("No se pueden dejar campos vacios!!");
            }
            else
            {
                try
                {
                    Boolean admin;
                    var qw =  ConnectionDB.ExecuteQuery($"SELECT admin FROM \'user\' WHERE" +
                                                        $" username = '{textBox1.Text}' AND " +
                                                        $"password = '{textBox2.Text}'");
                    admin = Convert.ToBoolean(qw);
                    //si tiene al menos un valor, devuelve true, caso contrario devuelve false
                    if (admin == true)
                    {
                        /*Form form2 = new normalUser();
                        form2.Show();
                        
                    }else
                    {
                        Form form = new adminUser();
                        form.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error!");
                }
            }
            */
        }
    }
}