using System.Collections.ObjectModel;
using NotebookShelf.Domain;
using NotebookShelf.Util;

namespace NotebookShelf
{
    public class CategoryViewModel
    {
        private readonly Category _category;
        private readonly NotebookNameGenerator _notebookNameGenerator;

        public CategoryViewModel(Category category)
        {
            _category = category;
            _notebookNameGenerator = new NotebookNameGenerator();

            Initialize();
        }

        public string Name => _category.Name;

        public ObservableCollection<Notebook> Notebooks { get; set; } = new ObservableCollection<Notebook>();

        private void Initialize()
        {
            foreach (var categoryNotebook in _category.Notebooks)
            {
                Notebooks.Add(categoryNotebook);
            }
        }

        public string GetNextName() => _notebookNameGenerator.GetNextNotebookName();

        public string GetRandomCoverPath() => CoverPagePathHandler.GetRandomCoverPath();
    }
}