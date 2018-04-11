using Autofac;
using NTierApplication.BLL.Services;
using NTierApplication.BLL.DependecyResolver;
using NTierApplication.Entity.Entities;
 

using System;
using System.Linq;
using System.Windows.Forms;

namespace NTierApplication.WinForms
{
    public partial class CategoryForm : Form
    {
        private readonly ILogService _serviceLogger;
        private readonly ICategoryService _serviceCategory;
        private readonly IProductService _serviceProduct;

        public CategoryForm()
        {
            _serviceLogger = AutofacDependencyContainer.Container.Resolve<ILogService>();

            _serviceProduct = AutofacDependencyContainer.Container.Resolve<IProductService>();
            _serviceCategory = AutofacDependencyContainer.Container.Resolve<ICategoryService>();

             
            InitializeComponent();
        }

        private void LoadCategories()
        {
            var model = _serviceCategory.GetAllList();

            model.ForEach(item =>
            {
                ListViewItem li = new ListViewItem();
                li.Text = item.Name;
                li.SubItems.Add(_serviceProduct.GetProductsByCategoryId(item.Id).Count().ToString());
                li.Tag = item;
                listView1.Items.Add(li);
            });
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var model = new Category
            {
                Name = txtCategoryName.Text
            };

            var result = _serviceCategory.Create(model);

            lblResult.Text = result.IsValid ? result.Message : string.Join("\n", result.Errors);

            listView1.Items.Clear();
            LoadCategories();
        }
    }
}
