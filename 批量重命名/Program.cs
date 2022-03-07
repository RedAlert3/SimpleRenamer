// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

while (true)
{
    Console.WriteLine("Hello, World!");
    Console.Write("Input work dir: ");
    string path = Console.ReadLine();
    if (path == "" || path.Equals("exit")) break;
    //Console.Write("Input files num: ");
    //int num = int.Parse(Console.ReadLine());
    Console.Write("Input regex pattern: ");
    string regex_pattern = Console.ReadLine();
    List<FileInfo> files = new();
    foreach (FileInfo fi in new DirectoryInfo(path).GetFiles())
        if (Regex.IsMatch(fi.Name, regex_pattern))
        {
            files.Add(fi);
            Console.WriteLine($"\t{fi.Name}");
        }
    Console.Write("Input rename pattern(%i%): ");
    string rename_pattern = Console.ReadLine();
    int index = 1;
    foreach (FileInfo item in files)
    {
        item.MoveTo($"{path}\\{new Regex(regex_pattern).Replace(item.Name, rename_pattern.Replace("%i%", index.ToString()))}");
        ++index;
    }
}

//Console.Write("Input pattern (%i%): ");
//string pattern = Console.ReadLine();
//List<string> files = new();
//for (int i = 1; i <= num; ++i)
//    files.Add($"{path}\\{pattern.Replace("%i%", i.ToString())}");
//Console.Write("Input rename pattern (%i%): ");
//string rn_pattern = Console.ReadLine();
//int index = 1;
//foreach (string item in files)
//{
//    FileInfo fi = new FileInfo(item);
//    fi.MoveTo($"{path}\\{rn_pattern.Replace("%i%", index.ToString())}");
//    ++index;
//}

Console.WriteLine("Well done !");
Console.ReadLine();
