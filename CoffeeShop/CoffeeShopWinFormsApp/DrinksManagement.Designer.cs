namespace CoffeeShopWinFormsApp
{
    partial class frm_DrinksManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DGV_Drinks = new DataGridView();
            btn_Load = new Button();
            lb_DrinkName = new Label();
            txtDrinkName = new TextBox();
            lb_Price = new Label();
            txtPrice = new TextBox();
            btnDelete = new Button();
            lbStatus = new Label();
            txtStatus = new TextBox();
            lbID = new Label();
            txtID = new TextBox();
            btnNew = new Button();
            ((System.ComponentModel.ISupportInitialize)DGV_Drinks).BeginInit();
            SuspendLayout();
            // 
            // DGV_Drinks
            // 
            DGV_Drinks.BackgroundColor = Color.White;
            DGV_Drinks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Drinks.Location = new Point(12, 198);
            DGV_Drinks.Margin = new Padding(3, 2, 3, 2);
            DGV_Drinks.Name = "DGV_Drinks";
            DGV_Drinks.ReadOnly = true;
            DGV_Drinks.RowHeadersWidth = 51;
            DGV_Drinks.RowTemplate.Height = 29;
            DGV_Drinks.Size = new Size(676, 130);
            DGV_Drinks.TabIndex = 0;
            DGV_Drinks.CellDoubleClick += DGVDrink_CellDoubleClick;
            // 
            // btn_Load
            // 
            btn_Load.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Load.Location = new Point(141, 138);
            btn_Load.Margin = new Padding(3, 2, 3, 2);
            btn_Load.Name = "btn_Load";
            btn_Load.Size = new Size(68, 33);
            btn_Load.TabIndex = 1;
            btn_Load.Text = "Load";
            btn_Load.UseVisualStyleBackColor = true;
            btn_Load.Click += btnLoad_Click;
            // 
            // lb_DrinkName
            // 
            lb_DrinkName.AutoSize = true;
            lb_DrinkName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lb_DrinkName.Location = new Point(23, 85);
            lb_DrinkName.Name = "lb_DrinkName";
            lb_DrinkName.Size = new Size(102, 21);
            lb_DrinkName.TabIndex = 2;
            lb_DrinkName.Text = "Drink Name";
            // 
            // txtDrinkName
            // 
            txtDrinkName.Location = new Point(131, 87);
            txtDrinkName.Name = "txtDrinkName";
            txtDrinkName.Size = new Size(194, 23);
            txtDrinkName.TabIndex = 3;
            // 
            // lb_Price
            // 
            lb_Price.AutoSize = true;
            lb_Price.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lb_Price.Location = new Point(376, 85);
            lb_Price.Name = "lb_Price";
            lb_Price.Size = new Size(48, 21);
            lb_Price.TabIndex = 4;
            lb_Price.Text = "Price";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(439, 87);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(194, 23);
            txtPrice.TabIndex = 5;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.Location = new Point(470, 138);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(68, 33);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // lbStatus
            // 
            lbStatus.AutoSize = true;
            lbStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbStatus.Location = new Point(376, 39);
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(57, 21);
            lbStatus.TabIndex = 7;
            lbStatus.Text = "Status";
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(439, 37);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(194, 23);
            txtStatus.TabIndex = 8;
            // 
            // lbID
            // 
            lbID.AutoSize = true;
            lbID.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbID.Location = new Point(23, 39);
            lbID.Name = "lbID";
            lbID.Size = new Size(27, 21);
            lbID.TabIndex = 9;
            lbID.Text = "ID";
            // 
            // txtID
            // 
            txtID.Location = new Point(131, 41);
            txtID.Name = "txtID";
            txtID.Size = new Size(194, 23);
            txtID.TabIndex = 10;
            // 
            // btnNew
            // 
            btnNew.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnNew.Location = new Point(306, 138);
            btnNew.Margin = new Padding(3, 2, 3, 2);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(68, 33);
            btnNew.TabIndex = 11;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // frm_DrinksManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(700, 339);
            Controls.Add(btnNew);
            Controls.Add(txtID);
            Controls.Add(lbID);
            Controls.Add(txtStatus);
            Controls.Add(lbStatus);
            Controls.Add(btnDelete);
            Controls.Add(txtPrice);
            Controls.Add(lb_Price);
            Controls.Add(txtDrinkName);
            Controls.Add(lb_DrinkName);
            Controls.Add(btn_Load);
            Controls.Add(DGV_Drinks);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frm_DrinksManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DrinksManagement";
            Load += frmManegement_Load;
            ((System.ComponentModel.ISupportInitialize)DGV_Drinks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DGV_Drinks;
        private Button btn_Load;
        private Label lb_DrinkName;
        private TextBox txtDrinkName;
        private Label lb_Price;
        private TextBox txtPrice;
        private Button btnDelete;
        private Label lbStatus;
        private TextBox txtStatus;
        private Label lbID;
        private TextBox txtID;
        private Button btnNew;
    }
}