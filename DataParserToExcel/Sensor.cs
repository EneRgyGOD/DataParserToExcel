namespace DataParserToExcel
{
    public class SensorData
    {
        public string id ;
        public string version;
        public int age;
        public string key;
        public List<Variable> variables;
    }
    public class Variable
    {
        public string type;
        public string unit;
        public string sensor;
        public string value;
    }
}
