using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 미니프로젝트_2._0__칼라영상처리_
{
    public partial class subForm2 : Form
    {
        public subForm2(string labletxt1, string labletxt2)
        {
            InitializeComponent();
            label1.Text = labletxt1;
            label2.Text = labletxt2;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void num_UD1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
