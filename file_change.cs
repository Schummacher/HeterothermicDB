using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class Program
{
    class ChangeFile
    {
        private string file_data_in;
        private string file_data_out;

        public void Read_file(string name)
        {
            file_data_in = File.ReadAllText(name);
            file_data_out = file_data_in;
        }

        public void Print_file(string io)
        {
            if (string.Equals(io, "in"))
                Console.WriteLine(file_data_in);
            else if (string.Equals(io, "out"))
                Console.WriteLine(file_data_out);
        }

        public void Ccc()
        {
            for(int i = 0; i < file_data_in.Length; i++)
            {
                Console.WriteLine(file_data_in[i]);
            }
        }
    }

    static void Main(string[] args)
    {
        ChangeFile s = new ChangeFile();
        s.Read_file("a.txt");
        s.Print_file("in");
        s.Print_file("out");
    }
}