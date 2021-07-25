using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using NotebookShelf.Annotations;
using NotebookShelf.CategoryDialog;
using NotebookShelf.Domain;
using NotebookShelf.Repository;
using NotebookShelf.Util;

namespace NotebookShelf
{
    public class NotebookShelfPageViewModel : INotifyPropertyChanged
    {

        private readonly IBookShelfRepository _bookShelfRepository;
        private CategoryViewModel _selectedCategory;

        public NotebookShelfPageViewModel()
        {
            _bookShelfRepository = new BookShelfRepository();

            AddNotebookCommand = new NotebookCommandViewModel(CanAddNotebook, OnAddNotebook);
            AddCategoryCommand = new NotebookCommandViewModel(CanAddCategory, OnAddCategory);

            Load();
            SelectedCategory = Categories.SingleOrDefault(x => x.Name == "Default");
        }

        private void Load()
        {
            Categories.Clear();

            var categories = _bookShelfRepository.GetBookShelfCategories().Select(x => new CategoryViewModel(x));
            foreach (var category in categories)
            {
                Categories.Add(category);
            }
        }

        #region Properties

        public ObservableCollection<CategoryViewModel> Categories { get; set; } = new ObservableCollection<CategoryViewModel>();

        public CategoryViewModel SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }

        public Func<DialogResult> RaiseCategoryAddDialog { get; set; }

        #endregion

        #region Commands

        public NotebookCommandViewModel AddNotebookCommand { get; set; }

        private bool CanAddNotebook(object _)
        {
            return true;
        }

        private void OnAddNotebook(object _)
        {
            var notebook = new Notebook
            {
                Name = SelectedCategory.GetNextName(),
                DateTime = DateTime.Today,
                CoverPath = SelectedCategory.GetRandomCoverPath()
            };

            try
            {
                _bookShelfRepository.TryAddNotebook(notebook, SelectedCategory.Name);
                SelectedCategory.Notebooks.Add(notebook);
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public NotebookCommandViewModel AddCategoryCommand { get; set; }

        private void OnAddCategory(object _)
        {
            var result = RaiseCategoryAddDialog();

            if (!result.Status || string.IsNullOrEmpty(result.Message))
            {
                return;
            }

            try
            {
                _bookShelfRepository.TryAddCategory(result.Message);
                var category = new CategoryViewModel(_bookShelfRepository.GetBookShelfCategory(result.Message));
                Categories.Add(category);
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                SelectedCategory = Categories.SingleOrDefault(x => x.Name == result.Message);
            }
        }

        private bool CanAddCategory(object _)
        {
            return true;
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}