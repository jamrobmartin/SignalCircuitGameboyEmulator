using SignalCircuitLib;
using SignalCircuitLib.Component;
using System.ComponentModel;

namespace SignalCircuitGameboyEmulator
{
    public partial class GameboyForm : Form
    {
        public DebugTextViewer debugTextViewer = new DebugTextViewer();

        public GameboyForm()
        {
            InitializeComponent();
        }


        #region ButtonPressEvents
        // Button Pressed Event
        public delegate void ButtomPressedEventHandler(object sender, ButtonPressedEventArgs e);
        public event ButtomPressedEventHandler ButtonPressed = delegate { };

        public void FireButtonPressedEvent(eButtonPress e)
        {
            ButtonPressed?.Invoke(this, new ButtonPressedEventArgs(e));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // On
            FireButtonPressedEvent(eButtonPress.On);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Off
            FireButtonPressedEvent(eButtonPress.Off);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Up
            FireButtonPressedEvent(eButtonPress.Up);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Right
            FireButtonPressedEvent(eButtonPress.Right);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Down
            FireButtonPressedEvent(eButtonPress.Down);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Left
            FireButtonPressedEvent(eButtonPress.Left);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // A
            FireButtonPressedEvent(eButtonPress.A);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // B
            FireButtonPressedEvent(eButtonPress.B);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Start
            FireButtonPressedEvent(eButtonPress.Start);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Select
            FireButtonPressedEvent(eButtonPress.Select);
        }
        #endregion

        private void GameboyForm_Activated(object sender, EventArgs e)
        {
            Logger.WriteLine("GameboyForm_Activated()", Logger.LogLevel.Information);
            debugTextViewer.Show();
            debugTextViewer.Location = new Point(this.ClientRectangle.Width+5, 0);
        }
    }
}
