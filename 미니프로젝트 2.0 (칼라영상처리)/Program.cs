using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 미니프로젝트_2._0__칼라영상처리_
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 스플래쉬 폼 실행 후
            SplashForm splashForm = new SplashForm();
            Application.Run(splashForm);

            // 영상처리 프로그램 실행
            Application.Run(new Form1());
        }
    }
}
