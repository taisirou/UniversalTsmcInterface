using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Mackoy.Bvets.TsmcInterface
{
    public partial class ConfigForm : Form
    {
        private string[] cabSwitchKeyTexts = { "Horn 1", "Horn 2", "Constant Speed Control", "Music Horn" };
        private string[] atsKeyTexts = new string[26];
        private List<int[]> keyCodeTable = new List<int[]>();

        public ConfigForm()
        {
            InitializeComponent();

            for (int i = 0; i < atsKeyTexts.Length; i++)
            {
                atsKeyTexts[i] = "ATS " + i.ToString();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            for (int i = 1; i <= 256; i++)
            {
                portList.Items.Add("COM" + i.ToString());
            }
            for (int i = 0; i < cabSwitchKeyTexts.Length; i++)
            {
                addKey(cabSwitchKeyTexts[i]);
                keyCodeTable.Add(new int[2] { -1, i });
            }
            for (int i = 0; i < atsKeyTexts.Length; i++)
            {
                addKey(atsKeyTexts[i]);
                keyCodeTable.Add(new int[2] { -2, i });
            }

            if (TsmcInterface.settings.Port >= 1 && TsmcInterface.settings.Port <= 256)
            {
                portList.SelectedIndex = TsmcInterface.settings.Port - 1;
            }
            selectDropDownList(buttonSKeyList, TsmcInterface.settings.ButtonS);
            selectDropDownList(buttonAKeyList, TsmcInterface.settings.ButtonA);
            selectDropDownList(buttonBKeyList, TsmcInterface.settings.ButtonB);
            selectDropDownList(buttonCKeyList, TsmcInterface.settings.ButtonC);
            selectDropDownList(button0KeyList, TsmcInterface.settings.Button0);
            selectDropDownList(button1KeyList, TsmcInterface.settings.Button1);
            selectDropDownList(button2KeyList, TsmcInterface.settings.Button2);
            selectDropDownList(button3KeyList, TsmcInterface.settings.Button3);
            selectDropDownList(button4KeyList, TsmcInterface.settings.Button4);
            selectDropDownList(button5KeyList, TsmcInterface.settings.Button5);
            selectDropDownList(button6KeyList, TsmcInterface.settings.Button6);
            selectDropDownList(button7KeyList, TsmcInterface.settings.Button7);
            selectDropDownList(button8KeyList, TsmcInterface.settings.Button8);
            selectDropDownList(button9KeyList, TsmcInterface.settings.Button9);
            selectDropDownList(button10KeyList, TsmcInterface.settings.Button10);
            selectDropDownList(button11KeyList, TsmcInterface.settings.Button11);
            selectDropDownList(button12KeyList, TsmcInterface.settings.Button12);
            selectDropDownList(button13KeyList, TsmcInterface.settings.Button13);
            selectDropDownList(button14KeyList, TsmcInterface.settings.Button14);
            selectDropDownList(button15KeyList, TsmcInterface.settings.Button15);
            selectDropDownList(button16KeyList, TsmcInterface.settings.Button16);
            selectDropDownList(button17KeyList, TsmcInterface.settings.Button17);
            selectDropDownList(button18KeyList, TsmcInterface.settings.Button18);
            selectDropDownList(button19KeyList, TsmcInterface.settings.Button19);
        }

        private void addKey(string s)
        {
            buttonSKeyList.Items.Add(s);
            buttonAKeyList.Items.Add(s);
            buttonBKeyList.Items.Add(s);
            buttonCKeyList.Items.Add(s);
            button0KeyList.Items.Add(s);
            button1KeyList.Items.Add(s);
            button2KeyList.Items.Add(s);
            button3KeyList.Items.Add(s);
            button4KeyList.Items.Add(s);
            button5KeyList.Items.Add(s);
            button6KeyList.Items.Add(s);
            button7KeyList.Items.Add(s);
            button8KeyList.Items.Add(s);
            button9KeyList.Items.Add(s);
            button10KeyList.Items.Add(s);
            button11KeyList.Items.Add(s);
            button12KeyList.Items.Add(s);
            button13KeyList.Items.Add(s);
            button14KeyList.Items.Add(s);
            button15KeyList.Items.Add(s);
            button16KeyList.Items.Add(s);
            button17KeyList.Items.Add(s);
            button18KeyList.Items.Add(s);
            button19KeyList.Items.Add(s);
        }

        private void selectDropDownList(ComboBox list, int[] assign)
        {
            switch (assign[0])
            {
                case -1:
                    if (assign[1] >= 0 && assign[1] < cabSwitchKeyTexts.Length)
                    {
                        list.SelectedIndex = assign[1];
                    }
                    break;
                case -2:
                    if (assign[1] >= 0 && assign[1] < atsKeyTexts.Length)
                    {
                        list.SelectedIndex = assign[1] + cabSwitchKeyTexts.Length;
                    }
                    break;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (portList.SelectedIndex >= 0)
            {
                TsmcInterface.settings.Port = portList.SelectedIndex + 1;
            }
            if (buttonSKeyList.SelectedIndex >= 0)
            {
                TsmcInterface.settings.ButtonS = keyCodeTable[buttonSKeyList.SelectedIndex];
            }
            if (buttonAKeyList.SelectedIndex >= 0)
            {
                TsmcInterface.settings.ButtonA = keyCodeTable[buttonAKeyList.SelectedIndex];
            }
            if (buttonBKeyList.SelectedIndex >= 0)
            {
                TsmcInterface.settings.ButtonB = keyCodeTable[buttonBKeyList.SelectedIndex];
            }
            if (buttonCKeyList.SelectedIndex >= 0)
            {
                TsmcInterface.settings.ButtonC = keyCodeTable[buttonCKeyList.SelectedIndex];
            }
            if (button0KeyList.SelectedIndex >= 0)
            {
                TsmcInterface.settings.Button0 = keyCodeTable[button0KeyList.SelectedIndex];
            }
            if (button1KeyList.SelectedIndex >= 0)
            {
                TsmcInterface.settings.Button1 = keyCodeTable[button1KeyList.SelectedIndex];
            }
            if (button2KeyList.SelectedIndex >= 0)
            {
                TsmcInterface.settings.Button2 = keyCodeTable[button2KeyList.SelectedIndex];
            }
            if (button3KeyList.SelectedIndex >= 0)
            {
                TsmcInterface.settings.Button3 = keyCodeTable[button3KeyList.SelectedIndex];
            }
            if (button4KeyList.SelectedIndex >= 0)
            {
                TsmcInterface.settings.Button4 = keyCodeTable[button4KeyList.SelectedIndex];
            }
            if (button5KeyList.SelectedIndex >= 0)
            {
                TsmcInterface.settings.Button5 = keyCodeTable[button5KeyList.SelectedIndex];
            }
            if (button6KeyList.SelectedIndex >= 0)
            {
                TsmcInterface.settings.Button6 = keyCodeTable[button6KeyList.SelectedIndex];
            }
            if (button7KeyList.SelectedIndex >= 0)
            {
                TsmcInterface.settings.Button7 = keyCodeTable[button7KeyList.SelectedIndex];
            }
            if (button8KeyList.SelectedIndex >= 0)
            {
                TsmcInterface.settings.Button8 = keyCodeTable[button8KeyList.SelectedIndex];
            }
            if (button9KeyList.SelectedIndex >= 0)
            {
                TsmcInterface.settings.Button9 = keyCodeTable[button9KeyList.SelectedIndex];
            }
            if (button10KeyList.SelectedIndex >= 0)
            {
                TsmcInterface.settings.Button10 = keyCodeTable[button10KeyList.SelectedIndex];
            }
            if (button11KeyList.SelectedIndex >= 0)
            {
                TsmcInterface.settings.Button11 = keyCodeTable[button11KeyList.SelectedIndex];
            }
            if (button12KeyList.SelectedIndex >= 0)
            {
                TsmcInterface.settings.Button12 = keyCodeTable[button12KeyList.SelectedIndex];
            }
            if (button13KeyList.SelectedIndex >= 0)
            {
                TsmcInterface.settings.Button13 = keyCodeTable[button13KeyList.SelectedIndex];
            }
            if (button14KeyList.SelectedIndex >= 0)
            {
                TsmcInterface.settings.Button14 = keyCodeTable[button14KeyList.SelectedIndex];
            }
            if (button15KeyList.SelectedIndex >= 0)
            {
                TsmcInterface.settings.Button15 = keyCodeTable[button15KeyList.SelectedIndex];
            }
            if (button16KeyList.SelectedIndex >= 0)
            {
                TsmcInterface.settings.Button16 = keyCodeTable[button16KeyList.SelectedIndex];
            }
            if (button17KeyList.SelectedIndex >= 0)
            {
                TsmcInterface.settings.Button17 = keyCodeTable[button17KeyList.SelectedIndex];
            }
            if (button18KeyList.SelectedIndex >= 0)
            {
                TsmcInterface.settings.Button18 = keyCodeTable[button18KeyList.SelectedIndex];
            }
            if (button19KeyList.SelectedIndex >= 0)
            {
                TsmcInterface.settings.Button19 = keyCodeTable[button19KeyList.SelectedIndex];
            }                                 
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {

        }
    }
}
