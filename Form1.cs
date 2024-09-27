using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using System.Drawing.Text;

namespace FilesSearch
{
    public partial class Form1 : Form
    {
        private string savePath = "./Save/save.json";
        private string searchDirectoryPath;
        private string searchPattern = string.Empty;

        private int founded;
        private int allFounded;
        private Searcher searcher;

        private ManualResetEvent resetEvent = new ManualResetEvent(true);

        public Form1()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            if (!File.Exists(savePath)) return;

            string jsonString = File.ReadAllText(savePath);

            SaveData sd = JsonConvert.DeserializeObject<SaveData>(jsonString);

            searchDirectoryText.Text = sd.searchDirectoryPath;
            searchDirectoryPath = sd.searchDirectoryPath;

            searchPatternText.Text = sd.searchPattern;
            searchPattern = sd.searchPattern;

            timeElapsed.Text = sd.timeSinseStart.ToString("mm':'ss");

            foundedFilesCounter.Text = sd.founded.ToString();
            allFilesCounter.Text = sd.allFounded.ToString();
        }

        private void SearchDirectoryTextChanged(object sender, EventArgs e)
        {
            searchDirectoryPath = searchDirectoryText.Text;


        }

        private void SearchPatternTextChanged(object sender, EventArgs e)
        {
            searchPattern = searchPatternText.Text;
        }



        private async void SearchButtonClick(object sender, EventArgs e)
        {
            var pattern = searchPattern;

            if (string.IsNullOrEmpty(searchPattern))
                pattern = "*.*";

            if (string.IsNullOrEmpty(searchDirectoryPath) || !Directory.Exists(searchDirectoryPath))
            {
                MessageBox.Show("„тобы начать поиск, введите стартовую директорию (место, с которого начнетс€ поиск)");
                return;
            }

            treeView1.Nodes.Clear();

            OnStart();

            founded = 0;

            var currentDirectoryProgress = new Progress<string>((x) => currentSearchDirectory.Text = x);
            Progress<int> foundedProgress = new Progress<int>(x =>
            {
                founded += x;
                foundedFilesCounter.Text = founded.ToString();
            });

            searcher = new Searcher(searchDirectoryPath, pattern, treeView1, foundedProgress, currentDirectoryProgress);

            await searcher.Start();

            timeElapsed.Text = searcher.GetTime().ToString("mm':'ss");
            allFounded = Directory.GetFiles(searchDirectoryPath, "*.*", SearchOption.AllDirectories).Length;
            allFilesCounter.Text = allFounded.ToString();

            if (searcher.IsCompleted)
                OnComplete();

        }

        private void OnStopSearchButtonClick(object sender, EventArgs e)
        {
            searcher.Pause();
            timeElapsed.Text = searcher.GetTime().ToString("mm':'ss");

            if (searcher.IsCompleted)
                OnComplete();
            else
                OnStop();

        }

        private async void OnContinueSearchButtonClick(object sender, EventArgs e)
        {
            OnStart();
            await searcher.Resume();
            timeElapsed.Text = searcher.GetTime().ToString("mm':'ss");

            if (searcher.IsCompleted)
                OnComplete();
        }

        private void OnStart()
        {
            stopSearchButton.Enabled = true;
            continueSearchButton.Enabled = false;

            statusLabel.Text = "¬ процессе поиска";
        }

        private void OnStop()
        {
            stopSearchButton.Enabled = false;
            continueSearchButton.Enabled = true;

            statusLabel.Text = "ѕоиск остановлен";
        }

        private void OnComplete()
        {
            continueSearchButton.Enabled = false;
            stopSearchButton.Enabled = false;

            statusLabel.Text = "ѕоиск завершен";
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Directory.Exists("./Save"))
                Directory.CreateDirectory("./Save");

            var timeSinceStart = new TimeSpan(0, 0, 0);

            //Ќе стал добавл€ть сохранение найденного, так как не представл€ю как сохранить иерархическую структуру без больших затрат на упаковку и распаковку всего этого из json
            if (searcher != null)
            {

                timeSinceStart = searcher.GetTime();
            }

            SaveData sd = new SaveData(searchDirectoryPath, searchPattern, founded, allFounded, timeSinceStart);

            string jsonString = JsonConvert.SerializeObject(sd);

            File.WriteAllText(savePath, jsonString);
        }

        
    }
}
