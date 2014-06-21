using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Design;
using ButtonUserControl;

namespace MainUserControl
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]    
    public partial class UserControl1: UserControl
    {

        ButtonUserControl.UserControl1[] _BtnUcs;

        public ButtonUserControl.UserControl1[] BtnUcs
        {
            get
            {
                return _BtnUcs;
            }
            set
            {
                _BtnUcs = value;
            }

        }
        public Button AmButton
        {
            get
            {
                return AmStatBtn;
            }
            set
            {
                AmButton = value;
            }

        }

        public Button OpButton
        {
            get
            {
                return OpAddrBtn;
            }
            set
            {
                OpAddrBtn = value;
            }

        }

        [Browsable(true)]
        [Description("Tag Text")]
        [Category("Appearance")]
        public string TagTextbox
        {
            get
            {
                return this.TagTxt.Text;
            }
            set
            {
                this.TagTxt.Text = value;
            }
        }

        [Browsable(true)]
        [Description("Intrument 1 Text")]
        [Category("Appearance")]
        public string Intru1Textbox
        {
            get
            {
                return this.Instru1Txt.Text;
            }
            set
            {
                this.Instru1Txt.Text = value;
            }
        }

        [Browsable(true)]
        [Description("Instrument 2 Text")]
        [Category("Appearance")]
        public string Intru2Textbox
        {
            get
            {
                return this.Instru2Txt.Text;
            }
            set
            {
                this.Instru2Txt.Text = value;
            }
        }
        
        [Browsable(true)]
        [Description("Auto-Manual Address Text")]
        [Category("Appearance")]
        public string AmAddrTextbox
        {
            get
            {
                return this.AmAddrTxt.Text;
            }
            set
            {
                this.AmAddrTxt.Text = value;
            }
        }
        
        [Browsable(true)]
        [Description("Operation Comment Address Text")]
        [Category("Appearance")]
        public string OpAddrTextbox
        {
            get
            {
                return this.OpAddrTxt.Text;
            }
            set
            {
                this.OpAddrTxt.Text = value;
            }
        }

        [Browsable(true)]
        [Description("AM Status Text")]
        [Category("Appearance")]
        public string AmStatusText
        {
            get
            {
                return this.AmStatBtn.Text;
            }
            set
            {
                this.AmStatBtn.Text = value;
            }
        }

        [Browsable(true)]
        [Description("AM Status Text")]
        [Category("Appearance")]
        public string OPStatusText
        {
            get
            {
                return this.OpAddrBtn.Text;
            }
            set
            {
                this.OpAddrBtn.Text = value;
            }
        }

        [Browsable(true)]
        [Description("Operational Comment Status Text")]
        [Category("Appearance")]
        public string OPStatTextbox
        {
            get
            {
                return this.OPStatText.Text;
            }
            set
            {
                this.OPStatText.Text = value;
            }
        }

        DxpSimpleAPI.DxpSimpleClass opc;
        public UserControl1(DxpSimpleAPI.DxpSimpleClass opc)
        {
            this.opc = opc;
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            Btn1Uc.Enabled = true;
            Btn2Uc.Enabled = true;
            Btn3Uc.Enabled = true;
            Btn4Uc.Enabled = true;

            _BtnUcs = new ButtonUserControl.UserControl1[] { Btn1Uc, Btn2Uc, Btn3Uc, Btn4Uc };
        }

        
        private void AmStatBtn_Click(object sender, EventArgs e)
        {
            int value;
            if (AmStatBtn.Text == "On")
            {
                value = 0;
            }
            else
            {
                value = -1;
            }
            OpcOnOff(AmAddrTxt.Text, value, AmStatBtn);
        }

        private void OpAddrBtn_Click(object sender, EventArgs e)
        {
            int value;
            if ((OPStatText.Text == "0") || (OPStatText.Text.ToLower() == "none"))
            {
                value = 0;
            }
            else if ((OPStatText.Text == "1") || (OPStatText.Text.ToLower() == "prohibition"))
            {
                value = 1;
            }
            else if ((OPStatText.Text == "2") || (OPStatText.Text.ToLower() == "maintenance"))
            {
                value = 2;
            }
            else if ((OPStatText.Text == "3") || (OPStatText.Text.ToLower() == "broke"))
            {
                value = 3;
            }
            else
            {
                return;
            }
            OpcOnOff(OpAddrTxt.Text, value, OpAddrBtn);
        }
        public void OpcOnOff(string addr, int value, Button btn)
        {
            try
            {               
                int[] nErrorArray;
                short[] wQualityArray;
                OpcRcw.Da.FILETIME[] fTimeArray;
                if(addr.Contains("/"))
                {
                    string newaddr = addr.Replace("/", "");
                    string[] target = new string[] { newaddr };
                    object[] val = new object[] { value };
                    opc.Write(target, val, out nErrorArray);
                    if (nErrorArray[0] != 0)
                    {
                        return;
                    }
                    if (opc.Read(target, out val, out wQualityArray, out fTimeArray, out nErrorArray) == true)
                    {
                        string regValue;
                        regValue = ReadValCopy(val[0], 0, nErrorArray[0]);
                        if (btn == OpAddrBtn)
                        {
                            if (regValue == "0")
                            {
                                OPStatText.Text = "None";
                            }
                            else if (regValue == "1") 
                            {
                                OPStatText.Text = "Prohibition";
                            }
                            else if (regValue == "2") 
                            {
                                OPStatText.Text = "Maintenance";
                            }
                            else if (regValue == "3")
                            {
                                OPStatText.Text = "Broke";
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
                                btn.Text = "Off";

                            }
                            else if (regValue == "False" || regValue == "0")
                            {
                                btn.Text = "On";
                            }
                        }
                    }
                }
                else
                {
                    string[] target = new string[] { addr };
                    object[] val = new object[] { value };
                    opc.Write(target, val, out nErrorArray);
                    if (nErrorArray[0] != 0)
                    {
                        return;
                    }
                    if (opc.Read(target, out val, out wQualityArray, out fTimeArray, out nErrorArray) == true)
                    {
                        string regValue;
                        regValue = ReadValCopy(val[0], 0, nErrorArray[0]);
                        if (btn == OpAddrBtn)
                        {
                            if (regValue == "0")
                            {
                                OPStatText.Text = "None";
                            }
                            else if (regValue == "1")
                            {
                                OPStatText.Text = "Prohibition";
                            }
                            else if (regValue == "2")
                            {
                                OPStatText.Text = "Maintenance";
                            }
                            else if (regValue == "3")
                            {
                                OPStatText.Text = "Broke";
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
                                btn.Text = "On";

                            }
                            else if (regValue == "False" || regValue == "0")
                            {
                                btn.Text = "Off";
                            }
                        }
                    }
                }
               
           }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
