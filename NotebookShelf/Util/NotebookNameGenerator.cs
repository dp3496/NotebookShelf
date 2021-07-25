namespace NotebookShelf.Util
{
    public class NotebookNameGenerator
    {
        private int _count = 0;

        public string GetNextNotebookName()
        {
            _count++;
            return $"Book-{_count}";
        }
    }
}