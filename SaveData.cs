using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesSearch
{
    internal class SaveData
    {
        public string searchDirectoryPath;
        public string searchPattern;

        public int founded;
        public int allFounded;

        public TimeSpan timeSinseStart;

        public SaveData(string searchDirectoryPath, string searchPattern, int founded, int allFounded, TimeSpan timeSinceStart)
        {
            this.searchDirectoryPath = searchDirectoryPath;
            this.searchPattern = searchPattern;

            this.founded = founded;
            this.allFounded = allFounded;

            this.timeSinseStart = timeSinceStart;
        }
    }

    public class SaveNode
    {
        public string name;
        public string parentName;

        public SaveNode(string name, string parentName)
        {
            this.name = name;
            this.parentName = parentName;
        }
    }
}
