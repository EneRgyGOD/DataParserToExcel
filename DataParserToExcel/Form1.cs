using Newtonsoft.Json;

namespace DataParserToExcel
{
    public partial class TTEP : Form
    {
        public TTEP()
        {
            InitializeComponent();
        }

        string ImportPath = null, ExportPath = null;

        private void btnChooseImportFile_Click(object sender, EventArgs e)
        {
            btnChooseImportFile.Enabled = false;

            //opening dialog windows for import file picker
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ImportPath = openFileDialog.FileName;
                    textBox1.Text = Path.GetFileName(openFileDialog.FileName);
                }
            }

            btnChooseImportFile.Enabled = true;
        }

        private void btnChooseExportPath_Click(object sender, EventArgs e)
        {
            btnChooseExportPath.Enabled = false;

            //opening dialog windows for choose export folder
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                ExportPath = folderBrowserDialog.SelectedPath;
            }


            btnChooseImportFile.Enabled = true;
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            btnExport.Enabled = false;

            if (ImportPath == null || ExportPath == null) return;

            //getting lines from file
            List<SensorData> sensorData = new List<SensorData>();
            List<string> lines = File.ReadAllLines(ImportPath).ToList();
            lines.RemoveAll(s => s == "NEW LOG");

            //deserializing and adding lines to list
            foreach (string line in lines)
            {
                sensorData.Add(JsonConvert.DeserializeObject<SensorData>(line));
            }




            btnExport.Enabled = true;
        }


    }
}