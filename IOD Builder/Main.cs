using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Configuration;
using Excel;

namespace IOD_Builder
{
    public partial class Main : Form
    {
        #region Global Variables
        private BackgroundWorker minion = new BackgroundWorker();
        List<List<string>> pkgList;
        #endregion

        public Main()
        {
            InitializeComponent();
            minion.DoWork += new DoWorkEventHandler(minion_DoWork);
            minion.ProgressChanged += new ProgressChangedEventHandler(minion_ProgressChanged);
            minion.RunWorkerCompleted += new RunWorkerCompletedEventHandler(minion_RunWorkerCompleted);
        }

        #region backgroundworker
        void minion_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (List<string> l in pkgList)
            {
                Console.WriteLine(string.Join(",",l.ToArray()));
            }
            cancelBtn.Text = "Cancel";
        }

        void minion_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           
        }

        void minion_DoWork(object sender, DoWorkEventArgs e)
        {
            Load_Data();
        }
        #endregion

        #region GUI Controls
        private void Form1_Load(object sender, EventArgs e)
        {
            minion.WorkerReportsProgress = true;
            minion.WorkerSupportsCancellation = true;
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            string fn;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select XLSX File";
            ofd.InitialDirectory = "c:\\Documents";
            ofd.Filter = "CSV files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                fn = ofd.FileName;
                filePath.Text = fn;
            }
            else if (result == DialogResult.Cancel)
            {

            }
        }

        private void buildBtn_Click(object sender, EventArgs e)
        {
            if (filePath.Text == "")
            {
                outputBox.Text = "Please select an .xlsx file first.";
            }
            else
            {
                outputBox.Text = "Building...";
                cancelBtn.Text = "Stop";
                minion.RunWorkerAsync();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (minion.IsBusy)
            {
                minion.CancelAsync();
                cancelBtn.Text = "Cancel";
            }
            else
                Environment.Exit(0);
        }
        #endregion

        #region Internal Functions
        private void Load_Data()
        {
            int count = 0;
            pkgList = new List<List<string>>();
            //Need a config file that will identify the worksheet for the program.
            foreach (worksheet ws in Workbook.Worksheets(filePath.Text))
            {
                switch(count) {
                    case 0:
                        SetPkgSpecs(ws);
                    break;

                    case 1:
                        List<List<string>> c0g = new List<List<string>>();
                        SetSeriesInfo(ws,c0g);
                    break;

                    default:
                    break;
                }
                count++;
            }
        }

        private void SetPkgSpecs(worksheet ws)
        {
            pkgList = new List<List<string>>();
            int r = 1;

            while (ws.Rows[r].Cells[3] != null)
            {
                List<string> rowData = new List<string>();
                for (int c = 3; c < 9; c++)
                {
                    rowData.Add(ws.Rows[r].Cells[c].Text);
                }
                pkgList.Add(rowData);
                r++;
            }
        }

        private void SetSeriesInfo(worksheet ws, List<List<string>> series)
        {
            
        }
        #endregion
    }
}
