using System;
using System.IO;

string content = "";
string filepath = @"";
int appendMethod = 0;

Console.Title = "TEXT EDITOR";

static string LineWidth(string args)
{
    string LineWidth = "";
    int LineWidthLenght = args.Length;
    if (LineWidthLenght % 2 == 1)
    {
        LineWidthLenght++;
    }
    for (float i = 0; i < (Console.WindowWidth / 2) - (LineWidthLenght / 2); i++)
    {
        LineWidth = LineWidth + "_";
    }
    return LineWidth + args + LineWidth;
}

static string fileTemplates(string filepath)
{
    Console.WriteLine("1 - USERS FOLDER\n2 - DOWNLOADS FOLDER\n3 - DESKTOP FOLDER\n4 - DOCUMENTS FOLDER");
    ConsoleKeyInfo key = Console.ReadKey();
    if (key.Key == ConsoleKey.D1)
    {
        filepath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\";
    }
    else if (key.Key == ConsoleKey.D2)
    {
        filepath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Downloads\";
    }
    else if (key.Key == ConsoleKey.D3)
    {
        filepath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop\";
    }
    else if (key.Key == ConsoleKey.D4)
    {
        filepath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Documents\";
    }
    else if (key.Key == ConsoleKey.D0)
    {
        Environment.Exit(0);
    }
    else
    {
        filepath = "";
    }
    Console.Write(@"\");
    return filepath;
}

while (true)
{
    Console.Clear();
    Console.WriteLine(LineWidth(" TEXT  EDITOR "));
    Console.WriteLine();
    Console.WriteLine(content);
    string cmd = Console.ReadLine();
    if (cmd.ToLower() == ":x")
    {
        break;
    }
    else if (cmd.ToLower() == ":u")
    {
        content = content.ToUpper();
    }
    else if (cmd.ToLower() == ":l")
    {
        content = content.ToLower();
    }
    else if (cmd.ToLower() == ":n")
    {
        content = content + "\n";
    }
    else if (cmd.ToLower() == "")
    {
        content = content + "\n";
    }
    else if (cmd.ToLower() == ":s")
    {

        Console.Clear();
        Console.WriteLine(LineWidth("SAVE"));
        if (filepath == "")
        {
            Console.Write("FILE & PATH: ");
            filepath = Console.ReadLine();
            if (filepath == "")
            {
                break;
            }
        }
        if (Directory.Exists(filepath) == false)
        {
            File.WriteAllText(filepath, content);
        }
        else
        {
            filepath = "";
        }
    }
    else if (cmd.ToLower() == ":sa")
    {
        Console.Clear();
        Console.WriteLine(LineWidth("SAVE AS"));
        Console.Write("FILE & PATH: ");
        filepath = Console.ReadLine();
        if (filepath == "")
        {
            break;
        }
        File.WriteAllText(filepath, content);
    }
    else if (cmd.ToLower() == ":st")
    {
        Console.Clear();
        Console.WriteLine(LineWidth("SAVE FROM RECOMENDED PATHS"));
        filepath = fileTemplates(filepath);
        string appendfilepath = Console.ReadLine();
        filepath = filepath + appendfilepath;
        File.WriteAllText(filepath, content);
        Console.WriteLine(filepath);
        Console.Read();
    }
    else if (cmd.ToLower() == ":t")
    {
        content = content + "\t";
    }
    else if (cmd.ToLower() == ":tn")
    {
        content = content + "\n \t";
    }
    else if (cmd.ToLower() == ":d")
    {
        content = "";
    }
    else if (cmd.ToLower() == ":lf")
    {
        Console.Write("FILE & PATH: ");
        filepath = Console.ReadLine();
        if (filepath == "")
        {
            break;
        }
        content = File.ReadAllText(filepath);
    }
    else if (cmd.ToLower() == ":lt")
    {
        Console.Clear();
        Console.WriteLine(LineWidth("LOAD FROM RECOMENDED PATHS"));
        filepath = fileTemplates(filepath);
        string appendfilepath = Console.ReadLine();
        filepath = filepath + appendfilepath;
        content = File.ReadAllText(filepath);
        Console.WriteLine(filepath);
        Console.Read();
    }
    else if (cmd.ToLower() == ":h")
    {
        Console.Clear();
        Console.WriteLine(LineWidth(" HELP "));
        Console.WriteLine(":cmd \t\t Command");
        Console.WriteLine(":x \t\t Close/Exit");
        Console.WriteLine(":u \t\t Text To Upper");
        Console.WriteLine(":l \t\t Text To Lower");
        Console.WriteLine(":n \t\t New line");
        Console.WriteLine(":s \t\t Save");
        Console.WriteLine(":sa \t\t Save As");
        Console.WriteLine(":st \t\t Save With Template Path");
        Console.WriteLine(":t \t\t Add Tab");
        Console.WriteLine(":tn \t\t New Line & Add Tab");
        Console.WriteLine(":d \t\t Delete/Remove All Content");
        Console.WriteLine(":h \t\t Help");
        Console.WriteLine(":i \t\t Info");
        Console.WriteLine(":lf \t\t Load From File");
        Console.WriteLine(":lt \t\t Load From Template Path");
        Console.WriteLine(":i0 \t\t Append Method 0");
        Console.WriteLine(":i1 \t\t Append Method 1 append empty char");
        Console.WriteLine(":i2 \t\t Append Method 2 append new line");
        Console.WriteLine("Without \t Save Text To Memory");
        Console.Read();
    }
    else if (cmd.ToLower() == ":i")
    {

        Console.Clear();
        Console.WriteLine(LineWidth("INFO"));
        Console.WriteLine($"Lenght: {content.Length}");
        Console.WriteLine($"Lines: {content.Split('\n').Length}");
        Console.WriteLine($"Path: {filepath}");
        Console.WriteLine($"Append Method: {appendMethod}");
        Console.Read();
    }
    else if (cmd.ToLower() == ":i0")
    {
        appendMethod = 0;
    }
    else if (cmd.ToLower() == ":i1")
    {
        appendMethod = 1;
    }
    else if (cmd.ToLower() == ":i2")
    {
        appendMethod = 2;
    }
    else
    {
        if (appendMethod == 1)
        {
            content = content + " " + cmd;
        }
        else if (appendMethod == 2)
        {
            content = content + "\n" + cmd;
        }
        else
        {
            content = content + cmd;
        }
    }
}

return 0;