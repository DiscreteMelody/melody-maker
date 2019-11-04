namespace Melody_Maker
{
    partial class MelodyMakerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MelodyMakerForm));
            this.optionsContainer = new System.Windows.Forms.GroupBox();
            this.createMelodyButton = new System.Windows.Forms.Button();
            this.tempoContainer = new System.Windows.Forms.GroupBox();
            this.tempoDropDown = new System.Windows.Forms.ComboBox();
            this.beatContainer = new System.Windows.Forms.GroupBox();
            this.longestBeatLabel = new System.Windows.Forms.Label();
            this.longestLabel = new System.Windows.Forms.Label();
            this.longestBeatTrackBar = new System.Windows.Forms.TrackBar();
            this.shortestBeatLabel = new System.Windows.Forms.Label();
            this.shortestLabel = new System.Windows.Forms.Label();
            this.shortestBeatTrackBar = new System.Windows.Forms.TrackBar();
            this.measureContainer = new System.Windows.Forms.GroupBox();
            this.measureDropDown = new System.Windows.Forms.ComboBox();
            this.playMelodyButton = new System.Windows.Forms.Button();
            this.instrumentContainer = new System.Windows.Forms.GroupBox();
            this.instrumentDropDown = new System.Windows.Forms.ComboBox();
            this.octaveContainer = new System.Windows.Forms.GroupBox();
            this.highestOctaveLabel = new System.Windows.Forms.Label();
            this.lowestLabel = new System.Windows.Forms.Label();
            this.highestLabel = new System.Windows.Forms.Label();
            this.lowestOctaveLabel = new System.Windows.Forms.Label();
            this.lowestOctaveTrackBar = new System.Windows.Forms.TrackBar();
            this.highestOctaveTrackBar = new System.Windows.Forms.TrackBar();
            this.keyContainer = new System.Windows.Forms.GroupBox();
            this.keyTypeDropDown = new System.Windows.Forms.ComboBox();
            this.keyDropDown = new System.Windows.Forms.ComboBox();
            this.sheetMusicPictureBox = new System.Windows.Forms.PictureBox();
            this.outputContainer = new System.Windows.Forms.Panel();
            this.downloadButton = new System.Windows.Forms.Button();
            this.sheetMusicScrollBar = new System.Windows.Forms.VScrollBar();
            this.optionsContainer.SuspendLayout();
            this.tempoContainer.SuspendLayout();
            this.beatContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.longestBeatTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shortestBeatTrackBar)).BeginInit();
            this.measureContainer.SuspendLayout();
            this.instrumentContainer.SuspendLayout();
            this.octaveContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lowestOctaveTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.highestOctaveTrackBar)).BeginInit();
            this.keyContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sheetMusicPictureBox)).BeginInit();
            this.outputContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // optionsContainer
            // 
            this.optionsContainer.BackColor = System.Drawing.SystemColors.Control;
            this.optionsContainer.Controls.Add(this.createMelodyButton);
            this.optionsContainer.Controls.Add(this.tempoContainer);
            this.optionsContainer.Controls.Add(this.beatContainer);
            this.optionsContainer.Controls.Add(this.measureContainer);
            this.optionsContainer.Controls.Add(this.playMelodyButton);
            this.optionsContainer.Controls.Add(this.instrumentContainer);
            this.optionsContainer.Controls.Add(this.octaveContainer);
            this.optionsContainer.Controls.Add(this.keyContainer);
            this.optionsContainer.Location = new System.Drawing.Point(24, 26);
            this.optionsContainer.Margin = new System.Windows.Forms.Padding(6);
            this.optionsContainer.Name = "optionsContainer";
            this.optionsContainer.Padding = new System.Windows.Forms.Padding(6);
            this.optionsContainer.Size = new System.Drawing.Size(400, 770);
            this.optionsContainer.TabIndex = 0;
            this.optionsContainer.TabStop = false;
            this.optionsContainer.Text = "Options";
            // 
            // createMelodyButton
            // 
            this.createMelodyButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.createMelodyButton.Location = new System.Drawing.Point(199, 672);
            this.createMelodyButton.Name = "createMelodyButton";
            this.createMelodyButton.Size = new System.Drawing.Size(93, 88);
            this.createMelodyButton.TabIndex = 7;
            this.createMelodyButton.Text = "Create Melody";
            this.createMelodyButton.UseVisualStyleBackColor = true;
            this.createMelodyButton.Click += new System.EventHandler(this.createMelodyButton_Click);
            // 
            // tempoContainer
            // 
            this.tempoContainer.Controls.Add(this.tempoDropDown);
            this.tempoContainer.Location = new System.Drawing.Point(10, 341);
            this.tempoContainer.Name = "tempoContainer";
            this.tempoContainer.Size = new System.Drawing.Size(188, 100);
            this.tempoContainer.TabIndex = 6;
            this.tempoContainer.TabStop = false;
            this.tempoContainer.Text = "Tempo (in bpm)";
            // 
            // tempoDropDown
            // 
            this.tempoDropDown.FormattingEnabled = true;
            this.tempoDropDown.Items.AddRange(new object[] {
            "60",
            "90",
            "120",
            "150"});
            this.tempoDropDown.Location = new System.Drawing.Point(30, 41);
            this.tempoDropDown.Name = "tempoDropDown";
            this.tempoDropDown.Size = new System.Drawing.Size(121, 34);
            this.tempoDropDown.TabIndex = 1;
            // 
            // beatContainer
            // 
            this.beatContainer.Controls.Add(this.longestBeatLabel);
            this.beatContainer.Controls.Add(this.longestLabel);
            this.beatContainer.Controls.Add(this.longestBeatTrackBar);
            this.beatContainer.Controls.Add(this.shortestBeatLabel);
            this.beatContainer.Controls.Add(this.shortestLabel);
            this.beatContainer.Controls.Add(this.shortestBeatTrackBar);
            this.beatContainer.Location = new System.Drawing.Point(10, 447);
            this.beatContainer.Name = "beatContainer";
            this.beatContainer.Size = new System.Drawing.Size(381, 207);
            this.beatContainer.TabIndex = 5;
            this.beatContainer.TabStop = false;
            this.beatContainer.Text = "Beat Length";
            // 
            // longestBeatLabel
            // 
            this.longestBeatLabel.AutoSize = true;
            this.longestBeatLabel.Location = new System.Drawing.Point(41, 156);
            this.longestBeatLabel.Name = "longestBeatLabel";
            this.longestBeatLabel.Size = new System.Drawing.Size(25, 26);
            this.longestBeatLabel.TabIndex = 10;
            this.longestBeatLabel.Text = "¹/₁";
            // 
            // longestLabel
            // 
            this.longestLabel.AutoSize = true;
            this.longestLabel.Location = new System.Drawing.Point(14, 130);
            this.longestLabel.Name = "longestLabel";
            this.longestLabel.Size = new System.Drawing.Size(78, 26);
            this.longestLabel.TabIndex = 9;
            this.longestLabel.Text = "Longest";
            // 
            // longestBeatTrackBar
            // 
            this.longestBeatTrackBar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.longestBeatTrackBar.LargeChange = 1;
            this.longestBeatTrackBar.Location = new System.Drawing.Point(103, 130);
            this.longestBeatTrackBar.Maximum = 4;
            this.longestBeatTrackBar.Name = "longestBeatTrackBar";
            this.longestBeatTrackBar.Size = new System.Drawing.Size(269, 45);
            this.longestBeatTrackBar.TabIndex = 8;
            this.longestBeatTrackBar.Value = 4;
            this.longestBeatTrackBar.Scroll += new System.EventHandler(this.longestBeatTrackbar_Scroll);
            // 
            // shortestBeatLabel
            // 
            this.shortestBeatLabel.AutoSize = true;
            this.shortestBeatLabel.Location = new System.Drawing.Point(41, 84);
            this.shortestBeatLabel.Name = "shortestBeatLabel";
            this.shortestBeatLabel.Size = new System.Drawing.Size(33, 26);
            this.shortestBeatLabel.TabIndex = 7;
            this.shortestBeatLabel.Text = "¹/₁₆";
            // 
            // shortestLabel
            // 
            this.shortestLabel.AutoSize = true;
            this.shortestLabel.Location = new System.Drawing.Point(14, 58);
            this.shortestLabel.Name = "shortestLabel";
            this.shortestLabel.Size = new System.Drawing.Size(83, 26);
            this.shortestLabel.TabIndex = 2;
            this.shortestLabel.Text = "Shortest";
            // 
            // shortestBeatTrackBar
            // 
            this.shortestBeatTrackBar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.shortestBeatTrackBar.LargeChange = 1;
            this.shortestBeatTrackBar.Location = new System.Drawing.Point(103, 58);
            this.shortestBeatTrackBar.Maximum = 4;
            this.shortestBeatTrackBar.Name = "shortestBeatTrackBar";
            this.shortestBeatTrackBar.Size = new System.Drawing.Size(269, 45);
            this.shortestBeatTrackBar.TabIndex = 1;
            this.shortestBeatTrackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.shortestBeatTrackBar.Scroll += new System.EventHandler(this.shortestBeatTrackBar_Scroll);
            // 
            // measureContainer
            // 
            this.measureContainer.Controls.Add(this.measureDropDown);
            this.measureContainer.Location = new System.Drawing.Point(203, 341);
            this.measureContainer.Name = "measureContainer";
            this.measureContainer.Size = new System.Drawing.Size(188, 100);
            this.measureContainer.TabIndex = 4;
            this.measureContainer.TabStop = false;
            this.measureContainer.Text = "Measures";
            // 
            // measureDropDown
            // 
            this.measureDropDown.FormattingEnabled = true;
            this.measureDropDown.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8",
            "16"});
            this.measureDropDown.Location = new System.Drawing.Point(33, 41);
            this.measureDropDown.Name = "measureDropDown";
            this.measureDropDown.Size = new System.Drawing.Size(121, 34);
            this.measureDropDown.TabIndex = 5;
            // 
            // playMelodyButton
            // 
            this.playMelodyButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playMelodyButton.Enabled = false;
            this.playMelodyButton.Location = new System.Drawing.Point(298, 672);
            this.playMelodyButton.Name = "playMelodyButton";
            this.playMelodyButton.Size = new System.Drawing.Size(93, 88);
            this.playMelodyButton.TabIndex = 8;
            this.playMelodyButton.Text = "Play Melody";
            this.playMelodyButton.UseVisualStyleBackColor = true;
            this.playMelodyButton.Click += new System.EventHandler(this.playMelodyButton_Click);
            // 
            // instrumentContainer
            // 
            this.instrumentContainer.Controls.Add(this.instrumentDropDown);
            this.instrumentContainer.Location = new System.Drawing.Point(10, 660);
            this.instrumentContainer.Name = "instrumentContainer";
            this.instrumentContainer.Size = new System.Drawing.Size(188, 100);
            this.instrumentContainer.TabIndex = 3;
            this.instrumentContainer.TabStop = false;
            this.instrumentContainer.Text = "Instrument";
            // 
            // instrumentDropDown
            // 
            this.instrumentDropDown.FormattingEnabled = true;
            this.instrumentDropDown.Items.AddRange(new object[] {
            "Piano",
            "Violin",
            "Vibes"});
            this.instrumentDropDown.Location = new System.Drawing.Point(30, 41);
            this.instrumentDropDown.Name = "instrumentDropDown";
            this.instrumentDropDown.Size = new System.Drawing.Size(121, 34);
            this.instrumentDropDown.TabIndex = 1;
            // 
            // octaveContainer
            // 
            this.octaveContainer.Controls.Add(this.highestOctaveLabel);
            this.octaveContainer.Controls.Add(this.lowestLabel);
            this.octaveContainer.Controls.Add(this.highestLabel);
            this.octaveContainer.Controls.Add(this.lowestOctaveLabel);
            this.octaveContainer.Controls.Add(this.lowestOctaveTrackBar);
            this.octaveContainer.Controls.Add(this.highestOctaveTrackBar);
            this.octaveContainer.Location = new System.Drawing.Point(10, 136);
            this.octaveContainer.Name = "octaveContainer";
            this.octaveContainer.Size = new System.Drawing.Size(381, 198);
            this.octaveContainer.TabIndex = 2;
            this.octaveContainer.TabStop = false;
            this.octaveContainer.Text = "Octaves";
            // 
            // highestOctaveLabel
            // 
            this.highestOctaveLabel.AutoSize = true;
            this.highestOctaveLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highestOctaveLabel.Location = new System.Drawing.Point(39, 84);
            this.highestOctaveLabel.Name = "highestOctaveLabel";
            this.highestOctaveLabel.Size = new System.Drawing.Size(61, 19);
            this.highestOctaveLabel.TabIndex = 14;
            this.highestOctaveLabel.Text = "Soprano";
            this.highestOctaveLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lowestLabel
            // 
            this.lowestLabel.AutoSize = true;
            this.lowestLabel.Location = new System.Drawing.Point(251, 160);
            this.lowestLabel.Name = "lowestLabel";
            this.lowestLabel.Size = new System.Drawing.Size(72, 26);
            this.lowestLabel.TabIndex = 13;
            this.lowestLabel.Text = "Lowest";
            // 
            // highestLabel
            // 
            this.highestLabel.AutoSize = true;
            this.highestLabel.Location = new System.Drawing.Point(75, 160);
            this.highestLabel.Name = "highestLabel";
            this.highestLabel.Size = new System.Drawing.Size(76, 26);
            this.highestLabel.TabIndex = 12;
            this.highestLabel.Text = "Highest";
            // 
            // lowestOctaveLabel
            // 
            this.lowestOctaveLabel.AutoSize = true;
            this.lowestOctaveLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lowestOctaveLabel.Location = new System.Drawing.Point(226, 84);
            this.lowestOctaveLabel.Name = "lowestOctaveLabel";
            this.lowestOctaveLabel.Size = new System.Drawing.Size(40, 19);
            this.lowestOctaveLabel.TabIndex = 8;
            this.lowestOctaveLabel.Text = "Bass";
            this.lowestOctaveLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lowestOctaveTrackBar
            // 
            this.lowestOctaveTrackBar.BackColor = System.Drawing.SystemColors.Control;
            this.lowestOctaveTrackBar.LargeChange = 1;
            this.lowestOctaveTrackBar.Location = new System.Drawing.Point(293, 28);
            this.lowestOctaveTrackBar.Maximum = 3;
            this.lowestOctaveTrackBar.Name = "lowestOctaveTrackBar";
            this.lowestOctaveTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.lowestOctaveTrackBar.Size = new System.Drawing.Size(45, 129);
            this.lowestOctaveTrackBar.TabIndex = 7;
            this.lowestOctaveTrackBar.Scroll += new System.EventHandler(this.lowestOctaveTrackBar_Scroll);
            // 
            // highestOctaveTrackBar
            // 
            this.highestOctaveTrackBar.LargeChange = 1;
            this.highestOctaveTrackBar.Location = new System.Drawing.Point(106, 28);
            this.highestOctaveTrackBar.Maximum = 3;
            this.highestOctaveTrackBar.Name = "highestOctaveTrackBar";
            this.highestOctaveTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.highestOctaveTrackBar.Size = new System.Drawing.Size(45, 129);
            this.highestOctaveTrackBar.TabIndex = 1;
            this.highestOctaveTrackBar.Value = 3;
            this.highestOctaveTrackBar.Scroll += new System.EventHandler(this.highestOctaveTrackBar_Scroll);
            // 
            // keyContainer
            // 
            this.keyContainer.Controls.Add(this.keyTypeDropDown);
            this.keyContainer.Controls.Add(this.keyDropDown);
            this.keyContainer.Location = new System.Drawing.Point(10, 36);
            this.keyContainer.Name = "keyContainer";
            this.keyContainer.Size = new System.Drawing.Size(381, 93);
            this.keyContainer.TabIndex = 0;
            this.keyContainer.TabStop = false;
            this.keyContainer.Text = "Key";
            // 
            // keyTypeDropDown
            // 
            this.keyTypeDropDown.FormattingEnabled = true;
            this.keyTypeDropDown.Items.AddRange(new object[] {
            "Major",
            "Natural Minor",
            "Harmonic Minor",
            "Melodic Minor"});
            this.keyTypeDropDown.Location = new System.Drawing.Point(193, 32);
            this.keyTypeDropDown.Name = "keyTypeDropDown";
            this.keyTypeDropDown.Size = new System.Drawing.Size(178, 34);
            this.keyTypeDropDown.TabIndex = 1;
            // 
            // keyDropDown
            // 
            this.keyDropDown.FormattingEnabled = true;
            this.keyDropDown.Items.AddRange(new object[] {
            "C",
            "C# / D♭",
            "D",
            "E♭ / D#",
            "E",
            "F",
            "F# / G♭",
            "G",
            "A♭ / G#",
            "A",
            "B♭ / A#",
            "B"});
            this.keyDropDown.Location = new System.Drawing.Point(30, 32);
            this.keyDropDown.Name = "keyDropDown";
            this.keyDropDown.Size = new System.Drawing.Size(121, 34);
            this.keyDropDown.TabIndex = 0;
            // 
            // sheetMusicPictureBox
            // 
            this.sheetMusicPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sheetMusicPictureBox.ErrorImage = ((System.Drawing.Image)(resources.GetObject("sheetMusicPictureBox.ErrorImage")));
            this.sheetMusicPictureBox.Location = new System.Drawing.Point(6, 11);
            this.sheetMusicPictureBox.Name = "sheetMusicPictureBox";
            this.sheetMusicPictureBox.Size = new System.Drawing.Size(1126, 366);
            this.sheetMusicPictureBox.TabIndex = 9;
            this.sheetMusicPictureBox.TabStop = false;
            // 
            // outputContainer
            // 
            this.outputContainer.AutoScroll = true;
            this.outputContainer.Controls.Add(this.downloadButton);
            this.outputContainer.Controls.Add(this.sheetMusicScrollBar);
            this.outputContainer.Controls.Add(this.sheetMusicPictureBox);
            this.outputContainer.Location = new System.Drawing.Point(433, 26);
            this.outputContainer.Name = "outputContainer";
            this.outputContainer.Size = new System.Drawing.Size(1189, 531);
            this.outputContainer.TabIndex = 10;
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(6, 383);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(127, 79);
            this.downloadButton.TabIndex = 11;
            this.downloadButton.Text = "Download Song";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // sheetMusicScrollBar
            // 
            this.sheetMusicScrollBar.Enabled = false;
            this.sheetMusicScrollBar.LargeChange = 1;
            this.sheetMusicScrollBar.Location = new System.Drawing.Point(1135, 11);
            this.sheetMusicScrollBar.Maximum = 0;
            this.sheetMusicScrollBar.Name = "sheetMusicScrollBar";
            this.sheetMusicScrollBar.Size = new System.Drawing.Size(17, 366);
            this.sheetMusicScrollBar.TabIndex = 10;
            this.sheetMusicScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sheetsScrollBar_Scroll);
            // 
            // MelodyMakerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Melody_Maker.Properties.Resources.piano_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1634, 811);
            this.Controls.Add(this.outputContainer);
            this.Controls.Add(this.optionsContainer);
            this.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MelodyMakerForm";
            this.Text = "Melody Maker";
            this.Load += new System.EventHandler(this.melodyMakerForm_Load);
            this.optionsContainer.ResumeLayout(false);
            this.tempoContainer.ResumeLayout(false);
            this.beatContainer.ResumeLayout(false);
            this.beatContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.longestBeatTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shortestBeatTrackBar)).EndInit();
            this.measureContainer.ResumeLayout(false);
            this.instrumentContainer.ResumeLayout(false);
            this.octaveContainer.ResumeLayout(false);
            this.octaveContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lowestOctaveTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.highestOctaveTrackBar)).EndInit();
            this.keyContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sheetMusicPictureBox)).EndInit();
            this.outputContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox optionsContainer;
        private System.Windows.Forms.GroupBox keyContainer;
        private System.Windows.Forms.ComboBox keyDropDown;
        private System.Windows.Forms.TrackBar highestOctaveTrackBar;
        private System.Windows.Forms.GroupBox octaveContainer;
        private System.Windows.Forms.Label lowestLabel;
        private System.Windows.Forms.Label highestLabel;
        private System.Windows.Forms.Label lowestOctaveLabel;
        private System.Windows.Forms.TrackBar lowestOctaveTrackBar;
        private System.Windows.Forms.GroupBox instrumentContainer;
        private System.Windows.Forms.ComboBox instrumentDropDown;
        private System.Windows.Forms.GroupBox measureContainer;
        private System.Windows.Forms.ComboBox measureDropDown;
        private System.Windows.Forms.GroupBox beatContainer;
        private System.Windows.Forms.Label shortestBeatLabel;
        private System.Windows.Forms.Label shortestLabel;
        private System.Windows.Forms.TrackBar shortestBeatTrackBar;
        private System.Windows.Forms.Label longestLabel;
        private System.Windows.Forms.TrackBar longestBeatTrackBar;
        private System.Windows.Forms.GroupBox tempoContainer;
        private System.Windows.Forms.ComboBox tempoDropDown;
        private System.Windows.Forms.Button createMelodyButton;
        private System.Windows.Forms.Button playMelodyButton;
        private System.Windows.Forms.ComboBox keyTypeDropDown;
        private System.Windows.Forms.Label highestOctaveLabel;
        private System.Windows.Forms.Label longestBeatLabel;
        private System.Windows.Forms.PictureBox sheetMusicPictureBox;
        private System.Windows.Forms.Panel outputContainer;
        private System.Windows.Forms.VScrollBar sheetMusicScrollBar;
        private System.Windows.Forms.Button downloadButton;
    }
}

