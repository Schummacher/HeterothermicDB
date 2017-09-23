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
        private string file_data_out;

        public string input_name;
        public string output_name;

        public void Read_file(string io)
        {
            if (string.Equals(io, "in"))
            {
                file_data_in = File.ReadAllText(input_name);
                file_data_out = file_data_in;
            }
            else
            {
                file_data_in = File.ReadAllText(output_name);
                file_data_out = file_data_in;
            }
        }

        public void Print_file(string io)
        {
            if (string.Equals(io, "in"))
                Console.WriteLine(file_data_in);
            else if (string.Equals(io, "out"))
                Console.WriteLine(file_data_out);
        }

        public void Write_file(string data)
        {
            File.WriteAllText("b.txt", data);
        }

        public string Data_com()
        {
            char[] initial = file_data_in.ToCharArray();
            string result = "(";
            int i = 0;
            const char none = ' ';

            while(i < initial.Length)
            {
                int j = 0;
                result += "(";
                while(j < 8)
                {
                    if(initial[i] == none)
                    {
                        if (j < 7)
                        {
                            result += " ";
                        }                        
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
            result += ")";
            return result;
        }
    }

    static void Main(string[] args)
    {
        HeterothermicDB db = new HeterothermicDB();
        db.input_name = "a.txt";
        db.output_name = "b.txt";
        db.Read_file("in");
        db.Write_file(db.Data_com());
    }
}
