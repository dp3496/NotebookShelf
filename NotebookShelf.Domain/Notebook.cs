using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookShelf.Domain
{
    public class Notebook
    {
        public string Name { get; set; }

        public DateTime DateTime { get; set; }

        public string CoverPath { get; set; }
    }
}
