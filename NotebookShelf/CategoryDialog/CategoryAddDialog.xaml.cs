using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NotebookShelf.CategoryDialog
{
    /// <summary>
    /// Interaction logic for CategoryAddDialog.xaml
    /// </summary>
    public partial class CategoryAddDialog : Window
    {
        public CategoryAddDialog()
        {
            InitializeComponent();
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as CategoryAddDialogViewModel;

            if(vm != null && !string.IsNullOrEmpty(vm["CategoryName"]))
            {
                return;
            }

            DialogResult = true;
        }
    }
}
