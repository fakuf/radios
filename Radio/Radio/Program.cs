using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radio
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var homePath = Environment.GetEnvironmentVariable("HOMEPATH");
                StreamReader reader = File.OpenText(homePath+"/radiosNacionales.txt");
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string cleanedString = System.Text.RegularExpressions.Regex.Replace(line, @"\s+", " ");
                    string[] stringWithOneBlank = cleanedString.Split(' ');
                    string radioName="";
                    for (int i = stringWithOneBlank.Length - 1; i > 0; i--)
                    {
                        radioName += stringWithOneBlank[i];
                    }
                    if (args.Length > 0) {
                        string parameter = args[0].ToLower();
                        radioName = radioName.ToLower();
                        if (radioName.Contains(parameter))
                        {
                            Process.Start("C:/Program Files (x86)/VideoLAN/VLC/vlc", stringWithOneBlank[0]);
                        }
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
