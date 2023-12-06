using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignalCircuitGameboyEmulator
{
    public partial class DebugTextViewer : Form
    {
        public DebugTextViewer()
        {
            InitializeComponent();

            Logger.MessageLogged += Logger_MessageLogged;
        }

        private void Logger_MessageLogged(object? sender, Logger.LoggerMessageEventArgs e)
        {
            try
            {
                if (textBox1.InvokeRequired)
                {
                    Action action = delegate { Logger_MessageLogged(sender, e); };
                    textBox1.Invoke(action);
                }
                else
                {
                    this.textBox1.AppendText(e.Message);
                }
            }
            catch { }
        }
    }
}
