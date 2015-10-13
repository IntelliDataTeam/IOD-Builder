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
using System.Xml;
using OfficeOpenXml;
using System.IO;

namespace IOD_Builder
{

    public partial class Main : Form
    {
        class wSheet
        {
            public string id;
            public string name;
            public string type;
        }

        class Waterfall
        {
            public List<string> lookup;
            public List<string> cap;
            public List<List<string>> table;
            public Waterfall()
            {
                lookup = new List<string>();
                cap = new List<string>();
                table = new List<List<string>>();
            }
        }

        #region Global Variables
        private BackgroundWorker minion = new BackgroundWorker();
        List<List<string>> pkgList;
        List<Waterfall> serList;
        List<wSheet> works;

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
            cancelBtn.Text = "Cancel";
            outputBox.Text = "Done.";
        }

        void minion_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            percentOut.Text = e.ProgressPercentage.ToString() + "%";
        }

        void minion_DoWork(object sender, DoWorkEventArgs e)
        {
            progressBar.Maximum = 100;
            progressBar.Minimum = 0;
            progressBar.Value = 0;
            //xmlRdr();
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
            pkgList = new List<List<string>>();
            serList = new List<Waterfall>();

            FileInfo existingFile = new FileInfo(filePath.Text);
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                int max = package.Workbook.Worksheets.Count;
                for (int x = 1; x <= max; x++)
                {
                    Console.WriteLine(x + " : " + package.Workbook.Worksheets[x].Name);
                    minion.ReportProgress((x/max)*100);
                }
            }
        }

        private void SetPkgSpecs(ExcelWorksheet ws)
        {
            pkgList = new List<List<string>>();
            int r = 1;

            while (ws.Cells[r,3] != null)
            {
                List<string> rowData = new List<string>();
                for (int c = 3; c < 9; c++)
                {
                    rowData.Add(ws.Cells[r,c].Text);
                }
                pkgList.Add(rowData);
                r++;
            }
        }

        private Waterfall SetSeriesTable(ExcelWorksheet ws)
        {
            Waterfall waFa = new Waterfall();
            int c = 1;
            int r = 10;

            // Adding Cap Range
            while (ws.Cells[r,0] != null) {
                waFa.cap.Add(ws.Cells[r,0].Text);
                r++;
            }
            // Adding lookup values
            while (ws.Cells[4,c] != null)
            {
                waFa.lookup.Add(ws.Cells[4,c].Text);
                c++;
            }
            // Adding table values
            int max = waFa.cap.Count * waFa.lookup.Count;
            int count = 0;
            for (int x = 1; x < waFa.lookup.Count + 1; x++)
            {
                List<string> temp = new List<string>();
                for (int y = 10; y < waFa.cap.Count + 10; y++)
                {
                    if (ws.Cells[y,x] == null)
                        temp.Add("");
                    else
                        temp.Add(ws.Cells[y,x].Text);
                    count++;
                    minion.ReportProgress(100 * (count / max));
                }
                waFa.table.Add(temp);
            }
            return waFa;
        }

        private void xmlRdr()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\Quang\Documents\Configs\worksheets.xml");
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/worksheets/worksheet");

            works = new List<wSheet>();

            foreach (XmlNode node in nodes)
            {
                wSheet ws = new wSheet();

                ws.name = node.SelectSingleNode("name").InnerText;
                ws.type = node.SelectSingleNode("type").InnerText;
                ws.id = node.Attributes["id"].Value;

                works.Add(ws);
            }

            System.Console.WriteLine("Total worksheets: " + works.Count);
        }
        #endregion
    }
}
