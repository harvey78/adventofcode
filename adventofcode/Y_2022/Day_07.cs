using System.Diagnostics;

namespace adventofcode.Y_2022;

internal class Day_07
{


    static public void run()
    {

        Console.WriteLine("Avvio giorno 7");

        List<string> lines = new();
        FS_Directory root = new("", null);
        FS_Directory actual = new("", null);

        foreach (string line in File.ReadLines("Y_2022\\input_07.txt"))
            lines.Add(line);


        foreach (var l in lines)
            if (l.StartsWith('$'))
            {//Comando

                if (l == "$ cd /")
                {
                    //Inizio
                    root = new("", null);
                    actual = root;
                }
                else if (l == "$ cd ..")
                {
                    actual = actual.parent;
                }
                else if (l == "$ ls")
                {
                }
                else if (l.StartsWith("$ cd"))
                {
                    string dirName = l.Split(' ')[2];
                    bool find = false;
                    foreach (var i in actual.Directory)
                    {
                        if (i.Name == dirName)
                        {
                            actual = i;
                            find = true;
                            break;
                        }
                    }
                    if (!find)
                        Debugger.Break();

                }
                else
                    Debugger.Break();

            }
            else
            {//Risposta  

                if (l.StartsWith("dir"))
                {
                    //aggiungo directory 
                    actual.Directory.Add(new FS_Directory(l.Substring(4), actual));
                }
                else
                {
                    //aggiungo file 
                    string[] column = l.Split(' ');
                    int size = int.Parse(column[0]);
                    actual.File.Add(new FS_File(column[1], size));
                }
            }

        root.calculateSize();
        int totalSpace = 70000000;
        int NeedSpace = 30000000;
        int ToDelete =  (NeedSpace + root.Size)- 70000000;
        int maxSpace = int.MaxValue;
        intGetSizeToDelete(root, ToDelete, ref maxSpace);

        // 1886043
        Console.WriteLine("Totalsize <= 100000        " + intGetTotalSize_Under_100000(root));
        // 3842121
        Console.WriteLine("Size to delete             " + maxSpace);


        Console.WriteLine("******************************************* ");

    }

    static int  intGetTotalSize_Under_100000(FS_Directory actual)
    {
        int Size=0;

        if (actual.Size <= 100000)
            Size += actual.Size;

        foreach (var i in actual.Directory)
            Size += intGetTotalSize_Under_100000(i);

            return Size;
    }

    static void intGetSizeToDelete(FS_Directory actual, int ToDelete,ref int maxSpace)
    {
        if (actual.Size >= ToDelete && actual.Size <= maxSpace)          
            maxSpace = actual.Size;

        foreach (var i in actual.Directory)
            intGetSizeToDelete(i, ToDelete, ref maxSpace);
    }

    class FS_Directory
    {
        public string Name;
        public int Size;
        public List<FS_Directory> Directory = new();
        public List<FS_File> File = new();
        public FS_Directory? parent;

        public FS_Directory(string Name, FS_Directory? parent)
        {
            this.Name = Name;
            this.parent = parent;
        }

        public void calculateSize()
        {
            Size = 0;
            foreach (var i in Directory)
            {
                i.calculateSize();
                Size += i.Size;
            }
            foreach (var i in File)
                Size += i.Size;
        }
    }

    class FS_File
    {
        public string Name;
        public int Size;

        public FS_File(string Name, int Size)
        {
            this.Name = Name;
            this.Size = Size;
        }
    }

}

