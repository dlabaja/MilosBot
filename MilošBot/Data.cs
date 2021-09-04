using System.IO;

namespace MilošBot
{
    internal static class Data
    {
        public static string Pictrazky(string name) => Path.Combine("Data", "Pictrazky", name);

        public static string Linux(string name) => Path.Combine("Data", "Linux", name);
    }
}