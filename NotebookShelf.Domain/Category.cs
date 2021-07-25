using System.Collections.Generic;

namespace NotebookShelf.Domain
{
    public class Category
    {
        public string Name { get; set; }

        public IList<Notebook> Notebooks { get; set; } = new List<Notebook>();
    }
}