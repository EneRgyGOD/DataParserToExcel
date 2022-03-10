using Newtonsoft.Json;
using ClosedXML.Excel;

namespace DataParserToExcel
{
    public struct SortingList
    {
        public string header;
        public int column;
        public SortingList(string header, int column)
        {
            this.header = header;
            this.column = column;
        }
    }
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

        XLWorkbook workbook = new XLWorkbook();
        List<SensorData> sensorData = new List<SensorData>();
        List<SortingList> SortingList = new List<SortingList>();
        IXLWorksheet worksheet;
        private void btnExport_Click(object sender, EventArgs e)
        {
            btnExport.Enabled = false;

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.FileName = ImportPath;

            if (saveFileDialog.ShowDialog() != DialogResult.OK && ImportPath == null) 
            {
                btnExport.Enabled = true;
                
                return;
            }

            ExportPath = saveFileDialog.FileName;

            //getting lines from file

            List<string> lines = File.ReadAllLines(ImportPath).ToList();
            lines.RemoveAll(s => s == "NEW LOG");

            //deserializing and adding lines to list
            foreach (string line in lines)
            {
                sensorData.Add(JsonConvert.DeserializeObject<SensorData>(line));
            }

            Proccesing();
            


            ExportPath = ExportPath.Replace(".txt", "");
            workbook.SaveAs($"{ExportPath}.xlsx");

            btnExport.Enabled = true;
        }
        public void Proccesing()
        {
            Sorting(0);

            while (true)
            {
                int answer = Writting();

                if (answer == 0) return;
                else Sorting(answer);
            }
        }
        public void Sorting(int missing)
        {
            if (missing == 0)
            {
                //writing header and sorting list              
                for (int i = 0; i < sensorData[0].variables.Count; i++)
                {
                    SortingList.Add(new SortingList($"{sensorData[0].variables[i].type} ({sensorData[0].variables[i].unit} / {sensorData[0].variables[i].sensor})", i + 1));
                }
            }
            else
            {
                //sorting
                foreach (Variable variable in sensorData[missing].variables)
                {
                    string tempVariable = $"{variable.type} ({variable.unit} / {variable.sensor})";
                    if (SortingList.Any(x => x.header != tempVariable))
                    {
                        SortingList.Add(new SortingList(tempVariable, SortingList.Count - 1));
                    }
                }
            }
        }
        public int Writting()
        {
            //writing data
            worksheet = workbook.Worksheets.Add("Sensor Data");

            worksheet.Cell(1, 1).Value = "N";
            for (int i = 0; i < sensorData[0].variables.Count; i++)
            {
                worksheet.Cell(1, i + 1).Value = SortingList[i].header;
            }

            int row = 2;
            foreach (SensorData data in sensorData)
            {
                worksheet.Cell(row, 1).Value = row - 1;

                foreach (Variable variable in data.variables)
                {
                    string temp = $"{variable.type} ({variable.unit} / {variable.sensor})";
                    int column = 2;
                    if (SortingList.Any(x => x.header == temp))
                    {
                        column = SortingList.Find(x => x.header == temp).column;
                    }
                    else
                    {
                        worksheet.Delete();
                        return row - 2;
                    }

                    if (variable.value == "null") variable.value = "";

                    worksheet.Cell(row, column).Value = $"{variable.value} + {variable.sensor}";
                }
                row++;
            }
            return 0;
        }
    }
}