using System;
using System.Collections.Generic;
using System.Linq;
using NotebookShelf.Domain;

namespace NotebookShelf.Repository
{
    public class BookShelfRepository : IBookShelfRepository
    {
        private readonly IDictionary<string, Category> _nameToCategories;

        public BookShelfRepository()
        {
            _nameToCategories = new Dictionary<string, Category>();

            TryAddCategory("Default");
        }

        public Category GetBookShelfCategory(string categoryName)
        {
            if (_nameToCategories.TryGetValue(categoryName, out var category))
            {
                return category;
            }

            throw new ArgumentException("category not found");
        }

        public IList<Category> GetBookShelfCategories()
        {
            return _nameToCategories.Values.ToList();
        }

        public void TryAddNotebook(Notebook notebook, string categoryName)
        {
            if (_nameToCategories.TryGetValue(categoryName, out var category))
            {
                category.Notebooks.Add(notebook);
            }
        }

        public void TryAddCategory(string categoryName)
        {
            if (_nameToCategories.TryGetValue(categoryName, out var _))
            {
                throw new ArgumentException("category with same name already exists");
            }

            _nameToCategories.Add(categoryName, new Category {Name = categoryName});
        }
    }
}