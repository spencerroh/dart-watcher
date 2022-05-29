using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace dart_watcher
{
    public class KeywordStorage
    {
        private string myPath;

        public KeywordStorage(string path)
        {
            myPath = path;
        }

        public void Save(IEnumerable<string> keywords)
        {
            using (var sw = new StreamWriter(File.Open(myPath, FileMode.Create)))
            {
                foreach (var keyword in keywords)
                {
                    sw.WriteLine(keyword);
                }
            }
        }

        public IEnumerable<string> Load()
        {
            if (!File.Exists(myPath))
                return Enumerable.Empty<string>();

            var keywords = new List<string>();
            using (StreamReader sr = new StreamReader(File.Open(myPath, FileMode.Open)))
            {
                keywords.Add(sr.ReadLine());
            }

            return keywords;
        }
    }
}
