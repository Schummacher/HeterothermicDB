using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class Program
{
    class HeterothermicDB
    {
        private string file_data_in;

        public string input_name;
        public string output_name;

        public void Read_file() => file_data_in = File.ReadAllText(input_name);
        public void Write_file(string data) => File.WriteAllText("b.txt", data);
        public void Print_file() => Console.WriteLine(file_data_in);

        public string Data_com
        {
            get
            {
                char[] initial = file_data_in.ToCharArray();
                string result = "(";
                int i = 0;

                while (i < initial.Length)
                {
                    int j = 0;
                    result += "(";
                    while (j < 8)
                    {
                        if (initial[i] == ' ')
                        {
                            if (j < 7)
                                result += " ";
                            j++;
                            i++;
                        }
                        else
                        {
                            result += initial[i];
                            i++;
                        }
                    }
                    result += ")";
                    if (i != initial.Length)
                        result += " ";
                }
                return result += ")";
            }
        }
    }

    static void Main(string[] args)
    {
        HeterothermicDB db = new HeterothermicDB
        {
            input_name = "a.txt",
            output_name = "b.txt"
        };
        db.Read_file();
        db.Write_file(db.Data_com);
    }
}
