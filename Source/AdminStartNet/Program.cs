using System;
using System.Diagnostics;
using System.IO;

namespace AdminStartNet
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
                ProcessStartInfo info = new();
                info.FileName = path;
                info.WorkingDirectory = GetWorkingDirectory(path);
                info.Verb = "RunAs";

                Process proc = new();
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
                using StreamReader reader = new(INI_NAME);
                return reader.ReadLine();
            }
            catch (Exception)
            {
                throw;
            }
        }

        static string GetWorkingDirectory(string exePath) => Directory.GetParent(exePath).FullName;

    }
}
