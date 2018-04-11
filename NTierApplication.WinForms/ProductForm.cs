using Autofac;
using NTierApplication.BLL.Services;
using NTierApplication.BLL.DependecyResolver;
using NTierApplication.Entity.Entities;
 
using System;
using System.Windows.Forms;

namespace NTierApplication.WinForms
{
    public partial class ProductForm : Form
    {
        private readonly IProductService  _serviceProduct;
        private readonly ICategoryService _serviceCategory;

        private readonly ILogService _serviceLogger;

        public ProductForm()
        {
            _serviceLogger = AutofacDependencyContainer.Container.Resolve<ILogService>();
            
            _serviceProduct = AutofacDependencyContainer.Container.Resolve<IProductService>();
            _serviceCategory = AutofacDependencyContainer.Container.Resolve<ICategoryService>();
             

            InitializeComponent();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            #region ContextMenu

            ContextMenu menu = new ContextMenu();
            menu.MenuItems.Add("Update", new EventHandler(Product_Update));
            menu.MenuItems.Add("Delete", new EventHandler(Product_Delete));

            lstProducts.ContextMenu = menu;


            #endregion

            #region ListView

            GetProducts();
            
            #endregion

            #region CategoryComboBox

            cmbCategory.DataSource = _serviceCategory.GetAllList();
            cmbCategory.ValueMember = "Id";
            cmbCategory.DisplayMember = "Name";

            #endregion
        }

        private void Product_Delete(object sender, EventArgs e)
        {
            Product selected = lstProducts.FocusedItem.Tag as Product;

            _serviceProduct.Delete(selected.Id);
            lstProducts.Items.Clear();
            GetProducts();

        }

        private void Product_Update(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void GetProducts()
        {
            var model = _serviceProduct.GetAllProducts();

            model.ForEach(item =>
            {
                ListViewItem li = new ListViewItem();
                li.Text = item.Name;
                li.SubItems.Add(item.Price.ToString());
                li.SubItems.Add(item.Stock.ToString());
                li.SubItems.Add(_serviceCategory.GetById((int)item.CategoryId).ToString());
                li.Tag = item;

                lstProducts.Items.Add(li);
            });

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Product model = new Product
            {
                Name = txtProductName.Text,
                Price = decimal.Parse(txtPrice.Text),
                Stock = short.Parse(txtStock.Text),
                CategoryId = (cmbCategory.SelectedItem as Category).Id
            };

            var result = _serviceProduct.ProductSave(model);

            lblResult.Text = result.IsValid ? result.Message : string.Join("\n",result.Errors);

            lstProducts.Items.Clear();
            GetProducts();

        }
    }
}
