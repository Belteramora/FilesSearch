namespace FilesSearch
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            searchDirectoryText = new TextBox();
            label1 = new Label();
            label2 = new Label();
            searchPatternText = new TextBox();
            searchButton = new Button();
            treeView1 = new TreeView();
            label3 = new Label();
            foundedFilesCounter = new Label();
            label4 = new Label();
            allFilesCounter = new Label();
            label5 = new Label();
            currentSearchDirectory = new Label();
            stopSearchButton = new Button();
            continueSearchButton = new Button();
            label6 = new Label();
            timeElapsed = new Label();
            label7 = new Label();
            statusLabel = new Label();
            SuspendLayout();
            // 
            // searchDirectoryText
            // 
            searchDirectoryText.Location = new Point(148, 12);
            searchDirectoryText.Name = "searchDirectoryText";
            searchDirectoryText.Size = new Size(254, 23);
            searchDirectoryText.TabIndex = 0;
            searchDirectoryText.TextChanged += SearchDirectoryTextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(130, 15);
            label1.TabIndex = 1;
            label1.Text = "Стартовая директория";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 47);
            label2.Name = "label2";
            label2.Size = new Size(94, 15);
            label2.TabIndex = 2;
            label2.Text = "Шаблон поиска";
            // 
            // searchPatternText
            // 
            searchPatternText.Location = new Point(148, 44);
            searchPatternText.Name = "searchPatternText";
            searchPatternText.Size = new Size(254, 23);
            searchPatternText.TabIndex = 3;
            searchPatternText.TextChanged += SearchPatternTextChanged;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(12, 81);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(113, 23);
            searchButton.TabIndex = 4;
            searchButton.Text = "Начать поиск";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += SearchButtonClick;
            // 
            // treeView1
            // 
            treeView1.Location = new Point(12, 110);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(390, 318);
            treeView1.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(440, 15);
            label3.Name = "label3";
            label3.Size = new Size(118, 15);
            label3.TabIndex = 7;
            label3.Text = "Найденных файлов:";
            // 
            // foundedFilesCounter
            // 
            foundedFilesCounter.AutoSize = true;
            foundedFilesCounter.Location = new Point(564, 15);
            foundedFilesCounter.Name = "foundedFilesCounter";
            foundedFilesCounter.Size = new Size(13, 15);
            foundedFilesCounter.TabIndex = 8;
            foundedFilesCounter.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(440, 47);
            label4.Name = "label4";
            label4.Size = new Size(86, 15);
            label4.TabIndex = 9;
            label4.Text = "Всего файлов:";
            // 
            // allFilesCounter
            // 
            allFilesCounter.AutoSize = true;
            allFilesCounter.Location = new Point(564, 47);
            allFilesCounter.Name = "allFilesCounter";
            allFilesCounter.Size = new Size(13, 15);
            allFilesCounter.TabIndex = 10;
            allFilesCounter.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(440, 81);
            label5.Name = "label5";
            label5.Size = new Size(101, 15);
            label5.TabIndex = 11;
            label5.Text = "Поиск ведется в: ";
            // 
            // currentSearchDirectory
            // 
            currentSearchDirectory.AutoSize = true;
            currentSearchDirectory.Location = new Point(564, 81);
            currentSearchDirectory.Name = "currentSearchDirectory";
            currentSearchDirectory.Size = new Size(0, 15);
            currentSearchDirectory.TabIndex = 12;
            // 
            // stopSearchButton
            // 
            stopSearchButton.Enabled = false;
            stopSearchButton.Location = new Point(131, 81);
            stopSearchButton.Name = "stopSearchButton";
            stopSearchButton.Size = new Size(122, 23);
            stopSearchButton.TabIndex = 13;
            stopSearchButton.Text = "Остановить поиск";
            stopSearchButton.UseVisualStyleBackColor = true;
            stopSearchButton.Click += OnStopSearchButtonClick;
            // 
            // continueSearchButton
            // 
            continueSearchButton.Enabled = false;
            continueSearchButton.Location = new Point(259, 81);
            continueSearchButton.Name = "continueSearchButton";
            continueSearchButton.Size = new Size(143, 23);
            continueSearchButton.TabIndex = 14;
            continueSearchButton.Text = "Продолжить поиск";
            continueSearchButton.UseVisualStyleBackColor = true;
            continueSearchButton.Click += OnContinueSearchButtonClick;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(440, 110);
            label6.Name = "label6";
            label6.Size = new Size(112, 15);
            label6.TabIndex = 15;
            label6.Text = "Прошло времени: ";
            // 
            // timeElapsed
            // 
            timeElapsed.AutoSize = true;
            timeElapsed.Location = new Point(564, 110);
            timeElapsed.Name = "timeElapsed";
            timeElapsed.Size = new Size(13, 15);
            timeElapsed.TabIndex = 16;
            timeElapsed.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(440, 147);
            label7.Name = "label7";
            label7.Size = new Size(46, 15);
            label7.TabIndex = 17;
            label7.Text = "Статус:";
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(564, 147);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(0, 15);
            statusLabel.TabIndex = 18;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusLabel);
            Controls.Add(label7);
            Controls.Add(timeElapsed);
            Controls.Add(label6);
            Controls.Add(continueSearchButton);
            Controls.Add(stopSearchButton);
            Controls.Add(currentSearchDirectory);
            Controls.Add(label5);
            Controls.Add(allFilesCounter);
            Controls.Add(label4);
            Controls.Add(foundedFilesCounter);
            Controls.Add(label3);
            Controls.Add(treeView1);
            Controls.Add(searchButton);
            Controls.Add(searchPatternText);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(searchDirectoryText);
            Name = "Form1";
            Text = "Form1";
            FormClosing += OnFormClosing;
            Load += OnLoad;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox searchDirectoryText;
        private Label label1;
        private Label label2;
        private TextBox searchPatternText;
        private Button searchButton;
        private TreeView treeView1;
        private Label label3;
        private Label foundedFilesCounter;
        private Label label4;
        private Label allFilesCounter;
        private Label label5;
        private Label currentSearchDirectory;
        private Button stopSearchButton;
        private Button continueSearchButton;
        private Label label6;
        private Label timeElapsed;
        private Label label7;
        private Label statusLabel;
    }
}
