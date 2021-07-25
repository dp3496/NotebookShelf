using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NotebookShelf.Util
{
    public static class CoverPagePathHandler
    {
        private static readonly IDictionary<int, string> _idToPath;

        static CoverPagePathHandler()
        {
            _idToPath = new Dictionary<int, string>();
            InitializeCoverPagePaths();
        }

        private static void InitializeCoverPagePaths()
        {
            var files = File.ReadAllLines(@"Resources/ResourceNames.txt").Select(x => $"Resources/Covers/{x}");

            int key = 1;

            foreach (var file in files)
            {
                _idToPath.Add(key, file);
                key++;
            }
        }

        public static string GetRandomCoverPath()
        {
            if (_idToPath.Count <= 0)
            {
                return string.Empty;
            }

            var random = new Random();
            var randomValue = random.Next(1, _idToPath.Count);

            return _idToPath[randomValue];
        }
    }
}