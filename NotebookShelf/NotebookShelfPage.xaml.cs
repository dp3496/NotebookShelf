using System.Windows;
using System.Windows.Controls;
using NotebookShelf.CategoryDialog;

namespace NotebookShelf
{
    /// <summary>
    /// Interaction logic for NotebookShelfPage.xaml
    /// </summary>
    public partial class NotebookShelfPage : Page
    {
        public NotebookShelfPage()
        {
            InitializeComponent();
            DataContextChanged += OnDataContextChanged;
        }

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ViewModel = DataContext as NotebookShelfPageViewModel;
            ViewModel.RaiseCategoryAddDialog = RaiseCategoryAddDialog;
        }

        private DialogResult RaiseCategoryAddDialog()
        {
            var dialogVm = new CategoryAddDialogViewModel();

            var dialog = new CategoryAddDialog {DataContext = dialogVm};
            dialog.Owner = Application.Current.MainWindow;
            
            var result = dialog.ShowDialog();
            var dialogResult = new DialogResult
            {
                Status = result.GetValueOrDefault(false),
                Message = dialogVm.CategoryName
            };

            return dialogResult;
        }

        public NotebookShelfPageViewModel ViewModel { get; set; }

        public void OnWindowResized()
        {
            ShowHideToggle.IsChecked = false;
        }
    }
}
