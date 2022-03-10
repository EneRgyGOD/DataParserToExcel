namespace DataParserToExcel
{
    public class SensorData
    {
        string id;
        string version;
        int age;
        string key;
        List<Variable> variables;
    }
    public class Variable 
    {
        string type;
        string unit;
        string sensor;
        float value;
    }
}
