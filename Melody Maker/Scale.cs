using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Melody_Maker
{
    public class Scale
    {

        int halfStepsUpFromC;
        //0 and 4 are the lowest and highest octaves
        int highOctave;
        int lowOctave;
        //Chromatic ascending scale starting at C natural using sharp notation names
        private string[] sharpNotations = new string[]
        {
            "c_natural", "c_sharp", "d_natural", "d_sharp", "e_natural", "f_natural",
            "f_sharp", "g_natural", "g_sharp", "a_natural", "a_sharp", "b_natural"
        };

        //Chromatic ascending scale starting at C natural using flat notations
        private string[] flatNotations = new string[]
        {
            "c_natural", "d_flat", "d_natural", "e_flat", "e_natural", "f_natural",
            "g_flat", "g_natural", "a_flat", "a_natural", "b_flat", "b_natural",
        };

        //the preferred style of notation of each scale using accidentals. starts with C natural and moves up a half step in the array
        private string[] notationPreferences = new string[]
        {
            "sharp", "flat", "sharp", "flat", "sharp", "flat",
            "sharp", "sharp", "flat", "sharp", "flat", "sharp"
        };

        //a major scale's pitches based on the number of half steps up from the root note
        private int[] majorScaleIntervals = new int[]
        {
            0, 2, 4, 5, 7, 9, 11, 12
        };

        //a natural minor scale's pitches based on the number of half steps up from the root note
        private int[] naturalMinorScaleIntervals = new int[]
        {
            0, 2, 3, 5, 7, 8, 10, 12
        };
        //a harmonic minor scale's pitches based on the number of half steps up from the root note
        private int[] harmonicMinorScaleIntervals = new int[]
        {
            0, 2, 3, 5, 7, 8, 11, 12
        };
        //a melodic minor scale's pitches based on the number of half steps up from the root note
        private int[] melodicMinorScaleIntervals = new int[]
        {
            0, 2, 3, 5, 7, 9, 11, 12
        };

        private string[] preferredNotation;
        private int[] selectedScaleIntervals;
        private List<Note> scaleNotes = new List<Note>();
        private const int LENGTH_OF_SCALE = 7;

        public Note getNote(int note_number)
        {
            return scaleNotes[note_number];
        }

        public int Count
        {
            get { return scaleNotes.Count; }
        }

        //scale_index is based on the listed order on the form the user submits. currently: 0 = Major, 1 = Natural Minor, 2 = Harmonic Minor, 3 = Melodic Minor
        public Scale(int half_steps_above_c_natural, int scale_type_index, int start_octave, int end_octave)
        {
            halfStepsUpFromC = half_steps_above_c_natural;
            lowOctave = start_octave;
            highOctave = end_octave;

            if (scale_type_index == 0)
                selectedScaleIntervals = majorScaleIntervals;
            else if (scale_type_index == 1)
                selectedScaleIntervals = naturalMinorScaleIntervals;
            else if (scale_type_index == 2)
                selectedScaleIntervals = harmonicMinorScaleIntervals;
            else if (scale_type_index == 3)
                selectedScaleIntervals = melodicMinorScaleIntervals;

            if (notationPreferences[halfStepsUpFromC] == "sharp")
                preferredNotation = sharpNotations;
            else if (notationPreferences[halfStepsUpFromC] == "flat")
                preferredNotation = flatNotations;

            fillScaleNotes();
        }

        //populates the scaleNotes with whole notes from the selected key
        private void fillScaleNotes()
        {

            int octave;

            for (int i = 0; i < selectedScaleIntervals.Length; i++)
            {
                octave = lowOctave;
                selectedScaleIntervals[i] += halfStepsUpFromC;

                //if a note is above C natural, raise its octave
                if (selectedScaleIntervals[i] >= 12)
                {
                    selectedScaleIntervals[i] -= 12;
                    octave += 1;
                }

                scaleNotes.Add(new Note(preferredNotation[selectedScaleIntervals[i]], 1, octave));
            }

            //if more than one octave is selected, add the last 7 notes of the scale to itself but 1 octave higher
            while(lowOctave < highOctave)
            {
                int counter = LENGTH_OF_SCALE;
                for(int i = scaleNotes.Count - LENGTH_OF_SCALE; counter > 0; i++)
                {
                    Note octaveHigherNote = new Note(scaleNotes[i].Name, 1, scaleNotes[i].Octave + 1);
                    scaleNotes.Add(octaveHigherNote);
                    counter--;
                }
                lowOctave++;
            }

        }

        public List<Note> getNotes()
        {
            return scaleNotes;
        }

        public async void play()
        {
            Piano piano = new Piano();

            for(int i = 0; i < scaleNotes.Count; i++)
            {
                piano.playNote(scaleNotes[i]);
                await Task.Delay(250);
            }
        }
    }
}
