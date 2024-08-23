
namespace MidiLearner
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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



        private void InitializeComponent()
        {
            BTN_TEST = new Button();
            BTN_PRACTICE = new Button();
            SuspendLayout();
            // 
            // BTN_TEST
            // 
            BTN_TEST.Location = new Point(48, 55);
            BTN_TEST.Name = "BTN_TEST";
            BTN_TEST.Size = new Size(94, 29);
            BTN_TEST.TabIndex = 0;
            BTN_TEST.Text = "Test";
            BTN_TEST.UseVisualStyleBackColor = true;
            BTN_TEST.Click += BTN_CONNECT_Click;
            // 
            // BTN_PRACTICE
            // 
            BTN_PRACTICE.Location = new Point(48, 110);
            BTN_PRACTICE.Name = "BTN_PRACTICE";
            BTN_PRACTICE.Size = new Size(94, 29);
            BTN_PRACTICE.TabIndex = 1;
            BTN_PRACTICE.Text = "Practice";
            BTN_PRACTICE.UseVisualStyleBackColor = true;
            BTN_PRACTICE.Click += BTN_PRACTICE_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BTN_PRACTICE);
            Controls.Add(BTN_TEST);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button BTN_TEST;
        private Button BTN_PRACTICE;
    }
}
