
namespace MidiLearner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();





        }

        private void BTN_CONNECT_Click(object sender, EventArgs e)
        {
            ChordTest chordTest = new ChordTest();
            chordTest.ShowDialog();
        }

        private void BTN_PRACTICE_Click(object sender, EventArgs e)
        {
            ChordPractice chord = new ChordPractice();
            chord.ShowDialog();
        }
    }
}
