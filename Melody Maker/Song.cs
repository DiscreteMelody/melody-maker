using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Melody_Maker.Properties;
using System.Windows.Forms;
using System.IO;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Melody_Maker
{
    public class Song
    {
        int tempo;
        Scale scale;
        List<Note> usableNotes = new List<Note>();
        List<Note> songNotes = new List<Note>();
        List<int> commonRhythm = new List<int>();
        //longest and shortest beats have a numerator of 1
        int shortestBeat;
        int longestBeat;
        int measures;
        int repeatingMeasureInterval;
        int deviation = 7;
        int previousNoteIndex = 0;
        int currentNoteIndex = 0;
        const int BEATS_PER_MEASURE = 4;
        Instrument instrument;
        Random random = new Random();

        public Song(int beats_per_minute, int num_of_measures, int shortest_beat, int longest_beat, Scale created_scale, Instrument instrument_type)
        {
            instrument = instrument_type;
            tempo = beats_per_minute;
            scale = created_scale;
            measures = num_of_measures;
            shortestBeat = shortest_beat;
            longestBeat = longest_beat;

            usableNotes = scale.getNotes();
            repeatingMeasureInterval = getRandomRepeatingMeasureInterval();
            createCommonRhythm();
        }

        public int Tempo
        {
            get { return tempo; }
            set { tempo = value; }
        }

        public Scale setScale
        {
            set { scale = value; }
        }

        public int ShortestBeat
        {
            get { return shortestBeat; }
            set { shortestBeat = value; }
        }

        public int LongestBeat
        {
            get { return longestBeat; }
            set { longestBeat = value; }
        }

        public Instrument setInstrument
        {
            set { instrument = value; }
        }

        public int NumOfNotes
        {
            get { return songNotes.Count; }
        }

        public void compose()
        {
            int measuresLeft = measures;

            //choose a random starting first note
            currentNoteIndex = random.Next(0, usableNotes.Count);
            
            while(measuresLeft > 0)
            {
                if(measuresLeft % repeatingMeasureInterval == 0)
                {
                    composeCommonRhythmMeasure();
                }
                else
                {
                    createRandomBeats();
                }
                measuresLeft--;
            }

        }

        private void addRandomNote()
        {
            int min = currentNoteIndex - deviation;
            int max = currentNoteIndex + deviation + 1;

            if (min < 0)
                min = 0;
            if (max > usableNotes.Count)
                max = usableNotes.Count;

            int index = random.Next(min, max);
            Note selectedNote = new Note(usableNotes[index].Name, 4, usableNotes[index].Octave);

            previousNoteIndex = currentNoteIndex;
            currentNoteIndex = index;

            songNotes.Add(selectedNote);
            checkForDeviation();
        }

        private void createRandomBeats()
        {
            float beatsLeft = BEATS_PER_MEASURE;
            int beatChosen;

            while (beatsLeft > 0)
            {
                beatChosen = getRandomBeat();

                if (beatsLeft - getBeatDuration(beatChosen) >= 0)
                {
                    addRandomNote();
                    songNotes[NumOfNotes - 1].Beat = beatChosen;
                    beatsLeft -= getBeatDuration(beatChosen);
                    if (beatsLeft == 0)
                    {
                        songNotes[NumOfNotes - 1].EndsMeasure = true;
                    }
                }
            }
        }

        private void checkForDeviation()
        {
            if (currentNoteIndex - previousNoteIndex >= 1 || currentNoteIndex - previousNoteIndex <= 1)
                deviation++;
            else
                deviation = 2;
            
        }

        private int getRandomBeat()
        {
            Dictionary<int, int> Beats = new Dictionary<int, int>
            {
                {16, 0},
                {8, 1},
                {4, 2},
                {2, 3},
                {1, 4}
            };

            int index = random.Next(Beats[shortestBeat], Beats[longestBeat] + 1);

            return Beats.Keys.ElementAt(index);
        }

        //chooses which measures in a song should have repeating rhythms
        private int getRandomRepeatingMeasureInterval()
        {
            int chosenInterval;

            Dictionary<int, int> MeasureIntervals = new Dictionary<int, int>
            {
                {0, 1 },
                {1, 2 },
                {2, 4 }
            };

            chosenInterval = MeasureIntervals[random.Next(2)];

            return chosenInterval;
        }

        private void createCommonRhythm()
        {
            float beatsLeft = BEATS_PER_MEASURE;
            int beatChosen;

            while (beatsLeft > 0)
            {
                beatChosen = getRandomBeat();

                if (beatsLeft - getBeatDuration(beatChosen) >= 0)
                {
                    commonRhythm.Add(beatChosen);
                    beatsLeft -= getBeatDuration(beatChosen);
                }
            }
        }

        private void composeCommonRhythmMeasure()
        {
            for(int i = 0; i < commonRhythm.Count; i++)
            {
                addRandomNote();
                songNotes[NumOfNotes - 1].Beat = commonRhythm[i];
            }

            songNotes[NumOfNotes - 1].EndsMeasure = true;
        }

        //returns how many beats a note consumes in a measure, a measure currently contains BEATS_PER_MEASURE beats
        private float getBeatDuration(int beat_fraction)
        {
            //to ensure the method does not round, 1 is a float
            float beatDuration = BEATS_PER_MEASURE * (1f / beat_fraction);
            return beatDuration;
        }

        public async void play()
        {
            for(int i = 0; i < songNotes.Count; i++)
            {
                instrument.playNote(songNotes[i]);
                int pause = getPauseDuration(songNotes[i]);
                await Task.Delay(pause);
            }
        }

        public void createAudioFile()
        {
            AudioFileReader[] noteSounds = new AudioFileReader[songNotes.Count];
            OffsetSampleProvider[] delayedNoteSounds = new OffsetSampleProvider[songNotes.Count];
            int pauseDuration = 0;
            string saveFileName;

            for (int i = 0; i < songNotes.Count; i++)
            {
                noteSounds[i] = new AudioFileReader(instrument.getNoteFilePath(songNotes[i]));
                delayedNoteSounds[i] = new OffsetSampleProvider(noteSounds[i]);
                delayedNoteSounds[i].DelayBy = TimeSpan.FromMilliseconds(pauseDuration);
                pauseDuration += getPauseDuration(songNotes[i]);
            }

            MixingSampleProvider mixer = new MixingSampleProvider(delayedNoteSounds);

            saveFileName = createSaveDialog();

            WaveFileWriter.CreateWaveFile16(saveFileName, mixer);
        }

        private string createSaveDialog()
        {
            string saveFileName = "saved_melody.wav";

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Save";
            saveDialog.Filter = "Wav Files (*.wav)|*.wav";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                saveFileName = saveDialog.FileName;
            }

            return saveFileName;
        }

        private int getPauseDuration(Note note)
        {
            float pauseDuration = 240 / ((float)tempo * note.Beat);
            return (int)(pauseDuration * 1000);
        }

        public Note getSongNote(int note_index)
        {
            return songNotes[note_index];
        }
    } 
}
