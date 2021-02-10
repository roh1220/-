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
    public partial class SplashForm : Form
    {
        delegate void TestDelegate(string msg);
        delegate void TestDelegate2();

        public SplashForm()
        {
            InitializeComponent();

            System.Threading.Thread thread = new System.Threading.Thread(Thread1);
            thread.Start();
        }
        private void showText(string msg)
        {
            label3.Text = "Processing... " + msg + "%";
        }
        private void formClose()
        {
            this.Close();
        }
        private void Thread1()
        {
            for(int i=0;i<=100; i+=5)
            {
                progressBar1.Value = i;
                this.Invoke(new TestDelegate(showText), i.ToString());
                System.Threading.Thread.Sleep(100);
            }
            System.Threading.Thread.Sleep(1000);
            this.Invoke(new TestDelegate2(formClose));
        }
    }
}
