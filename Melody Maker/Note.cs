using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Melody_Maker
{

    public class Note
    {
        private string name;
        //beats values are with a numerator of 1, so a quarter note is 4, a whole note is 1, etc.
        private int beat;
        //octaves can range from 0 to 4 for this project
        private int octave;
        private bool endsMeasure = false;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Beat
        {
            get { return beat; }
            set { beat = value; }
        }
        public int Octave
        {
            get { return octave; }
            set { octave = value; }
        }
        public bool EndsMeasure
        {
            get { return endsMeasure; }
            set { endsMeasure = value; }
        }

        public Note(string note_name, int beat_value, int octave_index)
        {
            name = note_name;
            beat = beat_value;
            octave = octave_index;
        }

        //returns the string name of a beat given the integer value of a beat
        public string getBeatNameByBeat(int beat_number)
        {
            Dictionary<int, string> BeatNames = new Dictionary<int, string>
            {
                { 1, "whole" },
                { 2, "half" },
                { 4, "quarter" },
                { 8,  "eighth" },
                { 16, "sixteenth" }
            };

            return BeatNames[beat_number];
        }

    }
}
