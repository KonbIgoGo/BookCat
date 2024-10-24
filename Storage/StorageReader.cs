using System.IO;
using System.Text.Json;

namespace BookCat.Storage
{
    public static class StorageReader<T>
    {
        public static T GetDataFromJson(string filename)
        {
            if (!File.Exists(filename))
            {
                return default;
            }
            string text = File.ReadAllText(filename);
            return string.IsNullOrEmpty(text) ? default : JsonSerializer.Deserialize<T>(text);
        }
    }
}