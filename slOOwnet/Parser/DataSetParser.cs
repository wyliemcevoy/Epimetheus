using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace slOOwnet
{
    class DataSetParser
    {
        public LearningDataSet readTextFile(String path)
        {
            LearningDataSet data = null;

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    String line = sr.ReadToEnd();
                    Console.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Parser Error: \n" + e.StackTrace);
            }


            return data;
        }


        public LearningDataSet openFilePicker()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return readTextFile(dialog.FileName);
            }

            return null;
        }

    }
}
