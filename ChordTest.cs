using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Multimedia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidiLearner
{
    public partial class ChordTest : Form
    {

        System.Windows.Forms.Timer m_timer;

        private readonly Mutex m_mutex = new Mutex();


        public ChordTest()
        {
            InitializeComponent();


            m_timer = new System.Windows.Forms.Timer();
            m_timer.Interval = 50;
            m_timer.Tick += new EventHandler(TimerEventProcessor);
            m_timer.Start();
        }

        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            m_mutex.WaitOne();

            // Code to execute on each tick
            var chord = PianoManager.Instance.GetChord();

            label1.Text = "";
            if (chord != null)
            {
                label1.Text = chord.ToString();
            }

            m_mutex.ReleaseMutex();
        }


        

    }
}
