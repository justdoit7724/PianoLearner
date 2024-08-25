using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Multimedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MidiLearner
{
    class PianoManager
    {
        private static readonly Lazy<PianoManager> m_instance = new Lazy<PianoManager>(() => new PianoManager());

        private InputDevice m_inputDevice=null;
        private HashSet<int> m_pressedNote;

        public const int SCALE_PITCH_NUM = 12;
        public const NoteKind m_startingNote = NoteKind.A;
        public const int m_startingPitch = 21;


        private PianoManager() {

            try
            {
                m_inputDevice = InputDevice.GetByName("Digital Piano");
                m_inputDevice.EventReceived += OnEventReceived;
                m_inputDevice.StartEventsListening();
            } catch {

            }

            m_pressedNote = new HashSet<int>();
        }

        public static PianoManager Instance { get { return m_instance.Value; } }


        public void Clear()
        {
            m_pressedNote.Clear();
        }

        public Chord GetTriad( )
        {
            var nList = PianoManager.Instance.m_pressedNote;

            foreach (int root in nList)
            {
                NoteKind rNote = GetNoteKind(root);

                bool second = false;
                bool third = false;


                //major check
                foreach (int i in nList)
                {
                    int curPitch = i;

                    if (root == curPitch)
                        continue;


                    curPitch += SCALE_PITCH_NUM * 10;
                    while ((curPitch - SCALE_PITCH_NUM) >= root)
                        curPitch -= SCALE_PITCH_NUM;

                    if ((curPitch - root) == 4)
                        second = true;
                    if ((curPitch - root) == 7)
                        third = true;
                }
                if (second && third)
                {
                    return new Chord(rNote, ChordKind.Major, false, false);
                }

                //minor check
                foreach (int i in nList)
                {
                    int curPitch = i;

                    if (root == curPitch)
                        continue;

                    while ((curPitch - SCALE_PITCH_NUM) >= root)
                        curPitch -= SCALE_PITCH_NUM;

                    if ((curPitch - root) == 3)
                        second = true;
                    if ((curPitch - root) == 7)
                        third = true;
                }
                if (second && third)
                {
                    return new Chord(rNote, ChordKind.Minor, false, false);
                }

                //aug check
                foreach (int i in nList)
                {
                    int curPitch = i;

                    if (root == curPitch)
                        continue;



                    while ((curPitch - SCALE_PITCH_NUM) >= root)
                        curPitch -= SCALE_PITCH_NUM;

                    if ((curPitch - root) == 4)
                        second = true;
                    if ((curPitch - root) == 8)
                        third = true;
                }
                if (second && third)
                {
                    return new Chord(rNote, ChordKind.Aug, false, false);
                }

                //dim check
                foreach (int i in nList)
                {
                    int curPitch = i;

                    if (root == curPitch)
                        continue;



                    while ((curPitch - SCALE_PITCH_NUM) >= root)
                        curPitch -= SCALE_PITCH_NUM;

                    if ((curPitch - root) == 3)
                        second = true;
                    if ((curPitch - root) == 6)
                        third = true;
                }
                if (second && third)
                {
                    return new Chord(rNote, ChordKind.Dim, false, false);
                }

            }

            return null;
        }
        public Chord Get7()
        {
            var nList = PianoManager.Instance.m_pressedNote;

            if (nList.Count < 4)
                return null;

            foreach (int root in nList)
            {
                NoteKind rNote = GetNoteKind(root);

                bool second = false;
                bool third = false;
                bool fourth = false;

                //dominent check
                foreach (int i in nList)
                {
                    int curPitch = i;

                    if (root == curPitch)
                        continue;

                    curPitch += SCALE_PITCH_NUM * 10;
                    while ((curPitch - SCALE_PITCH_NUM) >= root)
                        curPitch -= SCALE_PITCH_NUM;

                    if ((curPitch - root) == 4)
                        second = true;
                    if ((curPitch - root) == 7)
                        third = true;
                    if ((curPitch - root) == 10)
                        fourth = true;
                }
                if (second && third && fourth)
                {
                    return new Chord(rNote, ChordKind.Major, true, true);
                }

                //major check
                foreach (int i in nList)
                {
                    int curPitch = i;

                    if (root == curPitch)
                        continue;

                    while ((curPitch - SCALE_PITCH_NUM) >= root)
                        curPitch -= SCALE_PITCH_NUM;

                    if ((curPitch - root) == 4)
                        second = true;
                    if ((curPitch - root) == 7)
                        third = true;
                    if ((curPitch - root) == 11)
                        fourth = true;
                }
                if (second && third && fourth)
                {
                    return new Chord(rNote, ChordKind.Major, true, false);
                }

                //minor check
                foreach (int i in nList)
                {
                    int curPitch = i;

                    if (root == curPitch)
                        continue;

                    while ((curPitch - SCALE_PITCH_NUM) >= root)
                        curPitch -= SCALE_PITCH_NUM;

                    if ((curPitch - root) == 3)
                        second = true;
                    if ((curPitch - root) == 7)
                        third = true;
                    if ((curPitch - root) == 10)
                        fourth = true;
                }
                if (second && third && fourth)
                {
                    return new Chord(rNote, ChordKind.Minor, true, false);
                }

                //aug check
                foreach (int i in nList)
                {
                    int curPitch = i;

                    if (root == curPitch)
                        continue;

                    while ((curPitch - SCALE_PITCH_NUM) >= root)
                        curPitch -= SCALE_PITCH_NUM;

                    if ((curPitch - root) == 4)
                        second = true;
                    if ((curPitch - root) == 8)
                        third = true;
                    if ((curPitch - root) == 11)
                        fourth = true;
                }
                if (second && third && fourth)
                {
                    return new Chord(rNote, ChordKind.Aug, true, false);
                }

                //dim check
                foreach (int i in nList)
                {
                    int curPitch = i;

                    if (root == curPitch)
                        continue;

                    while ((curPitch - SCALE_PITCH_NUM) >= root)
                        curPitch -= SCALE_PITCH_NUM;

                    if ((curPitch - root) == 3)
                        second = true;
                    if ((curPitch - root) == 6)
                        third = true;
                    if ((curPitch - root) == 9)
                        fourth = true;
                }
                if (second && third && fourth)
                {
                    return new Chord(rNote, ChordKind.Dim, true, false);
                }

            }


            return null;
        }

        public Chord GetChord(  )
        {
            var newChord = Get7();
            if (newChord != null)
                return newChord;

            return GetTriad ();
        }

        private static NoteKind GetNoteKind(int pitch)
        {
            return (NoteKind)(((int)PianoManager.m_startingNote + pitch - PianoManager.m_startingPitch) % SCALE_PITCH_NUM);
        }
        private NoteKind GetNoteKind(NoteKind curNote, int pitch)
        {
            return (NoteKind)(((int)curNote + pitch) % SCALE_PITCH_NUM);
        }

        private void OnEventReceived(object sender, MidiEventReceivedEventArgs e)
        {
            var midiDevice = (MidiDevice)sender;

            var midiEvent = e.Event;

            if (midiEvent is NoteOnEvent noteOnEvent)
            {
                var pitch = noteOnEvent.NoteNumber;

                if (noteOnEvent.Velocity > 0)
                    m_pressedNote.Add(pitch);
                else
                    m_pressedNote.Remove(pitch);
            }
        }
    }
}
