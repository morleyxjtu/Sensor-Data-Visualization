using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    class Read
    {
        private string[] header;
        private float[,] data;
        private int nLines;
        private int nColumns;

        //constructor
        public Read(Stream myStream, TextBox rotation)
        {
            string aux;
            string[] pieces;
            float rota = float.Parse(rotation.Text);
            //float ini_time;

            //read the file line by line
            StreamReader sr = new StreamReader(myStream);
            aux = sr.ReadLine();
            header = aux.Split('\t');
            nColumns = 2;
            nLines = 0;
            while ((aux = sr.ReadLine()) != null)
            {
               if (aux.Length > 0) nLines++;
            }

            //read the numerical data from file in an array
            data = new float[nLines, nColumns];
            sr.BaseStream.Seek(0, 0);
            sr.ReadLine();
            //aux = sr.ReadLine();
            //pieces = aux.Split(',');
            //ini_time = float.Parse(pieces[4]);
            for (int i = 0; i < nLines; i++)
            {
                aux = sr.ReadLine();
                pieces = aux.Split('\t');
                //for (int j = 0; j < nColumns; j++) data[i, j] = float.Parse(pieces[j]);
                data[i, 0] = i;
                if (float.Parse(pieces[1]) < rota/2)
                    data[i, 1] = float.Parse(pieces[1]);
                else
                    data[i, 1] = float.Parse(pieces[1]) - rota;
            }
            sr.Close();
        }

        public int get_nLines()
        {
            return nLines;
        }

        public int get_nColumns()
        {
            return nColumns;
        }

        public float[,] get_Data()
        {
            return data;
        }

        public string[] get_Header()
        {
            return header;
        }
    }
}
