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
    public partial class ChordPractice : Form
    {
        private System.Windows.Forms.Timer m_updateTimer;
        private System.Windows.Forms.Timer m_spawnTimer;
        private readonly Point m_startingPt;
        private readonly Point m_endPt;
        private Dictionary<System.Windows.Forms.Label, Chord> m_chords;
        private int m_speed = 1;
        private int m_passCount = 0;
        private bool m_isPlaying = false;

        private BindingList<string> m_indiChords = new BindingList<string>();
        public ChordPractice()
        {
            InitializeComponent();

            m_updateTimer = new System.Windows.Forms.Timer();
            m_updateTimer.Interval = 20;
            m_updateTimer.Tick += new EventHandler(TimerEventProcessor);
            m_updateTimer.Start();
            m_spawnTimer = new System.Windows.Forms.Timer();
            m_spawnTimer.Interval = 1000;
            m_spawnTimer.Tick += new EventHandler(SpawnEventProcessor);

            m_startingPt = PlayGround.Location;
            m_startingPt.X += PlayGround.Width;
            m_startingPt.Y += PlayGround.Height / 2;

            m_endPt = PlayGround.Location;
            m_endPt.Y += PlayGround.Height / 2;

            m_chords = new Dictionary<System.Windows.Forms.Label, Chord>();

            LB_CHORD_INDI.DataSource = m_indiChords;

            TB_CHORDSPEED_Scroll(null, null);
        }


        private void CreateChord()
        {
            Random random = new Random();
            Chord testChord=null;
            if (LB_CHORD_INDI.Items.Count == 0)
            {
                int rInt = random.Next(0, ChordCheck.CheckedItems.Count);
                bool is7 = CB_SEVEN.Checked && random.Next(0, 2) == 1;
                bool isDominent7 = false;
                ChordKind rChord = ChordKind.Major;

                if (is7)
                {
                    rInt++;
                }

                if (ChordCheck.GetItemChecked(0))//major
                {
                    if (rInt-- == 0)
                        rChord = ChordKind.Major;
                }
                if (ChordCheck.GetItemChecked(1))//minor
                {
                    if (rInt-- == 0)
                        rChord = ChordKind.Minor;

                }
                if (ChordCheck.GetItemChecked(2))//aug
                {

                    if (rInt-- == 0)
                        rChord = ChordKind.Aug;
                }
                else if (ChordCheck.GetItemChecked(3))//dim
                {

                    if (rInt-- == 0)
                        rChord = ChordKind.Dim;
                }

                //dominent
                if (rInt-- == 0)
                    isDominent7 = true;


                rInt = random.Next(0, PianoManager.SCALE_PITCH_NUM);
                NoteKind note = (NoteKind)rInt;

                testChord= new Chord(note, rChord, is7, isDominent7);
            }
            else
            {
                int rInt = random.Next(0, LB_CHORD_INDI.Items.Count);
                testChord = Chord.FromString(LB_CHORD_INDI.Items[rInt].ToString());
            }


            var testChordLabel = new System.Windows.Forms.Label();
            testChordLabel.Text = testChord.ToString();
            var newPt = m_startingPt;
            newPt.Y += (int)((random.Next(0, PlayGround.Height) - PlayGround.Height / 2) * 0.7);
            testChordLabel.Location = newPt;
            testChordLabel.AutoSize = true;
            //testChordLabel.Size = new System.Drawing.Size(40, 30); // Width=200, Height=30
            testChordLabel.Font = new System.Drawing.Font("Arial", 12);


            this.Controls.Add(testChordLabel);
            testChordLabel.BringToFront();
            testChordLabel.Show();
            testChordLabel.Enabled = true;

            m_chords.Add(testChordLabel, testChord);

        }

        private void Play_Click(object sender, EventArgs e)
        {
            StartPlay();
        }
        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            //chords
            Random random = new Random();
            foreach (var label in m_chords.Keys.ToList())
            {
                var tmp = label.Location;
                tmp.X -= m_speed>0? m_speed: random.Next(0,2);
                label.Location = tmp;

                if (label.Location.X <= m_endPt.X)
                {
                    Controls.Remove(label);
                    m_chords.Remove(label);

                    PB_LIFE.Value -= 10;

                    if (PB_LIFE.Value <= 0)
                    {
                        StopPlay();
                    }
                    else if (PB_LIFE.Value <= 20)
                        PB_LIFE.ForeColor = Color.Red;
                    else if (PB_LIFE.Value <= 60)
                        PB_LIFE.ForeColor = Color.Yellow;
                }
            }

            //play
            var curChord = PianoManager.Instance.GetChord();
            foreach (var Keys in m_chords.Keys)
            {
                if (curChord == m_chords[Keys])
                {
                    m_chords.Remove(Keys);
                    this.Controls.Remove(Keys);
                    m_passCount++;
                    LB_PASS_COUNT.Text = Convert.ToString(m_passCount);

                    PianoManager.Instance.Clear();
                    break;
                }
            }
        }
        private void SpawnEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            CreateChord();
        }

        private void TB_CHORDSPEED_Scroll(object sender, EventArgs e)
        {
            StopPlay();

            switch (TB_CHORDSPEED.Value)
            {
                case 0:
                    m_spawnTimer.Interval = 7000;
                    m_speed = 0;
                    break;
                case 1:
                    m_spawnTimer.Interval = 5000;
                    m_speed = 0;
                    break;
                case 2:
                    m_spawnTimer.Interval = 4500;
                    m_speed = 1;
                    break;
                case 3:
                    m_spawnTimer.Interval = 3500;
                    m_speed = 1;
                    break;
                case 4:
                    m_speed = 2;
                    m_spawnTimer.Interval = 3000;
                    break;
                case 5:
                    m_speed = 2;
                    m_spawnTimer.Interval = 2000;
                    break;

                case 6:
                    m_speed = 3;
                    m_spawnTimer.Interval = 1500;
                    break;
                case 7:
                    m_speed = 3;
                    m_spawnTimer.Interval = 900;
                    break;
            }
        }

        private void BT_CHORD_ADD_Click(object sender, EventArgs e)
        {
            var newChord = Chord.FromString(TB_CHORD_ADD.Text);
            if (newChord != null)
                m_indiChords.Add(newChord.ToString());

            TB_CHORD_ADD.Text = "";

            StopPlay();
        }

        private void StartPlay()
        {
                m_spawnTimer.Start();

                PB_LIFE.Value = 100;
                PB_LIFE.ForeColor = Color.Green;
                LB_PASS_COUNT.Text = "0";
                m_passCount = 0;
                m_isPlaying = true;
        }
        private void StopPlay()
        {
            m_spawnTimer.Stop();

            foreach (var label in m_chords.Keys.ToList())
            {
                Controls.Remove(label);
            }
            m_chords.Clear();
            m_isPlaying = false;
        }

        private void ChordCheck_SelectedValueChanged(object sender, EventArgs e)
        {
            StopPlay();
        }

        private void CB_SEVEN_CheckedChanged(object sender, EventArgs e)
        {
            StopPlay();
        }
    }
}
