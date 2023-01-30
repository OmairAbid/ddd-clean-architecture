using Application.Commands.Common.Models;

namespace Application.Commands.Contracts.Common;

public interface IFileHandler
{
    Task<List<JSONFileViewModel>> ReadLanguageFile(string path);
}