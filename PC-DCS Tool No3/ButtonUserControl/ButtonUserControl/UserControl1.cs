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

namespace ButtonUserControl
{
     [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class UserControl1: UserControl
    {
         DxpSimpleAPI.DxpSimpleClass opc;
         public UserControl1(DxpSimpleAPI.DxpSimpleClass opc)
        {
            InitializeComponent();
            //var parent = this.Parent as MainUserControl.UserControl1;
            //this.opc = opc;
            //for (int num = 0; num < parent.BtnUcs.Length; num++)
            //{
            //    string[] target = new string[] { parent.BtnUcs[num].SwAddrTextbox, parent.BtnUcs[num].DoAddrTextbox, parent.BtnUcs[num].AnsAddrTextbox };
            //    object[] val;
            //    int[] nErrorArray;
            //    short[] wQualityArray;
            //    OpcRcw.Da.FILETIME[] fTimeArray;
            //    for (int i = 0; i < target.Length; i++)
            //    {
            //        if (opc.Read(target, out val, out wQualityArray, out fTimeArray, out nErrorArray) == true)
            //        {
            //            SwStatBtn.Text = ReadValCopy(val[0], 0, nErrorArray[0]);
            //            DoStatBtn.Text = ReadValCopy(val[0], 0, nErrorArray[0]);
            //            AnsStatBtn.Text = ReadValCopy(val[0], 0, nErrorArray[0]);
            //        }
            //    }
            //}
        }

        
        public Button SwButton
        {
            get
            {
                return SwStatBtn;
            }
            set
            {
                SwStatBtn = value;
            }

        }

        public Button DoButton
        {
            get
            {
                return DoStatBtn;
            }
            set
            {
                DoStatBtn = value;
            }

        }
        public Button AnsButton
        {
            get
            {
                return AnsStatBtn;
            }
            set
            {
                AnsStatBtn = value;
            }

        }
        
        [Browsable(true)]
        [Description("Button Text")]
        [Category("Appearance")]
        public string ButtonTextbox
        {
            get
            {
                return this.BtnTxt.Text;
            }
            set
            {
                this.BtnTxt.Text = value;
            }
        }

        [Browsable(true)]
        [Description("Switch Signal Address Text")]
        [Category("Appearance")]
        public string SwAddrTextbox
        {
            get
            {
                return this.SwAddrTxt.Text;
            }
            set
            {
                this.SwAddrTxt.Text = value;
            }
        }

        [Browsable(true)]
        [Description("Digital Output Signal Address Text")]
        [Category("Appearance")]
        public string DoAddrTextbox
        {
            get
            {
                return this.DoAddrTxt.Text;
            }
            set
            {
                this.DoAddrTxt.Text = value;
            }
        }

        [Browsable(true)]
        [Description("Answer Signal Address Text")]
        [Category("Appearance")]
        public string AnsAddrTextbox
        {
            get
            {
                return this.AnsAddrTxt.Text;
            }
            set
            {
                this.AnsAddrTxt.Text = value;
            }
        }

        [Browsable(true)]
        [Description("Switch Signal Button Text")]
        [Category("Appearance")]
        public string SwBtnTextbox
        {
            get
            {
                return this.SwStatBtn.Text;
            }
            set
            {
                this.SwStatBtn.Text = value;
            }
        }

        [Browsable(true)]
        [Description("Digital Output Signal Button Text")]
        [Category("Appearance")]
        public string DoBtnTextbox
        {
            get
            {
                return this.DoStatBtn.Text;
            }
            set
            {
                this.DoStatBtn.Text = value;
            }
        }

        [Browsable(true)]
        [Description("Answer Signal Button Text")]
        [Category("Appearance")]
        public string AnsBtnTextbox
        {
            get
            {
                return this.AnsStatBtn.Text;
            }
            set
            {
                this.AnsStatBtn.Text = value;
            }
        }


        private void SwStatBtn_Click(object sender, EventArgs e)
        {
            var parent = this.Parent as MainUserControl.UserControl1;
            int value;
            if (SwAddrTxt.Text.Contains("/"))
            {
                if (SwStatBtn.Text == "Off")
                {
                    value = 0;
                //    parent.BtnUcs[0].SwStatBtn.Text = "Off";
                }
                else
                {
                    value = -1;
             //       parent.BtnUcs[0].SwStatBtn.Text = "On";
                }                
                parent.OpcOnOff(SwAddrTxt.Text, value, SwStatBtn);
               
            }
            else
            {
                if (SwStatBtn.Text == "On")
                {
                    value = 0;
               //     parent.BtnUcs[1].SwStatBtn.Text = "On";
                }
                else
                {
                    value = -1;
               //     parent.BtnUcs[1].SwStatBtn.Text = "Off";
                }
                parent.OpcOnOff(SwAddrTxt.Text, value, SwStatBtn);
           }
        }
        private void DoStatBtn_Click(object sender, EventArgs e)
        {
            var parent = this.Parent as MainUserControl.UserControl1;
            int value;
            if (DoAddrTxt.Text.Contains("/"))
            {
                if (DoStatBtn.Text == "Off")
                {
                    value = 0;
                 //   parent.BtnUcs[0].DoStatBtn.Text = "Off";
                }
                else
                {
                    value = -1;
                //    parent.BtnUcs[0].DoStatBtn.Text = "On";
                }
                parent.OpcOnOff(DoAddrTxt.Text, value, DoStatBtn);
            }
            else
            {
                if (DoStatBtn.Text == "On")
                {
                    value = 0;
                  //  parent.BtnUcs[1].DoStatBtn.Text = "On";
                }
                else
                {
                    value = -1;
                  //  parent.BtnUcs[1].DoStatBtn.Text = "Off";
                }
            }
            parent.OpcOnOff(DoAddrTxt.Text, value, DoStatBtn);
        }
         //testing
        private void AnsStatBtn_Click(object sender, EventArgs e)
        {
            var parent = this.Parent as MainUserControl.UserControl1;
            int value;
            if (AnsAddrTxt.Text.Contains("/"))
            {
                if (AnsStatBtn.Text == "Off")
                {
                    value = 0;
                //    parent.BtnUcs[0].AnsStatBtn.Text = "Off";
                }
                else
                {
                    value = -1;
                //    parent.BtnUcs[0].AnsStatBtn.Text = "On";
                }
                parent.OpcOnOff(AnsAddrTxt.Text, value, AnsStatBtn);
            }
            else
            {
                if (AnsStatBtn.Text == "On")
                {
                    value = 0;
                 //   parent.BtnUcs[1].AnsStatBtn.Text = "On";
                }
                else
                {
                    value = -1;
                //    parent.BtnUcs[1].AnsStatBtn.Text = "Off";
                }
                parent.OpcOnOff(AnsAddrTxt.Text, value, AnsStatBtn);
            }
        }

         //public void ButtonEvent(DxpSimpleAPI.DxpSimpleClass opc)
         //{
         //    SwAddrTxt.Text = SwAddrTextbox;
         //    this.opc = opc;
         //    PC_DCS_Tool_No3.Form1 parent;
         //    //= new MainUserControl.UserControl1(opc);
         //    parent = null;
         //    parent = new PC_DCS_Tool_No3.Form1();
         ////    parent = this.Parent as MainUserControl.UserControl1;
         //   // SwAddrTxt.Text =  parent.BtnUcs[0].SwAddrTextbox;
             
         //    //for (int num = 0; num < ctrl.Length; num++)
         //    //{             
         //    // if (opc.Connect(txtNode.Text, cmbServerList.Text))
         //    // {
         //    //var frm = this.Parent as PC_DCS_Tool_No3.Form1;
         //    UserControl1 btn = parent.getPanel.Controls[0] as UserControl1;
         //    SwAddrTxt.Text = btn.SwAddrTextbox;
         //    for (int i = 0; i < parent.getPanel.Controls.Count; i++)
         //    {
         //      //  UserControl1 btn = parent.getPanel.Controls[i] as UserControl1;
         //      //  SwAddrTxt.Text = btn.SwAddrTextbox;
         //    }
             
             
         //    string[] target = new string[] { SwAddrTextbox };
         //        object[] val;
         //        int[] nErrorArray;
         //        short[] wQualityArray;
         //        OpcRcw.Da.FILETIME[] fTimeArray;
         //        for (int i = 0; i < target.Length; i++)
         //        {
         //            if (opc.Read(target, out val, out wQualityArray, out fTimeArray, out nErrorArray) == true)
         //            {
         //                SwStatBtn.Text = ReadValCopy(val[0], 0, nErrorArray[0]);
         //                DoStatBtn.Text = ReadValCopy(val[0], 0, nErrorArray[0]);
         //                AnsStatBtn.Text = ReadValCopy(val[0], 0, nErrorArray[0]);
         //            }
         //        }
         //    //}
         //    // }
         //}
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
