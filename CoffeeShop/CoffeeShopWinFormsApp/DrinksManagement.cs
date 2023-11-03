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

        private void DGVDrinks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void LoadDrinksList()
        {
            var drinksList = drinksRepository.GetAllDrinks();
            try
            {
                source = new BindingSource();
                source.DataSource = drinksList;
                DGV_Drinks.DataSource = null;
                DGV_Drinks.AutoGenerateColumns = false;
                DGV_Drinks.ColumnCount = 3;
                DGV_Drinks.Columns[0].HeaderText = "Drinks";
                DGV_Drinks.Columns[0].DataPropertyName = "DrinksName";
                DGV_Drinks.Columns[1].HeaderText = "Price";
                DGV_Drinks.Columns[1].DataPropertyName = "Price";
                DGV_Drinks.Columns[2].HeaderText = "Status";
                DGV_Drinks.Columns[2].DataPropertyName = "Status";
                //DGV_Drinks.DataSource = source;
                Drink selectStatus = (Drink)source.Current;
                int status = selectStatus.Status;
                foreach (var drinks in (List<Drink>)source.DataSource)
                {                  
                    if (drinks.Status == 1)
                    {
                        DGV_Drinks.Rows.Add(drinks.DrinksName, drinks.Price, "Con hang");
                    }
                    if(drinks.Status == 0)
                    {
                        DGV_Drinks.Rows.Add(drinks.DrinksName, drinks.Price, "Het hang");
                    }
                }
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
    }
}
