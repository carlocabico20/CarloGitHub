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
using Microsoft.VisualBasic.FileIO;
using MainUserControl;
using System.Diagnostics;

namespace PC_DCS_Tool_No3
{
    public partial class Form1 : Form
    {

        DxpSimpleAPI.DxpSimpleClass opc = new DxpSimpleAPI.DxpSimpleClass();
        public Panel getPanel
        {
            get
            {
                return panel1;
            }
            set
            {
                panel1 = value;
            }

        }
        public Form1()
        { 
            InitializeComponent();
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
            for (int i = 0; i < panel1.Controls.Count; i++)
            {
                UserControl1 btn = panel1.Controls[i] as UserControl1;               
                Button[] btnVal = new Button[] {
                    btn.AmButton,
                    btn.OpButton               
                };

                if (btn == null)
                {
                    Debug.WriteLine(string.Format("i={0} skipped;", i));
                    continue;
                }
                for (int k = 0; k < btnVal.Length; k++ )
                {
                    CheckButtonStatus(btn, btnVal[k]);
                };
                       
            }            
        }

        public void CheckButtonStatus(UserControl1 btn, Button btnVal) //, Button btnVal
        {
     
            if (opc.Connect(txtNode.Text, cmbServerList.Text))
            {
                btnListRefresh.Enabled = false;
                btnDisconnect.Enabled = true;
                btnConnect.Enabled = false;
                string[] target = new string[2];
               // string[] target = new string[];
                for (int l = 0; l < btn.BtnUcs.Length; l++)
                {
                    target[0] = btn.AmAddrTextbox;
                    target[1] = btn.OpAddrTextbox;

                 object[] val;
                 int[] nErrorArray;
                 short[] wQualityArray;
                    OpcRcw.Da.FILETIME[] fTimeArray;

                    if (opc.Read(target, out val, out wQualityArray, out fTimeArray, out nErrorArray) == true)
                    {
                        string regValue;
                        regValue = ReadValCopy(val[1], 0, nErrorArray[0]);
                                if (btnVal == btn.OpButton)
                                {
                                    if (regValue == "0") 
                                    {
                                        btn.OPStatTextbox = "None";
                                    }
                                    else if (regValue == "1") 
                                    {
                                        btn.OPStatTextbox = "Prohibition";
                                    }
                                    else if (regValue == "2") 
                                    {
                                        btn.OPStatTextbox = "Maintenance";
                                    }
                                    else if (regValue == "3") 
                                    {
                                        btn.OPStatTextbox = "Broke";
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    if (regValue == "True" || regValue == "-1")
                                    {
                                        btnVal.Text = "On";
                                    }
                                    else if (regValue == "False" || regValue == "0")
                                    {
                                        btnVal.Text = "Off";
                                    }
                                }
                        }                    
                };
                //ButtonUserControl.UserControl1 parent = new ButtonUserControl.UserControl1(opc);
                //parent.ButtonEvent(opc);  
            }
        }

        private void FileReadBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                List<string[]> list = new List<string[]>();
                using (TextFieldParser parser = new TextFieldParser(openFileDialog1.FileName))
                {
                    parser.Delimiters = new string[] { "," };
                    //bool st = false;
                    while (true)
                    {
                        string[] parts = parser.ReadFields();
                        if (parts == null)
                        {
                            break;
                        }
                        list.Add(parts);
                    }

                    panel1.Controls.Clear();

                    if (list.Count > 0)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            if (list[j][95] == "1")
                            {
                                UserControl1 uc = new UserControl1(opc);
                                uc.Location = new Point(0, 222 * (j));                        
                                
                                panel1.Controls.Add(uc);
                                uc.TagTextbox = list[j][0];
                                uc.Intru1Textbox = list[j][1];
                                uc.Intru2Textbox = list[j][2];
                                uc.AmAddrTextbox = list[j][114];
                                uc.OpAddrTextbox = list[j][119];
                                for (int num = 0; num < uc.BtnUcs.Length; num++)
                                {
                                        uc.BtnUcs[num].ButtonTextbox = list[j][98 + num];
                                        uc.BtnUcs[num].SwAddrTextbox = list[j][102 + num];
                                        uc.BtnUcs[num].DoAddrTextbox = list[j][106 + num];
                                        uc.BtnUcs[num].AnsAddrTextbox = list[j][110 + num];                                        
                                }
                            }
                         }
                    }
                    else
                    {
                        Label message = new Label();
                        message.Text = "There are no lists inside the file.";
                        message.Location = new Point(0, 222);
                        message.Width = 200;
                        panel1.Controls.Add(message);
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
        private string ReadValCopy(object oVal, int n, int nError)
        {
            if (nError != 0)
            {
                return "Read Error";
            }            
            return oVal.ToString();
        }
    }
}
