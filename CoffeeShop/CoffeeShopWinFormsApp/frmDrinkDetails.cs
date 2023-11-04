using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopWinFormsApp
{
    public partial class frmDrinkDetails : Form
    {
        public IDrinksRepository DrinksRepository { get; set; }
        public bool InsertOrUpdate { get; set; }
        public Drink DrinkInfo { get; set; }

        public frmDrinkDetails()
        {
            InitializeComponent();
        }

        private void frmDrinkDetails_Load(object sender, EventArgs e)
        {
            cboStatus.SelectedIndex = 0;
            txtID.Enabled = !InsertOrUpdate;

            if (InsertOrUpdate == true)
            {
                txtID.Text = DrinkInfo.DrinkId.ToString();
                txtDrinkName.Text = DrinkInfo.DrinkName;
                txtPrice.Text = DrinkInfo.Price.ToString();
                cboStatus.Text = DrinkInfo.Status.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var drink = new Drink
                {
                    DrinkId = int.Parse(txtID.Text),
                    DrinkName = txtDrinkName.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    Status = int.Parse(cboStatus.Text),
                };
                if (InsertOrUpdate == false)
                {
                    DrinksRepository.AddDrink(drink);
                }
                else
                {
                    DrinksRepository.UpdateDrink(drink);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new drink" : "Update a drink");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();
    }
}
