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
    public partial class GraphicForm : Form
    {
        public GraphicForm(long[,] inh, long[,] outh)
        {
            InitializeComponent();
            inHisto = inh;
            outHisto = outh;
        }

        long[,] inHisto, outHisto;
        int RGB = 3;

        private void GraphicForm_Load(object sender, EventArgs e)
        {
            chart1.Visible = true;
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart1.Series[0].Color = Color.Red;
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart1.Series[1].Color = Color.Green;
            chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart1.Series[2].Color = Color.Blue;

            chart2.Visible = true;
            chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart2.Series[0].Color = Color.Red;
            chart2.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart2.Series[1].Color = Color.Green;
            chart2.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart2.Series[2].Color = Color.Blue;

            for (int rgb = 0; rgb < RGB; rgb++)
                for (int i = 0; i < 256; i++)
                {
                    chart1.Series[rgb].Points.AddXY(i, inHisto[rgb, i]);
                    chart2.Series[rgb].Points.AddXY(i, outHisto[rgb, i]);
                }
        }
    }
}
