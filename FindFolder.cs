using System;
using System.IO;

namespace WindowsFormsApp4
{
    public static class FindFolder
    {

        public static string Folder(string folder)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string helpFolderPath = FindClosestHelpFolder(baseDirectory, folder);

            if (helpFolderPath != null)
            {
                Console.WriteLine($"Closest Help folder: {helpFolderPath}");
            }
            else
            {
                Console.WriteLine("Help folder not found.");
            }

            return helpFolderPath;
        }

        private static string FindClosestHelpFolder(string directory, string folder)
        {
            if (directory == null || directory == Path.GetPathRoot(directory))
            {
                return null; // Reached the root directory, Help folder not found
            }

            string helpFolderPath = Path.Combine(directory, folder);
            if (Directory.Exists(helpFolderPath))
            {
                return helpFolderPath; // Found the Help folder
            }

            return FindClosestHelpFolder(Path.GetDirectoryName(directory), folder); // Recursively search parent directory
        }
    }
}
