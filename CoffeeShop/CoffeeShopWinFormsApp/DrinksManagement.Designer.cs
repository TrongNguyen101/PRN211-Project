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
            ((System.ComponentModel.ISupportInitialize)DGV_Drinks).BeginInit();
            SuspendLayout();
            // 
            // DGV_Drinks
            // 
            DGV_Drinks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Drinks.Location = new Point(12, 264);
            DGV_Drinks.Name = "DGV_Drinks";
            DGV_Drinks.ReadOnly = true;
            DGV_Drinks.RowHeadersWidth = 51;
            DGV_Drinks.RowTemplate.Height = 29;
            DGV_Drinks.Size = new Size(776, 174);
            DGV_Drinks.TabIndex = 0;
            DGV_Drinks.CellContentClick += DGVDrinks_CellContentClick;
            // 
            // btn_Load
            // 
            btn_Load.Location = new Point(114, 129);
            btn_Load.Name = "btn_Load";
            btn_Load.Size = new Size(94, 29);
            btn_Load.TabIndex = 1;
            btn_Load.Text = "Load";
            btn_Load.UseVisualStyleBackColor = true;
            btn_Load.Click += btnLoad_Click;
            // 
            // frm_DrinksManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_Load);
            Controls.Add(DGV_Drinks);
            Name = "frm_DrinksManagement";
            Text = "DrinksManagement";
            Load += frmManegement_Load;
            ((System.ComponentModel.ISupportInitialize)DGV_Drinks).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DGV_Drinks;
        private Button btn_Load;
    }
}