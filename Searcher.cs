using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilesSearch
{
    internal class Searcher
    {
        private string startingDirectory;
        private string searchPattern;
        private TreeView treeView;
        private SearchNode rootNode;

        private Stopwatch stopwatch;

        private Queue<SearchNode> nodesQueue;

        private Progress<int> foundedProgress;
        private Progress<string> currentDirectoryProgress;
        public bool IsRunning { get; set; }
        public bool IsCompleted { get; set; }   

        public Searcher(string startingDirectory, 
            string searchPattern, 
            TreeView treeView, 
            Progress<int> foundedProgress, 
            Progress<string> currentDirectoryProgress)
        {
            this.startingDirectory = startingDirectory;
            this.searchPattern = searchPattern;
            this.treeView = treeView;

            stopwatch = Stopwatch.StartNew();

            nodesQueue = new Queue<SearchNode>();

            rootNode = new SearchNode(startingDirectory);
            treeView.Nodes.Add(rootNode.treeNode);

            var allNodes = rootNode.GetChildren();

            foreach (var node in allNodes)
            {
                nodesQueue.Enqueue(node);
            }

            this.foundedProgress = foundedProgress;
            this.currentDirectoryProgress = currentDirectoryProgress;
        }

        public async Task Start()
        {
            stopwatch.Start();
            await Start(currentDirectoryProgress);
        }

        private async Task Start(IProgress<string> currentDirectoryProgressProvider)
        {
            IsRunning = true;

            while (IsRunning && nodesQueue.Count > 0)
            {
                var node = nodesQueue.Dequeue();

                var directoryName = Path.GetFileName(node.appendedDirectory);
                currentDirectoryProgressProvider.Report(directoryName);

                await Search(node, foundedProgress);

                await Task.Delay(1000);
            }

            if (nodesQueue.Count == 0)
                IsCompleted = true;

            treeView.Update();
        }

        public void Pause()
        {
            IsRunning = false;
            stopwatch.Stop();
        }

        public async Task Resume()
        {
            await Start();
        }

        public TimeSpan GetTime()
        {
            return stopwatch.Elapsed;
        }

        private async Task Search(SearchNode node, IProgress<int> foundedProgressProvider)
        {
            int founded = 0;
            foreach (var file in Directory.GetFiles(node.appendedDirectory, searchPattern))
            {
                var fileName = Path.GetFileName(file);
                founded++;
                node.treeNode.Nodes.Add(new TreeNode(fileName));
            }

            if (founded != 0)
                node.SetNotEmpty();

            foundedProgressProvider.Report(founded);

        }

        public List<SearchNode> GetAllNodes()
        {
            var allNodes = rootNode.GetChildren();
            allNodes.Add(rootNode);
            return allNodes;
        }
    }

    public class SearchNode
    {
        public string appendedDirectory;
        public string dirName;

        public List<SearchNode> Nodes;
        public SearchNode Parent;
        public bool isEmpty = true;

        public TreeNode treeNode;

        public SearchNode(string appendedDirectory)
        {
            this.appendedDirectory = appendedDirectory;
            dirName = Path.GetFileName(appendedDirectory);
            treeNode = new TreeNode(dirName);
            Nodes = new List<SearchNode>();

            foreach(var directory in Directory.GetDirectories(appendedDirectory))
            {
                Nodes.Add(new SearchNode(directory, this));
            }
        }

        public SearchNode(string appendedDirectory, SearchNode parent): this(appendedDirectory)
        {
            Parent = parent;
        }

        public void SetNotEmpty()
        {
            isEmpty = false;

            if(Parent != null)
            {
                Parent.SetNotEmpty();

                if (!Parent.treeNode.Nodes.Contains(treeNode))
                    Parent.treeNode.Nodes.Add(treeNode);
            }
        }

        public List<SearchNode> GetChildren()
        {
            List<SearchNode> result = new List<SearchNode>();

            if (Nodes.Count != 0)
            {
                foreach(var node in Nodes)
                {
                    result.Add(node);
                    var subRes = node.GetChildren();
                    result.AddRange(subRes);
                }
            }


            return result;
        }
    }
}
