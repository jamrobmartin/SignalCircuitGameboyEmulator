using SignalCircuitLib.Signals;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalCircuitGameboyEmulator
{
    public class Emulator
    {
        #region Singleton
        private static readonly Lazy<Emulator> lazy = new Lazy<Emulator>(() => new Emulator());
        public static Emulator Instance { get; private set; } = lazy.Value;
        #endregion

        Oscillator oscillator = new Oscillator();
        Stopwatch stopwatch = new Stopwatch();

        public Emulator() 
        {
            oscillator.SignalChanged += Oscillator_SignalChanged;
        }

        private void Oscillator_SignalChanged(object? sender, SignalChangedEventArgs e)
        {
            //Logger.WriteLine("Oscillator changed to: " + e.Signal.ToString(), Logger.LogLevel.Information);
        }

        #region Button Presses
        public void GameboyForm_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            switch (e.buttonPressed)
            {
                case eButtonPress.On:
                    // If not already powered on, turn power on
                    TurnPowerOn();
                    break;
                case eButtonPress.Off:
                    // If powered on, turn power off
                    TurnPowerOff();
                    break;
                case eButtonPress.Up:
                    break;
                case eButtonPress.Down:
                    break;
                case eButtonPress.Left:
                    break;
                case eButtonPress.Right:
                    break;
                case eButtonPress.A:
                    break;
                case eButtonPress.B:
                    break;
                case eButtonPress.Start:
                    break;
                case eButtonPress.Select:
                    break;
                default:
                    break;
            }
        }

        public void TurnPowerOn()
        {
            oscillator.Start();
            stopwatch.Start();
        }

        public void TurnPowerOff()
        {
            oscillator.Stop();
            ulong elapsed = (ulong)stopwatch.ElapsedMilliseconds;
            stopwatch.Stop();

            double CyclesPerSecond = (double)oscillator.CycleCount / elapsed / 1000;

            Logger.WriteLine("Elapsed Milliseconds:" + elapsed.ToString(), Logger.LogLevel.Information);
            Logger.WriteLine("CycleCount:" + oscillator.CycleCount.ToString(), Logger.LogLevel.Information);
            Logger.WriteLine("Cycles/second:" + CyclesPerSecond + "MHz", Logger.LogLevel.Information);
        }
        #endregion
    }
}
