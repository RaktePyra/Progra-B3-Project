using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Data
{
    internal class GenericDataBase
    {
        private Dictionary<string, string> _dataTable = new Dictionary<string, string>();

        public void LoadDataFromCSV(string relative_path_to_data_file)
        {
            if (!File.Exists(relative_path_to_data_file))
            {
                throw new FileNotFoundException("File not found at " + relative_path_to_data_file);
            }
            string[] file_data_table = File.ReadAllLines(relative_path_to_data_file);
            string line;
            string[] line_values;

            for (int line_index = 1; line_index < file_data_table.Length; line_index++)
            {
                line = file_data_table[line_index];
                line_values = line.Split(";");
                if (line_values[0] != "")
                {
                    _dataTable.Add(line_values[0], line);
                }

            }
        }

        public List<KeyValuePair<string,string>> GetData()
        {
            List<KeyValuePair<string, string>> data_table = new List<KeyValuePair<string, string>>();
            foreach (KeyValuePair<string, string> data in _dataTable)
            {
                data_table.Add(data);
            }
            return data_table;
        }
    }
}
