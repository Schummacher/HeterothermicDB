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
                while(j < 2)
                {
                    if(initial[i] == none)
                    {
                        if (j == 0)
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
        ChangeFile s = new ChangeFile();
        s.Read_file("a.txt");
        s.Print_file("in");
        s.Print_file("out");

        string test = "sad";
        char[] ass = test.ToCharArray();
        Console.WriteLine(ass);
        for (int i = 0; i < ass.Length; i++)
        {
            Console.Write(ass[i] + "\n");
        }
        Console.WriteLine(s.Data_com());
    }
}

