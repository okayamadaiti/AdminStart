using System;
using System.Diagnostics;
using System.IO;

namespace AdminStartNetFramework
{
    class Program
    {
        const string INI_NAME = "target.ini";

        static void Main(string[] args)
        {
            try
            {
                var exePath = GetExePath();
                if (!File.Exists(exePath))
                {
                    ShowErrorMessage($"{exePath}が存在しません。");
                    return;
                }
                CallExe(exePath);
            }
            catch (IOException ioEx)
            {
                ShowErrorMessage(ioEx.Message);
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }
        static void ShowErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"エラー：");
            Console.WriteLine(message);
            Console.ReadLine();
        }

        static void CallExe(string path)
        {
            try
            {
                var info = new ProcessStartInfo();
                info.FileName = path;
                info.WorkingDirectory = GetWorkingDirectory(path);
                info.Verb = "RunAs";

                var proc = new Process();
                proc.StartInfo = info;
                proc.Start();
            }
            catch (Exception)
            {
                throw;
            }
        }

        static string GetExePath()
        {
            try
            {
                if (!File.Exists(INI_NAME))
                {
                    throw new IOException($"{INI_NAME}が存在しません。");
                }
                using (var reader = new StreamReader(INI_NAME))
                {
                    return reader.ReadLine();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        static string GetWorkingDirectory(string exePath) => Directory.GetParent(exePath).FullName;
    }
}
