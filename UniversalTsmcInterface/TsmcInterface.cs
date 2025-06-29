using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace Mackoy.Bvets.TsmcInterface
{
    public class TsmcInterface : Mackoy.Bvets.IInputDevice
    {
        private SerialPort myPort = null;
        private string lastWord = string.Empty;

        public static Settings settings = null;

        public event InputEventHandler KeyDown;
        public event InputEventHandler KeyUp;
        public event InputEventHandler LeverMoved;

        public void Load(string settingsPath)
        {
            settings = Settings.LoadFromXml(settingsPath);

            openPort();

            if (myPort != null)
            {
                try
                {
                    myPort.Write(new byte[] { 0 }, 0, 1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Universal TS Controller Interface", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        public void SetAxisRanges(int[][] ranges)
        {
        }

        public void Tick()
        {
            if (myPort == null)
            {
                return;
            }

            string text;
            try
            {
                text = myPort.ReadExisting();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Universal TS Controller Interface", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                closePort();
                return;
            }
            if (text.Length == 0)
            {
                return;
            }

            string[] words = (lastWord + text).Split('\r');
            for (int i = 0; i < words.Length - 1; i++)
            {
                switch (words[i])
                {
                    case "TSB20":
                        onLeverMoved(3, -9);
                        break;
                    case "TSB30":
                        onLeverMoved(3, -8);
                        break;
                    case "TSB40":
                        onLeverMoved(3, -7);
                        break;
                    case "TSE99":
                        onLeverMoved(3, -6);
                        break;
                    case "TSA05":
                        onLeverMoved(3, -5);
                        break;
                    case "TSA15":
                        onLeverMoved(3, -4);
                        break;
                    case "TSA25":
                        onLeverMoved(3, -3);
                        break;
                    case "TSA35":
                        onLeverMoved(3, -2);
                        break;
                    case "TSA45":
                        onLeverMoved(3, -1);
                        break;
                    case "TSA50":
                        onLeverMoved(3, 0);
                        break;
                    case "TSA55":
                        onLeverMoved(3, 1);
                        break;
                    case "TSA65":
                        onLeverMoved(3, 2);
                        break;
                    case "TSA75":
                        onLeverMoved(3, 3);
                        break;
                    case "TSA85":
                        onLeverMoved(3, 4);
                        break;
                    case "TSA95":
                        onLeverMoved(3, 5);
                        break;
                    case "TSB60":
                        onLeverMoved(3, 6);
                        break;
                    case "TSB70":
                        onLeverMoved(3, 7);
                        break;
                    case "TSB80":
                        onLeverMoved(3, 8);
                        break;
                    case "TSG99":
                        onLeverMoved(0, 1);
                        break;
                    case "TSG50":
                        onLeverMoved(0, 0);
                        break;
                    case "TSG00":
                        onLeverMoved(0, -1);
                        break;
                    case "TSK99":
                        onKeyDown(settings.ButtonS[0], settings.ButtonS[1]);
                        break;
                    case "TSK00":
                        onKeyUp(settings.ButtonS[0], settings.ButtonS[1]);
                        break;
                    case "TSX99":
                        onKeyDown(settings.ButtonA[0], settings.ButtonA[1]);
                        break;
                    case "TSX00":
                        onKeyUp(settings.ButtonA[0], settings.ButtonA[1]);
                        break;
                    case "TSY99":
                        onKeyDown(settings.ButtonB[0], settings.ButtonB[1]);
                        break;
                    case "TSY00":
                        onKeyUp(settings.ButtonB[0], settings.ButtonB[1]);
                        break;
                    case "TSZ99":
                        onKeyDown(settings.ButtonC[0], settings.ButtonC[1]);
                        break;
                    case "TSZ00":
                        onKeyUp(settings.ButtonC[0], settings.ButtonC[1]);
                        break;
                    case "S0":
                        onKeyDown(settings.Button0[0], settings.Button0[1]);
                        break;
                    case "S100":
                        onKeyUp(settings.Button0[0], settings.Button0[1]);
                        break;
                    case "S1":
                        onKeyDown(settings.Button1[0], settings.Button1[1]);
                        break;
                    case "S101":
                        onKeyUp(settings.Button1[0], settings.Button1[1]);
                        break;
                    case "S2":
                        onKeyDown(settings.Button2[0], settings.Button2[1]);
                        break;
                    case "S102":
                        onKeyUp(settings.Button2[0], settings.Button2[1]);
                        break;
                    case "S3":
                        onKeyDown(settings.Button3[0], settings.Button3[1]);
                        break;
                    case "S103":
                        onKeyUp(settings.Button3[0], settings.Button3[1]);
                        break;
                    case "S4":
                        onKeyDown(settings.Button4[0], settings.Button4[1]);
                        break;
                    case "S104":
                        onKeyUp(settings.Button4[0], settings.Button4[1]);
                        break;
                    case "S5":
                        onKeyDown(settings.Button5[0], settings.Button5[1]);
                        break;
                    case "S105":
                        onKeyUp(settings.Button5[0], settings.Button5[1]);
                        break;
                    case "S6":
                        onKeyDown(settings.Button6[0], settings.Button6[1]);
                        break;
                    case "S106":
                        onKeyUp(settings.Button6[0], settings.Button6[1]);
                        break;
                    case "S7":
                        onKeyDown(settings.Button7[0], settings.Button7[1]);
                        break;
                    case "S107":
                        onKeyUp(settings.Button7[0], settings.Button7[1]);
                        break;
                    case "S8":
                        onKeyDown(settings.Button8[0], settings.Button8[1]);
                        break;
                    case "S108":
                        onKeyUp(settings.Button8[0], settings.Button8[1]);
                        break;
                    case "S9":
                        onKeyDown(settings.Button9[0], settings.Button9[1]);
                        break;
                    case "S109":
                        onKeyUp(settings.Button9[0], settings.Button9[1]);
                        break;
                    case "S10":
                        onKeyDown(settings.Button10[0], settings.Button10[1]);
                        break;
                    case "S110":
                        onKeyUp(settings.Button10[0], settings.Button10[1]);
                        break;
                    case "S11":
                        onKeyDown(settings.Button11[0], settings.Button11[1]);
                        break;
                    case "S111":
                        onKeyUp(settings.Button11[0], settings.Button11[1]);
                        break;
                    case "S12":
                        onKeyDown(settings.Button12[0], settings.Button12[1]);
                        break;
                    case "S112":
                        onKeyUp(settings.Button12[0], settings.Button12[1]);
                        break;
                    case "S13":
                        onKeyDown(settings.Button13[0], settings.Button13[1]);
                        break;
                    case "S113":
                        onKeyUp(settings.Button13[0], settings.Button13[1]);
                        break;
                    case "S14":
                        onKeyDown(settings.Button14[0], settings.Button14[1]);
                        break;
                    case "S114":
                        onKeyUp(settings.Button14[0], settings.Button14[1]);
                        break;
                    case "S15":
                        onKeyDown(settings.Button15[0], settings.Button15[1]);
                        break;
                    case "S115":
                        onKeyUp(settings.Button15[0], settings.Button15[1]);
                        break;
                    case "S16":
                        onKeyDown(settings.Button16[0], settings.Button16[1]);
                        break;
                    case "S116":
                        onKeyUp(settings.Button16[0], settings.Button16[1]);
                        break;
                    case "S17":
                        onKeyDown(settings.Button17[0], settings.Button17[1]);
                        break;
                    case "S117":
                        onKeyUp(settings.Button17[0], settings.Button17[1]);
                        break;
                    case "S18":
                        onKeyDown(settings.Button18[0], settings.Button18[1]);
                        break;
                    case "S118":
                        onKeyUp(settings.Button18[0], settings.Button18[1]);
                        break;
                    case "S19":
                        onKeyDown(settings.Button19[0], settings.Button19[1]);
                        break;
                    case "S119":
                        onKeyUp(settings.Button19[0], settings.Button19[1]);
                        break;
                }
            }

            lastWord = words[words.Length - 1];
        }

        public void Configure(IWin32Window owner)
        {
            using (ConfigForm form = new ConfigForm())
            {
                form.ShowDialog(owner);
            }
        }

        public void Dispose()
        {
            closePort();

            if (settings != null)
            {
                settings.SaveToXml();
                settings = null;
            }
        }

        private void openPort()
        {
            try
            {
                myPort = new SerialPort("COM" + settings.Port.ToString(), 19200, Parity.None, 8, StopBits.One);
                myPort.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Universal TS Controller Interface", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                closePort();
            }
        }

        private void closePort()
        {
            if (myPort != null)
            {
                try
                {
                    myPort.Close();
                }
                catch { }
                try
                {
                    myPort.Dispose();
                }
                catch { }
                myPort = null;
            }
        }

        private void onLeverMoved(int axis, int notch)
        {
            if (LeverMoved != null)
            {
                LeverMoved(this, new InputEventArgs(axis, notch));
            }
        }

        private void onKeyDown(int axis, int keyCode)
        {
            if (LeverMoved != null)
            {
                KeyDown(this, new InputEventArgs(axis, keyCode));
            }
        }

        private void onKeyUp(int axis, int keyCode)
        {
            if (LeverMoved != null)
            {
                KeyUp(this, new InputEventArgs(axis, keyCode));
            }
        }
    }
}
