using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotebookShelf.Domain;

namespace NotebookShelf.Repository
{
    public interface IBookShelfRepository
    {
        Category GetBookShelfCategory(string categoryName);

        IList<Category> GetBookShelfCategories();

        void TryAddNotebook(Notebook notebook, string categoryName);

        void TryAddCategory(string categoryName);
    }
}
