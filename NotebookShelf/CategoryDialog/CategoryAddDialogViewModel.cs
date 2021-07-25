using NotebookShelf.Annotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NotebookShelf.CategoryDialog
{
    public class CategoryAddDialogViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private const string ErrorMessage = "Category Name cannot be empty";
        public string CategoryName { get; set; }

        public string Error { get; set; }

        public string this[string columnName]
        {
            get
            {
                if(columnName == nameof(CategoryName) && string.IsNullOrEmpty(CategoryName))
                {
                    Error = ErrorMessage;
                }
                else
                {
                    Error = string.Empty;
                }


                OnPropertyChanged(nameof(Error));
                return Error;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventArgs = new PropertyChangedEventArgs(propertyName);
            PropertyChanged?.Invoke(this, eventArgs);
        }
    }
}