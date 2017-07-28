using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagerverwaltung
{
    class Program
    {
        static void Main(string[] args)
        {
            String kat1;
            String kat2;
            String kat3;
            String fileone = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\lager\kategorie1.txt"; ;
            String filetwo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\lager\kategorie2.txt";
            String filethree = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\lager\kategorie3.txt";
            String directorypath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\lager";
            String filepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\lager\mainlist.txt";

            

            if (!Directory.Exists(directorypath))
            {
                DirectoryInfo info = Directory.CreateDirectory(directorypath);

                if (!File.Exists(filepath))
                {
                    
                    List<String> kategorien = new List<String>();

                    Console.WriteLine("Wählen sie 3 Kategorien");
                    Console.WriteLine("Kategorie 1:");
                    kat1 = Console.ReadLine();
                    kategorien.Add(kat1);
                    Console.WriteLine("Kategorie 2:");
                    kat2 = Console.ReadLine();
                    kategorien.Add(kat2);
                    Console.WriteLine("Kategorie 3:");
                    kat3 = Console.ReadLine();
                    kategorien.Add(kat3);

                    File.WriteAllLines(filepath, kategorien, Encoding.ASCII);
                    File.WriteAllLines(fileone, new[] { kat1 }, Encoding.ASCII);
                    File.WriteAllLines(filetwo, new[] { kat2 }, Encoding.ASCII);
                    File.WriteAllLines(filethree, new[] { kat3 }, Encoding.ASCII);
                }
                
            }
            else
            {
                String[] mainLines = File.ReadAllLines(filepath);

                kat1 = mainLines[0];
                kat2 = mainLines[1];
                kat3 = mainLines[2];

                Console.WriteLine("Welches Lager möchten sie aufrufen ?");
                String[] lines = System.IO.File.ReadAllLines(filepath);
                foreach (string line in lines)
                {
                    Console.WriteLine("\t" + line);
                }
                String answer = Console.ReadLine();

                if(answer == kat1)
                {
                    Console.WriteLine("Kategorie {0} enthält folgendes", kat1);
                    String[] kat1list = File.ReadAllLines(fileone);

                    foreach (string line in kat1list)
                    {
                        Console.WriteLine("\t" + line);
                    }

                } else if(answer == kat2)
                {
                    Console.WriteLine("Kategorie {0} enthält folgendes", kat2);
                    String[] kat2list = File.ReadAllLines(filetwo);

                    foreach (string line in kat2list)
                    {
                        Console.WriteLine("\t" + line);
                    }

                } else if(answer == kat3)
                {
                    Console.WriteLine("Kategorie {0} enthält folgendes", kat3);
                    String[] kat3list = File.ReadAllLines(filethree);

                    foreach (string line in kat3list)
                    {
                        Console.WriteLine("\t" + line);
                    }

                }
                else
                {
                    Console.WriteLine("Diese Kategorie ist nicht Vorhanden");
                }
                Console.ReadLine();
            }
        }
    }
}
