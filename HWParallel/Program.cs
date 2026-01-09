using static System.Net.Mime.MediaTypeNames;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var text = new string[]
        {
            "sgdfsg dgd dg sss",
            "s  ggr s  ",
            " gggg grr"
        };

        for (int i = 0; i < 3; i++) 
        {
            await CreateFile($"..\\..\\..\\..\\files\\{i}.txt", text[i]);
        }

        var files = Directory.GetFiles("..\\..\\..\\..\\files");

        var tasks = new Task<int>[files.Length];
        for (int i = 0; i < tasks.Length; i++)
        {
            tasks[i] = SpaceCounter(files[i]);
        }

        Task.WaitAll(tasks);
    }

    public static async Task CreateFile(string path, string text)
    {
        using (StreamWriter writer = new StreamWriter(path, false))
        {
            await writer.WriteLineAsync(text);
        }
    }

    public static async Task<int> SpaceCounter(string path)
    {
        var result = 0;
        using (StreamReader reader = new StreamReader(path))
        {
            string text = await reader.ReadToEndAsync();
            result = text.Count(x => x == ' ');
        }

        return result;
    }
}
