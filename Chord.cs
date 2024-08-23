using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiLearner
{
    public enum NoteKind
    {
        C = 0,
        C_Sharp,
        D,
        D_Sharp,
        E,
        F,
        F_Sharp,
        G,
        G_Sharp,
        A,
        A_Sharp,
        B
    };


    public enum ChordKind
    {
        Major,
        Minor,
        Aug,
        Dim
    }


    public class Chord
    {
        private readonly NoteKind m_note;
        private readonly ChordKind m_chordKind;
        private readonly bool m_is7;
        private readonly bool m_isDominent7;

        public Chord(NoteKind note, ChordKind chord, bool is7, bool isDominent7)
        {
            m_note = note;
            m_chordKind = chord;
            m_is7 = is7;
            m_isDominent7 = isDominent7;
        }

        public override string ToString()
        {
            string ret="";

            switch (m_note)
            {
                case NoteKind.C:
                    ret = "C";
                break;
                case NoteKind.C_Sharp:
                    ret = "C#";
                    break;
                case NoteKind.D:
                    ret = "D";
                    break;
                    case NoteKind.D_Sharp:
                    ret = "D#";
                    break;
                case NoteKind.E:
                    ret = "E";
                    break;
                case NoteKind.F:
                    ret = "F";
                    break;
                    case NoteKind.F_Sharp:
                    ret = "F#";
                    break;
                case NoteKind.G:
                    ret = "G";
                    break;
                    case NoteKind.G_Sharp:
                    ret = "G#";
                    break;
                case NoteKind.A:
                    ret = "A";
                    break;
                    case NoteKind.A_Sharp:
                    ret = "A#";
                    break;
                case NoteKind.B:
                    ret = "B";
                    break;
                default:
                break;
            }

            if (m_is7)
            {
                if (!m_isDominent7)
                {
                    switch (m_chordKind)
                    {
                        case ChordKind.Major:
                            ret += "M";
                            break;
                        case ChordKind.Minor:
                            ret += "m";
                            break;
                        case ChordKind.Aug:
                            ret += "aug";
                            break;
                        case ChordKind.Dim:
                            ret += "dim";
                            break;
                    }
                }


                ret+="7";
            }
            else
            {
                switch (m_chordKind)
                {
                    case ChordKind.Major:
                        break;
                    case ChordKind.Minor:
                        ret += "m";
                        break;
                    case ChordKind.Aug:
                        ret += "aug";
                        break;
                    case ChordKind.Dim:
                        ret += "dim";
                        break;
                }
            }

            return ret;
        }

        public static bool operator ==(Chord a, Chord b)
        {
            return a.m_chordKind==b.m_chordKind &&
                a.m_note==b.m_note&&
                a.m_is7 == b.m_is7 &&
                a.m_isDominent7==b.m_isDominent7;
        }
        public static bool operator !=(Chord a, Chord b)
        {
            return a.m_chordKind != b.m_chordKind ||
                a.m_note != b.m_note ||
                a.m_is7 != b.m_is7 ||
                a.m_isDominent7 != b.m_isDominent7;
        }
    }
}
