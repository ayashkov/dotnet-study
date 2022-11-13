using System.Net.Http.Headers;
using Microsoft.Build.Framework;
using BuildTask = Microsoft.Build.Utilities.Task;

namespace study.build;

public class HttpUpload: BuildTask {
    private static readonly HttpClient client;

    static HttpUpload()
    {
        client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept
            .Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    [Required]
    public ITaskItem[] Files { get; set; }

    [Required]
    public string Url { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public override bool Execute()
    {
        upload(new Uri(Url)).Wait();

        return true;
    }

    private async Task upload(Uri uri)
    {
        foreach (var item in Files) {
            var json = await upload(uri, item);

            Log.LogMessage(MessageImportance.Low, json);
        }
    }

    private async Task<string> upload(Uri uri, ITaskItem item)
    {
        var file = item.ItemSpec;
        var dest = new Uri(uri, Path.GetFileName(file));

        Log.LogMessage(MessageImportance.High, $"Uploading {file} to {dest}");

        using (var content = new StreamContent(File.Open(file, FileMode.Open))) {
            using var response = await client.PutAsync(dest, content);

            response.EnsureSuccessStatusCode();

            return await response.EnsureSuccessStatusCode()
                .Content.ReadAsStringAsync();
        }
    }
}
