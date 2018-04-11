namespace NTierApplication.WinForms
{
    partial class FormStart
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
            this.buttonProduct = new System.Windows.Forms.Button();
            this.buttonCategory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonProduct
            // 
            this.buttonProduct.Location = new System.Drawing.Point(79, 89);
            this.buttonProduct.Name = "buttonProduct";
            this.buttonProduct.Size = new System.Drawing.Size(179, 41);
            this.buttonProduct.TabIndex = 0;
            this.buttonProduct.Text = "Product";
            this.buttonProduct.UseVisualStyleBackColor = true;
            this.buttonProduct.Click += new System.EventHandler(this.buttonProduct_Click);
            // 
            // buttonCategory
            // 
            this.buttonCategory.Location = new System.Drawing.Point(79, 170);
            this.buttonCategory.Name = "buttonCategory";
            this.buttonCategory.Size = new System.Drawing.Size(179, 45);
            this.buttonCategory.TabIndex = 1;
            this.buttonCategory.Text = "Category";
            this.buttonCategory.UseVisualStyleBackColor = true;
            this.buttonCategory.Click += new System.EventHandler(this.buttonCategory_Click);
            // 
            // FormStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 373);
            this.Controls.Add(this.buttonCategory);
            this.Controls.Add(this.buttonProduct);
            this.Name = "FormStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormStart";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonProduct;
        private System.Windows.Forms.Button buttonCategory;
    }
}