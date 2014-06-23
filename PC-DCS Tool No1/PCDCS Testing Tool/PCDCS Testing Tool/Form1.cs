using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using WindowsFormsControlLibrary1;

using OpcRcw.Da;
using Microsoft.VisualBasic.FileIO;

namespace PCDCS_Testing_Tool
{
    public partial class Form1 : Form
    {
        DxpSimpleAPI.DxpSimpleClass opc = new DxpSimpleAPI.DxpSimpleClass();
        string[] sItemIDArray = new string[5];
        public Form1()
        {
            InitializeComponent();
        }
        public Panel Panel2
        {
            get
            {
                return panel2;
            }
            set
            {
                panel2 = value;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
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
            if (opc.Connect(txtNode.Text, cmbServerList.Text))
            {
                btnListRefresh.Enabled = false;
                btnDisconnect.Enabled = true;
                btnConnect.Enabled = false;

            }
        }

        object[] oValue = new object[5];
               
        private object WriteValCopy(string sText, int n)
        {
            if (oValue[n] is Array)
            {
                string[] sBufPut = sText.Split(',');
                Array ary = (Array)oValue[n];
                object[] oAry = new object[ary.Length];
                for (int j = 0; j < ary.Length; j++)
                {
                    if (j >= sBufPut.Length)
                        break;
                    try
                    {
                        if (oValue[n] is UInt16)
                        {
                            oAry[j] = UInt16.Parse(sBufPut[j]);
                        }
                        else if (oValue[n] is UInt32)
                        {
                            oAry[j] = UInt32.Parse(sBufPut[j]);
                        }
                        else
                        {
                            oAry[j] = (object)sBufPut[j];
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error");
                    }
                }
                return oAry;
            }
            else
            {
                return sText;
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
                    bool st = false;
                    while (true)
                    {
                        string[] parts = parser.ReadFields();
                        if (parts == null)
                        {
                            break;
                        }
                        if (st)
                        {
                            if (parts[0] != "[END]")
                            {
                                list.Add(parts);
                            }
                            else
                            {
                                st = false;
                            }
                        }
                        if (parts[0] == "[Dictionary for Alarm]")
                        {
                            st = true;
                        }
                    }


                    panel1.Controls.Clear();

                    if (list.Count > 0) {
                        for (int j = 0; j < list.Count; j++)                   
                        {
                            WindowsFormsControlLibrary1.UserControl1 uc = new WindowsFormsControlLibrary1.UserControl1(opc);
                            uc.Location = new Point(0, 30*(j));
                            panel1.Controls.Add(uc);
                            uc.NoTxtBox = list[j][0];
                            uc.TagTxtBox = list[j][1];
                            uc.RegisterTxtBox = list[j][6];
                        }
                    }
                    else {
                        Label message = new Label();
                        message.Text = "There are no lists inside the file.";
                        message.Location = new Point(0, 30);
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

                //txtTag1.ReadOnly = false;
                //txtTag2.ReadOnly = false;
                //txtTag3.ReadOnly = false;
                //txtTag4.ReadOnly = false;
                //txtTag5.ReadOnly = false;
            }
        }
   

  
    }
}
