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
             if (textBox5.Text.Equals(""))
             {
                 MessageBox.Show("Llene todos los campos");
             }
             else
             {
                 try
                 {
                     
                     ConnectionDB.ExecuteNonQuery($"DELETE FROM public.orders WHERE" +
                                                      $" username = '{textBox5.Text}'");
                     ConnectionDB.ExecuteNonQuery($"DELETE FROM public.user WHERE" +
                                                      $" username = '{textBox5.Text}'");

                     MessageBox.Show("Se ha eliminado el usuario");
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show("Ha ocurrido un error!");
                 }
             }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.Equals("") ||
                textBox4.Text.Equals(""))
            {
                MessageBox.Show("Llene todos los campos");
            }
            else
            {
                try
                {
                    if (checkBox1.Checked)
                    {
                        string up = $"UPDATE public.user SET password = '{textBox4.Text}', " +
                                    $"admin = {true} WHERE username = '{textBox6.Text}'";
                        ConnectionDB.ExecuteNonQuery(up);
                    }
                    else
                    {
                        string up = $"UPDATE public.user SET password = '{textBox4.Text}', " +
                                    $"admin = {false} WHERE username = '{textBox6.Text}'";
                        ConnectionDB.ExecuteNonQuery(up);
                    }

                    MessageBox.Show("Se ha modificado el usuario");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ha ocurrido un error");
                }
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox9.Text.Equals("") ||
                textBox13.Text.Equals("") ||
                textBox14.Text.Equals("") ||
                textBox8.Text.Equals(""))
            {
                MessageBox.Show("Llene todos los campos");
            }
            else
            {
                try
                {
                    var price = Convert.ToDouble(textBox13.Text);
                    var stock = Convert.ToInt32(textBox14.Text);
                    ConnectionDB.ExecuteNonQuery($"INSERT INTO public.inventory(\"productName\", description, price, stock)" +
                                                 $" VALUES('{textBox9.Text}', '{textBox8.Text}', {price}, {stock})");
                        
                        MessageBox.Show("Se ha agregado al inventario");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
            }
        }
        
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = ConnectionDB.ExecuteQuery($"SELECT * FROM public.orders");
                    
                dataGridView1.DataSource = dt;
                MessageBox.Show("Datos obtenidos exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema");
            }
        }
    }
}

