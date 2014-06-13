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
         
        public UserControl1()
        {
            InitializeComponent();
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
                    parent.BtnUcs[0].SwStatBtn.Text = "Off";
                }
                else
                {
                    value = -1;
                    parent.BtnUcs[0].SwStatBtn.Text = "On";
                }                
                parent.OpcOnOff(SwAddrTxt.Text, value, SwStatBtn);
               
            }
            else
            {
                if (SwStatBtn.Text == "On")
                {
                    value = 0;
                    parent.BtnUcs[1].SwStatBtn.Text = "On";
                }
                else
                {
                    value = -1;
                    parent.BtnUcs[1].SwStatBtn.Text = "Off";
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
                    parent.BtnUcs[0].DoStatBtn.Text = "Off";
                }
                else
                {
                    value = -1;
                    parent.BtnUcs[0].DoStatBtn.Text = "On";
                }
                parent.OpcOnOff(DoAddrTxt.Text, value, DoStatBtn);
            }
            else
            {
                if (DoStatBtn.Text == "On")
                {
                    value = 0;
                    parent.BtnUcs[1].DoStatBtn.Text = "On";
                }
                else
                {
                    value = -1;
                    parent.BtnUcs[1].DoStatBtn.Text = "Off";
                }
            }
            parent.OpcOnOff(DoAddrTxt.Text, value, DoStatBtn);
        }

        private void AnsStatBtn_Click(object sender, EventArgs e)
        {
            var parent = this.Parent as MainUserControl.UserControl1;
            int value;
            if (AnsAddrTxt.Text.Contains("/"))
            {
                if (AnsStatBtn.Text == "Off")
                {
                    value = 0;
                    parent.BtnUcs[0].AnsStatBtn.Text = "Off";
                }
                else
                {
                    value = -1;
                    parent.BtnUcs[0].AnsStatBtn.Text = "On";
                }
                parent.OpcOnOff(AnsAddrTxt.Text, value, AnsStatBtn);
            }
            else
            {
                if (AnsStatBtn.Text == "On")
                {
                    value = 0;
                    parent.BtnUcs[1].AnsStatBtn.Text = "On";
                }
                else
                {
                    value = -1;
                    parent.BtnUcs[1].AnsStatBtn.Text = "Off";
                }
                parent.OpcOnOff(AnsAddrTxt.Text, value, AnsStatBtn);
            }
        }

    }
}
