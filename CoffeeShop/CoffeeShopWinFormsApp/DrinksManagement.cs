using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;
using BusinessObject;
using DataAccess.Repository;

namespace CoffeeShopWinFormsApp
{
    public partial class frm_DrinksManagement : Form
    {
        IDrinksRepository drinksRepository = new DrinksRepository();
        BindingSource source;
        public frm_DrinksManagement()
        {
            InitializeComponent();
        }

        private void frmManegement_Load(object sender, EventArgs e)
        {

        }

        private void DGVDrink_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDrinkDetails frmDrinkDetails = new frmDrinkDetails
            {
                Text = "Update drink",
                InsertOrUpdate = true,
                DrinkInfo = GetDrinkObject(),
                DrinksRepository = drinksRepository
            };
            if (frmDrinkDetails.ShowDialog() == DialogResult.OK)
            {
                LoadDrinksList();
                source.Position = source.Count - 1;
            }
        }

        private Drink GetDrinkObject()
        {
            Drink drink = null;
            try
            {
                drink = new Drink
                {
                    DrinkId = int.Parse(txtID.Text),
                    DrinkName = txtDrinkName.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    Status = int.Parse(txtStatus.Text)
                };
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Get drink");
            }
            return drink;
        }

        private Drink GetDrinkObjectAdd()
        {
            Drink drink = null;
            try
            {
                drink = new Drink
                {
                    DrinkName = txtDrinkName.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    Status = int.Parse(txtStatus.Text)
                };
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Get drink");
            }
            return drink;
        }

        public void LoadDrinksList()
        {
            var drinksList = drinksRepository.GetAllDrinks();
            try
            {
                source = new BindingSource();
                source.DataSource = drinksList;

                txtID.DataBindings.Clear();
                txtDrinkName.DataBindings.Clear();
                txtPrice.DataBindings.Clear();
                txtStatus.DataBindings.Clear();

                txtID.DataBindings.Add("Text", source, "DrinkId");
                txtDrinkName.DataBindings.Add("Text", source, "DrinkName");
                txtPrice.DataBindings.Add("Text", source, "Price");
                txtStatus.DataBindings.Add("Text", source, "Status");
                DGV_Drinks.DataSource = null;

                DGV_Drinks.AutoGenerateColumns = false;
                DGV_Drinks.ColumnCount = 4;
                DGV_Drinks.Columns[0].HeaderText = "DrinkId";
                DGV_Drinks.Columns[0].DataPropertyName = "DrinkId";
                DGV_Drinks.Columns[1].HeaderText = "Drink Name";
                DGV_Drinks.Columns[1].DataPropertyName = "DrinkName";
                DGV_Drinks.Columns[2].HeaderText = "Price";
                DGV_Drinks.Columns[2].DataPropertyName = "Price";
                DGV_Drinks.Columns[3].HeaderText = "Status";
                DGV_Drinks.Columns[3].DataPropertyName = "Status";

                DGV_Drinks.DataSource = source;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Load drinks list");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadDrinksList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var drink = GetDrinkObject();
                drinksRepository.DeleteDrink(drink.DrinkId);
                LoadDrinksList();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Delete drink successfully");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmDrinkDetails frmDrinkDetails = new frmDrinkDetails
            {
                Text = "Add drink",
                InsertOrUpdate = false,
                DrinkInfo = GetDrinkObjectAdd(),
                DrinksRepository = drinksRepository
            };
            if (frmDrinkDetails.ShowDialog() == DialogResult.OK)
            {
                LoadDrinksList();
                source.Position = source.Count - 1;
            }
        }
    }
}
