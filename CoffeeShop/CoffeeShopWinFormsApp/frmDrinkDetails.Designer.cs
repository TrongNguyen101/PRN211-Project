namespace CoffeeShopWinFormsApp
{
    partial class frmDrinkDetails
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
            button1 = new Button();
            btnCancel = new Button();
            lbDrinkName = new Label();
            txtDrinkName = new TextBox();
            lbPrice = new Label();
            txtPrice = new TextBox();
            lbStatus = new Label();
            cboStatus = new ComboBox();
            lbID = new Label();
            txtID = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.OK;
            button1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(129, 242);
            button1.Name = "button1";
            button1.Size = new Size(75, 36);
            button1.TabIndex = 0;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.Location = new Point(310, 242);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 36);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lbDrinkName
            // 
            lbDrinkName.AutoSize = true;
            lbDrinkName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbDrinkName.Location = new Point(25, 84);
            lbDrinkName.Name = "lbDrinkName";
            lbDrinkName.Size = new Size(98, 21);
            lbDrinkName.TabIndex = 2;
            lbDrinkName.Text = "DrinkName";
            // 
            // txtDrinkName
            // 
            txtDrinkName.Location = new Point(129, 86);
            txtDrinkName.Name = "txtDrinkName";
            txtDrinkName.Size = new Size(256, 23);
            txtDrinkName.TabIndex = 3;
            // 
            // lbPrice
            // 
            lbPrice.AutoSize = true;
            lbPrice.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbPrice.Location = new Point(25, 119);
            lbPrice.Name = "lbPrice";
            lbPrice.Size = new Size(48, 21);
            lbPrice.TabIndex = 4;
            lbPrice.Text = "Price";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(129, 117);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(256, 23);
            txtPrice.TabIndex = 5;
            // 
            // lbStatus
            // 
            lbStatus.AutoSize = true;
            lbStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbStatus.Location = new Point(25, 153);
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(57, 21);
            lbStatus.TabIndex = 6;
            lbStatus.Text = "Status";
            // 
            // cboStatus
            // 
            cboStatus.FormattingEnabled = true;
            cboStatus.Items.AddRange(new object[] { "0", "1" });
            cboStatus.Location = new Point(129, 153);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(256, 23);
            cboStatus.TabIndex = 7;
            // 
            // lbID
            // 
            lbID.AutoSize = true;
            lbID.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbID.Location = new Point(25, 49);
            lbID.Name = "lbID";
            lbID.Size = new Size(27, 21);
            lbID.TabIndex = 8;
            lbID.Text = "ID";
            // 
            // txtID
            // 
            txtID.Location = new Point(129, 51);
            txtID.Name = "txtID";
            txtID.Size = new Size(256, 23);
            txtID.TabIndex = 9;
            // 
            // frmDrinkDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 309);
            Controls.Add(txtID);
            Controls.Add(lbID);
            Controls.Add(cboStatus);
            Controls.Add(lbStatus);
            Controls.Add(txtPrice);
            Controls.Add(lbPrice);
            Controls.Add(txtDrinkName);
            Controls.Add(lbDrinkName);
            Controls.Add(btnCancel);
            Controls.Add(button1);
            Name = "frmDrinkDetails";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmDrinkDetails";
            Load += frmDrinkDetails_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button btnCancel;
        private Label lbDrinkName;
        private TextBox txtDrinkName;
        private Label lbPrice;
        private TextBox txtPrice;
        private Label lbStatus;
        private ComboBox cboStatus;
        private Label lbID;
        private TextBox txtID;
    }
}