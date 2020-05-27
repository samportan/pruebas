using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;

namespace negocio
{
    public partial class normalUser : Form
    {
        private string username = "";
        public normalUser(string nombre)
        {
            InitializeComponent();
            username = nombre;
        }
        
        private void normalUser_Load(object sender, EventArgs e)
        {
            var products = ConnectionDB.ExecuteQuery("SELECT \"productName\" FROM public.inventory");
            var productsCombo = new List<string>();
                        
            foreach (DataRow dr in products.Rows)
            {
                productsCombo.Add(dr[0].ToString());
            }
            
            ProductComboBox.DataSource = productsCombo;
        }

        private void buttonBuy_Click(object sender, EventArgs e)
        {
            int quantity = int.Parse(textBox1.Text);
            var qr = "SELECT id_product FROM public.inventory WHERE" +
                        $" \"productName\" = '{ProductComboBox.GetItemText(ProductComboBox.SelectedItem)}'";
            DataTable dt = ConnectionDB.ExecuteQuery(qr);
            //var ids = dt.Rows[0][0].ToString();
            int id = Convert.ToInt32(dt.Rows[0][0].ToString());            
        
            ConnectionDB.ExecuteNonQuery($"INSERT INTO public.orders(username, id_product, quantity)" +
                                         $" VALUES('{username}', {id}, {quantity})");

            MessageBox.Show("La orden ha sido registrada!!");
           
        }
    }
}