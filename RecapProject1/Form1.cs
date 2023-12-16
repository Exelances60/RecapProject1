using RecapProject1.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecapProject1
{
    public partial class Form1 : Form
    {
        ProductDal _productDal = new ProductDal();
        CategoriesDal _categoriesDal = new CategoriesDal();


        public void LoadAllProducts()
        {
            dgwProduct.DataSource = _productDal.GetAll();
        }

        public void selectCategory()
        {
            cbxCategory.DataSource = _categoriesDal.GetAllCategory();
            cbxCategory.DisplayMember = "CategoryName";
            cbxCategory.ValueMember = "CategoryId";
            cbxCategory.SelectedIndex = 0;
            cbxCategory.Text = "Select";
        }

        public void LoadProductsByCategory(int categoryId)
        {
            dgwProduct.DataSource = _productDal.GetByCategory(categoryId);
        }

        public void LoadProductsByNameAndCategory(string name, int categoryId)
        {
            if (cbxCategory.SelectedIndex == 0)
            {
                dgwProduct.DataSource = _productDal.GetByName(name, 0);
            }
            else
            {
                dgwProduct.DataSource = _productDal.GetByName(name, categoryId);
            }
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAllProducts();
            selectCategory();
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCategory.SelectedIndex == 0)
            {
                LoadAllProducts();

            }
            else
            {
                LoadProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue));
            }
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            int categoryId = Convert.ToInt32(cbxCategory.SelectedValue);
            LoadProductsByNameAndCategory(tbxSearch.Text, categoryId);
        }
    }
}
