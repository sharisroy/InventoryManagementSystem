using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryManagementSystem.Manager;
using InventoryManagementSystem.Model;

namespace InventoryManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductManager aProductManager = new ProductManager();
        CategoryManager aCategoryManager = new CategoryManager();
        private void showButton_Click(object sender, EventArgs e)
        {

            List<ProductWithCategory> products = aProductManager.GetAllProducts();

            productListView.Items.Clear();
            foreach (ProductWithCategory product in products)
            {

                ListViewItem item = new ListViewItem();
                item.Text = product.Name;
                item.SubItems.Add(product.CategoryName.ToString());
                item.SubItems.Add(product.Quantity.ToString());

                productListView.Items.Add(item);
            }

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Product aProduct = new Product();

                aProduct.Name = nameTextBox.Text;
                aProduct.CategoryId = Convert.ToInt32(catagoriComboBox.SelectedValue);
                aProduct.Quantity = Convert.ToInt32(quantityTextBox.Text);



                string message = aProductManager.saveProductManger(aProduct);

                // products.Add(aProduct);

                MessageBox.Show(message);
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Please Fill All Data \n\nor \n\n The Error is " + ex.ToString());
            }
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            catagoriComboBox.Items.Clear();
            List<Category> categories = aCategoryManager.GetAllCategories();
            catagoriComboBox.DataSource = categories;
            catagoriComboBox.DisplayMember = "NameCategory";
            catagoriComboBox.ValueMember = "IdCategory";
        }
    }
}
