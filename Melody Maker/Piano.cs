using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Melody_Maker.Properties;
using System.IO;

namespace Melody_Maker
{
    public class Piano : Instrument
    {

        public Piano()
        {
            Name = "piano";
            HighOctave = 3;
            LowOctave = 0;
        }
    }
}
