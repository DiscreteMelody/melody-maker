using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Melody_Maker
{
    public partial class MelodyMakerForm : Form
    {
        public MelodyMakerForm()
        {
            InitializeComponent();
        }

        Song song;
        Scale scale;
        Instrument instrument;
        List<Image> sheets = new List<Image>();
        int sheetNumber = 0;
        float nextNoteX = 60;

        //on the form loading
        private void melodyMakerForm_Load(object sender, EventArgs e)
        {
            //make the form elements opaque
            optionsContainer.BackColor = Color.FromArgb(150, optionsContainer.BackColor);
            keyContainer.BackColor = Color.FromArgb(0, keyContainer.BackColor);
            octaveContainer.BackColor = Color.FromArgb(0, octaveContainer.BackColor);
            instrumentContainer.BackColor = Color.FromArgb(0, instrumentContainer.BackColor);
            measureContainer.BackColor = Color.FromArgb(0, measureContainer.BackColor);
            beatContainer.BackColor = Color.FromArgb(0, beatContainer.BackColor);
            tempoContainer.BackColor = Color.FromArgb(0, tempoContainer.BackColor);
            outputContainer.BackColor = Color.FromArgb(200, outputContainer.BackColor);

            //disable resizing of the window and start the window center screen
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.WindowsDefaultBounds;

            //set the style of the comboboxes to a dropdownlist
            keyDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            keyTypeDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            instrumentDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            measureDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            tempoDropDown.DropDownStyle = ComboBoxStyle.DropDownList;

            //set the default selections
            keyDropDown.SelectedIndex = 0;
            keyTypeDropDown.SelectedIndex = 0;
            instrumentDropDown.SelectedIndex = 0;
            measureDropDown.SelectedIndex = 0;
            tempoDropDown.SelectedIndex = 2;

            sheetMusicPictureBox.BackgroundImage = System.Drawing.Image.FromFile(Path.Combine("images", "grand_staff.wmf"));

            //create empty graphics for the sheetMusicPictureBox
            sheets.Add(createEmptyImage(sheetMusicPictureBox));
            sheetMusicPictureBox.Image = sheets[0];
        }

        //whenever the highest octave trackbar is moved, adjust the lowest octave trackbar down if it is above the highest octave trackbar
        private void highestOctaveTrackBar_Scroll(object sender, EventArgs e)
        {
            if(lowestOctaveTrackBar.Value > highestOctaveTrackBar.Value)
            {
                lowestOctaveTrackBar.Value = highestOctaveTrackBar.Value;
            }
            updateOctaveLabels();
        }

        //whenever the lowest octave trackbar is moved, adjust the highest octave trackbar up if it is below the lowest octave trackbar
        private void lowestOctaveTrackBar_Scroll(object sender, EventArgs e)
        {
            if(lowestOctaveTrackBar.Value > highestOctaveTrackBar.Value)
            {
                highestOctaveTrackBar.Value = lowestOctaveTrackBar.Value;
            }
            updateOctaveLabels();
        }

        //changes the octave label text to reflect their position on their respective trackbars
        private void updateOctaveLabels()
        {
            Dictionary<int, string> Octaves = new Dictionary<int, string>
            {
                {0, "Bass"},
                {1, "Alto"},
                {2, "Tenor"},
                {3, "Soprano"}
            };

            highestOctaveLabel.Text = Octaves[highestOctaveTrackBar.Value];
            lowestOctaveLabel.Text = Octaves[lowestOctaveTrackBar.Value];
        }

        //whenever the shortest beat trackbar is moved, adjust the longest beat trackbar to be at or above the shortest beat trackbar
        private void shortestBeatTrackBar_Scroll(object sender, EventArgs e)
        {
            if(shortestBeatTrackBar.Value > longestBeatTrackBar.Value)
            {
                longestBeatTrackBar.Value = shortestBeatTrackBar.Value;
            }
            updateBeatLabels();
        }

        //whenever the longest beat trackbar is moved, adjust the shortest beat trackbar to be at or below the longest beat trackbar
        private void longestBeatTrackbar_Scroll(object sender, EventArgs e)
        {
            if (shortestBeatTrackBar.Value > longestBeatTrackBar.Value)
            {
                shortestBeatTrackBar.Value = longestBeatTrackBar.Value;
            }
            updateBeatLabels();
        }

        //change the beat label text to reflect their position of their respective trackbars
        private void updateBeatLabels()
        {
            Dictionary<int, string> Beats = new Dictionary<int, string>
            {
                {0, "¹/₁₆"},
                {1, "¹/₈"},
                {2, "¹/₄"},
                {3, "¹/₂"},
                {4, "¹/₁"}
            };

            shortestBeatLabel.Text = Beats[shortestBeatTrackBar.Value];
            longestBeatLabel.Text = Beats[longestBeatTrackBar.Value];
        }

        private void createMelodyButton_Click(object sender, EventArgs e)
        {
            sheets.Clear();
            sheets.Add(createEmptyImage(sheetMusicPictureBox));
            sheetMusicPictureBox.Image = sheets[0];
            sheetMusicScrollBar.Value = 0;
            sheetMusicScrollBar.Maximum = 0;
            sheetMusicScrollBar.Enabled = false;
            sheetNumber = 0;
            nextNoteX = 60;

            playMelodyButton.Enabled = true;

            updateSongSelections();
            song.compose();

            for(int i = 0; i < song.NumOfNotes; i++)
            {
                drawNote(song.getSongNote(i));
            }
        }

        private void playMelodyButton_Click(object sender, EventArgs e)
        {
            song.play();
        }

        private void updateSongSelections()
        {
            int keyIndex = keyDropDown.SelectedIndex;
            int keyTypeIndex = keyTypeDropDown.SelectedIndex;
            int lowOctaveIndex = lowestOctaveTrackBar.Value;
            int highOctaveIndex = highestOctaveTrackBar.Value;
            int tempo = int.Parse(tempoDropDown.SelectedItem.ToString());
            int measures = int.Parse(measureDropDown.SelectedItem.ToString());
            int shortestBeat = getBeatByIndex(shortestBeatTrackBar.Value);
            int longestBeat = getBeatByIndex(longestBeatTrackBar.Value);

            scale = new Scale(keyIndex, keyTypeIndex, lowOctaveIndex, highOctaveIndex);
            instrument = new Piano();
            song = new Song(tempo, measures, shortestBeat, longestBeat, scale, instrument);
        }

        private int getBeatByIndex(int beat_index)
        {
            Dictionary<int, int> Beats = new Dictionary<int, int>
            {
                { 0, 16 },
                { 1, 8 },
                { 2, 4 },
                { 3, 2 },
                { 4, 1 }
            };

            return Beats[beat_index];
        }

        //draws a Note in music notation
        private void drawNote(Note note)
        {
            string noteFile;
            string projectPath = AppDomain.CurrentDomain.BaseDirectory.ToString();

            float noteY;
            float noteX;
            float noteWidth;
            float noteHeight;

            //the note height based on its beat, all notes have a numerator of 1 -- a whole is 1, half is 2, quarter is 4, etc
            Dictionary<int, float> NoteHeights = new Dictionary<int, float>
            {
                {1, 26},
                {2, 99},
                {4, 99},
                {8, 99},
                {16, 99}
            };

            //the image width of notes that have upward pointing stems based upon their beats
            //all beats have a numerator of 1, so a whole note is 1, a quarter note 4, a sixteenth 16 etc
            Dictionary<int, float> StemUpNoteWidths = new Dictionary<int, float>
            {
                {1, 45},
                {2, 33},
                {4, 33},
                {8, 51},
                {16, 51}
            };

            //the image width of notes that have downward pointing stems based upon their beats
            //all beats have a numerator of 1, so a whole note is 1, a quarter note 4, a sixteenth 16 etc
            Dictionary<int, float> StemDownNoteWidths = new Dictionary<int, float>
            {
                {1, 45},
                {2, 33},
                {4, 33},
                {8, 33},
                {16, 33}
            };

            //the vertical coordinates of up-pointing stem notes in the treble clef on the staff image used for this project
            Dictionary<string, float> TrebleNoteYCoordinates = new Dictionary<string, float>
            {
                {"f_natural", 14},
                {"f_sharp",  14},
                {"g_flat", 0},
                {"g_natural", 0},
                {"g_sharp",  0},
                {"a_flat",  -14},
                {"a_natural", -14},
                {"a_sharp", -14},
                {"b_flat", -28},
                {"b_natural", -28},
                {"c_natural", -42},
                {"c_sharp", -42},
                {"d_flat",  -56},
                {"d_natural", -56},
                {"d_sharp", -56},
                {"e_flat", -68},
                {"e_natural", -68}

            };

            //the vertical coordinates of up-pointing stem notes in the bass clef on the staff image used for this project
            Dictionary<string, float> BassNoteYCoordinates = new Dictionary<string, float>
            {
                {"a_flat",  265},
                {"a_natural", 265},
                {"a_sharp", 265},
                {"b_flat", 251},
                {"b_natural", 251},
                {"c_natural", 237},
                {"c_sharp", 237},
                {"d_flat",  223},
                {"d_natural", 223},
                {"d_sharp", 223},
                {"e_flat", 209},
                {"e_natural", 209},
                {"f_natural", 195},
                {"f_sharp",  195},
                {"g_flat", 181},
                {"g_natural", 181},
                {"g_sharp",  181}
            };

            //gets a note image by bath based upon a note's beat duration
            Dictionary<int, string> NoteImages = new Dictionary<int, string>
            {
                {1, @"images\whole_note"},
                {2, @"images\half_note"},
                {4, @"images\quarter_note"},
                {8, @"images\eighth_note"},
                {16, @"images\sixteenth_note"}
            };

            noteX = nextNoteX;
            noteY = TrebleNoteYCoordinates[note.Name];
            noteWidth = StemUpNoteWidths[note.Beat];
            noteHeight = NoteHeights[note.Beat];
            noteFile = NoteImages[note.Beat];

            float accidentalY = noteY + 40;

            //determine where to place the vertical position of a note (the Y coordinate)
            //the treble clef
            if (note.Octave >= 2)
            {
                //if a note is a B through E on the treble scale, use a downward facing stem
                if ((note.Name.Contains("b_") || note.Name.Contains("c_") || note.Name.Contains("d_") || note.Name.Contains("e_")) && note.Beat != 1)
                {
                    noteY += 72;
                    accidentalY -= 2;
                    noteWidth = StemDownNoteWidths[note.Beat];
                    if (note.Beat != 1)
                        noteFile += "_stem_down";
                }
                //otherwise use up facing stem
                else
                {
                    noteWidth = StemUpNoteWidths[note.Beat];
                    if (note.Beat != 1)
                        noteFile += "_stem_up";
                }
                    
            }
            //base clef
            else {
                noteY = BassNoteYCoordinates[note.Name];
                accidentalY = noteY + 40;
                //if a note is a D through G on the bass scale, use a downward facing stem
                if ((note.Name.Contains("d_") || note.Name.Contains("e_") || note.Name.Contains("f_") || note.Name.Contains("g_")) && note.Beat != 1)
                {
                    noteY += 72;
                    accidentalY -= 2;
                    noteWidth = StemDownNoteWidths[note.Beat];
                    if (note.Beat != 1)
                        noteFile += "_stem_down";
                }
                //otherwise use up facing stem
                else
                {
                    noteWidth = StemUpNoteWidths[note.Beat];
                    if (note.Beat != 1)
                        noteFile += "_stem_up";
                }
                
            }

            //whole notes need special adjustment due to their height
            if (note.Beat == 1)
                noteY += 73;

            noteFile += ".wmf";
            string file = Path.Combine(projectPath, noteFile);

            //set the next x coordinate of a note equal to the width of the currently drawn note
            nextNoteX += noteWidth;

            //decides the spacing between notes depending on their beats
            if (note.Beat == 16 || note.Beat == 8)
                nextNoteX += 10;
            else if (note.Beat == 4)
                nextNoteX += 30;
            else if (note.Beat == 2)
                nextNoteX += 40;
            else if (note.Beat == 1)
                nextNoteX += 60;

            //add some space between the note and its accidental if it has one
            if(note.Name.Contains("sharp") || note.Name.Contains("flat"))
            {
                noteX += 24;
            }

            //draws the note on the picturebox specified
            using (Graphics graphics = Graphics.FromImage(sheets[sheetNumber]))
            {
                graphics.DrawImage(System.Drawing.Image.FromFile(file), noteX, noteY, noteWidth, noteHeight);
                sheetMusicPictureBox.Invalidate();

                //if the note contains a flat or sharp, draw it to the left of the note
                if (note.Name.Contains("flat"))
                {
                    graphics.DrawImage((System.Drawing.Image.FromFile(Path.Combine(projectPath, @"images\flat_sign.wmf"))), noteX - 30, accidentalY, 24, 64);
                    nextNoteX += 24;
                }
                else if (note.Name.Contains("sharp"))
                {
                    graphics.DrawImage((System.Drawing.Image.FromFile(Path.Combine(projectPath, @"images\sharp_sign.wmf"))), noteX - 30, accidentalY + 14, 24, 64);
                    nextNoteX += 24;
                }
                if (note.EndsMeasure)
                {
                    //draw a bar line to separate measures
                    graphics.DrawLine(new Pen(Color.Black, 3), nextNoteX, 2, nextNoteX, 368);
                    nextNoteX += 10;
                }
            }



            //use the next sheet if the current one is used up
            if(nextNoteX >= 1050)
            {
                nextNoteX = 60;
                sheetNumber++;
                sheets.Add(createEmptyImage(sheetMusicPictureBox));
                sheetMusicScrollBar.Maximum = sheets.Count - 1;
                sheetMusicScrollBar.Enabled = true;
            }

            sheetMusicPictureBox.Invalidate();
        }

        //whenever the scrollbar to the right of the sheetMusicBox is scrolled
        private void sheetsScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            displaySheet(sheetMusicScrollBar.Value);
        }

        //hides all but the specified sheets picturebox
        private void displaySheet(int index)
        {
            sheetMusicPictureBox.Image = sheets[index];
        }

        //creates a transparent image to fill the entirety of a passed in picturebox
        private Bitmap createEmptyImage(PictureBox picbox)
        {
            Bitmap bmp = new Bitmap(picbox.Width, picbox.Height);
            SolidBrush opaqueBrush = new SolidBrush(Color.FromArgb(0, 0, 0, 0));
            using (Graphics graph = Graphics.FromImage(bmp))
            {
                Rectangle imageSize = new Rectangle(0, 0, picbox.Width, picbox.Height);
                graph.FillRectangle(opaqueBrush, imageSize);
            }

            return bmp;
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            song.createAudioFile();
        }
    }
}
