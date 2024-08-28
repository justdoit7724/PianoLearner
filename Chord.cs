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

        public Chord(  NoteKind note, ChordKind chord, bool is7, bool isDominent7)
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

        public static Chord FromString(string sChord)
        {
            if (sChord.Length == 0)
                return null;

            int i = 0;
            sChord = sChord.Replace(" ", "");


            bool is7 = sChord.Last() == '7';
            if (is7)
                sChord = sChord.Remove(sChord.Length - 1);

            NoteKind note; 
            switch (sChord[i++])
            {
                case 'C':
                    note = NoteKind.C;
                    break;
                case 'D':
                    note = NoteKind.D;
                    break;
                case 'E':
                    note = NoteKind.E;
                    break;
                case 'F':
                    note = NoteKind.F;
                    break;
                case 'G':
                    note = NoteKind.G;
                    break;
                case 'A':
                    note = NoteKind.A;
                    break;
                case 'B':
                    note = NoteKind.B;
                    break;
                default:
                    return null;
            }
            if (i >= sChord.Length)
                return new Chord(note, ChordKind.Major, is7, true);
            switch (sChord[i])
            {
                case '#':

                    if (note == NoteKind.B)
                        note = NoteKind.C;
                    else
                        note = note + 1;
                    i++;
                    break;

                case 'b':
                    if (note == NoteKind.C)
                        note = NoteKind.B;
                    else
                        note = note - 1;
                    i++;
                    break;

            }
            if (i >= sChord.Length)
                return new Chord(note, ChordKind.Major, is7, is7);

            switch(sChord[i++])
            {
                case 'M':
                    return new Chord(note, ChordKind.Major, is7, false);
                case 'm':
                    return new Chord(note, ChordKind.Minor, is7, false);
                case 'a':
                    return new Chord(note, ChordKind.Aug, is7, false);
                case 'd':
                    return new Chord(note, ChordKind.Dim, is7, false);
            }

            return null;
        }

        public static bool operator ==(Chord a, Chord b)
        {
            if (object.Equals(a, null) && object.Equals(b, null))
                return true;
            if ((object.Equals(a,null) && !object.Equals(b, null)) || !object.Equals(a, null) && object.Equals(b,null))
                return false;

            return a.m_chordKind==b.m_chordKind &&
                a.m_note==b.m_note&&
                a.m_is7 == b.m_is7 &&
                (!a.m_is7 || a.m_isDominent7==b.m_isDominent7);
        }
        public static bool operator !=(Chord a, Chord b)
        {
            if (object.Equals(a, null) && object.Equals(b, null))
                return false;
            if ((object.Equals(a, null) && !object.Equals(b, null)) || !object.Equals(a, null) && object.Equals(b, null))
                return true;

            return a.m_chordKind != b.m_chordKind ||
                a.m_note != b.m_note ||
                a.m_is7 != b.m_is7 ||
                a.m_isDominent7 != b.m_isDominent7;
        }
    }
}
