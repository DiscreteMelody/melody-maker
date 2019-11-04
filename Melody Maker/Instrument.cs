using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Melody_Maker.Properties;
using System.IO;
using NAudio.Wave;

namespace Melody_Maker
{
    public class Instrument
    {
        //highest octave is 3 and lowest octave is 0 for this project
        int lowOctave;
        int highOctave;
        string name = "";

        public int LowOctave
        {
            get { return lowOctave; }
            set { lowOctave = value; }
        }
        public int HighOctave
        {
            get { return highOctave; }
            set { highOctave = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value.ToLower(); }
        }

        public Instrument()
        {

        }

        public async void playNote(Note note)
        {

            var reader = new WaveFileReader(getNoteFilePath(note));
            var waveOut = new WaveOut();
            waveOut.Init(reader);
            waveOut.Play();

            await Task.Delay(3000);
            waveOut.Dispose();
            reader.Dispose();
        }

        private string getNoteFolder(int note_beat)
        {
            Dictionary<int, string> NoteFolderNamesByBeat = new Dictionary<int, string>
            {
                {1, "whole" },
                {2, "half" },
                {4, "quarter" },
                {8, "eighth" },
                {16, "sixteenth" }
            };

            return NoteFolderNamesByBeat[note_beat];
        }

        private string getNoteFileName(string note_name, int octave)
        {
            string noteFileName;

            //gets the filenames of files used in this project by a note's name
            Dictionary<string, string> NoteFileNamePrefixes = new Dictionary<string, string>
            {
                { "c_natural", "c" },
                { "c_sharp", "dflat" },
                { "d_flat", "dflat" },
                { "d_natural", "d" },
                { "d_sharp", "eflat" },
                { "e_flat", "eflat" },
                { "e_natural", "e" },
                { "f_natural", "f" },
                { "f_sharp", "gflat" },
                { "g_flat", "gflat" },
                { "g_natural", "g" },
                { "g_sharp", "aflat" },
                { "a_flat", "aflat" },
                { "a_natural", "a" },
                { "a_sharp", "bflat" },
                { "b_flat", "bflat" },
                { "b_natural", "b" }
            };

            noteFileName = NoteFileNamePrefixes[note_name] + "_" + octave.ToString(); 

            return noteFileName;
        }

        public string getNoteFilePath(Note note)
        {
            string projectpath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "sounds";
            string filepath = name + @"\" + getNoteFolder(note.Beat) + @"\" + getNoteFileName(note.Name, note.Octave) + ".wav";
            string file = Path.Combine(projectpath, filepath);

            return file;
        }

    }
}
