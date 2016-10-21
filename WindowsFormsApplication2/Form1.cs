using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication2
{

    public partial class Form1 : Form
    {
        Read rr;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.Stream myStream = null;
            OpenFileDialog ff = new OpenFileDialog();

            ff.InitialDirectory = "c:\\";
            ff.Filter = "text files (*.txt)|*.txt|All files (*.*)|*.*";
            ff.FilterIndex = 1;
            ff.RestoreDirectory = true;

            if (ff.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = ff.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            rr = null;
                            rr = new Read(myStream, rotation);
                            lowB.Text = "0";
                            highB.Text = rr.get_nLines().ToString();
                            /*
                            string[] header = rr.get_Header();
                            List<string> lX = new List<string>();
                            List<string> lY = new List<string>();
                            for (int i = 0; i < header.Length; i++)
                            {
                                lX.Add(header[i]); lY.Add(header[i]);
                            }
                            //Populate the ComboBoxes
                            xBox.DataSource = lX;
                            yBox.DataSource = lY;
                            */
                            myStream.Close();
                        }
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            if (rr != null)
            {
                Plot pl = new Plot(rr, lowB, highB, chart);
                double aver = pl.get_average();
                averageBox.Text = aver.ToString();
            }
            else
            {
                MessageBox.Show("Error, no data to plot! Please load txt file");
                return;
            }
        }

        private void recover_Click(object sender, EventArgs e)
        {
            lowB.Text = "0";
            highB.Text = rr.get_nLines().ToString();
            if (rr != null)
            {
                Plot pl = new Plot(rr, lowB, highB, chart);
                double aver = pl.get_average();
                averageBox.Text = aver.ToString();
            }
            else
            {
                MessageBox.Show("Error, no data to plot! Please load txt file");
                return;
            }

        }
    }


}
