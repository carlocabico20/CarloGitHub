using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpcRcw.Da;

namespace PC_DCS_Tool_No2
{
    public partial class Form1 : Form
    {
        DxpSimpleAPI.DxpSimpleClass opc = new DxpSimpleAPI.DxpSimpleClass();
        private int value;
        private string[] reg = {
                            "DEV1.SM403",
                            "DEV2.SM403",
                            "DEV3.SM403",
                            "DEV4.SM403",
                            "DEV5.SM403",
                            "DEV6.SM403",
                            "DEV7.SM403",
                            "DEV8.SM403",
                            "DEV9.SM403",
                            "DEV10.SM403" };
        public Form1()
        {
            InitializeComponent();
        }
            
        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox1.Tag = reg[0];
            checkBox2.Tag = reg[1];
            checkBox3.Tag = reg[2];
            checkBox4.Tag = reg[3];
            checkBox5.Tag = reg[4];
            checkBox6.Tag = reg[5];
            checkBox7.Tag = reg[6];
            checkBox8.Tag = reg[7];
            checkBox9.Tag = reg[8];
            checkBox10.Tag = reg[9];
        }
        private string ReadValCopy(object oVal, int n, int nError)
        {
            if (nError != 0)
            {
                return "Read Error";
            }

            return oVal.ToString();
        }
        private void OpcOnOff(int value, string register)
        {
            try
            {
                string[] target = new string[] { register };
                object[] val = new object[] { value };
                int[] nErrorArray;

                opc.Write(target, val, out nErrorArray);
                if (nErrorArray[0] != 0)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnListRefresh_Click(object sender, EventArgs e)
        {
            cmbServerList.Items.Clear();
            string[] ServerNameArray;
            opc.EnumServerList(txtNode.Text, out ServerNameArray);

            for (int a = 0; a < ServerNameArray.Count<string>(); a++)
            {
                cmbServerList.Items.Add(ServerNameArray[a]);
            }
            cmbServerList.SelectedIndex = 0;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {

                if (opc.Connect(txtNode.Text, cmbServerList.Text))
                {
                    btnListRefresh.Enabled = false;
                    btnDisconnect.Enabled = true;
                    btnConnect.Enabled = false;

                    for (int num = 0; num < reg.Length; num++ )
                    {
                        string[] target = new string[] { reg[num] };
                        CheckPlcStatus(target, num);
                    }
                }
            }
            catch (Exception ex)
            {
                checkBox3.Enabled = false;
                MessageBox.Show(ex.ToString());
            }
        }

        private void CheckPlcStatus(string[] target, int num)
        {
            CheckBox[] cbs = new CheckBox[] { checkBox1, 
                checkBox2, checkBox3, checkBox4, checkBox5, 
                checkBox6, checkBox7, checkBox8, checkBox9, 
                checkBox10 };
            object[] val = new object[] { value };
            int[] nErrorArray;

            short[] wQualityArray;
            OpcRcw.Da.FILETIME[] fTimeArray;

            if (opc.Read(target, out val, out wQualityArray, out fTimeArray, out nErrorArray) == true)
            {
                string regValue;
                if (nErrorArray[0] != 0)
                {
                    cbs[num].Enabled = false;
                }
                else
                {
                    checkBox1.Enabled = true;
                    regValue = ReadValCopy(val[0], 0, nErrorArray[0]);
                    if (regValue == "True")
                    {
                        cbs[num].Checked = true;
                    }
                    else if (regValue == "False")
                    {
                        cbs[num].Checked = false;                        
                    }
                }
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (opc.Disconnect())
            {
                btnConnect.Enabled = true;
                btnListRefresh.Enabled = true;
                btnDisconnect.Enabled = false;          
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb == null)
            {
                System.Diagnostics.Debug.Assert(false, "CheckBox Casting Failed");
                return;
            }

            if (cb.Checked == true)
            {
                value = -1;
            }
            else
            {
                value = 0;
            }
            OpcOnOff(value, (string)cb.Tag);
        }

     }
}
