using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication2
{
    class Plot
    {
        private float average = 0;
        public Plot(Read rr, TextBox lowB, TextBox highB, Chart chart)
        {
            // Code for drawing on the Chart
            //int indX = xBox.SelectedIndex;
            //int indY = yBox.SelectedIndex;
            float[,] data = rr.get_Data();
            int nLines = rr.get_nLines();

            chart.Series.Clear(); //ensure that the chart is empty
            chart.Series.Add("Series0");
            chart.Series[0].ChartType = SeriesChartType.Line;
            chart.Legends.Clear();
            if (string.IsNullOrWhiteSpace(lowB.Text) || string.IsNullOrWhiteSpace(highB.Text)) { 
                for (int j = 0; j < nLines; j++)
                {
                    average += data[j, 1];
                    chart.Series[0].Points.AddXY(data[j, 0], data[j, 1]);
                }
                average = average / nLines;
            }
            else
            {
                int low = int.Parse(lowB.Text);
                int high = int.Parse(highB.Text);
                for (int j = low; j < high; j++)
                {
                    average += data[j, 1];
                    chart.Series[0].Points.AddXY(data[j, 0], data[j, 1]);
                }
                average = average / (high-low);
            }
        }

        public float get_average()
        {
            return average;
        }
    }
}
