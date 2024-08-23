namespace MidiLearner
{
    partial class ChordPractice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ChordCheck = new CheckedListBox();
            Play = new Button();
            PlayGround = new GroupBox();
            TB_CHORDSPEED = new TrackBar();
            CB_SEVEN = new CheckBox();
            PB_LIFE = new ProgressBar();
            LB_PASS_COUNT = new Label();
            ((System.ComponentModel.ISupportInitialize)TB_CHORDSPEED).BeginInit();
            SuspendLayout();
            // 
            // ChordCheck
            // 
            ChordCheck.FormattingEnabled = true;
            ChordCheck.Items.AddRange(new object[] { "Major", "Minor", "Aug", "Dim" });
            ChordCheck.Location = new Point(27, 42);
            ChordCheck.Name = "ChordCheck";
            ChordCheck.Size = new Size(77, 92);
            ChordCheck.TabIndex = 0;
            // 
            // Play
            // 
            Play.Location = new Point(27, 251);
            Play.Name = "Play";
            Play.Size = new Size(70, 63);
            Play.TabIndex = 1;
            Play.Text = "button1";
            Play.UseVisualStyleBackColor = true;
            Play.Click += Play_Click;
            // 
            // PlayGround
            // 
            PlayGround.Location = new Point(157, 62);
            PlayGround.Name = "PlayGround";
            PlayGround.Size = new Size(613, 201);
            PlayGround.TabIndex = 2;
            PlayGround.TabStop = false;
            // 
            // TB_CHORDSPEED
            // 
            TB_CHORDSPEED.Location = new Point(12, 178);
            TB_CHORDSPEED.Maximum = 6;
            TB_CHORDSPEED.Name = "TB_CHORDSPEED";
            TB_CHORDSPEED.Size = new Size(130, 56);
            TB_CHORDSPEED.TabIndex = 3;
            TB_CHORDSPEED.Scroll += TB_CHORDSPEED_Scroll;
            // 
            // CB_SEVEN
            // 
            CB_SEVEN.AutoSize = true;
            CB_SEVEN.Location = new Point(30, 136);
            CB_SEVEN.Name = "CB_SEVEN";
            CB_SEVEN.Size = new Size(39, 24);
            CB_SEVEN.TabIndex = 4;
            CB_SEVEN.Text = "7";
            CB_SEVEN.UseVisualStyleBackColor = true;
            // 
            // PB_LIFE
            // 
            PB_LIFE.Location = new Point(157, 30);
            PB_LIFE.MarqueeAnimationSpeed = 50;
            PB_LIFE.Name = "PB_LIFE";
            PB_LIFE.Size = new Size(246, 29);
            PB_LIFE.Style = ProgressBarStyle.Continuous;
            PB_LIFE.TabIndex = 5;
            PB_LIFE.Value = 30;
            // 
            // LB_PASS_COUNT
            // 
            LB_PASS_COUNT.AutoSize = true;
            LB_PASS_COUNT.Font = new Font("Segoe UI", 12F);
            LB_PASS_COUNT.Location = new Point(418, 30);
            LB_PASS_COUNT.Name = "LB_PASS_COUNT";
            LB_PASS_COUNT.Size = new Size(65, 28);
            LB_PASS_COUNT.TabIndex = 6;
            LB_PASS_COUNT.Text = "label1";
            // 
            // ChordPractice
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(LB_PASS_COUNT);
            Controls.Add(PB_LIFE);
            Controls.Add(CB_SEVEN);
            Controls.Add(TB_CHORDSPEED);
            Controls.Add(Play);
            Controls.Add(ChordCheck);
            Controls.Add(PlayGround);
            Name = "ChordPractice";
            Text = "ChordPractice";
            ((System.ComponentModel.ISupportInitialize)TB_CHORDSPEED).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox ChordCheck;
        private Button Play;
        private GroupBox PlayGround;
        private TrackBar TB_CHORDSPEED;
        private CheckBox CB_SEVEN;
        private ProgressBar PB_LIFE;
        private Label LB_PASS_COUNT;
    }
}