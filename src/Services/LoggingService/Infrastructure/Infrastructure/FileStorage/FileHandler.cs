using Application.Commands.Common.Models;
using Application.Commands.Contracts.Common;
using Newtonsoft.Json;

namespace Infrastructure.FileStorage;

public class FileHandler : IFileHandler
{
    public async Task<List<JSONFileViewModel>> ReadLanguageFile(string path)
    {
        List<JSONFileViewModel> supportedLanguages = new List<JSONFileViewModel>();
        string jsonText = string.Empty;
        using (var reader = File.OpenText(path))
        {
            jsonText = await reader.ReadToEndAsync();

            if (!string.IsNullOrEmpty(jsonText))
            {
                supportedLanguages = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonText)?.Select(x => new JSONFileViewModel { Key = x.Value, Value = x.Key }).ToList() ?? new List<JSONFileViewModel>();
            }
        }
        return supportedLanguages;
    }
}